using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using ReportManagement;
using System.Web.Mvc;
using OLProject.Models;

namespace OLProject.Controllers
{
    public class ReportsExamController : Controller
    {
        //
        // GET: /Subject/

        kzonlineEntities db = new kzonlineEntities();
        public ActionResult SubjectList(Int32 id)
        {
            var ddList = db.tb_UserMaster.ToList().Where(x => x.UserId == id).Single();
            string strQuery = "";
            strQuery += "select e.subjectid id,e.subjectname name from tb_ProductLinkedClass a,tb_productmaster b,tb_productclassmaster c,tb_classmaster d ";
            strQuery += ",tb_subjectmaster e where b.publish=1 and  a.productid=b.productid and  c.autoid=a.classid  and d.classid=c.autoid ";
            strQuery += "and d.subjectid=e.subjectid and e.publish=1 and a.classid=" + Convert.ToInt32(ddList.ClassId) + " and b.productid=" + Convert.ToInt32(ddList.PackageId);


            IEnumerable<LessonInformation> results = db.Database.SqlQuery<LessonInformation>(strQuery);
            var selectList = new SelectList(results, "ID", "Name");
            ViewData["Subjectlist"] = selectList;
            return View();
        }

        public ActionResult ClassList(Int32 id)
        {
            Int32 UserId = Convert.ToInt32(Request.QueryString["StudentID"]);
            var ddList = db.tb_UserMaster.ToList().Where(x => x.UserId == UserId).Single();
            string strQuery = "";
            strQuery += "select d.classesid id,c.classname name from tb_ProductLinkedClass a,tb_productmaster b,tb_productclassmaster c,tb_classmaster d ";
            strQuery += ",tb_subjectmaster e where b.publish=1 and  a.productid=b.productid and  c.autoid=a.classid  and d.classid=c.autoid ";
            strQuery += "and d.subjectid=e.subjectid and e.publish=1 and a.classid=" + Convert.ToInt32(ddList.ClassId) + " and b.productid=" + Convert.ToInt32(ddList.PackageId);

            IEnumerable<LessonInformation> results = db.Database.SqlQuery<LessonInformation>(strQuery);
            var selectList = new SelectList(results, "ID", "Name");
            ViewData["Classlist"] = selectList;
            return View();
        }

        public void setViews()
        {
            Int32 userid = Convert.ToInt32(Session["pmsuserid"]);


            if (Convert.ToInt32(Session["cateid"]) == 9)
            {
                var ddList1 = (from c in db.tb_UserMaster
                               where c.UserId == userid
                               select new { ID = c.UserId, Name = c.UserName }).OrderBy(x => x.Name);

                var selectList1 = new SelectList(ddList1, "ID", "Name");
                ViewData["userList"] = selectList1;
            }
            else
            {
                var ddList1 = (from c in db.tb_UserMaster
                               where c.ParentId == userid
                               select new { ID = c.UserId, Name = c.UserName }).OrderBy(x => x.Name);

                var selectList1 = new SelectList(ddList1, "ID", "Name");
                ViewData["userList"] = selectList1;
            }
        }
        public ActionResult MasterPage()
        {
            setViews();
            return View();
        }

        public ActionResult MasterPage1()
        {
            setViews();

            return View();
        }


        public ActionResult Detail(Int32 id)
        {

            var model = (from m in db.tb_ExamResults
                         from t in db.tb_QuizDetail
                         where m.QuestionId == t.AutoId && m.TestId == id
                         select new QuizInformation
                         {
                             Decription = t.Decription,
                             Ans1 = t.Ans1,
                             Ans2 = t.Ans2,
                             Ans3 = t.Ans3,
                             Ans4 = t.Ans4,
                             UserAns = (Int32)m.Answer,
                             QuesTypeId = (Int32)t.QuesTypeId,
                             Check1 = (Boolean)t.Check1,
                             Check2 = (Boolean)t.Check2,
                             Check3 = (Boolean)t.Check3,
                             Check4 = (Boolean)t.Check4,
                             ComputerAns = (Int32)m.ActualAns

                         });

            var model1 = db.tb_ExamMaster.ToList().Where(m => m.Autoid == id).Single();
            ViewData["SubjectName"] = clsCommon.getSubjectName(Convert.ToInt32(model1.SubjectId));
            ViewData["ClassName"] = clsCommon.getClassNameProduct(Convert.ToInt32(model1.ClassID));
            ViewData["UnitName"] = clsCommon.getUnitName(Convert.ToInt32(model1.UnitID));
            ViewData["StudentName"] = clsCommon.getUserName1(Convert.ToInt32(model1.UserID));
            ViewData["StarString"] = "You have achieved " + model1.StarRating + " Star !!!";
            ViewData["Total"] = model1.TotalQuestion;
            ViewData["TotalCorrect"] = model1.TotalCorrect;
            ViewData["TotalWrong"] = model1.TotalWrong;

            return View(model);
            //return ViewPdf("Lesson report", "Detail1", model);
            // return RedirectToAction("index", "pdfreports", new { id = id });

        }
        public ActionResult TodayReport()
        {
            Int32 userid = Convert.ToInt32(Request.QueryString["userid"]);
            Int32 subjectid = Convert.ToInt32(Request.QueryString["subjectid"]);
            Int32 reportid = Convert.ToInt32(Request.QueryString["reportid"]);
            Int32 classid = Convert.ToInt32(Request.QueryString["classid"]);

            var model = (from m in db.tb_ExamMaster
                         from t in db.tb_ClassMaster
                         from p in db.tb_UnitMaster
                         from k in db.tb_SubjectMaster
                         where m.ClassID == t.ClassesId && m.UnitID == p.UnitId && k.SubjectId == m.SubjectId
                         && m.StudentId == userid
                         select new
                         {
                             TotalQuestion = m.TotalQuestion,
                             TestID = m.Autoid,
                             TotalCorrect = m.TotalCorrect,
                             SystemDate = m.SystemDate,
                             ClassName = t.ClassName,
                             UnitName = p.UnitName,
                             classid = m.ClassID,
                             SubjectId = m.SubjectId,
                             subjectname = k.SubjectName
                         }).AsQueryable();

            if (subjectid > 0)
            {
                model = model.Where(x => x.SubjectId == subjectid);
            }
            if (classid > 0)
            {
                model = model.Where(x => x.classid == classid);
            }

            if (reportid == 1) //Today
            {
                model = model.Where(x => x.SystemDate.Day == DateTime.Now.Day && x.SystemDate.Month == DateTime.Now.Month
                    && x.SystemDate.Year == DateTime.Now.Year);
            }
            if (reportid == 5) //Yesterday
            {
                model = model.Where(x => x.SystemDate.Day == DateTime.Now.Day - 1 && x.SystemDate.Month == DateTime.Now.Month
                    && x.SystemDate.Year == DateTime.Now.Year);
            }

            //if (reportid == 2) //This week
            //{

            //    model = model.Where(x => clsCommon.GetWeekNumber(Convert.ToDateTime(x.SystemDate)) == clsCommon.GetWeekNumber(DateTime.Now));
            //}
            //if (reportid == 6) //Last Week
            //{
            //    model = model.Where(x => clsCommon.GetWeekNumber(Convert.ToDateTime(x.SystemDate)) == clsCommon.GetWeekNumber(DateTime.Now) - 1);
            //}



            if (reportid == 3) //This month
            {
                model = model.Where(x => x.SystemDate.Month == DateTime.Now.Month
                    && x.SystemDate.Year == DateTime.Now.Year);
            }
            if (reportid == 7) //lastmonth
            {
                model = model.Where(x => x.SystemDate.Month == DateTime.Now.Month - 1
                    && x.SystemDate.Year == DateTime.Now.Year);
            }


            Int32 mcounter = 0;
            string strTable = "";

            foreach (var item in model)
            {
                mcounter += 1;
                Int32 totalper = 0; // Convert.ToInt32((item.TotalCorrect * 100) / item.TotalQuestion);
                if (item.TotalQuestion > 0)
                {
                    totalper = Convert.ToInt32((item.TotalCorrect * 100) / item.TotalQuestion);
                }

                strTable += "<tr  class='even'>";
                strTable += "<td align='left'>" + mcounter + "</td>";
                strTable += "<td align='left'>" + item.SystemDate + "</td>";
                strTable += "<td align='left'>" + item.TestID + "</td>";
                strTable += "<td align='left'>" + totalper + "%</td>";
                strTable += "<td align='left'>" + item.SystemDate.TimeOfDay + "</td>";
                strTable += "<td align='left'>1</td>";
                strTable += "<td align='left'>" + item.subjectname + "</td>";
                strTable += "<td align='left'>" + item.ClassName + "</td>";
                strTable += "<td align='left'>" + item.UnitName + "</td>";
                if (item.TotalQuestion > 0)
                {
                    strTable += "<td align='left'>Complete</td>";
                }
                else
                {
                    strTable += "<td align='left'>In-Complete</td>";
                }
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/reportsExam/Detail/" + item.TestID + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/viewb.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";

                strTable += "</tr>";
            }
            ViewData["data"] = strTable;



            return View();
        }
    
    }
}
