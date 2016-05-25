using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class ExerciseController : Controller
    {
        //
        // GET: /Subject/
        kzonlineEntities db = new kzonlineEntities();
        // ****************************************************************************
        // ****************************************************************************
        private string getButton(Int32 SlideId, Int32 Buttonid)
        {
            string result = "";
            var model = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == Convert.ToInt32(Buttonid)).Single();
            if (SlideId > 0)
            {
                var model1 = db.tb_QuizDetail.ToList().Where(x => x.AutoId == Convert.ToInt32(SlideId)).Single();
                if (Buttonid == 1 || Buttonid == 2 || Buttonid == 3 || Buttonid == 4 || Buttonid == 8)
                {
                    if (Buttonid == 1 && model1.HelpQuiz != null)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slideshow/popup/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 3 && model1.UsefulTips != null)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slideshow/popup/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 2 && model1.Solution != null)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slideshow/popup/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 4 && model1.Question != null)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slideshow/popup/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 8 && model1.Formulas != null)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slideshow/popup/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else
                    {
                        result = "<span style='float:right;' class='btn-grey' ' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</span>";
                    }
                }
                /**************************************/
                if (Buttonid == 5) //PDF
                {
                    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/feedback/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                }

                if (Buttonid == 13) //TeacherHelp
                {
                    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/teacherhelp/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                }
                if (Buttonid == 9) //PDf
                {
                    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/PDF/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                }
                if (Buttonid == 10) //Print
                {
                    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/Print/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                }
            }
            else
            {
                result = "<span style='float:right;' class='btn-grey' ' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</span>";
            }

            return result;
        }
        public ActionResult popup(Int32 id)
        {
            Int32 buttonid = Convert.ToInt32(Request.QueryString["buttonid"]);
            var model = db.tb_QuizDetail.ToList().Where(x => x.AutoId == id).Single();
            string result = "";

            if (buttonid == 1) { result = model.HelpQuiz; };
            if (buttonid == 2) { result = model.UsefulTips; };
            if (buttonid == 3) { result = model.Solution; };
            if (buttonid == 4) { result = model.Question; };
            if (buttonid == 8) { result = model.Formulas; };

            ViewData["results"] = result;
            return View();
        }
        private void displaybutton(Int32 SlideId)
        {
            String Buttons = "";
            Buttons += getButton(SlideId, 9);
            Buttons += getButton(SlideId, 13);
            Buttons += getButton(SlideId, 10);
            Buttons += getButton(SlideId, 5);
            Buttons += getButton(SlideId, 8);
            Buttons += getButton(SlideId, 4);
            Buttons += getButton(SlideId, 3);
            Buttons += getButton(SlideId, 2);
            Buttons += getButton(SlideId, 1);
            ViewData["buttons"] = Buttons;

        }
        public ActionResult Index()
        {
            var model = db.tb_QuizMaster.ToList().AsQueryable();
            Int32 SlideId = 0;
            Int32 LessonId = 0;
            if (Request.QueryString["SlideId"] != null)
            {
                SlideId = Convert.ToInt32(Request.QueryString["SlideId"]);
                Session.Add("TestSlideId", SlideId);
            }
            if (Request.QueryString["LessonId"] != null)
            {
                LessonId = Convert.ToInt32(Request.QueryString["LessonId"]);
                Session.Add("TestLessonId", LessonId);
            }
            if (SlideId > 0)
            {
                model = model.Where(x => x.SlideId == SlideId);
            }
            if (LessonId > 0)
            {
                model = model.Where(x => x.LessonId == LessonId);
            }
            //*****************************************************************
            string strTable = "";
            foreach (var item in model)
            {
                strTable += "<tr>";
                strTable += "<td valign='top'>" + item.QuizHeading + "</td>";
                strTable += "<td valign='top'>" + item.QuizDesc + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/Exercise/welcome/?testid=" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/test.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
            }
            ViewData["data"] = strTable;
            return View();
        }
        public ActionResult Welcome1()
        {
            Int32 TestId = 0;

            Session.Add("ModuleName0", "Start Quiz");


            Session.Remove("UserTestIdSession");
            if (Request.QueryString["LessonId"] != null)
            {
                TestId = Convert.ToInt32(Request.QueryString["LessonId"]);
                Session.Add("TestLessonId", TestId);
                Session.Add("CurrentTestID", TestId);
            }
            if (Session["TestLessonId"] != null)
            {
                TestId = Convert.ToInt32(Session["TestLessonId"]);
            }

            var model1 = db.tb_LessionMaster.ToList().Where(x => x.LessionId == TestId).Single();

            ViewData["SubjectName"] = clsCommon.getSubjectName(Convert.ToInt32(model1.SubjectId));
            ViewData["ClassName"] = clsCommon.getClassNameProduct(Convert.ToInt32(model1.ClassId));
            ViewData["UnitName"] = clsCommon.getUnitName(Convert.ToInt32(model1.UnitId));

            ViewData["PassingScore"] = model1.PassingScore;

            var model = db.tb_QuizDetail.ToList().Where(x => x.LessonId == TestId);
            Int32 total = model.Count();
            ViewData["Intruductionofpage"] = model1.IntroductionPage;
            ViewData["total"] = total;

            if (total > 0)
            {
                ViewData["startbutton"] = "<a href='/Exercise/Startup/?LessonId=" + TestId + "' id='A2' runat='server' ><img src='../../SiteImages/start.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
            }
            else
            {
                ViewData["startbutton"] = "Quiz Information not found...";
            }
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["Question"] != null)
                {
                    Int32 tot = Convert.ToInt32(Request.Form["Question"]);
                    Session.Add("totq", tot);
                    return RedirectToAction("Startup", "Exercise", new { qid = 0 });
                }

            }
            return View();
        }

        public ActionResult Startup()
        {
            try
            {
                Int32 Duration = 5;
                ViewData["timerTime"] = Duration;
                if (Session["startdate"] != null)
                {
                    DateTime startTime = Convert.ToDateTime(Session["startdate"]);
                    DateTime endTime = DateTime.Now;
                }
                else
                {
                    Session.Add("startdate", DateTime.Now);
                    ViewData["duration"] = Duration;
                }

                Int32 totalRecord = 0;
                if (Session["totq"] != null)
                {
                    totalRecord = Convert.ToInt32(Session["totq"]);
                    ViewData["dispmess"] = " 1 of  " + totalRecord;
                }
                var model = db.tb_QuizDetail.ToList().AsQueryable();
                Int32 LessonId = 0;
                if (Session["TestLessonId"] != null)
                {
                    LessonId = Convert.ToInt32(Session["TestLessonId"]);
                    model = model.Where(x => x.LessonId == LessonId);
                }

                if (Session["UserTestIdSession"] != null)
                {
                    var totalQues = db.tb_QuizResults.ToList().Where(x => x.TestId == Convert.ToInt32(Session["UserTestIdSession"]));
                    Int32 total1 = Convert.ToInt32(totalQues.Count());
                    if (total1 != 0)
                    {
                        ViewData["dispmess"] = (total1 + 1) + "  of  " + totalRecord;
                    }
                    if (total1 + 1 > totalRecord)
                    {
                        return RedirectToAction("Results", "Exercise", new { qid = 0 });
                    }
                }

                if (Session["UserTestIdSession"] == null)
                {
                    Int32 testId = Convert.ToInt32(Session["CurrentTestID"]);
                    // var model1 = db.tb_QuizMaster.ToList().Where(x => x.AutoId == testId).Single();
                    var model2 = db.tb_LessionMaster.ToList().Where(x => x.LessionId == testId).Single();

                    tb_OnlineTestMaster model01 = new tb_OnlineTestMaster();
                    model01.UserID = Convert.ToInt32(Session["pmsuserid"]);
                    model01.StudentId = Convert.ToInt32(Session["pmsuserid"]);

                    model01.SystemDate = DateTime.Now;
                    model01.Ipaddress = Request.ServerVariables["remote_address"].ToString();

                    model01.LessonID = model2.LessionId;
                    model01.SubjectId = model2.SubjectId;
                    model01.ClassID = model2.ClassId;
                    model01.UnitID = model2.UnitId;

                    model01.SubCateId = 0;
                    model01.CateId = 0;

                    model01.Remarks = "";
                    model01.TotalCorrect = 0;
                    model01.TotalQuestion = 0;
                    model01.TotalWrong = 0;
                    db.tb_OnlineTestMaster.Add(model01);
                    db.SaveChanges();
                    Session.Add("UserTestIdSession", model01.TestID);

                    Int32 testId1 = Convert.ToInt32(model01.TestID);
                    //Storing Unit information against all the lesson
                    var vmodel = db.tb_UserUnitInformation.ToList().Where(x => x.UnitId == model2.UnitId && x.StudentId == Convert.ToInt32(Session["pmsuserid"]));
                    if (vmodel.Count() == 0)
                    {
                        var model21 = db.tb_LessionMaster.ToList().Where(x => x.UnitId == model2.UnitId);

                        tb_UserUnitInformation vmodel1 = new tb_UserUnitInformation();
                        vmodel1.UserId = Convert.ToInt32(Session["pmsuserid"]);
                        vmodel1.StudentId = Convert.ToInt32(Session["pmsuserid"]);

                        vmodel1.SubjectId = model2.SubjectId;
                        vmodel1.ClassId = model2.ClassId;
                        vmodel1.UnitId = model2.UnitId;

                        vmodel1.TotalRight = 0; //For final test
                        vmodel1.TotalQuestion = 0; //form final test
                        vmodel1.TotalWrong = 0; //For final Test

                        vmodel1.TestRefId = 0; //For final test
                        vmodel1.TestDate = DateTime.Now;//for final Test
                        vmodel1.FinalTestStatus = false; //for final test

                        vmodel1.SystemDate = DateTime.Now;
                        vmodel1.LastUpdated = DateTime.Now;

                        vmodel1.TotalTested = 0;

                        vmodel1.TotalLesson = Convert.ToInt32(model21.Count());
                        vmodel1.UnitStatus = false;

                        vmodel1.IpAddress = Request.ServerVariables["remote_address"].ToString();
                        db.tb_UserUnitInformation.Add(vmodel1);
                        db.SaveChanges();
                    }

                }

                Int32 TestId = 0;

                if (Request.QueryString["TestId"] != null)
                {
                    TestId = Convert.ToInt32(Request.QueryString["TestId"]);

                }
                string strQuery = "";

                //if (SlideId > 0)
                //{
                //    strQuery = @"select top 1 b.* from tb_QuizMaster a,tb_quizdetail b where a.autoid=b.refid and a.slideid=" + SlideId;
                //    strQuery += " and  b.autoid not in (select questionid from  tb_QuizRESULTs where testid=" + Convert.ToInt32(Session["UserTestIdSession"]) + " and  userid=" + Convert.ToInt32(Session["pmsuserid"]) + ")  order by newid()";
                //}
                if (LessonId > 0)
                {
                    strQuery = @"select top 1 a.* from tb_quizdetail a where a.lessonid=" + LessonId;
                    strQuery += " and  a.autoid not in (select questionid from  tb_QuizRESULTs where testid=" + Convert.ToInt32(Session["UserTestIdSession"]) + " and  userid=" + Convert.ToInt32(Session["pmsuserid"]) + ")  order by newid()";
                }


                //IEnumerable<tb_QuizDetail> results = db.ExecuteStoreQuery<tb_QuizDetail>(strQuery);
                //IEnumerable<tb_QuizDetail> results1 = db.ExecuteStoreQuery<tb_QuizDetail>(strQuery);
                //IEnumerable<tb_QuizDetail> results2 = db.ExecuteStoreQuery<tb_QuizDetail>(strQuery);

                IEnumerable<tb_QuizDetail> results = db.Database.SqlQuery<tb_QuizDetail>(strQuery);
                IEnumerable<tb_QuizDetail> results1 = db.Database.SqlQuery<tb_QuizDetail>(strQuery);
                IEnumerable<tb_QuizDetail> results2 = db.Database.SqlQuery<tb_QuizDetail>(strQuery);



                if (results1.Count() == 0)
                {
                    return RedirectToAction("Results", "Exercise", new { qid = 0 });
                }
                else
                {
                    foreach (var item in results2)
                    {
                        displaybutton(item.AutoId);

                    }
                }
                return View(results);
            }
            catch (Exception ce)
            {

                return View();
            }



        }
        public ActionResult StartupResult()
        {
            try
            {
                Int32 ResultId = 0;
                if (Request.QueryString["ResultId"] != null)
                {
                    ResultId = Convert.ToInt32(Request.QueryString["ResultId"]);
                }
                var model = db.tb_QuizResults.ToList().Where(x => x.AutoId == ResultId).Single();
                var model1 = db.tb_QuizDetail.ToList().Where(x => x.AutoId == model.QuestionId).Single();

                string strTables = "";
                string strTables1 = "";

                //string okIcon = "ok.png";
                //string okIcon1 = "wrong.png";
                //string check1 = "wrong.png";
                //string check2 = "wrong.png";
                //string check3 = "wrong.png";
                //string check4 = "wrong.png";




                string okIcon = "<label class='green'><i class='fa fa-check fa-lg'></i>";
                string okIcon1 = " <label class='red'><i class='fa fa-times fa-lg'></i>";
                string check1 = " <label class='red'><i class='fa fa-times fa-lg'></i>";
                string check2 = " <label class='red'><i class='fa fa-times fa-lg'></i>";
                string check3 = " <label class='red'><i class='fa fa-times fa-lg'></i>";
                string check4 = " <label class='red'><i class='fa fa-times fa-lg'></i>";

                //string check1 = "wrong.png";
                //string check2 = "wrong.png";
                //string check3 = "wrong.png";
                //string check4 = "wrong.png";

                if (model1.QuesTypeId != 5)
                {
                  //  strTables += "<tr><td colspan='2'> <h3>Question:" + model1.Decription + "</h3></td></tr>";
                    strTables += " <h3>Question:" + model1.Decription + "</h3>";

                }
                else
                {
                   // strTables += "<tr><td colspan='2'> <img alt='Image' width='100px' height='50px' src='../../uploads/" + model1.Decription + "' /></td></tr>";
                    strTables += "<img alt='Image' width='100px' height='50px' src='../../uploads/" + model1.Decription + "' />";

                }

                if (model.Answer == model.ActualAns)
                {
                   // strTables += "<tr><td colspan='2'> <embed src='../../sounds/right.mp3' loop='false' autoplay='true' width='0' height='0'  ></embed></audio></td></tr>";
                    strTables += "<embed src='../../sounds/right.mp3' loop='false' autoplay='true' width='0' height='0'  ><embed>";

                   // strTables1 = "<tr><td colspan='2'><img alt='Image' width='181px' height='40px' src='../../siteimages/right1.png' /></td></tr>";
                    strTables1 = "<label><i class='fa fa-thumbs-o-up fa-lg green'></i> Your answer is correct</label>";

                }
                else
                {
                   // strTables += "<tr><td colspan='2'> <embed src='../../sounds/wrong.mp3' loop='false' autoplay='true' width='0' height='0'  ></embed></audio></td></tr>";
                    strTables += "<embed src='../../sounds/wrong.mp3' loop='false' autoplay='true' width='0' height='0'  >";


                  //  strTables1 = "<tr><td colspan='2'><img alt='Image' width='181px' height='40px' src='../../siteimages/wrong1.png' /></td></tr>";
                    strTables1 = "<label><i class='fa fa-thumbs-o-down fa-lg green'></i> Wrong Answer, Try Next Time</label>";

                }

                if (model1.QuesTypeId == 1 || model1.QuesTypeId == 2 || model1.QuesTypeId == 5)
                {
                    if (model1.Check1 == true) { check1 = okIcon; }
                    if (model1.Check2 == true) { check2 = okIcon; }
                    if (model1.Check3 == true) { check3 = okIcon; }
                    if (model1.Check4 == true) { check4 = okIcon; }
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check1 + "' /></td><td>" + model1.Ans1 + "</td></tr>";
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check2 + "' /></td><td>" + model1.Ans2 + "</td></tr>";
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check3 + "' /></td><td>" + model1.Ans3 + "</td></tr>";
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check4 + "' /></td><td>" + model1.Ans4 + "</td></tr>";

                    //                    <label class="red"><i class="fa fa-times fa-lg"></i> Purpose and aim of the project </lable>
                    //<label class="red"><i class="fa fa-times fa-lg"></i> Resources available both human and material</lable>
                    //<label class="red"><i class="fa fa-times fa-lg"></i> Costing, human and time constraints</lable>
                    //<label class="green"><i class="fa fa-check fa-lg"></i> All</lable>

                    strTables += check1 + model1.Ans1 + "</label>";
                    strTables += check2 + model1.Ans2 + "</label>";
                    strTables += check3 + model1.Ans3 + "</label>";
                    strTables += check4 + model1.Ans4 + "</label>";

                }



                if (model1.QuesTypeId == 3)
                {
                    if (model1.Check1 == true) { check1 = okIcon; }
                    if (model1.Check2 == true) { check2 = okIcon; }
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check1 + "' /></td><td>" + model1.Ans1 + "</td></tr>";
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check2 + "' /></td><td>" + model1.Ans2 + "</td></tr>";
                    strTables += check1 + model1.Ans1 + "</label>";
                    strTables += check2 + model1.Ans2 + "</label>";
                }



                if (model1.QuesTypeId == 4)
                {
                    if (model1.Check1 == true) { check1 = okIcon; }
                    if (model1.Check2 == true) { check2 = okIcon; }
                    if (model1.Check3 == true) { check3 = okIcon; }
                    if (model1.Check4 == true) { check4 = okIcon; }
                    
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check1 + "' /></td><td><img alt='Image' width='100px' height='75px' src='../../uploads/" + model1.Ans1 + "' /></td></tr>";
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check2 + "' /></td><td><img alt='Image' width='100px' height='75px' src='../../uploads/" + model1.Ans2 + "' /></td></tr>";
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check3 + "' /></td><td><img alt='Image' width='100px' height='75px' src='../../uploads/" + model1.Ans3 + "' /></td></tr>";
                    //strTables += "<tr><td><img alt='Image' width='32px' height='32px' src='../../siteimages/" + check4 + "' /></td><td><img alt='Image' width='100px' height='75px' src='../../uploads/" + model1.Ans4 + "' /></td></tr>";
                    
                    strTables += check1 + "<img alt='Image' width='100px' height='75px' src='../../uploads/" + model1.Ans1 + "' />"  + "</label>";
                    strTables += check2 + "<img alt='Image' width='100px' height='75px' src='../../uploads/" + model1.Ans2 + "' />" + "</label>";
                    strTables += check3 + "<img alt='Image' width='100px' height='75px' src='../../uploads/" + model1.Ans3 + "' />" + "</label>";
                    strTables += check4 + "<img alt='Image' width='100px' height='75px' src='../../uploads/" + model1.Ans4 + "' />" + "</label>";
                }


                strTables += strTables1;

                ViewData["data"] = strTables;

            }
            catch (Exception ce)
            {


            }

            return View();

        }
        [HttpPost]
        public ActionResult Startup(tb_QuizDetail model)
        {


            tb_QuizResults model2 = new tb_QuizResults();
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
            model2.SystemDate = DateTime.Now;
            model2.TestId = Convert.ToInt32(Session["UserTestIdSession"]);
            db.tb_QuizResults.Add(model2);
            db.SaveChanges();

            return RedirectToAction("StartupResult", "Exercise", new { ResultId = model2.AutoId });

        }
        public ActionResult Results()
        {
            string clearedStatus = "Un-Successfull";
            var model = db.tb_QuizResults.ToList().Where(m => m.TestId == Convert.ToInt32(Session["UserTestIdSession"]));
            var model1 = db.tb_QuizResults.ToList().Where(m => m.ActualAns == m.Answer && m.TestId == Convert.ToInt32(Session["UserTestIdSession"]));
            var model2 = db.tb_QuizResults.ToList().Where(m => m.ActualAns != m.Answer && m.TestId == Convert.ToInt32(Session["UserTestIdSession"]));

            if (Session["UserTestIdSession"] != null)
            {
                Int32 totalc = 0;
                Int32 TestId = Convert.ToInt32(Session["UserTestIdSession"]);

                totalc = Convert.ToInt32((Convert.ToInt32(model1.Count()) * 100) / Convert.ToInt32(model.Count()));

                ViewData["totalScrore"] = totalc.ToString() + "%";
                ViewData["ok"] = model1.Count();
                ViewData["wrong"] = model2.Count();
                var test = db.tb_OnlineTestMaster.ToList().Where(x => x.TestID == Convert.ToInt32(Session["UserTestIdSession"])).Single();

                test.TotalQuestion = model.Count();
                test.TotalCorrect = model1.Count();
                test.TotalWrong = model2.Count();
                test.EndDate = DateTime.Now;
                ViewData["DateOfComplete"] = DateTime.Now;

                ViewData["total"] = model.Count();
                ViewData["totalcorrect"] = model1.Count();
                ViewData["totalWrong"] = model2.Count();
                ViewData["subject"] = clsCommon.getSubjectName(Convert.ToInt32(test.SubjectId));
                ViewData["class"] = clsCommon.getClassNameProduct(Convert.ToInt32(test.ClassID)); ;
                ViewData["UnitName"] = clsCommon.getUnitName(Convert.ToInt32(test.UnitID)); ;

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
                clearedStatus = "<img src='http://www.goonlineschool.com/uploads/" + vmodel5.ImagePath + "' width='100px' height='20px'/>";

                var starInfor = db.tb_StarInformation.ToList().Where(x => x.StarScore == Bricks);
                if (starInfor.Count() > 0)
                {
                    var starInfor1 = db.tb_StarInformation.ToList().Where(x => x.StarScore == Bricks).Single();
                    ViewData["mp3"] = "<audio autoplay='true' controls><source src='../../uploads/" + starInfor1.Mp3Path + "' type='audio/mpeg'> Your browser does not support this audio format.</audio>";
                    ViewData["graphics"] = "<img alt='Image' style='width:100%;' class='img-responsive' src='http://www.goonlineschool.com/uploads/" + starInfor1.ImagePath + "' />";
                }
                ViewData["StarString"] = "You have achieved " + Bricks + " Star !!!";


                test.ExamId = 0;
                test.StarRating = Bricks;
                db.SaveChanges();

                if (Bricks == 5)
                {
                    var vmodel = db.tb_UserUnitInformation.ToList().Where(x => x.UnitId == test.UnitID && x.StudentId == Convert.ToInt32(Session["pmsuserid"]));
                    if (vmodel.Count() > 0)
                    {
                        var LessonTestDone = db.tb_LessonTestDone.ToList().Where(x => x.LessonId == test.LessonID && x.StudentId == Convert.ToInt32(Session["pmsuserid"]));
                        if (LessonTestDone.Count() == 0)
                        {
                            var vmodel1 = db.tb_UserUnitInformation.ToList().Where(x => x.UnitId == test.UnitID && x.StudentId == Convert.ToInt32(Session["pmsuserid"])).Single();
                            vmodel1.TotalTested += 1;
                            db.SaveChanges();

                            string UpdateQuery = "update tb_UserUnitInformation set UnitStatus=1 where totallesson-totaltested=0 and unitid=" + test.UnitID + " and StudentId =" + Convert.ToInt32(Session["pmsuserid"]);
                            db.Database.ExecuteSqlCommand(UpdateQuery);

                            tb_LessonTestDone tb = new tb_LessonTestDone();
                            tb.LessonId = test.LessonID;
                            tb.UserId = Convert.ToInt32(Session["pmsuserid"]);
                            tb.StudentId = Convert.ToInt32(Session["pmsuserid"]);
                            tb.SystemDate = DateTime.Now;
                            tb.Ipaddress = Request.ServerVariables["remote_address"].ToString();
                            tb.TestRefId = test.TestID;
                            db.tb_LessonTestDone.Add(tb);
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    ViewData["startSlideShow"] = "<a href='/SlideShow/IntroLesson/" + test.LessonID + "' id='A2' runat='server' ><img src='../../SiteImages/start.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                    ViewData["startQuiz"] = "<a href='/Exercise/Welcome1/?LessonId=" + test.LessonID + "' id='A2' runat='server' ><img src='../../SiteImages/start.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                }

                //Send ing result of quiz to parents
                //Send ing result of quiz to parents
                Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
                var modelUser = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();

                //Student
                //Int32 StudentId = Convert.ToInt32(Session["pmsuserid"]);

                if (Convert.ToInt32(Session["cateid"]) == 9)
                {
                    var modelUser1 = db.tb_UserMaster.ToList().Where(x => x.UserId == modelUser.ParentId).Single();
                    var item1 = (from m in db.tb_emailsDescription
                                 where m.Autoid == 8
                                 select m).Single();
                    string desc = "";
                    desc = item1.Description;
                    String ProductDetail = "";
                    ProductDetail += "<br /> Subject : <b>" + clsCommon.getSubjectName(Convert.ToInt32(test.SubjectId)) + "</b>";
                    ProductDetail += "<br /> Class : <b>" + clsCommon.getClassNameProduct(Convert.ToInt32(test.ClassID)) + "</b>";
                    ProductDetail += "<br /> Unit: <b>" + clsCommon.getUnitName(Convert.ToInt32(test.UnitID)) + "</b>";
                    ProductDetail += "<br /> Lesson: <b>" + clsCommon.getLessonName(Convert.ToInt32(test.LessonID)) + "</b>";

                    ProductDetail += "<br /> Quiz Status</b>";
                    ProductDetail += "<br /> Time :</b>" + test.SystemDate;
                    ProductDetail += "<br /> Total Quesion: <b>" + model.Count() + "</b>";
                    ProductDetail += "<br /> Total correct: " + model1.Count();
                    ProductDetail += "<br /> Total Wrong: " + model2.Count(); ;
                    ProductDetail += "<br />  % : " + scoredname;
                    ProductDetail += "<br />  Result: " + clearedStatus;
                    ProductDetail += "<br />  Solved Paper: " + SetReportForParent(test.TestID);

                    desc = desc.Replace("UserName", modelUser.ProfileName);
                    desc = desc.Replace("QuizDetail", ProductDetail);

                    emailSystem.sendNewFormat(modelUser.EmailID, item1.EmailSubject, desc);
                    emailSystem.sendNewFormat(modelUser1.EmailID, item1.EmailSubject, desc);



                    //**************************************************************************************
                    //If Unit is done
                    var item2 = (from m in db.tb_emailsDescription
                                 where m.Autoid == 11
                                 select m).Single();
                    desc = "";
                    desc = item2.Description;
                    ProductDetail = "";
                    ProductDetail += "<br /> Subject : <b>" + clsCommon.getSubjectName(Convert.ToInt32(test.SubjectId)) + "</b>";
                    ProductDetail += "<br /> Class : <b>" + clsCommon.getClassNameProduct(Convert.ToInt32(test.ClassID)) + "</b>";
                    ProductDetail += "<br /> Unit: <b>" + clsCommon.getUnitName(Convert.ToInt32(test.UnitID)) + "</b>";
                    ProductDetail += "<br /> Lesson: <b>" + clsCommon.getLessonName(Convert.ToInt32(test.LessonID)) + "</b>";

                    desc = desc.Replace("UserName", modelUser.ProfileName);
                    desc = desc.Replace("Detail", ProductDetail);
                    emailSystem.sendNewFormat(modelUser.EmailID, item2.EmailSubject, desc);
                    //Session["cattestid"];d


                    //**************************************************************************************
                    ////If Subject is done
                    //var item3 = (from m in db.tb_emailsDescription
                    //             where m.Autoid == 12
                    //             select m).Single();
                    //desc = "";
                    //desc = item3.Description;
                    //ProductDetail = "";
                    //ProductDetail += "<br /> Subject : <b>" + clsCommon.getSubjectName(Convert.ToInt32(test.SubjectId)) + "</b>";
                    //ProductDetail += "<br /> Class : <b>" + clsCommon.getClassNameProduct(Convert.ToInt32(test.ClassID)) + "</b>";
                    //ProductDetail += "<br /> Unit: <b>" + clsCommon.getUnitName(Convert.ToInt32(test.UnitID)) + "</b>";
                    //ProductDetail += "<br /> Lesson: <b>" + clsCommon.getLessonName(Convert.ToInt32(test.LessonID)) + "</b>";

                    //desc = desc.Replace("UserName", modelUser.ProfileName);
                    //desc = desc.Replace("Detail", ProductDetail);
                    //emailSystem.sendNewFormat(modelUser.EmailID, item2.EmailSubject, desc);
                    ////Session["cattestid"];d



                    //Appreciation Email
                    if (Convert.ToInt32(ViewData["total"]) >= 90)
                    {
                        var item31 = (from m in db.tb_emailsDescription
                                      where m.Autoid == 14
                                      select m).Single();
                        desc = "";
                        desc = item31.Description;
                        ProductDetail = "";
                        ProductDetail += "<br /> Subject : <b>" + clsCommon.getSubjectName(Convert.ToInt32(test.SubjectId)) + "</b>";
                        ProductDetail += "<br /> Class : <b>" + clsCommon.getClassNameProduct(Convert.ToInt32(test.ClassID)) + "</b>";
                        ProductDetail += "<br /> Unit: <b>" + clsCommon.getUnitName(Convert.ToInt32(test.UnitID)) + "</b>";
                        ProductDetail += "<br /> Lesson: <b>" + clsCommon.getLessonName(Convert.ToInt32(test.LessonID)) + "</b>";

                        ProductDetail += "<br /> Quiz Status</b>";
                        ProductDetail += "<br /> Time :</b>" + test.SystemDate;
                        ProductDetail += "<br /> Total Quesion: <b>" + model.Count() + "</b>";
                        ProductDetail += "<br /> Total correct: " + model1.Count();
                        ProductDetail += "<br /> Total Wrong: " + model2.Count(); ;
                        ProductDetail += "<br />  % : " + scoredname;
                        ProductDetail += "<br />  Result: " + clearedStatus;

                        desc = desc.Replace("UserName", modelUser.ProfileName);
                        desc = desc.Replace("ProductDetail", ProductDetail);

                        emailSystem.sendNewFormat(modelUser.EmailID, item31.EmailSubject, desc);
                    }
                }



                //**************************************************************************************

            }



            ViewData["resultsuser"] = clearedStatus;


            return View();
        }
        public String SetReportForParent(Int32 id)
        {
            string strTables = "<table width='100%'>";
            var model = db.tb_QuizResults.ToList().Where(x => x.TestId == id);
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
                    strTables1 += "<tr><td colspan='2'><img alt='Image' width='181px' height='40px' src='http://www.goonlineschool.com/siteimages/wrong1.png' /></td></tr>";
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
