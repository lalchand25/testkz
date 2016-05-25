using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using OLProject.Models;
namespace OLProject.Controllers
{
    public class LessonsController : Controller
    {

        kzonlineEntities db = new kzonlineEntities();
        public ActionResult QuizList()
        {
            Int32 lessonid = 0;
            if (Request.QueryString["lessonid"] != null)
            {
                lessonid = Convert.ToInt32(Request.QueryString["lessonid"].ToString());
            }
            var model = db.tb_QuizDetail.ToList().Where(x => x.LessonId == lessonid);
            String strTable = "";
            Int32 mcounter = 0;
            foreach (var item in model)
            {
                mcounter += 1;
                if (mcounter % 2 == 0)
                {
                    strTable += "<tr  bgcolor='#DDEEEE'>";
                }
                else
                {
                    strTable += "<tr bgcolor='#EEFFFF'>";
                }



                strTable += "<td><img src='../../uploads/1.png' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
                if (item.QuesTypeId != 5)
                {
                    strTable += "<td>" + item.Decription + "</td>";
                }
                else
                {
                    strTable += "<td><img src='../../uploads/" + item.Decription + "' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
                }

                if (item.QuesTypeId == 1)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>  " + item.ActualAns + "</td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mc/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mc/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }
                if (item.QuesTypeId == 2)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>" + item.ActualAns + "</td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mCOrrect/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mCOrrect/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }
                if (item.QuesTypeId == 3)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>" + item.ActualAns + "</td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/truefalse/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/truefalse/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }

                if (item.QuesTypeId == 4)
                {
                    strTable += "<td><img src='../../uploads/" + item.Ans1 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td><img src='../../uploads/" + item.Ans2 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td><img src='../../uploads/" + item.Ans3 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td><img src='../../uploads/" + item.Ans4 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td align='center'>" + item.ActualAns + "</td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/imgchoice/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/imgchoice/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }
                if (item.QuesTypeId == 5)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>  " + item.ActualAns + "</td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mcImage/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mcImage/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }

                strTable += "</tr>";
            }
            ViewData["data"] = strTable;
            return View();
        }

        public void setViews()
        {

            var ddList1 = (from c in db.tb_UserMaster
                           where c.CategoryId == 3
                           select new { ID = c.UserId, Name = c.UserName }).OrderBy(x => x.Name);


            var selectList1 = new SelectList(ddList1, "ID", "Name");
            ViewData["userList"] = selectList1;
        }
        private string getHtml1(Int32 UploadTypeId, string ImageName)
        {
            string html = "";
            html += "<p  style='background-color:white;'>";
            html += ImageName;
            html += "</p>";
            return html;
        }
        private string getHtml(Int32 UploadTypeId, string ImageName)
        {
            string html = "";
            if (UploadTypeId == 1)
            {
                html += "<table width='100%' align='' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'>" + ImageName + "</td></tr>";
                html += "</table>";
            }
            if (UploadTypeId == 2)
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'><img src='../../uploads/" + ImageName + "' /></td></tr>";
                html += "</table>";
            }
            if (UploadTypeId == 3)
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'>";
                html += "<video width='320' height='240' controls autoplay>";
                html += "<source src='../../uploads/" + ImageName + "' type='video/mp4'>";
                html += "</video>";
                html += "</td></tr>";
                html += "</table>";
            }

            if (UploadTypeId == 4)
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
                html += "<EMBED src='../../uploads/" + ImageName + "' quality=high bgcolor=#333399 WIDTH='900' HEIGHT='450' NAME='Yourfilename' ALIGN='' TYPE='application/x-shockwave-flash' PLUGINSPAGE='http://www.macromedia.com/go/getflashplayer'></EMBED> </OBJECT>";
                html += "</td></tr>";
                html += "</table>";
            }
            return html;

        }
        private string getButtonSlide(Int32 SlideId, Int32 Buttonid)
        {
            string result = "";
            var model = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == Convert.ToInt32(Buttonid)).Single();
            if (SlideId > 0)
            {
                var model1 = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == Convert.ToInt32(SlideId)).Single();
                if (Buttonid == 1 || Buttonid == 2 || Buttonid == 3 || Buttonid == 4 || Buttonid == 8)
                {
                    if (Buttonid == 1 && model1.HelpSlide != null)
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
                    else if (Buttonid == 8 && model1.Formula != null)
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

                //if (Buttonid == 13) //TeacherHelp
                //{
                //    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/teacherhelp/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                //}
                //if (Buttonid == 9) //PDf
                //{
                //    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/PDF/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                //}
                if (Buttonid == 10) //Print
                {
                    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/Print/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
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
        public ActionResult Detail(Int32 id)
        {


            var gmodel = db.tb_LessionMaster.ToList().Where(x => x.LessionId == id).Single();
            ViewData["lessonname"] = gmodel.LessionHeading;
            ViewData["lessondesc"] = gmodel.LessionDesc;
            ViewData["lessonSpeech"] = "";

            if (gmodel.SpeechText != null)
            {
                ViewData["lessonSpeech"] = "<audio controls><source src='http://tts-api.com/tts.mp3?q=" + gmodel.SpeechText + "'  type='audio/mpeg'> Your browser does not support this audio format.</audio>"; ;
            }

            string url = System.Web.HttpContext.Current.Request.ServerVariables[""];

            //var cmodel = db.tb_ClassMaster.ToList().Where(x => x.ClassesId == gmodel.ClassId).Single();
            //ViewData["classname"] = cmodel.ClassName;

            //var umodel = db.tb_UnitMaster.ToList().Where(x => x.UnitId == gmodel.UnitId).Single();
            //ViewData["uname"] = umodel.UnitName;

            //var gmodel1 = db.tb_LessionMaster.ToList().Where(x => x.LessionId > id).FirstOrDefault();
            //var gmodel2 = db.tb_LessionMaster.ToList().Where(x => x.LessionId < id).FirstOrDefault();

            //ViewData["LessionName"] = gmodel.LessionHeading;

            ViewData["urlpdf"] = "<a href='javascript:OpenPopup1(&#34;/pdfreports/lesson/" + id + "&#34;,&#34;Browser1&#34;);'>Generate PDF</a>";

            var model = db.tb_LessionMasterSlides.ToList().AsQueryable().Where(x => x.LessionId == id);
            string html = "";
            Int32 SlideId = 0;
            if (model.Count() > 0)
            {

                Int32 sno = 0;
                Int32 total = model.Count();
                foreach (var item in model)
                {
                    sno += 1;
                    html += " <fieldset><legend><h2>" + item.SlideDescription + "    /  Slide :" + sno + " of " + total + "</h2></legend>";

                    SlideId = item.AutoId;
                    #region "Theme- 1"
                    if (item.ThemeId == 1)
                    {
                        if (item.UploadTypeId == 1) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //text
                        if (item.UploadTypeId == 2) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath); } //Image
                        if (item.UploadTypeId == 3) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath); } //Video
                        if (item.UploadTypeId == 4) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath); } //Video
                        if (item.UploadTypeId == 5) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath); } //Video
                    }
                    #endregion
                    #region "Theme- 2"
                    if (item.ThemeId == 2)
                    {
                        if (item.UploadTypeId == 2) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Image
                        if (item.UploadTypeId == 3) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 4) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 5) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                    }
                    #endregion
                    #region "Theme- 3"
                    if (item.ThemeId == 3) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2) + " </td></tr>"; }

                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2) + " </td></tr>"; }

                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2) + " </td></tr>"; }

                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2) + " </td></tr>"; }
                        html += "</table>";
                    }
                    #endregion
                    #region "Theme- 4"
                    if (item.ThemeId == 4)
                    {
                        html += "<div class='box4'>";

                        if (item.UploadTypeId == 2) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Image
                        if (item.UploadTypeId == 3) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 4) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 5) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        html += "</div>";
                    }
                    #endregion

                    #region "Theme- 6"
                    if (item.ThemeId == 6) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 2) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2) + " </td></tr>"; }

                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2) + " </td></tr>"; }

                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2) + " </td></tr>"; }

                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2) + " </td></tr>"; }
                        html += "</table>";
                    }
                    #endregion
                    html += " </fieldset><br /><br />";
                }

                String Buttons = "";
                Buttons += getButtonSlide(SlideId, 27);
                Buttons += getButtonSlide(SlideId, 9);
                Buttons += getButtonSlide(SlideId, 13);
                Buttons += getButtonSlide(SlideId, 10);
                Buttons += getButtonSlide(SlideId, 5);
                Buttons += getButtonSlide(SlideId, 8);
                Buttons += getButtonSlide(SlideId, 4);
                Buttons += getButtonSlide(SlideId, 3);
                Buttons += getButtonSlide(SlideId, 2);
                Buttons += getButtonSlide(SlideId, 1);
                ViewData["buttons"] = Buttons;
            }
            else
            {

                String Buttons = "";
                Buttons += getButtonSlide(0, 1);
                Buttons += getButtonSlide(0, 2);
                Buttons += getButtonSlide(0, 3);
                Buttons += getButtonSlide(0, 4);
                Buttons += getButtonSlide(0, 8);
                Buttons += getButtonSlide(0, 5);
                // Buttons += getButtonSlide(0, 13);
                // Buttons += getButtonSlide(0, 9);
                Buttons += getButtonSlide(0, 10);
                Buttons += getButtonSlide(0, 27);
                ViewData["buttons"] = Buttons;
                html = "<h2>Slide not found</h2>";

            }
            ViewData["slidedata"] = html;

            return View();
        }
        // ****************************************************************************
        // ****************************************************************************
        [ValidateInput(false)]
        public ActionResult PopupHelp(int id, tb_LessionMaster model)
        {
            var model1 = (from m in db.tb_LessionMaster where m.LessionId == id select m).Single();
            if (Request.HttpMethod == "POST")
            {
                model1.Help = model.Help; db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
            }





            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupFormula(int id, tb_LessionMaster model)
        {
            var model1 = (from m in db.tb_LessionMaster where m.LessionId == id select m).Single();
            if (Request.HttpMethod == "POST")
            {
                model1.Formulas = model.Formulas; db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
            }

            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupUsefulTips(int id, tb_LessionMaster model)
        {
            var model1 = (from m in db.tb_LessionMaster where m.LessionId == id select m).Single();
            if (Request.HttpMethod == "POST")
            {
                model1.UsefulTips = model.UsefulTips; db.SaveChanges(); ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
            }
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupSolution(int id, tb_LessionMaster model)
        {
            var model1 = (from m in db.tb_LessionMaster where m.LessionId == id select m).Single();
            if (Request.HttpMethod == "POST")
            {
                model1.Solution = model.Solution; db.SaveChanges(); ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
            }
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupQuestion(int id, tb_LessionMaster model)
        {
            var model1 = (from m in db.tb_LessionMaster where m.LessionId == id select m).Single();
            if (Request.HttpMethod == "POST")
            {
                model1.Question = model.Question; db.SaveChanges(); ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
            }
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupTutorial(int id, tb_LessionMaster model)
        {
            var model1 = (from m in db.tb_LessionMaster where m.LessionId == id select m).Single();
            if (Request.HttpMethod == "POST")
            {
                model1.Tutorial = model.Tutorial; db.SaveChanges(); ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
            }
            return View(model1);
        }
        public ActionResult PopupSpeech(int id, tb_LessionMaster model)
        {
            var model1 = (from m in db.tb_LessionMaster where m.LessionId == id select m).Single();
            if (Request.HttpMethod == "POST")
            {
                model1.SpeechText = model.SpeechText; db.SaveChanges(); ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
            }
            return View(model1);
        }
        private string getButton(Int32 SlideId, Int32 Buttonid)
        {
            string result = "";
            var model = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == Convert.ToInt32(Buttonid)).Single();
            if (SlideId > 0)
            {
                var model1 = db.tb_LessionMaster.ToList().Where(x => x.LessionId == Convert.ToInt32(SlideId)).Single();
                if (Buttonid == 1 || Buttonid == 2 || Buttonid == 3 || Buttonid == 4 || Buttonid == 8 || Buttonid == 21 || Buttonid == 22 || Buttonid == 29)
                {
                    if (Buttonid == 1)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/lessons/popupHelp/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 3)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/lessons/popupUsefulTips/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 2)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/lessons/popupSolution/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 4)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/lessons/popupQuestion/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 8)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/lessons/popupFormula/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 21)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/lessons/popupTutorial/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 22)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/lessons/popupview/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 29)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/lessons/popupspeech/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
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

                //if (Buttonid == 13) //TeacherHelp
                //{
                //    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/teacherhelp/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                //}
                //if (Buttonid == 9) //PDf
                //{
                //    result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/PDF/create/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                //}
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
            var model = db.tb_LessionMaster.ToList().Where(x => x.LessionId == id).Single();
            string result = "";

            if (buttonid == 1) { result = model.Help; };
            if (buttonid == 2) { result = model.UsefulTips; };
            if (buttonid == 3) { result = model.Solution; };
            if (buttonid == 4) { result = model.Question; };
            if (buttonid == 8) { result = model.Formulas; };
            if (buttonid == 21) { result = model.Tutorial; };

            ViewData["results"] = result;
            return View();
        }
        private void displaybutton(Int32 SlideId)
        {
            String Buttons = "";
            Buttons += getButton(SlideId, 29);
            //  Buttons += getButton(SlideId, 13);
            Buttons += getButton(SlideId, 5);
            Buttons += getButton(SlideId, 21);
            Buttons += getButton(SlideId, 8);
            Buttons += getButton(SlideId, 4);
            Buttons += getButton(SlideId, 3);
            Buttons += getButton(SlideId, 2);
            Buttons += getButton(SlideId, 1);
            ViewData["buttons"] = Buttons;
            displayTopbutton(SlideId);

        }
        private void displayTopbutton(Int32 SlideId)
        {
            String Buttons = "";
            //   Buttons += getButton(SlideId, 9);
            Buttons += getButton(SlideId, 10);
            Buttons += getButton(SlideId, 22);
            ViewData["topbuttons"] = Buttons;

        }
        public ActionResult popupView(int id)
        {
            var model = (from m in db.tb_LessionMaster
                         where m.LessionId == id
                         select m).Single();

            return View(model);
        }
        // ****************************************************************************
        // ****************************************************************************
        public ActionResult ClassList(Int32 id)
        {
            Int32 ClassesId = 0;
            Int32 UnitId = 0;

            if (Session["unitid"] != null)
            {
                UnitId = Convert.ToInt32(Session["unitid"]);
            }
            ViewData["UnitId"] = UnitId;

            if (Request.QueryString["id1"] != null)
            {

                ClassesId = Convert.ToInt32(Request.QueryString["id1"].ToString());
            }

            var ddList = (from m in db.tb_ClassMaster
                          from t in db.tb_ProductClassMaster
                          where m.SubjectId == id && m.ClassId == t.AutoId
                          select new
                          {
                              Name = t.ClassName,
                              ID = m.ClassesId
                          });

            var selectList = new SelectList(ddList, "ID", "Name", Convert.ToInt32(ClassesId));
            //var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["Classlist"] = selectList;
            return PartialView();
            // return View();
        }
        public ActionResult UnitList(Int32 id)
        {
            Int32 id1 = 0;

            if (Request.QueryString["id1"] != null)
            {

                id1 = Convert.ToInt32(Request.QueryString["id1"].ToString());
            }

            //var ddList = (from m in db.tb_UnitMaster
            //              where m.ClassesId == id
            //              select new
            //              {
            //                  Name = m.UnitName,
            //                  ID = m.UnitId
            //              });


            var ddList = (from m in db.tb_UnitMaster
                          where m.SubjectId == id
                          select new
                          {
                              Name = m.UnitName,
                              ID = m.UnitId
                          });

            var selectList = new SelectList(ddList, "ID", "Name", id1);
            ViewData["Unitlist"] = selectList;
            //return View();
            return PartialView();
        }
        private void SubjectList()
        {
            setViews();
            Int32 subjectid = 0;

            Int32 ClassesId = 0;
            Int32 UnitId = 0;

            if (Session["SubjectId"] != null)
            {
                subjectid = Convert.ToInt32(Session["SubjectId"]);
            }
            if (Session["ClassesId"] != null)
            {
                ClassesId = Convert.ToInt32(Session["ClassesId"]);
            }
            if (Session["unitid"] != null)
            {
                UnitId = Convert.ToInt32(Session["unitid"]);
            }
            ViewData["ClassesId"] = ClassesId;
            ViewData["SubjectId"] = subjectid;
            ViewData["UnitId"] = UnitId;







            int catid = 0;
            if (Session["cateid"] != null)
            {
                catid = Convert.ToInt32(Session["cateid"]);
            }

            if (catid != 8)
            {
                Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
                var ddList22 = (from m in db.tb_SubjectMaster
                                where m.UserId == userid
                                select new
                                {
                                    Name = m.SubjectName,
                                    ID = m.SubjectId

                                });
                var selectList = new SelectList(ddList22, "ID", "Name", Convert.ToInt32(subjectid));

                ViewData["Subjectlist"] = selectList;
            }
            else
            {

                var ddList = (from m in db.tb_SubjectMaster
                              select new
                              {
                                  Name = m.SubjectName,
                                  ID = m.SubjectId

                              });
                var selectList = new SelectList(ddList, "ID", "Name", Convert.ToInt32(subjectid));
                ViewData["Subjectlist"] = selectList;

            }


            //var ddList1 = (from m in db.tb_SubTitleMaster
            //               orderby m.SubTitle ascending
            //               select new
            //               {
            //                   Name = m.SubTitle,
            //                   ID = m.SubHeadId
            //               });

            //var selectList1 = new SelectList(ddList1, "ID", "Name");
            //ViewData["sublist"] = selectList1;


        }
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Lesson Information");
            Int32 SubjectId = 0;
            SubjectList();
            Int32 ClassesId = 0;
            Int32 unitid = 0;

            int page = 1;
            if (Request.QueryString["pageno"] != null)
            {
                page = Convert.ToInt32(Request.QueryString["pageno"].ToString());
            }

            if (Request.Form["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Request.Form["SubjectId"].ToString());
                Session.Add("SubjectId", SubjectId);
               ViewBag.CreateLink ="   <a href = '/lessons/create/'  <button class='btn btn-success' type='button'><i class='fa fa-plus'></i>Create</button></a> ";


            }

            if (Session["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Session["SubjectId"].ToString());
            }

            if (SubjectId > 0)
            {
                var model = db.tb_LessionMaster.ToList().AsQueryable();
                int catid = 0;
                if (Session["cateid"] != null)
                {
                    catid = Convert.ToInt32(Session["cateid"]);
                }

                if (catid != 8)
                {
                    int userid = Convert.ToInt32(Session["pmsuserid"]);

                    model = model.Where(x => x.Userid == userid);
                }

                if (SubjectId > 0)
                {
                    model = model.Where(x => x.SubjectId == SubjectId);
                    var model1 = db.tb_SubjectMaster.ToList().Where(x => x.SubjectId == SubjectId).Single();
                    ViewData["subjectname"] = model1.SubjectName.ToString();
                }


                if (unitid == 0 && ClassesId == 0 && SubjectId == 0)
                {
                    model = model.Take(15);

                }
                Int32 offset = 15;
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
                string pageUrl = "/lessons/index/";
                string pageLinks = clsCommon.getPageingInformationNew(page, totalpage, pageUrl);
                ViewData["totalrecords"] = totalRecord;
                ViewData["pageLinks"] = pageLinks;
                model = model.Skip(start).Take(offset).OrderBy(x => x.DisplayOrder);
                //*****************************************************************
                string strTable = "";

                Int32 userid2 = Convert.ToInt32(Session["pmsuserid"]);

                var model2 = from m in db.tb_LessionMaster
                             from t in db.tb_TeacherPermission
                             where t.TeacherId == userid2 && t.LessonId == m.LessionId
                             select new
                             {
                                 taskid = m.LessionId,
                             };

                if (model.Count() > 0)
                {
                    string header = clsCommon.getHeaderWithoutImages(10);
                    ViewBag.header = header;
                }

        //               < button class="btn  btn-small btn-primary" onclick="OpenPopupCenter('/application/create', 'Employee Master!?', 1300, 750);" type="button">
        //    <i class="fa fa-plus-square"></i>
        //    Create
        //</button>

                foreach (var item in model)
                {
                    strTable += "<tr>";
                    strTable += "<td><img src='../../uploads/" + item.imagePath + "' border='0'.   alt='Image' style='width:38px;Height:38px;'/></td>";
                    strTable += "<td><b><a  href='javascript:OpenPopup(&#34;/Lessons/Detail/" + item.LessionId + "&#34;);' />" + item.LessionHeading + "</a></b></td>";
                    strTable += "<td>" + item.DisplayOrder + "</td>";
                    strTable += "<td align='center' valign='top'>  <a href = '/lessons/edit/" + item.LessionId + "' <button class='btn btn-danger'  type='button'><i class='fa fa-edit'></i>Edit</button>  </a> </td>";
                    strTable += "<td align='center' valign='top'> <a href = '/lessons/delete/" + item.LessionId + "' <button class='btn btn-danger'  type='button'><i class='fa fa-trash-o'></i>Delete</button>  </a>  </td>";


                    strTable += "<td align='center' valign='top'> <a href='/slides/index/?lessonid=" + item.LessionId + "' class='btn btn-primary'> <i class='fa fa-sliders'></i>Slides</a> </td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-warning' onclick='javascript:OpenPopup(\"/SlideShownew/Index/" + item.LessionId + "\");' type='button'> <i class='fa fa-slideshare'></i>Slide Show</button> </td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-info' onclick='javascript:OpenPopup(\"/Exercisenew/Welcome1/?lessonid=" + item.LessionId + "\");' type='button'> <i class='fa glyphicon-remove'></i>    Quiz Show       </button> </td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-success'  onclick='javascript:OpenPopup(\"/lessons/Quizlist/?lessonid=" + item.LessionId + "\");' type='button'><i class='fa fa-book'></i> List of Quiz</button> </td>";
                    strTable += "</tr>";
                }
                ViewData["data"] = strTable;
                return View(model);
            }
            else
            {

                return View();
            }

        }
        public ActionResult IndexTeacher()
        {
            Session.Add("ModuleName0", "Lesson Information For Teacher");
            //*****************************************************************
            //*****************************************************************
            int page = 1;
            if (Request.QueryString["pageno"] != null)
            {
                page = Convert.ToInt32(Request.QueryString["pageno"].ToString());
            }

            Int32 userid = Convert.ToInt32(Session["pmsuserid"]);

            var model = (from m in db.tb_LessionMaster
                         from t in db.tb_TeacherPermission
                         where t.TeacherId == userid && t.LessonId == m.LessionId && m.Publish == true
                         select new
                         {
                             taskid = m.LessionId,
                             m.imagePath,
                             m.LessionHeading,
                             m.LessionId,
                             m.DisplayOrder
                         }).AsQueryable();


            //Int32 offset = 15;
            //int totalRecord = model.Count();
            //int start;
            //start = (page - 1) * offset;
            //Int32 totalpage = 0;
            //if (totalRecord > offset)
            //{
            //    int totalpage1 = (totalRecord % offset);
            //    totalpage = (totalRecord / offset);
            //    if (totalpage1 > 0)
            //    {
            //        totalpage += 1;
            //    }
            //}
            //else
            //{
            //    totalpage = 1;
            //}
            //string pageUrl = "/lessons/indexTeacher/";
            //string pageLinks = clsCommon.getPageingInformationNew(page, totalpage, pageUrl);
            //ViewData["totalrecords"] = totalRecord;
            //ViewData["pageLinks"] = pageLinks;
            //model = model.Skip(start).Take(offset).OrderBy(x => x.DisplayOrder);
            //*****************************************************************
            string strTable = "";
            // var bt = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 22).Single();
            foreach (var item in model)
            {
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/" + item.imagePath + "' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
                strTable += "<td><b><a  href='javascript:OpenPopup(&#34;/Lessons/Detail/" + item.LessionId + "&#34;);' />" + item.LessionHeading + "</a></b></td>";
                strTable += "<td>" + item.DisplayOrder + "</td>";
                //                strTable += "<td align='center' valign='top'> <a href='/Slides/index/?lessonid=" + item.LessionId + "' id='A2' runat='server' ><img src='../../SiteImages/bAdd.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'> <a href='/slides/index/?lessonid=" + item.LessionId + "' class='btn btn-primary'> <i class='fa fa-sliders'></i>Slides</a> </td>";


                //strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/SlideShow/Index/" + item.LessionId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/viewb.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'> <button class='btn btn-warning' onclick='javascript:OpenPopup(\"/SlideShownew/Index/" + item.LessionId + "\");' type='button'> <i class='fa fa-slideshare'></i>Slide Show</button> </td>";


                //                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/Exercise/Welcome1/?lessonid=" + item.LessionId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/show.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";

                strTable += "<td align='center' valign='top'> <button class='btn btn-info' onclick='javascript:OpenPopup(\"/Exercisenew/Welcome1/?lessonid=" + item.LessionId + "\");' type='button'> <i class='fa glyphicon-remove'></i>    Quiz Show       </button> </td>";

                strTable += "</tr>";



            }
            ViewData["data"] = strTable;
            return View(model);


        }
        public ActionResult Create()
        {
            //setView();
            displaybutton(0);
            SubjectList();
            ViewData["classid"] = "0";
            ViewData["unitid"] = "0";
            ViewData["buttonname"] = 1;


            return View();
        }
        private Boolean ValidateData(tb_LessionMaster model)
        {
            Boolean validateData1 = true;

            if (string.IsNullOrEmpty(model.LessionHeading))
                ViewData.ModelState.AddModelError("LessionHeading", "Please enter   Lession Heading!");

            if (string.IsNullOrEmpty(model.SlideDescription))
                ViewData.ModelState.AddModelError("SlideDescription", "Please enter   Lession Description!");

            if (model.SubjectId == null || model.SubjectId == 0)
            {
                ViewData.ModelState.AddModelError("SubjectId", "Please Select Subject  !");
            }

            //if (model.UnitId == null || model.UnitId == 0)
            //{
            //    ViewData.ModelState.AddModelError("UnitId", "Please Select Unit   !");
            //}

            //if (model.ClassId == null || model.ClassId == 0)
            //{
            //    ViewData.ModelState.AddModelError("ClassId", "Please Select Class   !");
            //}

            //if (model.SubHeadId == null || model.SubHeadId == 0)
            //{
            //    ViewData.ModelState.AddModelError("SubHeadId", "Please Select Sub Head   !");
            //}

            if (model.DisplayOrder == null)
            {
                ViewData.ModelState.AddModelError("DisplayOrder", "Please Select DisplayOrder !");
            }

            if (!ModelState.IsValid)
            {

                validateData1 = false;
            }
            return validateData1;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(HttpPostedFileBase file, tb_LessionMaster model1, FormCollection frm)
        {
            //  setView();
            displaybutton(0);
            SubjectList();
            ViewData["buttonname"] = 1;
            try
            {


                string filename1 = "intro.gif";
                string filename2 = "intro.gif";
                string filename3 = "intro.gif";

                if (ValidateData(model1))
                {

                    // HttpPostedFileBase file = Request.Files[0];
                    file = Request.Files[0];
                    if (file.ContentLength < 2000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png" || FileExtension == ".gif" || FileExtension == ".jpg" || FileExtension == ".jpeg")
                        {

                            string randName = emailSystem.CreateRandomPassword(8);

                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath);
                        }
                    }

            
                    model1.imagePath = filename1;
                    model1.graphics = filename2;

                    if (model1.LessionHeading == null)
                    {
                        model1.LessionHeading = "";
                    }
                    if (model1.LessionDesc == null)
                    {
                        model1.LessionDesc = "";
                    }
                    model1.Userid = Convert.ToInt32(Session["pmsuserid"]);
                    model1.CompanyId = 0;
                    model1.TotalView = 0;
                    model1.Downloads = 0;
                    model1.SubmitDate = DateTime.Now;
                    model1.SubHeadId = 0;
                    model1.Ipaddress = Request.ServerVariables["remote_address"];
                    db.tb_LessionMaster.Add(model1);
                    db.SaveChanges();
                    //Sending Email to teacher
                    Int32 Teacherid = model1.TeacherId == null ? 0 : Convert.ToInt32(model1.TeacherId);

                    SetTeacherEmail(Teacherid, Convert.ToInt32(model1.LessionId));

                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            var tb1 = new tb_LessionMaster();
            setView();
            return View(tb1);
        }

        private void setView()
        {

            var ddList = (from m in db.tb_ClassMaster
                          from t in db.tb_ProductClassMaster
                          where m.ClassId == t.AutoId
                          select new
                          {
                              Name = t.ClassName,
                              ID = m.ClassesId
                          });

            var selectList = new SelectList(ddList, "ID", "Name");
            //var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["Classlist"] = selectList;




            Int32 id1 = 0;

            if (Request.QueryString["id1"] != null)
            {
                id1 = Convert.ToInt32(Request.QueryString["id1"].ToString());
            }
            var ddList2 = (from m in db.tb_UnitMaster
                           select new
                           {
                               Name = m.UnitName,
                               ID = m.UnitId
                           });
            var selectList2 = new SelectList(ddList2, "ID", "Name", id1);
            ViewData["Unitlist"] = selectList2;


        }
        private void setdata(Int32 id)
        {
            var model = (from m in db.tb_LessionMaster
                         where m.LessionId == id
                         select m).Single();

            ViewData["Subjectid"] = model.SubjectId;

            //var model1 = (from m in db.tb_ClassMaster
            //              where m.ClassesId == model.ClassId
            //              select m).Single();

            //var model2 = (from m in db.tb_UnitMaster
            //              where m.UnitId == model.UnitId
            //              select m).Single();

            //ViewData["classname"] = model1.ClassName;
            //ViewData["unitname"] = model2.UnitName;


            //ViewData["LessonClassname"] = model1.ClassName;
            //ViewData["LessonUnitname"] = model2.UnitName;



            // ViewData["classid"] = model.ClassId;
            // ViewData["UnitId"] = model.UnitId;

        }
        public ActionResult edit(Int32 id)
        {
            // setView();
            displaybutton(id);
            SubjectList();
            ViewData["buttonname"] = 2;
            setdata(id);

            var model = (from m in db.tb_LessionMaster
                         where m.LessionId == id
                         select m).Single();


            return View(model);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(HttpPostedFileBase file, Int32 id, tb_LessionMaster model1)
        {
            //setView();
            try
            {
                displaybutton(id);
                SubjectList();
                setdata(id);
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                string filename3 = "";
                if (ValidateData(model1))
                {
                    file = Request.Files[0];
                    if (file.ContentLength < 2000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png")
                        {
                            string randName = emailSystem.CreateRandomPassword(8);
                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath);
                        }
                    }

            



                    var model = (from m in db.tb_LessionMaster
                                 where m.LessionId == id
                                 select m).Single();

                    Int32 Teacherid = model.TeacherId == null ? 0 : Convert.ToInt32(model.TeacherId);

                    SetTeacherEmail(Teacherid, Convert.ToInt32(id));


                    if (filename3 != "")
                    {
                        model.SlideImage = filename3;
                    }

                    model.LessionDesc = model1.LessionDesc;
                    model.DisplayOrder = model1.DisplayOrder;
                    model.LessionHeading = model1.LessionHeading;
                    model.TeacherId = model1.TeacherId;
                    model.PassingScore = model1.PassingScore;
                    model.SlideDescription = model1.SlideDescription;
                    model.Publish = model1.Publish;
                    if (filename1 != "")
                    {
                        model.imagePath = filename1;
                    }
                    if (filename2 != "")
                    {
                        model.graphics = filename2;
                    }
                    db.SaveChanges();

                    ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(2);

                    //Sending Email to teacher Current Teacher
                    Teacherid = model1.TeacherId == null ? 0 : Convert.ToInt32(model1.TeacherId);
                    SetTeacherEmail(Teacherid, Convert.ToInt32(model.LessionId));

                    return RedirectToAction("Index");
                    //var tb1 = new tb_LessionMaster();
                    //return View(tb1);

                }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();

        }
        public ActionResult delete(Int32 id)
        {
            displaybutton(0);
            SubjectList();
            setdata(id);
            ViewData["buttonname"] = 3;
            var model = (from m in db.tb_LessionMaster
                         where m.LessionId == id
                         select m).Single();


            return View(model);

        }
        private void SetTeacherEmail(Int32 TeacherId, Int32 LessonId)
        {
            if (TeacherId > 0)
            {
                var item1 = (from m in db.tb_emailsDescription
                             where m.Autoid == 15
                             select m).Single();
                String desc = "";
                var model = db.tb_LessionMaster.ToList().Where(x => x.LessionId == LessonId).Single();
                var model1 = db.tb_UserMaster.ToList().Where(x => x.UserId == TeacherId).Single();

                desc = item1.Description;
                String ProductDetail = "";
                ProductDetail += "<br /> Subject : <b>" + clsCommon.getSubjectName(Convert.ToInt32(model.SubjectId)) + "</b>";
                ProductDetail += "<br /> Class : <b>" + clsCommon.getClassNameProduct(Convert.ToInt32(model.ClassId)) + "</b>";
                ProductDetail += "<br /> Unit: <b>" + clsCommon.getUnitName(Convert.ToInt32(model.UnitId)) + "</b>";
                ProductDetail += "<br /> Lesson: <b>" + clsCommon.getLessonName(Convert.ToInt32(model.LessionId)) + "</b>";
                desc = desc.Replace("UserName", model1.ProfileName);
                desc = desc.Replace("ProductDetail", ProductDetail);
                emailSystem.sendNewFormat(model1.EmailID, item1.EmailSubject, desc);
            }


        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // setView();
            try
            {
                var model = db.tb_LessionMasterSlides.ToList().Where(x => x.LessionId == id);
                if (model.Count() == 0)
                {
                    setdata(id);
                    displaybutton(0);
                    ViewData["buttonname"] = 3;
                    SubjectList();
                    var tb = (from m in db.tb_LessionMaster
                              where m.LessionId == id
                              select m).Single();

                    db.tb_LessionMaster.Remove(tb);
                    db.SaveChanges();

                    ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
                    return RedirectToAction("Index");
                }
                else
                {


                    ViewData["errormsg"] = clsCommon.ErrorMessage(4);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(4);
                }

            }
            catch
            {

            }
            return View();
        }
    }
}
