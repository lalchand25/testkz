using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class modulesController : Controller
    {
        //
        // GET: /modules/
        kzonlineEntities db = new kzonlineEntities();
        
        public ActionResult popup(Int32 id)
        {
            var model = (from c in db.tb_ModuleMaster
                         where c.ModuleId == id
                         select c).Single();

           // ViewData["instructions"] = model.ModuleInstruction;
            ViewData["taskname"] = model.ModuleName;


            return View();
        }

        public ActionResult Index()
        {
            var model = (from m in db.tb_ModuleMaster
                         orderby m.Displayorderno
                         select m).ToList();


            return View(model);
        }

        //
        // GET: /modules/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /modules/Create

        public ActionResult Create()
        {
            return View();
        }

        private Boolean ValidateData(tb_ModuleMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.ModuleName))
                ViewData.ModelState.AddModelError("ModuleName", "Please enter   Module Name !");


            if (model.Displayorderno == null || model.Displayorderno == 0)
            {
                ViewData.ModelState.AddModelError("Displayorderno", "Please Select Display Order  !");
            }

          
            return validateData1;
        }
        // POST: /modules/Create
         [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(tb_ModuleMaster model)
        {
            try
            {
                if (ValidateData(model))
                {
                    model.Status = "0";
                    db.tb_ModuleMaster.Add(model);
                    db.SaveChanges();
                    // TODO: Add insert logic here
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /modules/Edit/5
 
        public ActionResult Edit(int id)
        {
            tb_ModuleMaster model = (from m in db.tb_ModuleMaster
                                     where m.ModuleId == id
                                     select m).Single();

            
            return View(model);
        }

        //
        // POST: /modules/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id,tb_ModuleMaster model1)
        {
            try
            {
                if (ValidateData(model1))
                {
                    tb_ModuleMaster model = (from m in db.tb_ModuleMaster
                                             where m.ModuleId == id
                                             select m).Single();

                    model.ModuleName = model1.ModuleName;
                    model.Displayorderno = model1.Displayorderno;
                    model.ModuleInstruction = model1.ModuleInstruction;

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
             
            }
            return View();
        }

        //
        // GET: /modules/Delete/5
 
        public ActionResult Delete(int id)
        {
            tb_ModuleMaster model = (from m in db.tb_ModuleMaster
                                     where m.ModuleId == id
                                     select m).Single();

            db.tb_ModuleMaster.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /modules/Delete/5

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
