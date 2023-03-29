using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text;
using lesohem.DataBase;
using lesohem.Models;

namespace lesohem_ASP_NET_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class TimeTableController : Controller
    {
        LesohemContext db;
        IFiles file;
        public TimeTableController(LesohemContext db, IFiles file)
        {
            this.db = db;
            this.file = file;
        }

        public IActionResult TimeTable() => View();
        [HttpGet]
        public IActionResult ShowTimeTable()
        {
            string TimeTable = @"
                            <!DOCTYPE html>
                            <html lang=""en"">
                            <head>
                                <meta charset=""UTF-8"">
                                <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                <link rel=""stylesheet"" href=""/css/TimeTableCss/DataTable.css"">
                                <link rel=""stylesheet""href=""https://cdn.jsdelivr.net/npm/swiper@8/swiper-bundle.min.css""/>
                                <title>Расписание</title>
                            </head>
                            <body>
                                <div class=""add-block"">
                                    <div class=""print-name-block"">
                                        <p>Введите название блока</p>
                                        <input type=""text"" placeholder=""Расписание на 02.02.2002"">
                                    </div>
                                    <div class=""print-name-file"">
                                        <p>Введите название файла</p>
                                        <input type=""text"" placeholder=""Расписание 02.02.2002"">
                                    </div>
                                    <div class=""add-block-buttons"">
                                        <button class=""cancel"">Отмена</button>
                                        <button class=""save"">Сохранить</button>
                                    </div>
                                    <input type=""file"" class=""fileTable"">
                                </div>
                            </body>
                            </html>";
            return Json(TimeTable);
        }
        [HttpPost]
        public IActionResult Save(UploadTimeTable fileObj)
        {
            TableContent? tableContent = JsonConvert.DeserializeObject<TableContent>(fileObj.Elements);
            var fullPath = file.GetPath(fileObj.File);
            tableContent.Path = fullPath.Result;
            tableContent.TableBlockId = 1;
            file.CreatePath(fullPath.Result);
            var text = file.FileRead(fileObj.File,fullPath.Result);
            file.FileWrite(text.Result,fullPath.Result);
            file.SaveContent(tableContent);
            return Json("");
        }
        [HttpGet]
        public IActionResult GetContent()
        {
            var res = file.GetContent();
            return Json(res);
        }
        public IActionResult LoadFiles(int id)
        {
            TableContent? content = db.TableContents.FirstOrDefault(u => u.Id == id);
            FileStream fs = new FileStream(content.Path, FileMode.Open);
            string fileType = "text/plain";
            string fileName = content.Name + ".xls";
            return File(fs, fileType,fileName);
        }
    }
}
