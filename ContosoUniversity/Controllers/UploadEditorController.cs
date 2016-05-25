using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace OLProject.Controllers
{
    public class UploadEditorController : Controller
    {
        //
        // GET: /UploadEditor/

        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {

            if (upload.ContentLength <= 0)
                return null;

            // here logic to upload image
            // and get file path of the image

            const string uploadFolder = "Uploads";

            var fileName = Path.GetFileName(upload.FileName);
            var path = Path.Combine(Server.MapPath(string.Format("~/{0}", uploadFolder)), fileName);
            upload.SaveAs(path);

            var url = string.Format("{0}{1}/{2}/{3}", Request.Url.GetLeftPart(UriPartial.Authority),
                Request.ApplicationPath == "/" ? string.Empty : Request.ApplicationPath,
                uploadFolder, fileName);

            // passing message success/failure
            const string message = "Image was saved correctly";

            // since it is an ajax request it requires this string
            var output = string.Format(
                "<html><body><script>window.parent.CKEDITOR.tools.callFunction({0}, \"{1}\", \"{2}\");</script></body></html>",
                CKEditorFuncNum, url, message);

            return Content(output);
        }


    }
}
