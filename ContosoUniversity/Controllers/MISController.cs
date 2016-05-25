using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class MISController : Controller
    {

        
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult LessonList()
        {
            DataRepository dr = new DataRepository();
            var model = dr.LessonList();

            //*****************************************************************
            //*****************************************************************
            int page = 1;
            if (Request.QueryString["pageno"] != null)
            {
                page = Convert.ToInt32(Request.QueryString["pageno"].ToString());
            }

            Int32 offset = 25;
            int totalRecord = model.Count();
            int start;
            start = (page - 1) * offset;
            Int32 totalpage = 0;
            if (totalRecord > offset)
            {
                int totalpage1 = (totalRecord % offset);
                totalpage = (totalRecord / offset);
                if (totalpage1 > 0)
                {
                    totalpage += 1;
                }
            }
            else
            {
                totalpage = 1;
            }
            string pageUrl = "/MIS/LessonList/";
            string pageLinks = clsCommon.getPageingInformation(page, totalpage, pageUrl);
            ViewData["totalrecords"] = totalRecord;
            ViewData["pageLinks"] = pageLinks;
            model = model.Skip(start).Take(offset);
            //*****************************************************************

            return View(model);
        }

        //
        // GET: /MIS/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MIS/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /MIS/Create

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
        // GET: /MIS/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MIS/Edit/5

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
        // GET: /MIS/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MIS/Delete/5

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
