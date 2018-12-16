using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoFiles.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase file)
        {
            var objId = MongoFactory.UploadFile(DateTime.Now.ToString("yyyy-MM-dd"), file.FileName, file.InputStream);
            return Json(objId);
        }

        [HttpGet]
        public Stream DownLoad(string id)
        {
            //var bytes = MongoFactory.GetFileBytes(DateTime.Now.ToString("yyyy-MM-dd"), id);
            var stream = MongoFactory.GetFileStream(DateTime.Now.ToString("yyyy-MM-dd"), id);
            return stream;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}