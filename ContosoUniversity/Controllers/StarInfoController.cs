using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class StarInfoController : Controller
    {

        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Star Information");
            var model = db.tb_StarInformation.ToList().AsQueryable();
            string strTable = "";
            // var bt = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 22).Single();
            foreach (var item in model)
            {
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/" + item.ImagePath + "' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
                strTable += "<td>" + item.StarName + "</a></td>";
                strTable += "<td>" + item.StarScore + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/StarInfo/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/StarInfo/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                strTable += "</tr>";
            }
            ViewData["data"] = strTable;
            return View(model);

        }


        public ActionResult Create()
        {
            ViewData["buttonname"] = 1;
            return View();
        }

        private Boolean ValidateData(tb_StarInformation model)
        {
            Boolean validateData1 = true;

            if (string.IsNullOrEmpty(model.StarName))
                ViewData.ModelState.AddModelError("StarName", "Please enter   Star Name!");
            if (model.StarScore == null)
            {
                ViewData.ModelState.AddModelError("StarScore", "Please Select StarScore  !");
            }

            if (!ModelState.IsValid)
            {
               
                validateData1 = false;
            }
            return validateData1;
        }
    


        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_StarInformation model1)
        {
         
            ViewData["buttonname"] = 1;
            try
            {


                string filename1 = "";
                string filename2 = "";

                if (ValidateData(model1))
                {

                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength < 2000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".gif" || FileExtension == ".jpg" || FileExtension == ".jpeg")
                        {

                            string randName = emailSystem.CreateRandomPassword(8);

                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath); 
                        }
                    }


                    file = Request.Files[1];
                    if (file.ContentLength < 5000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".mp3")
                        {
                            string randName = emailSystem.CreateRandomPassword(8);
                            filename2 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                            file.SaveAs(filePath);
                        }
                    }


                    if (filename1 != "")
                    {
                        model1.ImagePath = filename1;
                    }

                    if (filename2 != "")
                    {
                        model1.Mp3Path = filename2;
                    }

                   
                    model1.UserId = Convert.ToInt32(Session["pmsuserid"]);
                    model1.CompanyID = 0;
                    model1.SystemDate = DateTime.Now;
                    model1.IpAddress = Request.ServerVariables["remote_address"];
                    db.tb_StarInformation.Add(model1);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                }
            }
            catch(Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            var tb1 = new tb_StarInformation();
            return View(tb1);

        }
   

        public ActionResult edit(Int32 id)
        {
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_StarInformation
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Int32 id, tb_StarInformation model1)
        {
            try
            {
               
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                if (ValidateData(model1))
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength < 2000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                         if (FileExtension == ".png" || FileExtension == ".gif" || FileExtension == ".jpg" || FileExtension == ".jpeg")
                        {
                            string randName = emailSystem.CreateRandomPassword(8);
                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath); 
                        }
                    }

                    file = Request.Files[1];
                    if (file.ContentLength < 5000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".mp3")
                        {

                            string randName = emailSystem.CreateRandomPassword(8);

                            filename2 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                            file.SaveAs(filePath);
                        }
                    }

                    var model = (from m in db.tb_StarInformation
                                 where m.AutoId == id
                                 select m).Single();



                    model.StarName = model1.StarName;
                    model.StarScore = model1.StarScore;
             

                    if (filename1 != "")
                    {
                        model.ImagePath = filename1;
                    }
                    if (filename2 != "")
                    {
                        model.Mp3Path = filename2;
                    }
                    db.SaveChanges();

                    ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(2);


                    var tb1 = new tb_StarInformation();
                    return View(tb1);

                }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();

        }
        public ActionResult delete(Int32 id)
        {
        
            ViewData["buttonname"] = 3;
            var model = (from m in db.tb_StarInformation
                         where m.AutoId == id
                         select m).Single();


            return View(model);
           
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ViewData["buttonname"] = 3;
                var tb = (from m in db.tb_StarInformation
                          where m.AutoId == id
                          select m).Single();

                db.tb_StarInformation.Remove(tb);
                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
            }
            catch
            {

            }
            return View();
        }
    }
}
