using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class FlashLibController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Flash Library Information");
           var Llist = db.tb_FlashLibMaster.ToList();
            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/2.png' border='0'.   alt='Delete' style='width:80px;Height:80px;'/></td>";
                strTable += "<td><a href='javascript:OpenPopup(&#34;/FlashLib/Detail/" + item.AutoId + "&#34;);' id='A2' runat='server' >" + item.FlashName + "</a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/FlashLib/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/FlashLib/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
            }
            ViewData["data"] = strTable;

            return View();
        }

        //
        // GET: /Subject/Edit/5
        public ActionResult Detail(int id)
        {

            var model = (from m in db.tb_FlashLibMaster
                         where m.AutoId == id
                         select m).Single();
            string html = "";
            html += "<table width='100%' align='left' style='background-color:white;'>";
            html += "<tr><td align='left' valign='top'>";
            html += "<OBJECT classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' ";
            html += "codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0' ";
            html += "WIDTH='320' HEIGHT='240' id='Puggle' ALIGN=''>";
            html += "<PARAM NAME=movie VALUE='../../uploads/" + model.ImagePath + "'> ";
            html += "<PARAM NAME=quality VALUE=high>";
            html += "<PARAM NAME=bgcolor VALUE=#333399>";
            html += "<EMBED src='../../uploads/" + model.ImagePath + "' quality=high WIDTH='900' HEIGHT='450' NAME='Yourfilename' ALIGN='' TYPE='application/x-shockwave-flash' PLUGINSPAGE='http://www.macromedia.com/go/getflashplayer'></EMBED> </OBJECT>";
            html += "</td></tr>";
            html += "</table>";
            ViewData["desc"] = html;

            return View(model);
        }


        public ActionResult Create()
        {
            ViewData["buttonname"] = 1;

            return View();
        }
        private Boolean ValidateData(tb_FlashLibMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.FlashName))
                ViewData.ModelState.AddModelError("FlashName", "Please enter   Flash Clip Name!");
            
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
    
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_FlashLibMaster model)
        {
            ViewData["buttonname"] = 1;
            try
            {
                string filename1 = "";
                string filename2 = "";
                if (Request.HttpMethod == "POST")
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength < 20000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".swf")
                        {
                            string randName = emailSystem.CreateRandomPassword(8);
                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath);
                        }
                    }

                   

                    model.ImagePath = filename1;
                    model.SystemDate = DateTime.Now;

                    db.tb_FlashLibMaster.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);

                    var tb = new tb_FlashLibMaster();
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
            var model = (from m in db.tb_FlashLibMaster
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_FlashLibMaster model)
        {
            try
            {
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                var tb = (from m in db.tb_FlashLibMaster
                          where m.AutoId == id
                          select m).Single();
                HttpPostedFileBase file = Request.Files[0];
                if (file.ContentLength < 20000000)
                {
                    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (FileExtension == ".swf")
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        filename1 = randName + "_" + file.FileName;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                        file.SaveAs(filePath);
                    }
                }
                
                if (filename1 != "")
                {
                    tb.ImagePath = filename1;
                }
               
                tb.FlashName = model.FlashName;

                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);

                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);

                var tb1 = new tb_FlashLibMaster();
                return View(tb1);
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;

                return View();
            }
        }

        //
        // GET: /Subject/Delete/5
 
        public ActionResult Delete(int id)
        {
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_FlashLibMaster
                      where m.AutoId == id
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
                var tb = (from m in db.tb_FlashLibMaster
                          where m.AutoId == id
                          select m).Single();

                db.tb_FlashLibMaster.Remove(tb);
                db.SaveChanges();
                var tb1 = new tb_FlashLibMaster();

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
