using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OLProject.DAL;
using OLProject.Models;
using System.Data.Entity.Infrastructure;

namespace OLProject.Controllers
{
    public class CourseController : Controller
    {
        // private SchoolContext db = new SchoolContext();

        kzonlineEntities db = new kzonlineEntities();
        public ActionResult coursesemdetail()
        {
            return View();
        }

        public ActionResult course()
        {



            //  Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
            //  var ddList = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();


            //string strQuery = @"select distinct * from tb_subjectmaster where publish=1 and subjectid in (select d.subjectid  from tb_ProductLinkedClass a,";
            //strQuery += "tb_productmaster b,tb_productclassmaster c,tb_classmaster d where b.publish=1 and  a.productid=b.productid and  c.autoid=a.classid  and d.classid=c.autoid  )";

            //if (Convert.ToInt32(Session["cateid"]) == 8 || Convert.ToInt32(Session["cateid"]) == 3)
            //{
            string strQuery = @"select distinct * from tb_subjectmaster where publish=1";
            //}
            IEnumerable<tb_SubjectMaster> results = db.Database.SqlQuery<tb_SubjectMaster>(strQuery);

            results = results.Where(x =>  x.PublishAdmin == true &&  x.SubjectId != 26 && x.SubjectId != 27 && x.SubjectId != 28 && x.SubjectId != 46 && x.SubjectId != 51);

            string strTable = "";
            string strList = "";
            foreach (var item in results)
            {
                //strTable += "<div class='student-profile'>";
                //strTable += "<div class='container'>";
                //strTable += "<div class='row'>";
                //strTable += "<div class='span6'>";
                //strTable += "<h2>" + item.SubjectName + "</h2>";
                //strTable += item.SubjectDesc;
                //strTable += "<a href='/mytraining/courseSemester/" + item.SubjectId + "' class='btn-style'>View Courses</a>";


                //strTable += "</div>";
                //strTable += "<div class='span6'>";
                //strTable += "<img src='~/images/student-profile1.jpg' alt=''>";
                //strTable += "</div>";
                //strTable += "</div>";
                //strTable += "</div>";
                //strTable += "</div>";
                //string price = String.Format("{0:0}", item.Price); 

                //strTable += "  <div class='span3'>";
                //strTable += "<div class='course'>";
                //strTable += "<div class='thumb'>";
                //strTable += "<a href='/course/coursedetail/" + item.SubjectId + "'>     <img alt='' src='../uploads/" + item.SubjectImge + "' style='width:270px;Height:200px;'  /> </a>    ";
                //strTable += "<div class='price'><span>$</span>" + price + "</div>";
                //strTable += "</div>";
                //strTable += "<div class='text'>";
                //strTable += "<div class='header'>";
                //strTable += "<h4>" + item.SubjectName + "</h4>";
                //strTable += "<div class='rating'>  <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>  </div> </div>";
                //strTable += "<div class='course-name'>";
                //strTable += "<p> &nbsp;</p>";

                //int lenth1 = item.SubjectDesc.Length;
                //if (lenth1 > 60)
                //{
                //    strTable += "<p>" + item.SubjectDesc.Substring(0, 60) + "</p>";
                //}
                //else
                //{
                //    strTable += "<p>" + item.SubjectDesc.Substring(0, lenth1) + "</p>";

                //    //html = html.Replace("xx-small", "8pt");
                //    //html = html.Replace("small", "9pt");
                //    //html = html.Replace("x-large", "18pt");
                //    //html = html.Replace("large", "18pt");

                //    //html = html.Replace("medium", "12pt");
                //}

  

                //strTable += "<span>$" + price + "</span>";
                //strTable += "</div>";
                //strTable += "<div class='course-detail-btn'>";
                //strTable += "<a href='/register/signin/?courseid=" + item.SubjectId + "'>Subscribe</a>";
                //strTable += "<a href='/course/coursedetail/" + item.SubjectId + "'>Detail</a>";
                //strTable += "</div>";
                //strTable += "</div>";
                //strTable += "</div>";
                //strTable += "</div>";


                string price = String.Format("{0:0}", item.Price); 


                strTable += "  <div class='span3'>";
                strTable += "  <div class='course'>";
                strTable += "    <div class='thumb'>";
                strTable += "      <a href='#'>";
                strTable += "      <img alt='' src='../uploads/" + item.SubjectImge + "' style='width:100%;Height:200px;'  /> </a>";
                strTable += "     <div class='price'><span>$" + price + " </span></div> ";
                strTable += "   </div>";
                strTable += "    <div class='text'>";
                strTable += "       <div class='header'>";
                strTable += "          <h4>" + item.SubjectName + "</h4>";
                strTable += "     </div>";
                strTable += "  <div class='course-name'>";
                strTable += "            <div class='rating2'>";
                strTable += "        <span1>☆</span1><span1>☆</span1><span1>☆</span1><span1>☆</span1><span1>☆</span1><span>$" + price + "</span>";
                strTable += "     </div>";
                strTable += "   </div>";
                strTable += "  <div class='course-detail-btn'>";
                strTable += "  <a href='/register/signin/?courseid=" + item.SubjectId + "&&cattype=9'>Subscribe</a> ";
               // strTable += "  <a href='/register/signin/?courseid=" + item.SubjectId + "'>Subscribe</a> ";
                strTable += "  <a href='/course/coursedetail/" + item.SubjectId + "'> Detail </a>   ";
                strTable += " </div>";
                strTable += "  </div>";
                strTable += "  </div>";
                strTable += "</div>";


                strList += "<li> <a href='/course/coursedetail/" + item.SubjectId + "'> " + item.SubjectName + "</a></li>";

            }
            ViewData["data"] = strTable;
            ViewBag.strList = strList;

            return View();
        }

        public ActionResult courseSearch()
        {

            string searchString = Request.QueryString["searchString"];

            ViewBag.yoursearch = searchString;

            string strQuery = @"select distinct * from tb_subjectmaster where publish=1 and SubjectName like '%" + searchString + "%'";
            //}
            IEnumerable<tb_SubjectMaster> results = db.Database.SqlQuery<tb_SubjectMaster>(strQuery);
            string strTable = "";
            string strList = "";
            foreach (var item in results)
            {
               


                string price = String.Format("{0:0}", item.Price);


                strTable += "  <div class='span3'>";
                strTable += "  <div class='course'>";
                strTable += "    <div class='thumb'>";
                strTable += "      <a href='#'>";
                strTable += "      <img alt='' src='../uploads/" + item.SubjectImge + "' style='width:100%;Height:200px;'  /> </a>";
                strTable += "     <div class='price'><span>$" + price + " </span></div> ";
                strTable += "   </div>";
                strTable += "    <div class='text'>";
                strTable += "       <div class='header'>";
                strTable += "          <h4>" + item.SubjectName + "</h4>";
                strTable += "     </div>";
                strTable += "  <div class='course-name'>";
                strTable += "            <div class='rating2'>";
                strTable += "        <span1>☆</span1><span1>☆</span1><span1>☆</span1><span1>☆</span1><span1>☆</span1><span>$" + price + "</span>";
                strTable += "     </div>";
                strTable += "   </div>";
                strTable += "  <div class='course-detail-btn'>";
                strTable += "  <a href='/register/signin/?courseid=" + item.SubjectId + " && cattype=9'>Subscribe</a> ";

                strTable += "  <a href='/course/coursedetail/" + item.SubjectId + "'> Detail </a>   ";
                strTable += " </div>";
                strTable += "  </div>";
                strTable += "  </div>";
                strTable += "</div>";


                strList += "<li> <a href='/course/coursedetail/" + item.SubjectId + "'> " + item.SubjectName + "</a></li>";

            }
            ViewData["data"] = strTable;
            ViewBag.strList = strList;

            return View();
        }

        public ActionResult coursedetail(int id)
        {
            var tbCourse = (from m in db.tb_SubjectMaster where m.SubjectId == id select m).Single();

            ViewBag.name = tbCourse.SubjectName;
            ViewBag.desc = tbCourse.SubjectDesc;
            ViewBag.SubjectId = tbCourse.SubjectId;


            //   string strQuery = @"select distinct * from tb_subjectmaster where publish=1";
            return View(tbCourse);
        }

        public ActionResult ourlessons(int id)
        {
            var model = db.tb_SubjectMaster.ToList().Where(x => x.SubjectId == id).Single();


            Session.Add("currentSubject", model.SubjectName);
            var ddList = db.tb_ClassMaster.ToList().Where(x => x.SubjectId == id).OrderBy(x => x.DisplayOrder);
            string LevelList = "";
            foreach (var item in ddList)
            {
                LevelList += "  <li class='span4'>";
                LevelList += "              <div class='thumb'>";
                LevelList += "                 <a href='/mytraining/courseSubject/" + item.ClassesId + "'>   <img alt='' src='../../uploads/" + item.ClassImage + "'   /> </a>";
                LevelList += "           </div>";
                LevelList += "             <div class='text'>";
                LevelList += "               <h4><a href='/mytraining/courseSubject/" + item.ClassesId + "'>" + item.ClassName + "</a></h4>";
                LevelList += "              <p>&nbsp;&nbsp;</p>";
                LevelList += "          </div>";
                LevelList += "      </li>";


              

            }
            var subject = from m in db.tb_SubjectMaster where m.SubjectId == id select m;
            if (subject.Count() > 0)
            {
                var subject2 = (from m in db.tb_SubjectMaster where m.SubjectId == id select m).Single();
                ViewData["subject"] = subject2.SubjectName;
            }
            ViewData["Classlist"] = LevelList;
            return View();
        }

        public ActionResult ourlessonsdetail()
        {
            return View();
        }

        public ActionResult questions()
        {
            return View();
        }


        //// GET: Course
        //public ActionResult Index(int? SelectedDepartment)
        //{
        //    var departments = db.Departments.OrderBy(q => q.Name).ToList();
        //    ViewBag.SelectedDepartment = new SelectList(departments, "DepartmentID", "Name", SelectedDepartment);
        //    int departmentID = SelectedDepartment.GetValueOrDefault();

        //    IQueryable<Course> courses = db.Courses
        //        .Where(c => !SelectedDepartment.HasValue || c.DepartmentID == departmentID)
        //        .OrderBy(d => d.CourseID)
        //        .Include(d => d.Department);
        //    var sql = courses.ToString();
        //    return View(courses.ToList());
        //}

        // GET: Course/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(course);
        //}


        //public ActionResult Create()
        //{
        //    PopulateDepartmentsDropDownList();
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Courses.Add(course);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (RetryLimitExceededException /* dex */)
        //    {
        //        //Log the error (uncomment dex variable name and add a line here to write a log.)
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //    }
        //    PopulateDepartmentsDropDownList(course.DepartmentID);
        //    return View(course);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    PopulateDepartmentsDropDownList(course.DepartmentID);
        //    return View(course);
        //}

        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var courseToUpdate = db.Courses.Find(id);
        //    if (TryUpdateModel(courseToUpdate, "",
        //       new string[] { "Title", "Credits", "DepartmentID" }))
        //    {
        //        try
        //        {
        //            db.SaveChanges();

        //            return RedirectToAction("Index");
        //        }
        //        catch (RetryLimitExceededException /* dex */)
        //        {
        //            //Log the error (uncomment dex variable name and add a line here to write a log.
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //        }
        //    }
        //    PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
        //    return View(courseToUpdate);
        //}

        //private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        //{
        //    var departmentsQuery = from d in db.Departments
        //                           orderby d.Name
        //                           select d;
        //    ViewBag.DepartmentID = new SelectList(departmentsQuery, "DepartmentID", "Name", selectedDepartment);
        //}


        //// GET: Course/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(course);
        //}

        //// POST: Course/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Course course = db.Courses.Find(id);
        //    db.Courses.Remove(course);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult UpdateCourseCredits()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateCourseCredits(int? multiplier)
        {
            if (multiplier != null)
            {
                ViewBag.RowsAffected = db.Database.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
