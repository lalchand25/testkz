using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class emailsystemController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        public void setViews()
        {
            var ddList = from c in db.tb_emailsDescription
                         orderby c.EmailSubject
                         select new { ID = c.Autoid, Name = c.EmailSubject };
            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["emaillist"] = selectList;
        }
        public ActionResult detail(Int32 id)
        {
            setViews();
            var model = (from m in db.tb_emailsDescription
                         where m.Autoid == id
                         select m).Single();

            return PartialView(model);
           // return View(model);
        }
        public ActionResult Index()
        {
            setViews();
            var model = (from m in db.tb_emailsDescription
                         orderby m.GroupId
                         select m);

            return View(model);
        }
        //
        // GET: /emailsystem/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
        //public ActionResult sendEmail(int id)
        //{
        //    var item = (from m in db.tb_emailsDescription
        //                where m.SetModuleID == id
        //                select m).Single();

        //    if (item.GroupId != null)
        //    {
        //        var item1 = (from m in db.tb_emailsDescription
        //                     where m.GroupId == item.GroupId
        //                     select m);
        //        foreach (var model in item1)
        //        {
        //            emailSystem.sendEmail("ceo@gaganz.com", "", Convert.ToInt32(model.SetModuleID));
        //        }
        //    }
        //    else
        //    {
        //        emailSystem.sendEmail("ceo@gaganz.com", "", id);
        //    }
        //    return RedirectToAction("Index");
        //}



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
        public ActionResult Create(tb_emailsDescription model)
        {
            try
            { 
                model.CreatedBy = Convert.ToInt32(Session["pmsuserid"]).ToString();
                model.CreationDate = DateTime.Now;
                model.Remarks="";
                model.EmailStatus=false;
                
                db.tb_emailsDescription.Add(model);
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
            var model = (from m in db.tb_emailsDescription
                         where m.Autoid == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /emailsystem/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_emailsDescription model)
        {
            try
            {
                var model2 = (from m in db.tb_emailsDescription
                             where m.Autoid == id
                             select m).Single();
                model2.Description = model.Description;
                model2.EmailModule_ = model.EmailModule_;
                model2.EmailSubject = model.EmailSubject;
                model2.GroupId = model.GroupId;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /emailsystem/Delete/5
 
        public ActionResult Delete(int id)
        {
            var model = (from m in db.tb_emailsDescription
                          where m.Autoid == id
                          select m).Single();
            db.tb_emailsDescription.Add(model);
          
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
