using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    

    public class ApplicationPageController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        
        private void SetViews()
        {
            var ddList = (from m in db.tb_ApplicationPage
                          select new
                          {
                              Name = m.PageName,
                              ID = m.Pageid
                          }).OrderBy(x => x.Name);
            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["pagelist"] = selectList;
        }
        public ActionResult detail(Int32 id)
        {
            SetViews();
            var model = (from m in db.tb_ApplicationPage
                         where m.Pageid == id
                         select m).Single();

            return PartialView(model);
            //return View(model);
        }
        public ActionResult Index()
        {

            SetViews();

            return View();
        }
        //
        // GET: /emailsystem/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /emailsystem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /emailsystem/Create


        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_ApplicationPage model)
        {
            try
            {
                //tb_emailsDescription model2 = new tb_emailsDescription();
                //model2.Description = model.Description;
                //model2.EmailModule_ = model.EmailModule_;
                //model2.EmailSubject = model.EmailSubject;
                db.tb_ApplicationPage.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /emailsystem/Edit/5

        public ActionResult Edit(int id)
        {
            SetViews();
            var model = (from m in db.tb_ApplicationPage
                         where m.Pageid == id
                         select m).Single();

            return View(model);
        }
 
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_ApplicationPage model)
        {
            try
            {
                SetViews();
                var model2 = (from m in db.tb_ApplicationPage
                              where m.Pageid == id
                              select m).Single();
                model2.Description = model.Description;
                model2.PageName = model.PageName;
                model2.Title = model.Title;
                model2.SetModuleId = model.SetModuleId;
                model2.MvcUrl = model.MvcUrl;
                model2.UseAsMenu = model.UseAsMenu;
                db.SaveChanges();

                return View("Index");
            }
            catch (Exception ce)
            {
                ViewData["error"] = ce.Message;
                return View();
            }
        }

        //
        // GET: /emailsystem/Delete/5

        public ActionResult Delete(int id)
        {
            var model = (from m in db.tb_ApplicationPage
                         where m.Pageid == id
                         select m).Single();
            db.tb_ApplicationPage.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /emailsystem/Delete/5

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
