using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class ButtonsController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Button Information");
           var Llist = db.tb_ButtonMaster.ToList();
            string strTable = "";
            foreach (var item in Llist)
            {
                
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/" + item.ImagePath + "' border='0'.   alt='Delete' style='width:80px;Height:80px;'/></td>";
                strTable += "<td><img src='../../uploads/" + item.ImagePath1 + "' border='0'.   alt='Delete' style='width:80px;Height:80px;'/></td>";
             
                strTable += "<td>" + item.ButtonName + "</td>";

                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/buttons/edit/" + item.ButtonId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/buttons/Delete/" + item.ButtonId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

            }
            ViewData["data"] = strTable;

            return View();
        }

        //
        // GET: /Subject/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            ViewData["buttonname"] = 1;

            return View();
        }
        private Boolean ValidateData(tb_ButtonMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.ButtonName))
                ViewData.ModelState.AddModelError("ButtonName", "Please enter   ButtonName!");
            
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
    
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_ButtonMaster model)
        {
            ViewData["buttonname"] = 1;
            try
            {
                string filename1 = "";
                string filename2 = "";
                if (Request.HttpMethod == "POST")
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength < 2000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                        {
                            string randName = emailSystem.CreateRandomPassword(8);
                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath);
                        }
                    }

                    file = Request.Files[1];
                    if (file.ContentLength < 2000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                        {
                            string randName = emailSystem.CreateRandomPassword(8);
                            filename2 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                            file.SaveAs(filePath);
                        }
                    }

                    model.ImagePath = filename1;
                    model.ImagePath1 = filename2;
                    model.SystemDate = DateTime.Now;
                    db.tb_ButtonMaster.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                    var tb = new tb_ButtonMaster();
                    return View(tb);

                }
            }
            catch
            {

            }
            return View();
        }


        //
        // GET: /Subject/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_ButtonMaster
                         where m.ButtonId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_ButtonMaster model)
        {
            try
            {
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                var tb = (from m in db.tb_ButtonMaster
                          where m.ButtonId == id
                          select m).Single();
                HttpPostedFileBase file = Request.Files[0];
                if (file.ContentLength < 2000000)
                {
                    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        filename1 = randName + "_" + file.FileName;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                        file.SaveAs(filePath);
                    }
                }
                file = Request.Files[1];
                if (file.ContentLength < 2000000)
                {
                    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        filename2 = randName + "_" + file.FileName;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                        file.SaveAs(filePath);
                    }
                }
                if (filename1 != "")
                {
                    tb.ImagePath = filename1;
                }
                if (filename2 != "")
                {
                    tb.ImagePath1 = filename2;
                }
                tb.ButtonName = model.ButtonName;

                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);

                var tb1 = new tb_ButtonMaster();
                return View(tb1);
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
                ViewData["msgStatus"] = ce.Message;
                return View();
            }
        }

        //
        // GET: /Subject/Delete/5
 
        public ActionResult Delete(int id)
        {
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_ButtonMaster
                      where m.ButtonId == id
                      select m).Single();
            return View(tb);
        }

        //
        // POST: /Subject/Delete/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var tb = (from m in db.tb_ButtonMaster
                          where m.ButtonId == id
                          select m).Single();

                db.tb_ButtonMaster.Remove(tb);
                db.SaveChanges();
                var tb1 = new tb_ButtonMaster();

                ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(3);


                return View(tb1); 
            }
            catch
            {
                return View();
            }
        }
    }
}
