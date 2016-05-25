using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class ThemeContentController : Controller
    {
        // GET: /Subject/
        kzonlineEntities db = new kzonlineEntities();

        private void setViews()
        {
            var ddList = (from m in db.tb_UploadTypeMaster
                          select new
                          {
                              Name = m.UploadTypeName,
                              ID = m.UploadId
                          });

            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["typelist"] = selectList;


            var ddList1 = (from m in db.tb_ThemeMaster
                           select new
                           {
                               Name = m.ThemeName1,
                               ID = m.ThemeId
                           });

            var selectList1 = new SelectList(ddList1, "ID", "Name");
            ViewData["typelist1"] = selectList1;

        }

        public ActionResult ShowTheme(Int32 id)
        {
            var model = db.tb_ThemeMaster.ToList().Where(x => x.ThemeId == id).Single();
            ViewData["themeimage"] = "<img src='../../uploads/" + model.ImagePath + "' border='0'   alt='Delete' style='width:100px;Height:100px;'/>";


            return View();
        }
      
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Theme Content Parameters");
          
            ViewData["screate"] = " <a href='javascript:OpenPopup(&#34;/ThemeContent/create/&#34;);' id='A1' runat='server' >";

            var Llist = db.tb_ThemeContent.ToList().OrderBy(x => x.ThemeId);
            string strTable = "";
            Int32 mcounter = 0;
            string themename = "";

            foreach (var item in Llist)
            {

                var model = db.tb_ThemeMaster.ToList().Where(x => x.ThemeId == item.ThemeId).Single();
                var model1 = db.tb_UploadTypeMaster.ToList().Where(x => x.UploadId == item.UploadTypeId).Single();

                mcounter += 1;
                if (mcounter % 2 == 0)
                {
                    strTable += "<tr  bgcolor='#DDEEEE'>";
                }
                else
                {
                    strTable += "<tr bgcolor='#EEFFFF'>";
                }
                strTable += "<td><img src='../../uploads/" + model.ImagePath + "' border='0'   alt='Delete' style='width:75px;Height:75px;'/></td>";
                strTable += "<td>" + model.ThemeName1 + "</td>";
                strTable += "<td>" + model1.UploadTypeName + "</td>";
                strTable += "<td>" + item.intWidth + "</td>";
                strTable += "<td>" + item.intHeight + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/themeContent/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/themeContent/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";

       
            }
            ViewData["data"] = strTable;

            return View();
        }
        // GET: /Subject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
     
      
      
    
       
        public ActionResult Create()
        {
            setViews();
            ViewData["buttonname"] = 1;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_ThemeContent model)
        {
            setViews();
            ViewData["buttonname"] = 1;
            try
            {
                model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                model.SystemDate = DateTime.Now;
                model.IpAddress = Request.ServerVariables["remote_address"];
                db.tb_ThemeContent.Add(model);
                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(1);

            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();
        }
        // GET: /Subject/Edit/5


        public ActionResult Edit(int id)
        {
            setViews();

            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_ThemeContent
                         where m.AutoId == id
                         select m).Single();

            var model1 = db.tb_ThemeMaster.ToList().Where(x => x.ThemeId == model.ThemeId).Single();
            ViewData["themeimage"] = "<img src='../../uploads/" + model1.ImagePath + "' border='0'   alt='Delete' style='width:100px;Height:100px;'/>";

            return View(model);
        }

        //
        // POST: /Subject/Edit/5

 
         [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_ThemeContent model)
        {
            try
            {
                setViews();
                var tb = (from m in db.tb_ThemeContent
                          where m.AutoId == id
                          select m).Single();
                tb.intWidth = model.intWidth;
                tb.intHeight = model.intHeight;
                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
                return View();

            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;


            }
            return View();
        }

        //
        // GET: /Subject/Delete/5
 
        public ActionResult Delete(int id)
        {
            ViewData["buttonname"] = 3;
            setViews();
            var tb = (from m in db.tb_ThemeContent
                      where m.AutoId == id
                      select m).Single();

            var model1 = db.tb_ThemeMaster.ToList().Where(x => x.ThemeId == tb.ThemeId).Single();

            ViewData["themeimage"] = "<img src='../../uploads/" + model1.ImagePath + "' border='0'   alt='Delete' style='width:100px;Height:100px;'/>";

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
                var tb = (from m in db.tb_ThemeContent
                          where m.AutoId == id
                          select m).Single();

                db.tb_ThemeContent.Remove(tb);
                db.SaveChanges();

                ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
                ViewData["errormsg"] = clsCommon.ErrorMessage(3);
            }
            catch
            {
                ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
                ViewData["errormsg"] = clsCommon.ErrorMessage(3);
               
            }
            return View();
        }
    }
}
