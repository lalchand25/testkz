using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;

namespace OLProject.Controllers
{
    public class StateController : Controller
    {
        //
        // GET: /Country/
        kzonlineEntities db = new kzonlineEntities();
        private void SetViews()
        {
            var ddListy = (from m in db.tb_CountryMaster
                           orderby m.CountryName
                           select new
                           {
                               Name = m.CountryName,
                               ID = m.CountryID
                           });

            var selectList2y = new SelectList(ddListy, "ID", "Name");
            ViewData["countrylist"] = selectList2y;
 
        }
        public ActionResult Index()
        {
            SetViews();
            Int32 CountryID = 0;
            if (Request.Form["CountryID"] != null)
            {
                CountryID = Convert.ToInt32(Request.Form["CountryID"]);
            }

            if (CountryID > 0)
            {
                var tb1 = (from m in db.tb_StateMaster
                           orderby m.StateName
                           where m.CountryID == CountryID select m).ToList();
                return View(tb1);
            }
            else
            {
                var tb1 = (from m in db.tb_StateMaster select m).ToList();
                return View(tb1);
            }
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
            SetViews();
            return View();
        }

        //
        // POST: /Country/Create

        [HttpPost]
        public ActionResult Create(tb_StateMaster  model)
        {
            try
            {
                SetViews();
                if (model.StateName == "" || model.StateName == null)
                {
                    ViewData.ModelState.AddModelError("StateName", " Please Enter Country Name!");
                    return View();
                }
                var quli = from m in db.tb_StateMaster where m.StateName == model.StateName select m;
                if (quli.Count() > 0)
                {
                    ViewData.ModelState.AddModelError("StateName", "Already Exists!");
                    return View();
                }
                db.tb_StateMaster.Add(model);
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
            SetViews();
            var tb1 = (from m in db.tb_StateMaster where m.StateID == id select m).Single();

            return View(tb1);
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, tb_StateMaster model)
        {
            try
            {
                SetViews();
                // TODO: Add update logic here
                tb_StateMaster tb1 = (from m in db.tb_StateMaster where m.StateID == id select m).Single();
                tb1.StateName = model.StateName;
                tb1.CountryID = model.CountryID;
                tb1.Country_Direct = model.Country_Direct;
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
            SetViews();
            var tb1 = (from m in db.tb_StateMaster where m.StateID == id select m).Single();

            return View(tb1);
        }

        //
        // POST: /Country/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, tb_StateMaster model)
        {
            try
            {
                // TODO: Add delete logic here
                SetViews();
                tb_StateMaster tb1 = (from m in db.tb_StateMaster where m.StateID == id select m).Single();

                db.tb_StateMaster.Remove(tb1);
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
