using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OLProject.Models;


namespace OLProject.Controllers
{
    public class uploadImagesController : Controller
    {

        kzonlineEntities db = new kzonlineEntities();
        // GET: uploadImages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            int userid = Convert.ToInt32(Session["pmsuserid"]);
            var images = from m in db.tb_ImagesUploaded where m.UserID == userid orderby m.ImageID descending select m;
            string strtable = "";
            foreach (var item in images)
            {
                //strtable += " <tr> <td> <img src='http://kzonline.org/uploads/" + item.ImageName + "' width = '80px' height = '80px'/> </td >  <td>  http://kzonline.org/uploads/" + item.ImageName + "</td> </tr>";

                strtable += " <li>    <table id = 'resultForm:result_table' class='table table-striped table-bordered table-hover'>     <tr>";
                strtable += " <td width = '98px' ><img src='http://kzonline.org/uploads/" + item.ImageName + "' width='80px' height='50px' /></td> ";
                strtable += " <td>  http://kzonline.org/uploads/" + item.ImageName + " </td>     </tr>         </table>   </li>";

            }

            ViewBag.strTable = strtable;
            return View();
        }

        [HttpPost]
        public ActionResult Create(IEnumerable<HttpPostedFileBase> files, FormCollection frm)
        {
            string filename1 = "";

            string fileName = "";
            foreach (var file in files)
            {

                //  HttpPostedFileBase file = Request.Files[0]; //For Images
                if (file.ContentLength < 500000)
                {
                    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                    fileName = Path.GetFileName(file.FileName).ToLower();
                    //if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                    //{
                    string randName = emailSystem.CreateRandomPassword(8);
                    string randName1 = emailSystem.CreateRandomPassword(8);
                    filename1 = randName1 + "_" + randName + FileExtension;
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                    file.SaveAs(filePath);

                    tb_ImagesUploaded tbImage = new tb_ImagesUploaded();
                    //tbImage.UserID = 0;
                    tbImage.UserID = Convert.ToInt32(Session["pmsuserid"]);
                    tbImage.Path = filePath;
                    tbImage.CreationDate = System.DateTime.Now;
                    //tbImage.Category =
                    tbImage.ImageName = filename1;

                    db.tb_ImagesUploaded.Add(tbImage);

                    //  }


                }
                db.SaveChanges();

                int userid = Convert.ToInt32(Session["pmsuserid"]);
                var images = from m in db.tb_ImagesUploaded where m.UserID == userid orderby m.ImageID descending select m;
                string strtable = "";
                foreach (var item in images)
                {
                    strtable += " <tr> <td> <img src='http://kzonline.org/uploads/" + item.ImageName + "' width = '80px' height = '80px' /> </td >  <td >  http://kzonline.org/uploads/" + item.ImageName +   "</td> </tr>";
                   

                }

                ViewBag.strTable = strtable;

            }
            return RedirectToAction("Create");
            
        }




        [HttpPost]
        public ActionResult Multiple(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Path.Combine(Server.MapPath("/uploads"), Guid.NewGuid() + Path.GetExtension(file.FileName)));
                }
            }
            return View();
        }
    }

}