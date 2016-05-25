using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class ProductClassController : Controller
    {
        //
        // GET: /Subject/


        kzonlineEntities db = new kzonlineEntities();

      
      
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Product Class Information");
            var model = db.tb_ProductClassMaster.ToList().OrderBy(x => x.ClassName);

            //int catid = 0;
            //if (Session["cateid"] != null)
            //{
            //    catid = Convert.ToInt32(Session["cateid"]);
            //}

            //if (catid != 8)
            //{
            //    int userid = Convert.ToInt32(Session["pmsuserid"]);

            //    model = model.Where(x => x.Userid == userid);
            //}


            string strTable = "";
            Int32 mcounter = 0;
            foreach (var item in model)
            {
                mcounter += 1;
                if (mcounter % 2 == 0)
                {
                    strTable += "<tr  bgcolor='#DDEEEE'>";
                }
                else
                {
                    strTable += "<tr bgcolor='#EEFFFF'>";
                }

              
                strTable += "<td><img src='../../Siteimages/1.png' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
                strTable += "<td>" + item.ClassName + "</a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/productclass/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/productclass/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

            }
            ViewData["data"] = strTable;

            return View();
        }

        //
        // GET: /Subject/Details/5

        //
        // GET: /Subject/Edit/5
        public ActionResult Detail(int id)
        {

            var model = (from m in db.tb_ProductClassMaster
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }


        public ActionResult Create()
        {
            ViewData["buttonname"] = 1;
            
            return View();
        }
        private Boolean ValidateData(tb_ProductClassMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.ClassName))
                ViewData.ModelState.AddModelError("ClassName", "Please enter   Class Name!");
            
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_ProductClassMaster model)
        {
            
            ViewData["buttonname"] = 1;
            try
            {

                string filename1 = "";

                if (ValidateData(model))
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
                            file.SaveAs(filePath); file.SaveAs(filePath);
                        }
                    }


                    if (filename1 != "")
                    {
                        model.ImageClass = filename1;
                    }

                    //model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                    model.SystemDate = DateTime.Now;
                    //model.IpAddress = Request.ServerVariables["remote_address"];
                    db.tb_ProductClassMaster.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                    return View();

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
            var model = (from m in db.tb_ProductClassMaster
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
         [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_ProductClassMaster model)
        {
            try
            {
              
                ViewData["buttonname"] = 2;
                string filename1 = "";

                if (ValidateData(model))
                {

                    var tb = (from m in db.tb_ProductClassMaster
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
                            file.SaveAs(filePath); file.SaveAs(filePath);
                        }
                    }


                    if (filename1 != "")
                    {
                        model.ImageClass = filename1;
                    }

                    tb.ClassName = model.ClassName;
                    tb.Duration = model.Duration;
                    tb.Price = model.Price;
                    
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
                    return View();
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        //
        // GET: /Subject/Delete/5
 
        public ActionResult Delete(int id)
         {
           
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_ProductClassMaster
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
                 var model = db.tb_ClassMaster.ToList().Where(x => x.ClassId == id);
                 if (model.Count() == 0)
                 {
                     var tb = (from m in db.tb_ProductClassMaster
                               where m.AutoId == id
                               select m).Single();
                     db.tb_ProductClassMaster.Remove(tb);

                     db.SaveChanges();
                     ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                     ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
                 }

                 else

                 {
                     ViewData["errormsg"] = clsCommon.ErrorMessage(4);
                     ViewData["msgStatus"] = clsCommon.ErrorMessage(4);
                 }
                return View();
                 
            }
            catch
            {
                return View();
            }
        }
    }
}
