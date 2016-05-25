using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;

namespace GCL_PMS_MVC.Controllers
{
    public class TestCreationController : Controller
    {
        //
        // GET: /Permissions/
        kzonlineEntities db = new kzonlineEntities();
        //Reset 

        public ActionResult CreatePermission()
        {
            Int32 TestId = 0;
            Int32 SubjectId = 0;
            if (Request.Form["TestId"] != null)
            {
                TestId = Convert.ToInt32(Request.Form["TestId"]);
            }
            if (Request.Form["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Request.Form["SubjectId"]);
            }
            var detail = from m in db.tb_QuizTestMasterDetail
                         where  m.TestRefId == TestId
                         select m;

            foreach (var detail1 in detail)
            {
                db.tb_QuizTestMasterDetail.Remove(detail1);
            }
            db.SaveChanges();
            if (Request.Form.GetValues("selectedObjects") != null)
            {
                int total = Convert.ToInt32(Request.Form.GetValues("selectedObjects").Count());
                Int32 QuizId = 0;
                string mystring = "";
                for (int i = 0; i < total; i++)
                {
                    mystring = Request.Form.GetValues("selectedObjects")[i].ToString();
                    QuizId = Convert.ToInt32(mystring);

                    tb_QuizTestMasterDetail sb = new tb_QuizTestMasterDetail();
                    sb.TestRefId = TestId;
                    sb.QuizId = Convert.ToInt32(QuizId);
                    sb.Systemdate = DateTime.Now;
                    db.tb_QuizTestMasterDetail.Add(sb);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("index", new { TestId = TestId, msg = 1, SubjectId = SubjectId });
        }
        //private void GetDetail(Int32 RefId)
        //{
        //    var model = db.tb_QuizDetail.ToList().Where(x => x.RefId == RefId);
        //    Session.Add("QuizRefId", RefId);
        //    String strTable = "";
        //    foreach (var item in model)
        //    {
        //        strTable += "<tr>";
        //        strTable += "<td><img src='../../uploads/1.png' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
        //        if (item.QuesTypeId != 5)
        //        {
        //            strTable += "<td>" + item.Decription + "</td>";
        //        }
        //        else
        //        {
        //            strTable += "<td><img src='../../uploads/" + item.Decription + "' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
        //        }

        //        if (item.QuesTypeId == 1)
        //        {
        //            strTable += "<td>" + item.Ans1 + "</td>";
        //            strTable += "<td>" + item.Ans2 + "</td>";
        //            strTable += "<td>" + item.Ans3 + "</td>";
        //            strTable += "<td>" + item.Ans4 + "</td>";
        //            strTable += "<td align='center'>  " + item.ActualAns + "</td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mc/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mc/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //        }
        //        if (item.QuesTypeId == 2)
        //        {
        //            strTable += "<td>" + item.Ans1 + "</td>";
        //            strTable += "<td>" + item.Ans2 + "</td>";
        //            strTable += "<td>" + item.Ans3 + "</td>";
        //            strTable += "<td>" + item.Ans4 + "</td>";
        //            strTable += "<td align='center'>" + item.ActualAns + "</td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mCOrrect/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mCOrrect/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //        }
        //        if (item.QuesTypeId == 3)
        //        {
        //            strTable += "<td>" + item.Ans1 + "</td>";
        //            strTable += "<td>" + item.Ans2 + "</td>";
        //            strTable += "<td>" + item.Ans3 + "</td>";
        //            strTable += "<td>" + item.Ans4 + "</td>";
        //            strTable += "<td align='center'>" + item.ActualAns + "</td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/truefalse/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/truefalse/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //        }

        //        if (item.QuesTypeId == 4)
        //        {
        //            strTable += "<td><img src='../../uploads/" + item.Ans1 + "' width='32' height='32' alt='img'/></td>";
        //            strTable += "<td><img src='../../uploads/" + item.Ans2 + "' width='32' height='32' alt='img'/></td>";
        //            strTable += "<td><img src='../../uploads/" + item.Ans3 + "' width='32' height='32' alt='img'/></td>";
        //            strTable += "<td><img src='../../uploads/" + item.Ans4 + "' width='32' height='32' alt='img'/></td>";
        //            strTable += "<td align='center'>" + item.ActualAns + "</td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/imgchoice/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/imgchoice/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //        }
        //        if (item.QuesTypeId == 5)
        //        {
        //            strTable += "<td>" + item.Ans1 + "</td>";
        //            strTable += "<td>" + item.Ans2 + "</td>";
        //            strTable += "<td>" + item.Ans3 + "</td>";
        //            strTable += "<td>" + item.Ans4 + "</td>";
        //            strTable += "<td align='center'>  " + item.ActualAns + "</td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mcImage/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //            strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mcImage/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
        //        }

        //        strTable += "</tr>";
        //    }
        //    ViewData["data"] = strTable;

        //}

        public string GetPermission(Int32 Testid, Int32 SubjectId)
        {
            Int32 mcounter = 0;
            Int32 total = 0;
            string strtables = "<table width='100%' border='0'>";
            strtables += "<tr  bgcolor='red'>";
            strtables += "<td width='5%'>Select</td>";
            strtables += "<td width='85%'><b>Description</b></td>";
            strtables += "<td width='10%'>Quesion Type</td>";
            strtables += "</tr>";
           // var model = db.tb_QuizDetail.ToList().Where(x => x.UnitId == UnitId).AsQueryable().OrderBy(x => x.AutoId);
            var model = db.tb_QuizDetail.ToList().Where(x => x.SubjectId == SubjectId).AsQueryable().OrderBy(x => x.AutoId);

            total = model.Count();
            string qname = "";
            string slideName="";
            foreach (var items in model)
            {
                if (mcounter == 0)
                {
                    slideName += "<tr>";
                    slideName += "<td><a href='javascript:OpenPopup1(&#34;/mc/create/?SlideId=" + items.SlideId + "&#34;,&#34;browser1&#34;);' id='A2' runat='server' ><img src='../../SiteImages/add.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                    slideName += "<td><a href='javascript:OpenPopup1(&#34;/mCorrect/create/?SlideId=" + items.SlideId + "&#34;,&#34;browser1&#34;);' id='A21' runat='server' ><img src='../../SiteImages/badd.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                    slideName += "<td><a href='javascript:OpenPopup1(&#34;/truefalse/create/?SlideId=" + items.SlideId + "&#34;,&#34;browser1&#34;);' id='A22' runat='server' ><img src='../../SiteImages/add.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                    slideName += "<td><a href='javascript:OpenPopup1(&#34;/imgchoice/create/?SlideId=" + items.SlideId + "&#34;,&#34;browser1&#34;);' id='A23' runat='server' ><img src='../../SiteImages/badd.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                    slideName += "<td><a href='javascript:OpenPopup1(&#34;/mcImage/create/?SlideId=" + items.SlideId + "&#34;,&#34;browser1&#34;);' id='A24' runat='server' ><img src='../../SiteImages/add.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                    slideName += "</tr>";
                    ViewData["DefaultSlide"] = slideName;
                }
                if (items.QuesTypeId == 1) { qname = "Multiple Choice"; }
                if (items.QuesTypeId == 2) { qname = "Multiple Correct"; }
                if (items.QuesTypeId == 3) { qname = "True False"; }
                if (items.QuesTypeId == 4) { qname = "Image Choice"; }
                if (items.QuesTypeId == 5) { qname = "Image Desc"; }

                var model1 = (from a in db.tb_QuizTestMasterDetail
                              where a.QuizId == items.AutoId
                              select a);
                mcounter += 1;
                if (mcounter % 2 == 0)
                {
                    strtables += "<tr  bgcolor='#DDEEEE'>";
                }
                else
                {
                    strtables += "<tr bgcolor='#EEFFFF'>";
                }
                if (model1.Count() > 0)
                {
                    strtables += "<td width='5%'><input type='checkbox' checked='checked' name='selectedObjects' value='" + items.AutoId + "'></td>";
                }
                else
                {
                    strtables += "<td width='5%'><input type='checkbox' name='selectedObjects' value='" + items.AutoId + "'></td>";
                }
                strtables += "<td width='85%'>" + items.Decription + "</td>";
                strtables += "<td width='10%'>" + qname + "</td>";
                strtables += "</tr>";
            }
            strtables += "</table>";
            string hiddenValues = "<input type='hidden' value='" + Testid + "' name='TestId' />";
//            hiddenValues += "<input type='hidden' value='" + UnitId + "' name='UnitId' />";

                        hiddenValues += "<input type='hidden' value='" + SubjectId + "' name='SubjectId' />";
            

            ViewData["datalist1"] = hiddenValues;

            if (total > 0)
            {
                ViewData["datalist"] = strtables;
            }
            else
            {
                ViewData["datalist11"] = "There is no Questions found......";
            }
            return strtables;

        }

        public ActionResult Index()
        {
            Int32 TestId = 0;
            Int32 UnitId = 0;
            Int32 SubjectId = 0;
            if (Request.QueryString["TestId"] != null)
            {
                TestId = Convert.ToInt32(Request.QueryString["TestId"]);
            }

            //if (Request.QueryString["UnitId"] != null)
            //{
            //    UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
            //}

            if (Request.QueryString["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Request.QueryString["SubjectId"]);
            }

            

            if (Request.QueryString["msg"] != null)
            {
                ViewData["msg"] = "Information Added";
            }

            if (SubjectId > 0)
            {
                GetPermission(TestId, SubjectId);
            }
            else
            {
               ViewData["datalist11"] = "There is no Questions found......";
            }

            return View();

        }

        public ActionResult Detail()
        {
            Int32 SubjectId = 0;
            Int32 TestId = 0;
           // Int32 ClassId = 0;

            if (Request.QueryString["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Request.QueryString["SubjectId"]);

            }
            if (Request.QueryString["TestId"] != null)
            {
                TestId = Convert.ToInt32(Request.QueryString["TestId"]);

            }
            //if (Request.QueryString["ClassId"] != null)
            //{
            //    ClassId = Convert.ToInt32(Request.QueryString["ClassId"]);
            //}
            
            //GetPermission1(TestId, SubjectId);
            var model = db.tb_QuizTestMaster.ToList().Where(x => x.AutoId == TestId).Single();
            return View(model);
        }


        public string GetPermission1(Int32 Testid, Int32 subjectid)
        {
            string strtables = "<table width='100%' border='0'>";
            Int32 icnt = 0;
            var model50 = db.tb_UnitMaster.ToList().Where(x => x.SubjectId == subjectid);
            foreach (var items50 in model50)
            {
                strtables += "<tr><td colspan='4'><h3>" + items50.UnitName + "</h3></td></tr>";
                var model = db.tb_LessionMaster.ToList().Where(x => x.SubjectId == subjectid                            );

                foreach (var items in model)
                {
                    icnt += 1;
                    if (icnt == 1)
                    {
                        strtables += "<tr>";

                    }
                    var model2 = from m in db.tb_LessionMaster
                                 from a in db.tb_QuizTestMasterDetail
                                 where a.TestRefId == Testid && m.LessionId == items.LessionId
                            && m.SubjectId == items.SubjectId
                                 

                                 select new
                                 {
                                     LessonName = m.LessionHeading,
                                     LessionId = m.LessionId
                                 };


                    if (model2.Count() > 0)
                    {
                        var model1 = from m in db.tb_LessionMaster
                                     from a in db.tb_QuizTestMasterDetail
                                     where a.TestRefId == Testid && m.LessionId == items.LessionId
                                    && m.SubjectId == items.SubjectId
                                   
                                     select new
                                     {
                                         LessonName = m.LessionHeading,
                                         LessionId = m.LessionId
                                     };

                        if (model1 != null)
                        {

                            strtables += "<td>" + items.LessionHeading + "</td>";

                        }

                    }

                    if (icnt == 4)
                    {
                        icnt = 0;
                        strtables += "</tr>";
                    }
                }

            }

            strtables += "</table>";

            string hiddenValues = "<input type='hidden' value='" + subjectid + "' name='SubjectId' />";
            hiddenValues += "<input type='hidden' value='" + Testid + "' name='TestId' />";
     

            ViewData["datalist1"] = hiddenValues;
            ViewData["datalist"] = strtables;
            return strtables;
        }

    }
}
