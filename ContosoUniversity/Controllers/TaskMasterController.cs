using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
using System.IO;
namespace OLProject.Controllers
{
    public class TaskMasterController : Controller
    {
        //
        // GET: /task/
        kzonlineEntities db = new kzonlineEntities();
        
        public ActionResult popup(Int32 id)
        {
            var model = (from c in db.tb_TaskMaster
                         where c.TaskID == id
                         select c).Single();

            ViewData["instructions"] = model.TaskInstruction;
            ViewData["taskname"] = model.TaskName;


            return View();
        }
        public ActionResult tasklist(Int32 id)
        {
            var model = (from c in db.tb_TaskMaster
                         orderby c.DispOrder
                         where c.ModuleID == id
                         select c).ToList();

            return PartialView(model);
        }
        public void setViews()
        {
            var ddList = from c in db.tb_ModuleMaster
                         select new { ID = c.ModuleId, Name = c.ModuleName };
            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["modulelist"] = selectList;
        }
    
        public ActionResult Index()
        {
          
            setViews();

            return View();
        }

        //
        // GET: /task/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /task/Create

        public ActionResult Create()
        {
            setViews();
            return View();
        } 

        //
        // POST: /task/Create

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_TaskMaster model)
        {
            try
            {
                string imagepath = "";
                string filename1 = "";
                foreach (string inputTagName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[inputTagName];
                    if (file.ContentLength < 500000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".jpeg" || FileExtension == ".jpg" || FileExtension == ".gif")
                        {
                            string randName = emailSystem.CreateRandomPassword(5);

                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath);

                            imagepath = filename1;

                            
                        }
                    }
                }

                if (imagepath != "")
                {
                    model.image = imagepath;

                }

                model.CreatedBy = Convert.ToInt32(Session["pmsuserid"]).ToString();
                model.CreationDate = DateTime.Now;
                model.ModificationDate = DateTime.Now;
                model.ModifiedBy = Convert.ToInt32(Session["pmsuserid"]).ToString();

                db.tb_TaskMaster.Add(model);

                db.SaveChanges();

                return RedirectToAction("Index");

            }
            catch
            {

            }
            return View();
        }
        
        //
        // GET: /task/Edit/5
 
        public ActionResult Edit(int id)
        {
            setViews();
            Int32 taskid = 0;
            if (Request.QueryString["taskid"] != null)
            {
                taskid = Convert.ToInt32(Request.QueryString["taskid"]);

                var model = (from m in db.tb_TaskMaster
                             where m.TaskID == taskid
                             select m).Single();

                ViewData["ImagePath"] = model.image;
                return View(model);

            }


            return View();
        }

        //
        // POST: /task/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(int id, tb_TaskMaster model)
        {
            try
            {
                string imagepath = "";
                string filename1 = "";
                foreach (string inputTagName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[inputTagName];
                    if (file.ContentLength < 500000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".jpeg" || FileExtension == ".jpg" || FileExtension == ".gif")
                        {

                            string randName = emailSystem.CreateRandomPassword(5);

                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath);
                            imagepath = filename1;
                        }
                    }
                }
                Int32 taskid = 0;
                if (Request.QueryString["taskid"] != null)
                {
                    taskid = Convert.ToInt32(Request.QueryString["taskid"]);

                    var model1 = (from m in db.tb_TaskMaster
                                  where m.TaskID == model.TaskID
                                  select m).Single();

                    model1.TaskName = model.TaskName;
                    model1.status = model.status;
                    model1.urlmvc = model.urlmvc;
                    model1.TaskDesc = model.TaskDesc;
                    model1.TaskInstruction = model.TaskInstruction;
                    if (imagepath != "")
                    {
                        model1.image = imagepath;

                    }
                    model1.TaskDesc = model.TaskDesc;
                    model1.DispOrder = model.DispOrder;
                    model1.ModuleID = model.ModuleID;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch
            {
               
            }
            return View();
        }

        //
        // GET: /task/Delete/5
 
        public ActionResult Delete(int id)
        {
            Int32 taskid = 0;
            if (Request.QueryString["taskid"] != null)
            {
                taskid = Convert.ToInt32(Request.QueryString["taskid"]);
                var model1 = (from m in db.tb_TaskMaster
                              where m.TaskID == taskid
                              select m).Single();
                db.tb_TaskMaster.Add(model1);
                db.SaveChanges();
            }



            return RedirectToAction("Index");
        }

        //
        // POST: /task/Delete/5

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
