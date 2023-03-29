using lesohem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace lesohem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public JsonResult CheckUser()
        {
            string link;
            var name = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var role = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (role == "admin")
                link = "/Admin/Profile/Profile";
            else
                link = "/Profile/Profile";
            var response = new
            {
                link = link,
                name = name,
                role = role
            };
            return Json(response);
        }
    }
}