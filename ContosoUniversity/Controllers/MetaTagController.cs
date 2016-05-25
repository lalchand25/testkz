using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;

namespace OLProject.Controllers
{ 
    public class MetaTagController : Controller
    {
        //
        // GET: /MetaTag/
        kzonlineEntities db = new kzonlineEntities();

        public ActionResult detail(Int32 id)
        {
            SetViews();
            var model1 = (from m in db.tb_MetatagMaster
                          where m.MetaId == id
                          select m);
            if (model1.Count() > 0)
            {

                var model = (from m in db.tb_MetatagMaster
                             where m.MetaId == id
                             select m).Single();

                return PartialView(model);
            }
            else
            {

                return PartialView();
            }
        }

        private void SetViews()
        {
            var ddList = (from m in db.tb_MetatagMaster
                          select new
                          {
                              Name = m.PageName,
                              ID = m.MetaId 
                          });
            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["pagelist"] = selectList;
        }

        public ActionResult Index()
        {
            SetViews();
            var tb1 = (from m in db.tb_MetatagMaster select m).ToList();
            return View(tb1);
        }

        public ActionResult Create()
        {
           return View();


        }
        public ActionResult edit(Int32 id)
        {

            var tb = (from m in db.tb_MetatagMaster
                       where m.MetaId == id
                       select m).Single();

            return View(tb);



        }
        public ActionResult delete(Int32 id)
        {

            var tb = (from m in db.tb_MetatagMaster
                      where m.MetaId == id
                      select m).Single();
            db.tb_MetatagMaster.Remove(tb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(tb_MetatagMaster model,Int32 id)
        {
            try
            {
                var tb = (from m in db.tb_MetatagMaster
                          where m.MetaId == id
                          select m).Single();

                tb.PageName = model.PageName;
                tb.Keywords = model.Keywords;
                tb.Description = model.Description;
                tb.RobotTag = model.RobotTag;
                tb.Title = model.Title;
                tb.Author = model.Author;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ce)
            {


            }
            return View();

        }

        [HttpPost]
        public ActionResult Create(tb_MetatagMaster model)
        {
            try
            {
                model.CreationDate = DateTime.Now;
                model.ModificationDate = DateTime.Now;
                 
                db.tb_MetatagMaster.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ce)
            {


            }
            return View();

        }



    }
}
