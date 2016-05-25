using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class BullShitController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "BullShit Information");
           var Llist = db.tb_BullshitWord.ToList();
            string strTable = "";
            foreach (var item in Llist)
            {
                
                strTable += "<tr>";
                strTable += "<td>" + item.Description + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/Bullshit/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/Bullshit/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

            }
            ViewData["data"] = strTable;

            return View();
        }

        //
        // GET: /Subject/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            ViewData["buttonname"] = 1;

            return View();
        }
        private Boolean ValidateData(tb_BullshitWord model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.Description))
                ViewData.ModelState.AddModelError("Description", "Please enter   Description!");
            
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
    
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_BullshitWord model)
        {
            ViewData["buttonname"] = 1;
            try
            {
                string filename1 = "";
                if (Request.HttpMethod == "POST")
                {
                   
                    db.tb_BullshitWord.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    var tb = new tb_BullshitWord();
                    return View(tb);

                }
            }
            catch
            {

            }
            return View();
        }


        //
        // GET: /Subject/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_BullshitWord
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_BullshitWord model)
        {
            try
            {
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                var tb = (from m in db.tb_BullshitWord
                          where m.AutoId == id
                          select m).Single();
               

               
                tb.Description = model.Description;

                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);

                var tb1 = new tb_BullshitWord();
                return View(tb1);
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;

                return View();
            }
        }

        //
        // GET: /Subject/Delete/5
 
        public ActionResult Delete(int id)
        {
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_BullshitWord
                      where m.AutoId == id
                      select m).Single();
            return View(tb);
        }

        //
        // POST: /Subject/Delete/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var tb = (from m in db.tb_BullshitWord
                          where m.AutoId == id
                          select m).Single();

                db.tb_BullshitWord.Remove(tb);
                db.SaveChanges();
                var tb1 = new tb_BullshitWord();

                ViewData["errormsg"] = clsCommon.ErrorMessage(3);

                return View(tb1); 
            }
            catch
            {
                return View();
            }
        }
    }
}
