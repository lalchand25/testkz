using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
using System.IO;
namespace OLProject.Controllers
{
    public class CompaniesController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Session.Add("siteurl", "http://silverapp.goeoffice.com/ClientBin/OLSilverlight.xap");
           //Session.Add("siteurl","http://localhost:52878/ClientBin/OLSilverlight.xap");
           
            //var item1 = (from m in db.tb_Companies
            //             where m.CreatedBy == Convert.ToInt32(Session["pmsuserid"]).ToString()
            //             select m);
            //if (item1.Count() > 0)
            //{
            //    var item = (from m in db.tb_Companies
            //                where m.CreatedBy == Convert.ToInt32(Session["pmsuserid"]).ToString()
            //                select m).Single();

            //    ViewData["ImagePath"] = item.Logopath;

            //    return View(item);
            //}
            //else
            //{
            return View();
        }

        [HttpPost]
        public ActionResult Index(tb_Company model)
        {
            try
            {
                string imagepath = "";
                string filename1 = "";
                foreach (string inputTagName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[inputTagName];
                    if (file.ContentLength < 3000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".jpeg" || FileExtension == ".jpg" || FileExtension == ".gif")
                        {
                            string randName = emailSystem.CreateRandomPassword(10);

                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath);
                            imagepath = filename1;
                        }
                    }
                }

                if (imagepath != "")
                {
                    model.Logopath = imagepath;
                }
                else
                {
                    model.Logopath = "";
                }
                var item1 = db.tb_Company.ToList().Where(m => m.EmailId == model.EmailId);
                if (item1.Count() > 0)
                {
                    model.LastUpdate = DateTime.Now;
                    db.tb_Company.Add(model);
                    db.SaveChanges();
                }
                else
                {
                    ViewData["error"] = "Emailid";
                }

                ViewData["error"] = "Updated";
            }
            catch (Exception ce)
            {
                ViewData["error"] = ce.Message;
            }

            return View();
        }

        //

        //
        // GET: /Companies/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Companies/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Companies/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Companies/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Companies/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Companies/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Companies/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
