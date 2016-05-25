using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
 
 
using System.Threading;
namespace OLProject.Controllersslidedata
{
    [HandleError]
    public class SlideShowController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();

        public ActionResult SlideIntro(Int32 id)
        {
            var gmodel = db.tb_LessionMaster.ToList().Where(x => x.LessionId == id).Single();
            
            //ViewData["startbutton"] = "<a href='/SlideShow/Index/" + id + "' id='A2' runat='server' ><img src='../../SiteImages/start.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
            ViewData["lessondesc"] = gmodel.SlideDescription;
            ViewData["graphics"] = "<img src='../../uploads/" + gmodel.SlideImage + "' border='0'   alt='Delete' style='width:420px;Height:390px;'/>";
            ViewData["startbutton"] = "<a href='/Exercise/Welcome1/?LessonId=" + id + "' id='A2' runat='server' ><img src='../../SiteImages/start.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
            return View();
        }
        public ActionResult IntroLesson(Int32 id)
        { 
            var gmodel = db.tb_LessionMaster.ToList().Where(x => x.LessionId == id).Single();
            ViewData["startbutton"] = "<a href='/SlideShow/Index/" + id + "' id='A2' runat='server' ><img src='../../SiteImages/start.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
            ViewData["lessondesc"] = gmodel.LessionDesc;
            ViewData["graphics"] = "<img src='../../uploads/" + gmodel.graphics + "' border='0'   alt='Delete' style='width:420px;Height:390px;'/>";
            ViewData["usefulltips"] = gmodel.UsefulTips;
            Session.Add("ModuleName0", gmodel.LessionHeading);
            return View();
        }

        public ActionResult PrintSlide(Int32 id)
        {
            var model = db.tb_LessionMasterSlides.ToList().AsQueryable().Where(x => x.AutoId == id);
            var modelg = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 10).Single();

            string html = "";
            if (model.Count() > 0)
            {
                foreach (var item in model)
                {

                    var gmodel = db.tb_LessionMaster.ToList().Where(x => x.LessionId == item.LessionId).Single();
                    ViewData["LessionName"] = gmodel.LessionHeading;

                  //  ViewData["classname"] = clsCommon.getClassNameProduct(Convert.ToInt32(gmodel.ClassId));
                  //  ViewData["uname"] = clsCommon.getUnitName(Convert.ToInt32(gmodel.UnitId));
                    ViewData["subjectname"] = clsCommon.getSubjectName(Convert.ToInt32(gmodel.SubjectId));

                    ViewData["printbutton"] = "<a href='javascript:window.print()'><img  width='60px' height='60px' src='../../uploads/" + modelg.ImagePath + "' /></a>";

                    html += "<h2>" + item.SlideDescription + "</h2>";
                    #region "Theme- 1"
                    if (item.ThemeId == 1)
                    {
                        if (item.UploadTypeId == 1) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImageDescription, Convert.ToInt32(item.ThemeId)); } //text
                        if (item.UploadTypeId == 2) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Image
                        if (item.UploadTypeId == 3) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Video
                        if (item.UploadTypeId == 4) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Video
                        if (item.UploadTypeId == 5) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Video
                    }
                    #endregion
                    #region "Theme- 2"
                    if (item.ThemeId == 2)
                    {
                        if (item.UploadTypeId == 2) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Image
                        if (item.UploadTypeId == 3) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 4) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 5) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                    }
                    #endregion
                    #region "Theme- 3"
                    if (item.ThemeId == 3) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        html += "</table>";
                    }
                    #endregion
                    #region "Theme- 4"
                    if (item.ThemeId == 4)
                    {
                        html += "<div class='box4'>";

                        if (item.UploadTypeId == 2) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Image
                        if (item.UploadTypeId == 3) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 4) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 5) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        html += "</div>";
                    }
                    #endregion
                    #region "Theme- 5"
                    if (item.ThemeId == 5) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        //First Row
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        //*************************************************************
                        //2 Row
                        if (item.UploadTypeId1 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************
                        //3 Row
                        if (item.UploadTypeId2 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId2 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId2 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId2 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************
                        //4 Row
                        if (item.UploadTypeId3 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId3 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId3 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId3 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************
                        //5 Row
                        if (item.UploadTypeId4 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId4 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId4 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId4 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************



                        html += "</table>";
                    }
                    #endregion

                    #region "Theme- 6"
                    if (item.ThemeId == 6) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 2) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        html += "</table>";
                    }
                    #endregion

                    html += "<table width='100%' align='center' style='background-color:white;'>";

                    html += "<tr><td align='left' valign='top' width='60%'><h3>Help</h3></td></tr>";
                    html += "<tr><td align='left' valign='top' width='60%'>" + item.HelpSlide + "</td></tr>";

                    html += "<tr><td align='left' valign='top' width='60%'><h3>Formula</h3></td></tr>";
                    html += "<tr><td align='left' valign='top' width='60%'>" + item.Formula + "</td></tr>";

                    html += "<tr><td align='left' valign='top' width='60%'><h3>Usefull Tips</h3></td></tr>";
                    html += "<tr><td align='left' valign='top' width='60%'>" + item.UsefulTips + "</td></tr>";

                    html += "<tr><td align='left' valign='top' width='60%'><h3>Question</h3></td></tr>";
                    html += "<tr><td align='left' valign='top' width='60%'>" + item.Question + "</td></tr>";

                    html += "<tr><td align='left' valign='top' width='60%'><h3>Solution</h3></td></tr>";
                    html += "<tr><td align='left' valign='top' width='60%'>" + item.Solution + "</td></tr>";


                    html += "</table>";
                }
            }

         

           
                      
            ViewData["slidedata"] = html;


            return View();
        }

        public ActionResult Index(Int32 id)
        {
            Int32 SlideId = 0;
            if (Request.QueryString["slideid"] != null)
            {
                SlideId = Convert.ToInt32(Request.QueryString["slideid"]);
            }

            Session.Add("LessonIdSlide", id);
            Session.Add("Menuid1", id);
            var gmodel = db.tb_LessionMaster.ToList().Where(x => x.LessionId == id).Single();
            var cmodel = db.tb_ClassMaster.ToList().Where(x => x.ClassesId == gmodel.ClassId).Single();
            ViewData["classname"] = cmodel.ClassName;

            var umodel = db.tb_UnitMaster.ToList().Where(x => x.UnitId == gmodel.UnitId).Single();
            ViewData["uname"] = umodel.UnitName;
            var gmodel1 = db.tb_LessionMaster.ToList().Where(x => x.LessionId > id).FirstOrDefault();
            var gmodel2 = db.tb_LessionMaster.ToList().Where(x => x.LessionId < id).FirstOrDefault();

            ViewData["LessionName"] = gmodel.LessionHeading;


            Session.Add("ModuleName0", gmodel.LessionHeading);

            //Next Lesson
            var model2 = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 19).Single();
            String ImagePath = "";

            if (gmodel1 != null)
            {
                ImagePath = model2.ImagePath;
                //ViewData["NextButton"] = "<a  style='float:right;' class='btn-grey' href='/SlideShow/Index/" + gmodel1.LessionId + "' /><img  width='60px' height='60px' src='../../uploads/" + ImagePath + "' /><br />" + model2.ButtonName + "</a>";
            }
            else
            {
                ImagePath = model2.ImagePath1;
                //ViewData["NextButton"] = "<a  style='float:right;' class='btn-grey' href='javascript:alert(&#34;Nothing&#34;)' /><img  width='60px' height='60px' src='../../uploads/" + ImagePath + "' /><br />" + model2.ButtonName + "</a>";
                //ViewData["NextButton"] = "<a  style='float:right;' class='btn-grey' href='/SlideShow/SlideIntro/" + gmodel1.LessionId + "' /><img  width='60px' height='60px' src='../../uploads/" + ImagePath + "' /><br />" + model2.ButtonName + "</a>";
            }
            //*******************
            //Last Lesson
            var model1 = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 20).Single();
            if (gmodel2 != null)
            {
                ImagePath = model1.ImagePath;
                ViewData["LastButton"] = "<a  style='float:right;' class='btn-grey' href='/SlideShow/Index/" + gmodel2.LessionId + "' /><img  width='60px' height='60px' src='../../uploads/" + ImagePath + "' /><br />" + model1.ButtonName + "</a>";
            }
            else
            {
                ImagePath = model1.ImagePath1;
                ViewData["LastButton"] = "<a  style='float:right;' class='btn-grey' href='#' /><img  width='60px' height='60px' src='../../uploads/" + ImagePath + "' /><br />" + model1.ButtonName + "</a>";
            }
            var model = db.tb_LessionMasterSlides.ToList().AsQueryable().Where(x => x.LessionId == Convert.ToInt32(Session["LessonIdSlide"]));
            if (SlideId > 0)
            {
                ViewData["LastButton"] = "";
                ViewData["NextButton"] = "";
                model = model.Where(x => x.AutoId == SlideId);
            }
            int page = 1;
            if (Request.QueryString["pageno"] != null)
            {
                page = Convert.ToInt32(Request.QueryString["pageno"].ToString());
            }
            Int32 offset = 1;
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
         
            string pageUrl = "/SlideShow/index/" + id;
           
            if (page == totalpage)
            {
                // ViewData["startbutton"] = "<a href='/Exercise/Welcome1/?LessonId=" + id + "' id='A2' runat='server' ><img src='../../SiteImages/start.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

                //ViewData["SlideDescription"] = gmodel.SlideDescription;
                pageUrl = "/SlideShow/SlideIntro/" + Convert.ToInt32(Session["LessonIdSlide"]);

                //Send ing result of Lession Information to parents

                //Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
                //var modelUser = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();
                //var item1 = (from m in db.tb_emailsDescription
                //             where m.Autoid == 9
                //             select m).Single();
                //string desc = "";
                //desc = item1.Description;
                //String ProductDetail = "";
                //ProductDetail += "<br /> The Following Lession is done by the User ";
                //ProductDetail += "<br /> User Name : <b>" + clsCommon.getUserName1(Convert.ToInt32(Session["pmsuserid"])) + "</b>";
                //ProductDetail += "<br /> Subject : <b>" + clsCommon.getSubjectName(Convert.ToInt32(gmodel.SubjectId)) + "</b>";
                //ProductDetail += "<br /> Class : <b>" + clsCommon.getClassNameProduct(Convert.ToInt32(gmodel.ClassId)) + "</b>";
                //ProductDetail += "<br /> Unit: <b>" + clsCommon.getUnitName(Convert.ToInt32(gmodel.UnitId)) + "</b>";
                //ProductDetail += "<br /> Lesson: <b>" + clsCommon.getLessonName(Convert.ToInt32(gmodel.LessionId)) + "</b>";
                //desc = desc.Replace("UserName", modelUser.ProfileName);
                //desc = desc.Replace("Detail", ProductDetail);
                //emailSystem.sendNewFormat(modelUser.EmailID, item1.EmailSubject, desc);
                //**************************************************************************************
            }
            string pageLinks = clsCommon.getPageingInformationNew(page, totalpage, pageUrl);
            ViewData["totalrecords"] = totalRecord;
            if (SlideId == 0)
            {
                ViewData["pageLinks"] = pageLinks;
                model = model.Skip(start).Take(offset);
            }

            string html = "";
            if (model.Count() > 0)
            {
                foreach (var item in model)
                {
                    html += "<h2>" + item.SlideDescription + "</h2>";
                    var modelSpeech = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId ==29).Single();
                    if (item.SpeechText != null && item.SpeechText != "")
                    {
                        ViewData["SpeechButton"] = "<a  style='float:right;' class='btn-grey' href='#' onclick='MyFunction();return false;' /><img  width='60px' height='60px' src='../../uploads/" + modelSpeech.ImagePath + "' /><br />" + modelSpeech.ButtonName + "</a>";
                        //ViewData["lessonSpeech"] = "<audio  controls><source src='http://tts-api.com/tts.mp3?q=" + item.SpeechText + "'  type='audio/mpeg'> Your browser does not support this audio format.</audio>";
                        ViewData["lessonSpeech"] = item.SpeechText;
                    }
                    else
                    {
                        ViewData["SpeechButton"] = "<a  style='float:right;' class='btn-grey' href='#' /><img  width='60px' height='60px' src='../../uploads/" + modelSpeech.ImagePath1 + "' /><br />" + modelSpeech.ButtonName + "</a>";
                    }
                    SlideId = item.AutoId;
                    CommentsSetting(SlideId);


                    clsCommon.setUserHistory(Convert.ToInt32(Session["pmsuserid"]), Convert.ToInt32(gmodel.SubjectId), Convert.ToInt32(gmodel.ClassId),
            Convert.ToInt32(gmodel.LessionId), SlideId, 0, Convert.ToInt32(gmodel.UnitId), Request.ServerVariables["remote_Address"].ToString());


                    #region "Theme- 1"
                    if (item.ThemeId == 1)
                    {
                        if (item.UploadTypeId == 1) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImageDescription, Convert.ToInt32(item.ThemeId)); } //text
                        if (item.UploadTypeId == 2) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Image
                        if (item.UploadTypeId == 3) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Video
                        if (item.UploadTypeId == 4) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Video
                        if (item.UploadTypeId == 5) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Video
                    }
                    #endregion
                    #region "Theme- 2"
                    if (item.ThemeId == 2)
                    {
                        if (item.UploadTypeId == 2) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Image
                        if (item.UploadTypeId == 3) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 4) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 5) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                    }
                    #endregion
                    #region "Theme- 3"
                    if (item.ThemeId == 3) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        html += "</table>";
                    }
                    #endregion
                    #region "Theme- 4"
                    if (item.ThemeId == 4)
                    {
                        html += "<div class='box4'>";

                        if (item.UploadTypeId == 2) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Image
                        if (item.UploadTypeId == 3) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 4) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 5) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        html += "</div>";
                    }
                    #endregion

                    #region "Theme- 5"
                    if (item.ThemeId == 5) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        //First Row
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        //*************************************************************
                        //2 Row
                        if (item.UploadTypeId1 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************
                        //3 Row
                        if (item.UploadTypeId2 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId2 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId2 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId2 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************
                        //4 Row
                        if (item.UploadTypeId3 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId3 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId3 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId3 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************
                        //5 Row
                        if (item.UploadTypeId4 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId4 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId4 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId4 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************


                        
                        html += "</table>";
                    }
                    #endregion

                    #region "Theme- 6"
                    if (item.ThemeId == 6) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 2) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        html += "</table>";
                    }
                    #endregion


                }

                String Buttons = "";
                Buttons += getButton(SlideId, 27);
                Buttons += getButton(SlideId, 9);
                Buttons += getButton(SlideId, 13);
                Buttons += getButton(SlideId, 10);
                Buttons += getButton(SlideId, 5);
              //  Buttons += getButton(SlideId, 8);
                Buttons += getButton(SlideId, 4);
                Buttons += getButton(SlideId, 3);
                Buttons += getButton(SlideId, 2);
                Buttons += getButton(SlideId, 1);
                ViewData["buttons"] = Buttons;
                //Buttons += getButton(SlideId, 17);
                //Buttons += getButton(SlideId, 15);
                //Buttons += getButton(SlideId, 16);
                //Buttons += getButton(SlideId, 18);
                //ViewData["buttons1"] = Buttons
            }
            else
            {

                String Buttons = "";
                Buttons += getButton(0, 1);
                Buttons += getButton(0, 2);
                Buttons += getButton(0, 3);
                Buttons += getButton(0, 4);
               // Buttons += getButton(0, 8);
                Buttons += getButton(0, 5);
                Buttons += getButton(0, 13);
                Buttons += getButton(0, 9);
                Buttons += getButton(0, 10);
                Buttons += getButton(0, 27);
                ViewData["buttons"] = Buttons;
                html = "<h2>Slide not found</h2>";
                ViewData["startbutton"] = "";
            }
            ViewData["slidedata"] = html;
            return View();
        }
        private void CommentsSetting(Int32 SlideId)
        {
            //var model = db.tb_NotePadMaster.ToList().Where(x => x.SlideId == SlideId);
            //string html = "";
            //html += "<table width='100%' align='' style='background-color:white;'>";
            //html += "<tr><td align='left' valign='top'><h3>User Comments:-<h3></td></tr>";
            //foreach (var item in model)
            //{
            //    html += "<tr><td align='left' valign='top'>" + item.Comments + "</td></tr>";
            //}
            //html += "</table>";
            //ViewData["comments"] = html;

        }
        private string getHtml1(Int32 UploadTypeId, string ImageName)
        {
            string html = "";
            html += "<p  style='background-color:white;'>";
            html += ImageName;
            html += "</p>";
            return html;
        }
        private string getHtml(Int32 UploadTypeId, string ImageName, Int32 ThemeId)
        {
            string html = "";
            Int32 imgeWidth = 100;
            Int32 imgHeight = 100;
            var model = db.tb_ThemeContent.ToList().Where(x => x.UploadTypeId == UploadTypeId && x.ThemeId == ThemeId);
            if (model.Count() > 0)
            {
                var model1 = db.tb_ThemeContent.ToList().Where(x => x.UploadTypeId == UploadTypeId && x.ThemeId == ThemeId).Single();
                imgeWidth = Convert.ToInt32(model1.intWidth);
                imgHeight = Convert.ToInt32(model1.intHeight);
            }

            if (UploadTypeId == 1) //text
            {
                html += "<table width='100%' align='' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'>" + ImageName + "</td></tr>";
                html += "</table>";
            }
            if (UploadTypeId == 2)
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
               // html += "<tr><td align='left' valign='top'><img src='../../uploads/" + ImageName + "' width='" + imgeWidth + "' height='" + imgHeight + "' /></td></tr>";
                html += "<tr><td align='left' valign='top'><img src='../../uploads/" + ImageName + "' /></td></tr>";

                html += "</table>";
            }
            if (UploadTypeId == 3) //Video
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'>";
                html += "<video width='" + imgeWidth + "' height='" + imgHeight + "' controls autoplay>";
                html += "<source src='../../uploads/" + ImageName + "' type='video/mp4'>";
                html += "</video>";
                html += "</td></tr>";
                html += "</table>";
            }

            if (UploadTypeId == 4) // Audio
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'>";
                html += " <audio controls>";
                html += "<source src='../../uploads/" + ImageName + "' type='audio/mpeg'></audio>";
                html += "</td></tr>";
                html += "</table>";
            }
            if (UploadTypeId == 5)
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'>";
                html += "<OBJECT classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' ";
                html += "codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0' ";
                html += "WIDTH='320' HEIGHT='240' id='Puggle' ALIGN=''>";
                html += "<PARAM NAME=movie VALUE='../../uploads/" + ImageName + "'> ";
                html += "<PARAM NAME=quality VALUE=high>";
                html += "<PARAM NAME=bgcolor VALUE=#333399>";
                html += "<EMBED src='../../uploads/" + ImageName + "' quality=high bgcolor=#333399 WIDTH='" + imgeWidth + "' HEIGHT='" + imgHeight + "' NAME='Yourfilename' ALIGN='' TYPE='application/x-shockwave-flash' PLUGINSPAGE='http://www.macromedia.com/go/getflashplayer'></EMBED> </OBJECT>";
                html += "</td></tr>";
                html += "</table>";
            }
            return html;

        }
        private string getButton(Int32 SlideId, Int32 Buttonid)
        {
            string result = "";
            var model = db.tb_ButtonMaster.ToList().Where(x=> x.ButtonId == Convert.ToInt32(Buttonid)).Single();
            if (SlideId > 0)
            {
               // var model1 = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == Convert.ToInt32(SlideId)).Single();
                if (Buttonid == 1 || Buttonid == 2 || Buttonid == 3 || Buttonid == 4 || Buttonid == 8)
                {
                   // if (Buttonid == 1 && model1.HelpSlide != null)
                        if (Buttonid == 1 )
                    {
//                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/HelpSlide/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/Help/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";

                        }
                 //   else if (Buttonid == 3 && model1.UsefulTips != null)
                         else if (Buttonid == 3 )
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/UsefulTips/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                  //  else if (Buttonid == 2 && model1.Solution != null)
                             else if (Buttonid == 2 )
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/Solution/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                   // else if (Buttonid == 4 && model1.Question != null)
                              else if (Buttonid == 4 )
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/Question/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                   // else if (Buttonid == 8 && model1.Formula != null)
                              else if (Buttonid == 8 )
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/Formula/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
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
                    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/PDFreports/SlidePDF/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                }
                if (Buttonid == 10) //Print
                {
                    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slideshow/printslide/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                }
                if (Buttonid == 27) //Print
                {
                    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/notepad/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
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
            var model = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == id).Single();
            string result = "";
            if (buttonid == 1) { result = model.HelpSlide; };
            if (buttonid == 3) { result = model.UsefulTips; };
            if (buttonid == 2) { result = model.Solution; };
            if (buttonid == 4) { result = model.Question; };
            if (buttonid == 8) { result = model.Formula; };
            ViewData["results"]=result;
            return View();
        }
        public ActionResult Thanks()
        {
            return View();
        }
    }
}
