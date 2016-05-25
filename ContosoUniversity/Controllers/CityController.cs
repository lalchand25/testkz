using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;

namespace OLProject.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /Country/
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult statelist(Int32 id)
        {
            var ddList0 = (from m in db.tb_StateMaster
                           where m.CountryID == id
                           select new
                           {
                               Name = m.StateName,
                               ID = m.StateID
                           });
            var selectList0 = new SelectList(ddList0, "ID", "Name");
            ViewData["slist"] = selectList0;
            return PartialView();
        }

        public ActionResult distlist(Int32 id)
        {
            var ddList0 = (from m in db.tb_CityMaster
                           where m.StateID == id
                           select new
                           {
                               Name = m.CityName,
                               ID = m.CityID
                           });

            var selectList0 = new SelectList(ddList0, "ID", "Name");
            ViewData["distlist"] = selectList0;
            return PartialView();
        }
        private void SetViews()
        {
            var ddListy = (from m in db.tb_CountryMaster
                           orderby  m.CountryName
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
            Int32 StateID = 0;

            if (Request.Form["CountryID"] != null)
            {
                CountryID = Convert.ToInt32(Request.Form["CountryID"]);
            }
            if (Request.Form["StateID"] != null)
            {
                StateID = Convert.ToInt32(Request.Form["StateID"]);
            }
            if (Request.QueryString["CountryID"] != null)
            {
                CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
            }
            if (Request.QueryString["StateID"] != null)
            {
                StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            }
            if (CountryID > 0)
            {
                var tb1 = (from m in db.tb_CityMaster where m.CountryId == CountryID 
                           && m.StateID == StateID
                           orderby m.CityName
                           select m).ToList();

                var tb2 = (from m in db.tb_StateMaster
                           from t in db.tb_CountryMaster
                            
                           where m.CountryID == t.CountryID  && m.StateID == StateID
                           select new
                           {
                               m.StateName,
                               t.CountryName
                           }
                         ).Single();

                ViewData["msg"] = "<b>You are showing : " + tb2.CountryName + " ->" + tb2.StateName + "</b>";

                return View(tb1);
            }
            else
            {
                var tb1 = (from m in db.tb_CityMaster
                           orderby m.CityName
                           select m).ToList().Take(100);

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
        public ActionResult Create(tb_CityMaster model)
        {
            try
            {

                SetViews();

                if (model.CityName == "" || model.CityName == null)
                {
                    ViewData["Error"] = "Please Enter City Name!";
                    return View();
                }

                var quli = from m in db.tb_CityMaster where m.CityName == model.CityName && m.StateID == model.StateID select m;
                if (quli.Count() > 0)
                {
                    //ViewData.ModelState.AddModelError("City Name", "Already Exists!");
                    ViewData["Error"] = "Already Exists!";
                    return View();
                }

                db.tb_CityMaster.Add(model);
                db.SaveChanges();
                ViewData["Error"] = "Successfully Created Record !!";
               
                return View();

            }
            catch (Exception ce)
            {
                ViewData["Error"] = ce.Message;
                return View();
            }
        }

        //
        // GET: /Country/Edit/5

        public ActionResult Edit(int id)
        {
            SetViews();
            var tb1 = (from m in db.tb_CityMaster where m.CityID == id select m).Single();

            return View(tb1);
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, tb_CityMaster model)
        {
            try
            {
                SetViews();
                // TODO: Add update logic here
                tb_CityMaster tb1 = (from m in db.tb_CityMaster where m.CityID == id select m).Single();
                tb1.CityName = model.CityName;
                tb1.BAPer = 0;
                tb1.Dist_Fee = model.Dist_Fee;
                tb1.State_Direct = model.State_Direct;
                tb1.From_District = model.From_District;
                
                tb1.BATarget = model.BATarget;

                tb1.ModificationDate = DateTime.Now;
                tb1.ModifiedBy = Convert.ToInt32(Session["pmsuserid"]).ToString();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Int32 CountryID = 0;
                Int32 StateID = 0;
                tb_CityMaster tb1 = (from m in db.tb_CityMaster where m.CityID == id select m).Single();
                CountryID = Convert.ToInt32(tb1.CountryId);
                StateID = Convert.ToInt32(tb1.StateID);
              //  db.tb_CityMaster.Remove(tb1);
                db.SaveChanges();
                return RedirectToAction("Index", "City", new { CountryID = CountryID, StateID = StateID });
            }
            catch
            {
                return View();
            }
        }
    }
}
