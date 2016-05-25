using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class RssfeedController : Controller
    {
        //
        // GET: /Rssfeed/
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {

            string rssfeed = "";
            rssfeed += "<?xml version='1.0' encoding='utf-8' ?>";
            rssfeed += "<rss version='2.0'>";
            rssfeed += "<channel>";
            rssfeed += "<title>Gaganz.com</title> ";
            rssfeed += "<link>http://www.Gaganz.com</link> ";
            rssfeed += "<description>Portal</description>";
            var tb = db.tb_LessionMasterSlides.ToList();
            foreach (var item in tb)
            {
                rssfeed += "<item>  ";
                rssfeed += "<title>" + item.SlideDescription + "</title>";
                rssfeed += "<link>http://www.Gaganz.com/</link>";
                rssfeed += "<description>" + item.ImageDescription + "</description>  ";
                rssfeed += "</item>  ";
            }
            rssfeed += " </channel>  ";
            rssfeed += "</rss>  ";
            ViewData["rssfeed"] = rssfeed;
            return View();
        }

        //
        // GET: /Rssfeed/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Rssfeed/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Rssfeed/Create

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
        // GET: /Rssfeed/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Rssfeed/Edit/5

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
        // GET: /Rssfeed/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Rssfeed/Delete/5

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
