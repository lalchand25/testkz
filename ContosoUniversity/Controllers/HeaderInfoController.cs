using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class HeaderInfoController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Header Information");
           var Llist = db.tb_HeaderMaster.ToList();
            string strTable = "";
            foreach (var item in Llist)
            {
                
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/" + item.HeadingImage + "' border='0'.   alt='Delete' style='width:50px;Height:50px;'/></td>";
             
                strTable += "<td>" + item.HeadingName + "</td>";

                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/HeaderInfo/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/HeaderInfo/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

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
        private Boolean ValidateData(tb_HeaderMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.HeadingName))
                ViewData.ModelState.AddModelError("HeadingName", "Please enter   Heading Name!");
            
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
    
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_HeaderMaster model)
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

                    model.HeadingImage = filename1;
                    model.SystemDate = DateTime.Now;
                    model.UserId =Convert.ToInt32(Session["pmsuserid"]);
                    model.IpAddress = Request.ServerVariables["remote_Address"];

                    db.tb_HeaderMaster.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                    var tb = new tb_HeaderMaster();
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
            var model = (from m in db.tb_HeaderMaster
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_HeaderMaster model)
        {
            try
            {
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                var tb = (from m in db.tb_HeaderMaster
                          where m.AutoId == id
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
             
                if (filename1 != "")
                {
                    tb.HeadingImage = filename1;
                }
                tb.HeadingName = model.HeadingName;

                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);

                var tb1 = new tb_HeaderMaster();
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

            var tb = (from m in db.tb_HeaderMaster
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
                var tb1 = db.tb_HeaderDetail.ToList().Where(x => x.HeaderId == id);
                if (tb1.Count() > 0)
                {
                    var tb = (from m in db.tb_HeaderMaster
                              where m.AutoId == id
                              select m).Single();

                    db.tb_HeaderMaster.Remove(tb);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
                }
                else
                {
                    ViewData["errormsg"] = clsCommon.ErrorMessage(4);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(4);

                }

                return View(tb1);
            }
            catch
            {
                return View();
            }
        }
    }
}
