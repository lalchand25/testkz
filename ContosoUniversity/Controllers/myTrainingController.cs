using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class myTrainingController : Controller
    {
        // GET: /Startup/
        kzonlineEntities db = new kzonlineEntities();

        //
        // GET: /myTraining/
        public ActionResult Index()
        {
            //var Llist = db.tb_SubjectMaster.ToList().AsQueryable();
            //Llist = Llist.Where(x => x.Publish == true);


            if (Session["pmsuserid"] == null)
            {
                return RedirectToAction("logon", "login", new { action1 = "edit", controller1 = "/profile.aspx" });
            }


            Int32 userid = Convert.ToInt32(Session["pmsuserid"]);

            var ddList = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();


            // stoped due to speed

            //string strQuery = @"select distinct * from tb_subjectmaster where publish=1 and subjectid=" + Convert.ToInt32(ddList.ClassId); // temrary need to study above

            //if (Convert.ToInt32(Session["cateid"]) == 8 || Convert.ToInt32(Session["cateid"]) == 3)
            //{
            //    strQuery = @"select distinct * from tb_subjectmaster where publish=1";
            //}
            //IEnumerable<tb_SubjectMaster> results = db.Database.SqlQuery<tb_SubjectMaster>(strQuery);

            //    var tbSub = db.tb_SubjectMaster.Take(1);
            string strTable = "";
            if (Convert.ToInt32(Session["cateid"]) == 8)
            {
                //  strQuery = @"select distinct * from tb_subjectmaster where publish=1";

                var tbSub = db.tb_SubjectMaster.Where(x => x.PublishAdmin == true & x.Publish == true).Select(x => new { x.SubjectName, x.SubjectDesc, x.SubjectId, x.SubjectImge });


                foreach (var item in tbSub)
                {
                    strTable += "<div class='student-profile'>";
                    strTable += "<div class='container'>";
                    strTable += "<div class='row'>";
                    strTable += "<div class='span8'>";
                    strTable += "<h2>" + item.SubjectName + "</h2>";

                    int lenth1 = item.SubjectDesc.Length;
                    if (lenth1 > 400)
                    {
                        strTable += item.SubjectDesc.Substring(0, 400);
                    }
                    else
                    {
                        strTable += item.SubjectDesc + "....";
                    }
                    strTable += "<br/> <br/> <a href='/mytraining/CourseSubject/" + item.SubjectId + "' class='btn-style'>View Courses</a>";
                    strTable += "</div>";
                    strTable += "<div class='span4'>";

                    strTable += " <img alt='' src='../uploads/" + item.SubjectImge + "' style='width:100%;Height:200px;'  />";
                    strTable += "</div>";
                    strTable += "</div>";
                    strTable += "</div>";
                    strTable += "</div>";


                }

            }

            else if (Convert.ToInt32(Session["cateid"]) == 3)
            {


                int useridn = Convert.ToInt32(Session["pmsuserid"]);

                var tbSub = db.tb_SubjectMaster.Where(x => x.PublishAdmin == true & x.Publish == true && x.UserId == useridn).Select(x => new { x.SubjectName, x.SubjectDesc, x.SubjectId, x.SubjectImge });

                foreach (var item in tbSub)
                {
                    strTable += "<div class='student-profile'>";
                    strTable += "<div class='container'>";
                    strTable += "<div class='row'>";
                    strTable += "<div class='span8'>";
                    strTable += "<h2>" + item.SubjectName + "</h2>";

                    int lenth1 = item.SubjectDesc.Length;
                    if (lenth1 > 400)
                    {
                        strTable += item.SubjectDesc.Substring(0, 400);
                    }
                    else
                    {
                        strTable += item.SubjectDesc + "....";
                    }
                    strTable += "<br/> <br/> <a href='/mytraining/CourseSubject/" + item.SubjectId + "' class='btn-style'>View Courses</a>";
                    strTable += "</div>";
                    strTable += "<div class='span4'>";

                    strTable += " <img alt='' src='../uploads/" + item.SubjectImge + "' style='width:100%;Height:200px;'  />";
                    strTable += "</div>";
                    strTable += "</div>";
                    strTable += "</div>";
                    strTable += "</div>";


                }

            }
            else
            {


                int classid = Convert.ToInt32(ddList.ClassId);

                var tbSub = db.tb_SubjectMaster.Where(x => x.PublishAdmin == true & x.Publish == true && x.SubjectId == classid).Select(x => new { x.SubjectName, x.SubjectDesc, x.SubjectId, x.SubjectImge });

                foreach (var item in tbSub)
                {
                    strTable += "<div class='student-profile'>";
                    strTable += "<div class='container'>";
                    strTable += "<div class='row'>";
                    strTable += "<div class='span8'>";
                    strTable += "<h2>" + item.SubjectName + "</h2>";

                    int lenth1 = item.SubjectDesc.Length;
                    if (lenth1 > 400)
                    {
                        strTable += item.SubjectDesc.Substring(0, 400);
                    }
                    else
                    {
                        strTable += item.SubjectDesc + "....";
                    }
                    strTable += "<br/> <br/> <a href='/mytraining/CourseSubject/" + item.SubjectId + "' class='btn-style'>View Courses</a>";
                    strTable += "</div>";
                    strTable += "<div class='span4'>";

                    strTable += " <img alt='' src='../uploads/" + item.SubjectImge + "' style='width:100%;Height:200px;'  />";
                    strTable += "</div>";
                    strTable += "</div>";
                    strTable += "</div>";
                    strTable += "</div>";


                }

            }



            ViewData["data"] = strTable;
            return View();


        }

        // GET: /myTraining/
        //public ActionResult CourseSemester(int id)
        //{
        //    Session.Add("subjectid", id);
        //    var bkey = db.tb_Keywords.ToList();
        //    foreach (var item in bkey)
        //    {

        //        if (item.KeyId == 1)
        //        {

        //            ViewData["Level"] = item.KeyName;
        //        }
        //        if (item.KeyId == 2)
        //        {

        //            ViewData["Unit"] = item.KeyName;

        //        }
        //        if (item.KeyId == 3)
        //        {
        //            ViewData["Activity"] = item.KeyName;
        //        }

        //    }





        //    Int32 MainUerId = Convert.ToInt32(Session["pmsuserid"]);
        //    var gmodel = db.tb_UserMaster.ToList().Where(x => x.UserId == MainUerId).Single();

        //    Session.Add("fusername", gmodel.UserName);



        //    clsCommon.setUserHistory(Convert.ToInt32(Session["pmsuserid"]), id, 0, 0, 0, 0, 0, Request.ServerVariables["remote_Address"].ToString());

        //    var model = db.tb_SubjectMaster.ToList().Where(x => x.SubjectId == id).Single();
        //    Session.Add("currentSubject", model.SubjectName);


        //    var ddList = db.tb_ClassMaster.ToList().Where(x => x.SubjectId == id).OrderBy(x => x.DisplayOrder);
        //    var usermodel = db.tb_UserMaster.ToList().Where(x => x.UserId == MainUerId).Single();
        //    Int32 productid = Convert.ToInt32(usermodel.PackageId);

        //    string LevelList = "";
        //    int cnt = 0;
        //    Int32 total = 0;
        //    foreach (var item in ddList)
        //    {
        //        // var classModel = db.tb_ProductLinkedClass.ToList().Where(x => x.ClassId == item.ClassId && x.ClassId == gmodel.ClassId);

        //        LevelList += "  <li class='span4'>";
        //        LevelList += "              <div class='thumb'>";
        //        LevelList += "                 <a href='/mytraining/courseSubject/" + item.ClassesId + "'>   <img alt='' src='../../uploads/" + item.ClassImage + "'   /> </a>";
        //        LevelList += "           </div>";
        //        LevelList += "             <div class='text'>";
        //        LevelList += "               <h4><a href='/mytraining/courseSubject/" + item.ClassesId + "'>" + item.ClassName + "</a></h4>";

        //        // LevelList += "              <p>"+item.ClasssDescription+"</p>";


        //        LevelList += "              <p>&nbsp;&nbsp;</p>";


        //        LevelList += "          </div>";
        //        LevelList += "      </li>";


        //        //total = classModel.Count();
        //        //if (total > 0 || usermodel.CategoryId == 8 || usermodel.CategoryId == 3)
        //        //{
        //        //    cnt += 1;
        //        //    if (cnt % 2 > 0)
        //        //    {
        //        //        LevelList += "<li class='bg-grey'><a href='javascript:UpdateClassList(" + item.ClassesId + ");'>" + item.ClassName + "</a></li>";
        //        //    }
        //        //    else
        //        //    {
        //        //        LevelList += "<li><a href='javascript:UpdateClassList(" + item.ClassesId + ");'>" + item.ClassName + "</a></li>";
        //        //    }
        //        //}
        //    }


        //    var subject = from m in db.tb_SubjectMaster where m.SubjectId == id select m;
        //    if (subject.Count() > 0)
        //    {
        //        var subject2 = (from m in db.tb_SubjectMaster where m.SubjectId == id select m).Single();
        //        ViewData["subject"] = subject2.SubjectName;
        //    }


        //    ViewData["Classlist"] = LevelList;
        //    return View();

        //}

        public ActionResult CourseSubject(int id, string buttonName)
        {

            if (Request.IsAjaxRequest())
            {
                id = Convert.ToInt16(buttonName);
                var gmodel = db.tb_LessionMaster.ToList().Where(x => x.LessionId == id).Single();
                ViewData["startbuttonNew"] = "<a href='/SlideShowNew/Index/" + id + "' style='border: medium none; background-color: #e8424e; border-radius: 5px; color: #fff; font-size: 16px; font-weight: 600; padding:10px 20px;  margin:0px;'>Start</a>";
                ViewData["heading"] = gmodel.LessionHeading;
                ViewData["slidedesc"] = gmodel.SlideDescription;
                ViewData["graphics"] = "<img src='../../uploads/" + gmodel.imagePath + "' border='0'   alt='Delete' style='width:420px;'/>";


                return PartialView("PartialCourse");
            }

            // var ddList = db.tb_LessionMaster.ToList().Where(x => x.SubjectId == id).OrderBy(x => x.DisplayOrder)  ;

            var ddList = db.tb_LessionMaster.Where(x => x.SubjectId == id).OrderBy(x => x.DisplayOrder).Select(x => new { x.LessionId, x.LessionHeading }).ToList();

            string LevelList = "";

            Int16 unitno = 1;
            int zero = 0;
            foreach (var item in ddList)
            {
                LevelList += " <li> <button  type='submit' class='displayLesson'  name='buttonName' value='" + item.LessionId + "' > " + item.LessionHeading + " </button> </li>";
                unitno += 1;
                // var ddLista = db.tb_LessionMasterSlides.ToList().Where(x => x.LessionId == item.LessionId).OrderBy(x => x.DispOrder);
                var ddLista = db.tb_LessionMasterSlides.Where(x => x.LessionId == item.LessionId).OrderBy(x => x.DispOrder).Select(x => new { x.LessionId });
                foreach (var item2 in ddLista)
                {
                    if (zero == 0)
                    {
                        zero = 1;
                        var gmodel = db.tb_LessionMaster.ToList().Where(x => x.LessionId == item2.LessionId).Single();
                        ViewData["startbuttonNew"] = "<a href='/SlideShowNew/Index/" + item2.LessionId + "' style='border: medium none; background-color: #e8424e; border-radius: 5px; color: #fff; font-size: 16px; font-weight: 600; padding:10px 20px;  margin:0px;'>Start</a>";

                        ViewData["heading"] = gmodel.LessionHeading;
                        ViewData["slidedesc"] = gmodel.SlideDescription;
                        ViewData["graphics"] = "<img src='../../uploads/" + gmodel.imagePath + "' border='0'   alt='Delete' style='width:420px;'/>";

                    }
                }
            }
            ViewData["UnitList"] = LevelList;

            //var csubTb = from m in db.tb_SubjectMaster where m.SubjectId == id select m;

            var csubTb = from m in db.tb_SubjectMaster where m.SubjectId == id select new { m.SubjectId };



            if (csubTb.Count() > 0)
            {
                var classTb2 = (from m in db.tb_SubjectMaster where m.SubjectId == id select m).Single();
                ViewData["subname"] = classTb2.SubjectName;
            }



            //if (Session["subjectid"] != null)
            //{
            //    Int32 clid = Convert.ToInt32(Session["subjectid"]);
            //    var ddListClass = db.tb_ClassMaster.ToList().Where(x => x.SubjectId == clid).OrderBy(x => x.DisplayOrder);
            //    string classList = "";
            //    foreach (var item2 in ddListClass)
            //    {
            //        classList += "<li><a href='/mytraining/courseSubject/" + item2.ClassesId + "' ><i class='fa fa-book'></i>" + item2.ClassName + "</a></li>";
            //    }
            //    ViewData["classList"] = classList;
            //}

            return View();
        }

        [HttpPost]
        public ActionResult CourseSubject(int id, string buttonName, FormCollection frm)
        {
            return View();
        }

    }
}