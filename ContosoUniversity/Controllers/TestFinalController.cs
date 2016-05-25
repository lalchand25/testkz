using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class TestFinalController : Controller
    {
        // GET: /Subject/
        kzonlineEntities db = new kzonlineEntities();

        public ActionResult SelectUser(Int32 id)
        {
            Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
            //var ddList = db.tb_UserMaster.ToList().Where(x => x.ParentId == userid);
            var ddList = db.tb_UserMaster.ToList().Where(x => x.UserId == userid);
            string LevelList = "";
            int cnt = 0;
            foreach (var item in ddList)
            {
                cnt += 1;
                if (cnt % 2 > 0)
                {
                    LevelList += "<li class='bg-grey'><a href='/testfinal/Welcome/?TestId=" + id + "&StudentId=" + item.UserId + "'>" + item.UserName + "</a></li>";
                }
                else
                {
                    LevelList += "<li><a href='/testfinal/Welcome/?TestId=" + id + "&StudentId=" + item.UserId + "'>" + item.UserName + "</a></li>";
                }
            }
            ViewData["userlist"] = LevelList;
            return View();
        }
        public ActionResult Index()
        {
            Int32 UserId = Convert.ToInt32(Session["pmsuserid"]);
     
            var model = (from m in db.tb_QuizTestMaster
                         from b in db.tb_UserUnitInformation
                         where m.SubjectId == b.SubjectId && b.UserId == UserId && b.UnitStatus == true && b.FinalTestStatus == false
                         select m).ToList().AsEnumerable();




            string strQuery = @"select distinct * from tb_subjectmaster where publish=1 and subjectid in (select d.subjectid  from tb_ProductLinkedClass a,";
            strQuery += "tb_productmaster b,tb_productclassmaster c,tb_classmaster d where a.productid=b.productid and  c.autoid=a.classid  and d.classid=c.autoid and b.productid=" + Convert.ToInt32(Session["ProductId"]) + ")";
            IEnumerable<tb_SubjectMaster> results = db.Database.SqlQuery<tb_SubjectMaster>(strQuery);
                      


            //*****************************************************************
            int page = 1;
            if (Request.QueryString["pageno"] != null)
            {
                page = Convert.ToInt32(Request.QueryString["pageno"].ToString());
            }
            Int32 offset = 10;
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
            string pageUrl = "/testFinal/index/";
            string pageLinks = clsCommon.getPageingInformation(page, totalpage, pageUrl);
            ViewData["totalrecords"] = totalRecord;
            ViewData["pageLinks"] = pageLinks;
            model = model.Skip(start).Take(offset);
            //*****************************************************************
            string strTable = "";
            Int32 mcounter = 0;
            foreach (var item in model)
            {
                var model21 = db.tb_QuizTestMasterDetail.ToList().Where(x => x.TestRefId == item.AutoId);
                Int32 avlTotal = model21.Count();

                mcounter += 1;
                if (mcounter % 2 == 0)
                {
                    strTable += "<tr  bgcolor='#DDEEEE'>";
                }
                else
                {
                    strTable += "<tr bgcolor='#EEFFFF'>";
                }
                strTable += "<td valign='top'><img src='../../uploads/" + item.TestImage + "' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
                strTable += "<td valign='top'>" + item.TestHeading + "<br /><b> " + clsCommon.getSubjectName(Convert.ToInt32(item.SubjectId)) + "</b></td>";
               strTable += "<td valign='top'>" + item.totalQues + "</td>";
                strTable += "<td valign='top'>" + item.Duration + "</td>";
                 strTable += "<td valign='top'>" + avlTotal + "</td>";
                 strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/testcreation/detail/?subjectid=" + item.SubjectId + "&testid=" + item.AutoId + "&Classid=" + item.ClassId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/viewb.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
               if (avlTotal >= item.totalQues)
                 {
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/testfinal/welcome/?subjectid=" + item.SubjectId + "&testid=" + item.AutoId + "&Classid=" + item.ClassId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/test.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                //strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/testfinal/selectuser/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/test.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
               }
                 else
                 {
                     strTable += "<td valign='top'>Please enter more Quiz...</td>";
                 }
            }
            ViewData["data"] = strTable;

            return View();
        }
        public ActionResult Welcome()
        {
            Int32 TestId = 0;
            Int32 StudentId = 0;
            Int32 subjectid = 0;

            Session.Remove("UserTestIdSession");

            //if (Request.QueryString["StudentId"] != null)
            //{
            //    StudentId = Convert.ToInt32(Request.QueryString["StudentId"]);
            //    Session.Add("StudentId", StudentId);
            //}

            if (Request.QueryString["TestId"] != null)
            {
                TestId = Convert.ToInt32(Request.QueryString["TestId"]);
                Session.Add("CurrentTestID", TestId);
            }

            if (Request.QueryString["subjectid"] != null)
            {
                subjectid = Convert.ToInt32(Request.QueryString["subjectid"]);
           
            }

            if (Session["CurrentTestID"] != null)
            {
                TestId = Convert.ToInt32(Session["CurrentTestID"]);
            }
            var model = db.tb_QuizTestMaster.ToList().Where(x => x.AutoId == TestId).Single();
            var model1 = db.tb_QuizTestMasterDetail.ToList().Where(x => x.TestRefId == TestId);
         //   var model2 = db.tb_UnitMaster.ToList().Where(x => x.UnitId == model.UnitId).Single();

            ViewData["SubjectName"] = clsCommon.getSubjectName(Convert.ToInt32(subjectid));
          //  ViewData["ClassName"] = clsCommon.getClassNameProduct(Convert.ToInt32(model2.ClassesId));
          //  ViewData["UnitName"] = clsCommon.getUnitName(Convert.ToInt32(model2.UnitId));
            ViewData["PassingScore"] = model.TestPassingScore;
            ViewData["TotalQuestoin"] = model.totalQues;
            ViewData["TimeDuration"] = model.Duration;
            Session.Add("totq", model.totalQues);
            Session.Add("Duration", model.Duration);
            Session.Add("timerTime", Convert.ToInt32(model.Duration) * 1000);
            Session.Add("timerTimeInMint", Convert.ToInt32(model.Duration));
            //Session.Add("timerTime", Convert.ToInt32(1) * 1000);
            Int32 total = model1.Count();

            if (total > 0)
            {
                //ViewData["startbutton"] = "<a href='/testfinal/Startupmain/' id='A2' runat='server' ><img src='../../SiteImages/start.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                ViewData["startbutton"] = "<a href='/testfinal/Startup/'  >    <button class='btn btn-success'  > Start Final Exam </button>            </a>";

                
                //ViewData["startbutton"] = " <button class='btn btn-success'  onclick='/testfinal/Startup/' type='button'  > Start Final Exam </button>";
            }
            else
            {
                ViewData["startbutton"] = "Quiz Information not found...";
            }


            ViewData["total"] = total;
            return View(model);
        }
        public ActionResult Startupmain()
        {



            return View();
        }
        public ActionResult Results()
        {
            string clearedStatus = "";
            var model = db.tb_ExamResults.ToList().Where(m => m.TestId == Convert.ToInt32(Session["UserTestIdSession"]));
            var model1 = db.tb_ExamResults.ToList().Where(m => m.ActualAns == m.Answer && m.TestId == Convert.ToInt32(Session["UserTestIdSession"]));
            var model2 = db.tb_ExamResults.ToList().Where(m => m.ActualAns != m.Answer && m.TestId == Convert.ToInt32(Session["UserTestIdSession"]));

            if (Session["UserTestIdSession"] != null)
            {
                Int32 totalc = 0;
                if (model1.Count() > 0)
                {
                    totalc = Convert.ToInt32((Convert.ToInt32(model1.Count()) * 100) / Convert.ToInt32(model.Count()));
                }
                else
                {
                    totalc = 0;
                }

                ViewData["totalScrore"] = totalc.ToString() + "%";
                ViewData["ok"] = model1.Count();
                ViewData["wrong"] = model2.Count();

                var test = db.tb_ExamMaster.ToList().Where(x => x.Autoid == Convert.ToInt32(Session["UserTestIdSession"])).Single();
                var vmodel2 = db.tb_UserUnitInformation.ToList().Where(x => x.UnitId == test.UnitID && x.UserId == Convert.ToInt32(Session["pmsuserid"]));
                if (vmodel2.Count() > 0)
                {
                    var vmodel1 = db.tb_UserUnitInformation.ToList().Where(x => x.UnitId == test.UnitID && x.UserId == Convert.ToInt32(Session["pmsuserid"])).Single();
                    vmodel1.TotalQuestion = model.Count();
                    vmodel1.TotalRight = model1.Count();
                    vmodel1.TotalWrong = model2.Count();
                    vmodel1.TestDate = DateTime.Now;
                    vmodel1.TestRefId = test.ExamId;
                    vmodel1.FinalTestStatus = true;

                    db.SaveChanges();
                }
                test.TotalQuestion = model.Count();
                test.TotalCorrect = model1.Count();
                test.TotalWrong = model2.Count();
                test.DateOfComplete = DateTime.Now;

                ViewData["DateOfComplete"] = DateTime.Now;

                ViewData["total"] = model.Count();
                ViewData["totalcorrect"] = model1.Count();
                ViewData["totalWrong"] = model2.Count();

                ViewData["subject"] = clsCommon.getSubjectName(Convert.ToInt32(test.SubjectId));
                ViewData["class"] = clsCommon.getClassNameProduct(Convert.ToInt32(test.ClassID));
                ViewData["unitname"] = clsCommon.getUnitName(Convert.ToInt32(test.UnitID));

                //Session["cattestid"];d
                string scoredname = totalc.ToString() + "%";
                Int32 Bricks = 0;


                if (Convert.ToInt32(totalc) >= 0)
                {
                    Bricks = Convert.ToInt32(totalc) / 20;
                }
                Int32 ButtonId = 35;
                if (Bricks == 1) { ButtonId = 30; }
                if (Bricks == 2) { ButtonId = 31; }
                if (Bricks == 3) { ButtonId = 32; }
                if (Bricks == 4) { ButtonId = 33; }
                if (Bricks == 5) { ButtonId = 34; }
                var vmodel5 = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == ButtonId).Single();
                clearedStatus = "<img src='http://www.kzonline.org/uploads/" + vmodel5.ImagePath + "' width='100px' height='20px'/>";

                var starInfor = db.tb_StarInformation.ToList().Where(x => x.StarScore == Bricks);
                if (starInfor.Count() > 0)
                {
                    var starInfor1 = db.tb_StarInformation.ToList().Where(x => x.StarScore == Bricks).Single();
                    ViewData["mp3"] = "<audio autoplay='true' controls><source src='../../uploads/" + starInfor1.Mp3Path + "' type='audio/mpeg'> Your browser does not support this audio format.</audio>";
                    ViewData["graphics"] = "<img alt='Image' style='width:420px;Height:390px;' src='http://www.kzonline.org/uploads/" + starInfor1.ImagePath + "' />";
                }
                ViewData["StarString"] = "You have achieved " + Bricks + " Star !!!";

                test.StarRating = Bricks;

                db.SaveChanges();

                //Send ing result of quiz to parents
                Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
                var modelUser = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();
               // var modelUser1 = db.tb_UserMaster.ToList().Where(x => x.UserId == modelUser.ParentId).Single();

                var item1 = (from m in db.tb_emailsDescription
                             where m.Autoid == 10
                             select m).Single();
                string desc = "";
                desc = item1.Description;
                String ProductDetail = "";
                ProductDetail += "<br /> Course : <b>" + clsCommon.getSubjectName(Convert.ToInt32(test.SubjectId)) + "</b>";
              //  ProductDetail += "<br /> Class : <b>" + clsCommon.getClassNameProduct(Convert.ToInt32(test.ClassID)) + "</b>";
               // ProductDetail += "<br /> Unit: <b>" + clsCommon.getUnitName(Convert.ToInt32(test.UnitID)) + "</b>";

                ProductDetail += "<br /> Exam Status</b>";
                ProductDetail += "<br /> Time :</b>" + test.SystemDate;
                ProductDetail += "<br /> Total Quesion: <b>" + model.Count() + "</b>";
                ProductDetail += "<br /> Total correct: " + model1.Count();
                ProductDetail += "<br /> Total Wrong: " + model2.Count(); ;
                ProductDetail += "<br />  Score % : " + scoredname;
                ProductDetail += "<br />  Result: " + clearedStatus;
                ProductDetail += "<br />  Solved Paper: " + SetReportForParent(test.Autoid);

                desc = desc.Replace("UserName", "Hi " + modelUser.FirstName);
                desc = desc.Replace("Detail", ProductDetail);
                emailSystem.sendNewFormat(modelUser.EmailID, item1.EmailSubject, desc);
              //  emailSystem.sendNewFormat(modelUser1.EmailID, item1.EmailSubject, desc);

                //**************************************************************************************
            }



            ViewData["resultsuser"] = clearedStatus;


            return View();
        }
        public ActionResult Startup()
        {
            Int32 totalRecord = 0;
            Session.Add("startdate", DateTime.Now);
            if (Session["timerTimeInMint"] != null)
            {
                if (Session["enddate"] == null)
                {
                    //    DateTime enddate = Convert.ToDateTime(Session["enddate"]);
                    //    DateTime todaysDateTime = DateTime.Now;
                    //    TimeSpan span = enddate.Subtract(todaysDateTime);
                    //    int totalMins = span.Minutes;
                    //    Session.Add("timerTime", Convert.ToInt32(totalMins) * 1000);
                    //}
                    //else
                    //{
                    Double totalMins = Convert.ToDouble(Session["timerTimeInMint"]);
                    DateTime endDateTime = DateTime.Now.AddMinutes(751 + totalMins);
                    Session.Add("enddate", endDateTime);

                }
            }

            if (Session["totq"] != null)
            {
                totalRecord = Convert.ToInt32(Session["totq"]);
                ViewData["dispmess"] = " 1 of  " + totalRecord;
            }

            if (Session["UserTestIdSession"] != null)
            {
                var totalQues = db.tb_ExamResults.ToList().Where(x => x.TestId == Convert.ToInt32(Session["UserTestIdSession"]));
                Int32 total1 = Convert.ToInt32(totalQues.Count());
                if (total1 != 0)
                {
                    ViewData["dispmess"] = (total1 + 1) + "  of  " + totalRecord;
                }
                if (total1 == totalRecord)
                {
                    return RedirectToAction("Results", "TestFinal", new { qid = 0 });
                }
            }
            if (Session["UserTestIdSession"] == null)
            {
                var model = db.tb_QuizTestMaster.ToList().Where(x => x.AutoId == Convert.ToInt32(Session["CurrentTestID"])).Single();

                tb_ExamMaster model01 = new tb_ExamMaster();
                model01.UserID = Convert.ToInt32(Session["pmsuserid"]);
                model01.StudentId = Convert.ToInt32(Session["pmsuserid"]);

                model01.SystemDate = DateTime.Now;
                model01.Ipaddress = Request.ServerVariables["remote_address"].ToString();

                model01.Remarks = "";
                model01.ExamId = Convert.ToInt32(Session["CurrentTestID"]);
                model01.TotalCorrect = 0;
                model01.TotalQuestion = 0;
                model01.TotalWrong = 0;

                model01.ClassID = model.ClassId;
                model01.SubjectId = model.SubjectId;
                model01.UnitID = model.UnitId;
                model01.LessonID = 0;
                model01.StarRating = 0;
                db.tb_ExamMaster.Add(model01);
                db.SaveChanges();

                Int32 testuserid = model01.Autoid;

                Session.Add("UserTestIdSession", testuserid);
            }

            Int32 TestId = 0;

            if (Request.QueryString["TestId"] != null)
            {
                TestId = Convert.ToInt32(Request.QueryString["TestId"]);

            }


            string strQuery = @"select top 1 b.* from tb_QuizTestMasterDetail a,tb_quizdetail b where a.quizid=b.autoid and a.testrefid= " + Convert.ToInt32(Session["CurrentTestID"]);
            strQuery += " and  b.autoid not in (select questionid from  tb_ExamResults where TestId=" + Convert.ToInt32(Session["UserTestIdSession"]) + " and  StudentId=" + Convert.ToInt32(Session["pmsuserid"]) + ")  order by newid()";
            IEnumerable<tb_QuizDetail> results = db.Database.SqlQuery<tb_QuizDetail>(strQuery);
            IEnumerable<tb_QuizDetail> results1 = db.Database.SqlQuery<tb_QuizDetail>(strQuery);

            if (results1.Count() == 0)
            {
                return RedirectToAction("Results", "TestFinal", new { qid = 0 });

            }

            return View(results);
        }
        [HttpPost]
        public ActionResult Startup(tb_QuizDetail model)
        {
            Int32 clocktime = 0;
            if (Request.Form["clock2"] != null)
            {
                clocktime = Convert.ToInt32(Request.Form["clock2"]);
            }

            tb_ExamResults model2 = new tb_ExamResults();
            model2.check1 = false;
            model2.check2 = false;
            model2.check3 = false;
            model2.check4 = false;
            model2.Answer = 0;
            if (model.QuesTypeId == 1 || model.QuesTypeId == 5 || model.QuesTypeId == 4)
            {
                if (model.ActualAns1 == 1) { model2.check1 = true; }
                if (model.ActualAns1 == 2) { model2.check2 = true; }
                if (model.ActualAns1 == 3) { model2.check3 = true; }
                if (model.ActualAns1 == 4) { model2.check4 = true; }
                model2.Answer = model.ActualAns1;
            }
            if (model.QuesTypeId == 3)
            {
                model2.check1 = false;
                model2.check2 = false;
                model2.check3 = false;
                model2.check4 = false;
                if (model.ActualAns1 == 1) { model2.check1 = true; }
                if (model.ActualAns1 == 2) { model2.check2 = true; }
                model2.Answer = model.ActualAns1;
            }
            if (model.QuesTypeId == 2)
            {
                model2.Answer = 0;
                if (model.Check1 == true) { model2.Answer += 1; model2.check1 = true; }
                if (model.Check2 == true) { model2.Answer += 2; model2.check2 = true; }
                if (model.Check3 == true) { model2.Answer += 3; model2.check3 = true; }
                if (model.Check4 == true) { model2.Answer += 4; model2.check4 = true; }
            }

            model2.ActualAns = model.ActualAns;
            model2.QuestionId = model.AutoId;

            model2.SessionId = Session.SessionID.ToString();
            model2.Check5 = false;
            model2.Check6 = false;
            model2.Userid = Convert.ToInt32(Session["pmsuserid"]);
            model2.StudentId = Convert.ToInt32(Session["pmsuserid"]);
            model2.Student = Convert.ToInt32(Session["pmsuserid"]);
            model2.SystemDate = DateTime.Now;
            model2.TestId = Convert.ToInt32(Session["UserTestIdSession"]);
            db.tb_ExamResults.Add(model2);
            db.SaveChanges();
            if (clocktime == 0)
            {
                return RedirectToAction("Results", "TestFinal", new { qid = 0 });
            }
            return RedirectToAction("Startup", "TestFinal", new { ResultId = model2.AutoId });

        }
        public String SetReportForParent(Int32 id)
        {
            string strTables = "<table width='100%'>";
            var model = db.tb_ExamResults.ToList().Where(x => x.TestId == id);
            foreach (var item in model)
            {
                var model1 = db.tb_QuizDetail.ToList().Where(x => x.AutoId == item.QuestionId).Single();

                string strTables1 = "";
                string okIcon = "ok.png";

                string check1 = "wrong.png";
                string check2 = "wrong.png";
                string check3 = "wrong.png";
                string check4 = "wrong.png";

                if (model1.QuesTypeId != 5)
                {
                    strTables += "<tr><td colspan='2'> <h3>Question:" + model1.Decription + "</h3></td></tr>";
                }
                else
                {
                    strTables += "<tr><td colspan='2'> <img alt='Image' width='100px' height='50px' src='http://www.goonlineschool.com/uploads/" + model1.Decription + "' /></td></tr>";
                }

                if (item.Answer == item.ActualAns)
                {
                    strTables1 += "<tr><td colspan='2'><img alt='Image' width='181px' height='40px' src='http://www.goonlineschool.com/siteimages/right1.png' /></td></tr>";
                }
                else
                {
                    strTables1 = "<tr><td colspan='2'><img alt='Image' width='181px' height='40px' src='http://www.goonlineschool.com/siteimages/wrong1.png' /></td></tr>";
                }

                if (model1.QuesTypeId == 1 || model1.QuesTypeId == 2 || model1.QuesTypeId == 5)
                {
                    if (model1.Check1 == true) { check1 = okIcon; }
                    if (model1.Check2 == true) { check2 = okIcon; }
                    if (model1.Check3 == true) { check3 = okIcon; }
                    if (model1.Check4 == true) { check4 = okIcon; }
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check1 + "' /></td><td>" + model1.Ans1 + "</td></tr>";
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check2 + "' /></td><td>" + model1.Ans2 + "</td></tr>";
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check3 + "' /></td><td>" + model1.Ans3 + "</td></tr>";
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check4 + "' /></td><td>" + model1.Ans4 + "</td></tr>";
                }

                if (model1.QuesTypeId == 3)
                {
                    if (model1.Check1 == true) { check1 = okIcon; }
                    if (model1.Check2 == true) { check2 = okIcon; }
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check1 + "' /></td><td>" + model1.Ans1 + "</td></tr>";
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check2 + "' /></td><td>" + model1.Ans2 + "</td></tr>";
                }
                if (model1.QuesTypeId == 4)
                {
                    if (model1.Check1 == true) { check1 = okIcon; }
                    if (model1.Check2 == true) { check2 = okIcon; }
                    if (model1.Check3 == true) { check3 = okIcon; }
                    if (model1.Check4 == true) { check4 = okIcon; }
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check1 + "' /></td><td><img alt='Image' width='100px' height='75px' src='http://www.goonlineschool.com/uploads/" + model1.Ans1 + "' /></td></tr>";
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check2 + "' /></td><td><img alt='Image' width='100px' height='75px' src='http://www.goonlineschool.com/uploads/" + model1.Ans2 + "' /></td></tr>";
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check3 + "' /></td><td><img alt='Image' width='100px' height='75px' src='http://www.goonlineschool.com/uploads/" + model1.Ans3 + "' /></td></tr>";
                    strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='http://www.goonlineschool.com/siteimages/" + check4 + "' /></td><td><img alt='Image' width='100px' height='75px' src='http://www.goonlineschool.com/uploads/" + model1.Ans4 + "' /></td></tr>";
                }
                strTables += strTables1;
            }
            strTables += "</table>";
            return strTables;
        }
    }
}
