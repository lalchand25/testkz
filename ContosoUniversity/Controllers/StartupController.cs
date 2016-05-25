using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class StartupController : Controller
    {
        //
        // GET: /Startup/
        kzonlineEntities db = new kzonlineEntities();

        public ActionResult Load(Int32 id)
        {
            Session.Add("StartupPagePara", id);
            //Session.Add("siteurl", "http://localhost:52878/ClientBin/OLSilverlight.xap");
            Session.Add("siteurl", "http://demo.gsmmastersonline.com/ClientBin/OLSilverlight.xap");
            //ViewData["showit"] = "N";
            var Llist = db.tb_ClassMaster.ToList().Where(x => x.SubjectId == id);
            string strTable = "";

            strTable += "<table width='98%' align='center'>";

            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/' border='0'.   alt='Image' width='16' height='16'/></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/Startup/Silverlight/" + item.SubjectId + "&#34;);' id='A2' runat='server' >" + item.ClassName + "</a></td>";
                strTable += "</td></tr>";
            }

            strTable += "</table>";


            ViewData["ClassData"] = strTable;
            return View();
        }
        public ActionResult SelectUser(Int32 id)
        {
            Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
            var ddList = db.tb_UserMaster.ToList().Where(x => x.ParentId == userid);
            string LevelList = "";
            int cnt = 0;
            foreach (var item in ddList)
            {
                cnt += 1;
                if (cnt % 2 > 0)
                {
                    LevelList += "<li class='bg-grey'><a href='/Startup/Silverlight/" + id + "?cuserid=" + item.UserId + "'>" + item.UserName + "</a></li>";
                }
                else
                {
                    LevelList += "<li><a href='/Startup/Silverlight/" + id + "?cuserid=" + item.UserId + "'>" + item.UserName + "</a></li>";
                }
            }
            ViewData["userlist"] = LevelList;
            return View();
        }

        public ActionResult Index()
        {
            //var Llist = db.tb_SubjectMaster.ToList().AsQueryable();
            //Llist = Llist.Where(x => x.Publish == true);

            Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
            var ddList = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();


            string strQuery = @"select distinct * from tb_subjectmaster where publish=1 and subjectid in (select d.subjectid  from tb_ProductLinkedClass a,";
            strQuery += "tb_productmaster b,tb_productclassmaster c,tb_classmaster d where b.publish=1 and  a.productid=b.productid and  c.autoid=a.classid  and d.classid=c.autoid and a.classid=" + Convert.ToInt32(ddList.ClassId) + " and b.productid=" + Convert.ToInt32(ddList.PackageId) + ")";

            if (Convert.ToInt32(Session["cateid"]) == 8 || Convert.ToInt32(Session["cateid"]) == 3)
            {
                strQuery = @"select distinct * from tb_subjectmaster where publish=1";
            }
            IEnumerable<tb_SubjectMaster> results = db.Database.SqlQuery<tb_SubjectMaster>(strQuery);
            string strTable = "";
            foreach (var item in results)
            {
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/" + item.BigImage + "' border='0'.   alt='Delete' width='128' height='85'/></td>";
                strTable += "<td><b>" + item.SubjectName + "</b><br />" + item.SubjectDesc + "</td>";
                strTable += "<td align='center' valign='top'><a href='/Startup/Silverlight/" + item.SubjectId + "' id='A2' runat='server' ><img src='../../SiteImages/select.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

                //strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/Startup/Silverlight/" + item.SubjectId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/select.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                //strTable += "<td align='center' valign='top'><a href='/Startup/selectuser/" + item.SubjectId + "' id='A2' runat='server' ><img src='../../SiteImages/select.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
            }
            ViewData["data"] = strTable;
            return View();
        }
        // GET: /Startup/Details/5
        public ActionResult UnitList(int id)
        {
            var ddList = db.tb_UnitMaster.ToList().Where(x => x.ClassesId == id).OrderBy(x => x.DisplayOrder); ;
            string LevelList = "";
            Int32 cnt = 0;
            foreach (var item in ddList)
            {
                cnt += 1;
                if (cnt % 2 > 0)
                {
                    LevelList += "<li class='bg-grey'><a href='javascript:UpdateUnitList(" + item.UnitId + ");'>" + item.UnitName + "</a></li>";
                }
                else
                {
                    LevelList += "<li><a href='javascript:UpdateUnitList(" + item.UnitId + ");'>" + item.UnitName + "</a></li>";
                }

            }
            ViewData["UnitList"] = LevelList;
            return PartialView();
            //return View();
        }
//        public ActionResult LessonList(int id)
//        {
//            var ddList1 = (from m in db.tb_LessionMaster
//                           from t in db.tb_SubTitleMaster
//                           where m.UnitId == id && m.SubHeadId == t.SubHeadId
//                           select new
//                           {
//                               m.SubHeadId,
//                               t.SubTitle

//                           }).Distinct();

//            string LevelList = "";
//            var ddList = db.tb_LessionMaster.ToList().Where(x => x.UnitId == id).OrderBy(x => x.DisplayOrder);
//            foreach (var item in ddList)
//            {
//                LevelList += "<li><a href='javascript:ShowSlide(" + item.LessionId + ");'>" + item.LessionHeading + "</a></li>";
//            }
//            ViewData["LessonList"] = LevelList;
//            return PartialView();

////            return View();
//        }
        public ActionResult Silverlight(int id)
        {

            var bkey = db.tb_Keywords.ToList();
            foreach (var item in bkey)
            {

                if (item.KeyId == 1)
                {

                    ViewData["Level"] = item.KeyName;
                }
                if (item.KeyId == 2)
                {

                    ViewData["Unit"] = item.KeyName;

                }
                if (item.KeyId == 3)
                {
                    ViewData["Activity"] = item.KeyName;
                }

            }





            Int32 MainUerId = Convert.ToInt32(Session["pmsuserid"]);
            var gmodel = db.tb_UserMaster.ToList().Where(x => x.UserId == MainUerId).Single();

            Session.Add("fusername", gmodel.UserName);



            clsCommon.setUserHistory(Convert.ToInt32(Session["pmsuserid"]), id, 0, 0, 0, 0, 0, Request.ServerVariables["remote_Address"].ToString());

            var model = db.tb_SubjectMaster.ToList().Where(x => x.SubjectId == id).Single();
            Session.Add("currentSubject", model.SubjectName);


            var ddList = db.tb_ClassMaster.ToList().Where(x => x.SubjectId == id).OrderBy(x => x.DisplayOrder);
            var usermodel = db.tb_UserMaster.ToList().Where(x => x.UserId == MainUerId).Single();
            Int32 productid = Convert.ToInt32(usermodel.PackageId);

            string LevelList = "";
            int cnt = 0;
            Int32 total = 0;
            foreach (var item in ddList)
            {
                var classModel = db.tb_ProductLinkedClass.ToList().Where(x => x.ClassId == item.ClassId && x.ClassId == gmodel.ClassId);
                total = classModel.Count();
                if (total > 0 || usermodel.CategoryId == 8 || usermodel.CategoryId == 3)
                {
                    cnt += 1;
                    if (cnt % 2 > 0)
                    {
                        LevelList += "<li class='bg-grey'><a href='javascript:UpdateClassList(" + item.ClassesId + ");'>" + item.ClassName + "</a></li>";
                    }
                    else
                    {
                        LevelList += "<li><a href='javascript:UpdateClassList(" + item.ClassesId + ");'>" + item.ClassName + "</a></li>";
                    }
                }
            }
            ViewData["Classlist"] = LevelList;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Startup/Create

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
        // GET: /Startup/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Startup/Edit/5

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
        // GET: /Startup/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Startup/Delete/5

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
