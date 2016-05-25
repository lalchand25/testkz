using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;

namespace OLProject.Controllers
{
    public class CountryController : Controller
    {
        //
        // GET: /Country/
        kzonlineEntities db = new kzonlineEntities();

        public ActionResult Index()
        {
            var tb1 = (from m in db.tb_CountryMaster 
                       orderby m.CountryName
                       select m).ToList();

            return View(tb1);
        }

        //
        // GET: /Country/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Country/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Country/Create

        [HttpPost]
        public ActionResult Create(tb_CountryMaster  model)
        {
            try
            {


                if (model.CountryName == "" || model.CountryName == null)
                {
                    ViewData.ModelState.AddModelError("CountryName", " Please Enter Country Name!");
                    return View();
                }

                var quli = from m in db.tb_CountryMaster  where m.CountryName  == model.CountryName select m;
                if (quli.Count() > 0)
                {
                    ViewData.ModelState.AddModelError("CountryName", "Already Exists!");
                    return View();
                }

                db.tb_CountryMaster.Add(model);

                db.SaveChanges();
                return RedirectToAction("Create");


            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Country/Edit/5

        public ActionResult Edit(int id)
        {
            var tb1 = (from m in db.tb_CountryMaster where m.CountryID == id select m).Single();

            return View(tb1);
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, tb_CountryMaster model)
        {
            try
            {
                // TODO: Add update logic here
                tb_CountryMaster tb1 = (from m in db.tb_CountryMaster where m.CountryID == id select m).Single();
                tb1.CountryName = model.CountryName;
                
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Country/Delete/5

        public ActionResult Delete(int id)
        {
            var tb1 = (from m in db.tb_CountryMaster where m.CountryID == id select m).Single();

            return View(tb1);
        }

        //
        // POST: /Country/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, tb_CountryMaster model)
       { 
            try
            {
                // TODO: Add delete logic here

                tb_CountryMaster tb1 = (from m in db.tb_CountryMaster where m.CountryID == id select m).Single();
                db.tb_CountryMaster.Remove(tb1);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
