using lesohem.DataBase;
using lesohem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace Area.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProfileController : Controller
    {
        ISocMedia service;
        IInfoProfile Infoprofile;
        public ProfileController(ISocMedia service, IInfoProfile infoProfile)
        {
            Infoprofile = infoProfile;
            this.service = service;
        }
        public IActionResult Profile() => View();
        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public JsonResult CheckUser()
        {
            string link;
            var name = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var role = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            var id = HttpContext.User.FindFirst("Id")?.Value;
            if (role == "admin")
                link = "/Admin/Profile/Profile";
            else
                link = "/Profile/Profile";
            var response = new
            {
                link = link,
                name = name,
                role = role,
                id = id
            };
            return Json(response);
        }
        [HttpPost]
        public void SaveMedia([FromBody] UploadMedia data)
        {
            SocMedium? media = new SocMedium();
            media.Mname = data.MediaName;
            media.Link = data.MediaLink;
            media.PersonId = Convert.ToInt32(HttpContext.User.FindFirst("Id")?.Value);
            service.Save(media);
        }
        [HttpGet]
        public JsonResult GetMedia()
        {
            var db = service.Get(Convert.ToInt32(HttpContext.User.FindFirst("Id")?.Value));
            return Json(db);
        }
        [HttpGet]
        public JsonResult GetInfoProfile()
        {
            var res = Infoprofile.GetUser(Convert.ToInt32(HttpContext.User.FindFirst("Id")?.Value));
            return Json(res);
        }
        [HttpPost]
        public JsonResult EditInfoProfile([FromForm]UploadInfo info)
        {
            User? user = JsonConvert.DeserializeObject<User>(info.Value);
            var res = Infoprofile.Edit(user, Convert.ToInt32(HttpContext.User.FindFirst("Id").Value));
            return Json(user);
        }
        [HttpPost]
        public async Task<IResult> LogoutProfile(string returnUrl)
        {
            await Logout();
            return Results.Redirect(returnUrl ?? "/Home/Index");
        }
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        [HttpPost]
        public async Task<IResult> SaveImage(FileUpload fileObj)
        {
            User user = new User();
            if(fileObj.file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileObj.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    user.Photo = fileBytes;

                    Infoprofile.SaveImage(user, Convert.ToInt32(HttpContext.User.FindFirst("Id")?.Value));
                }
                return Results.Json("Файл успешно сохранен!");
            }
            return Results.Json("Не удалось сохранить изображение");
        }
        public async Task <JsonResult> GetImage()
        {
            User user = Infoprofile.GetImage(Convert.ToInt32(HttpContext.User.FindFirst("Id")?.Value));
            return Json(user);
        }
    }
}