using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class Theme5TempController : Controller
    {
        // GET: /Subject/
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult SlideShow(Int32 id)
        {
            ViewData["selectTheme"] = " <a href='javascript:OpenPopup(&#34;/Slides/thememain/" + Session["clessionid"] + "&#34;);' class='btn-grey' runat='server' >Select Theme</a>";
            var model = db.tb_LessionMasterSlides.ToList().AsQueryable().Where(x => x.LessionId == Convert.ToInt32(id));
            string html = "";
            if (model.Count() > 0)
            {
                html = "<table width=100%' align='center'>";
                foreach (var item in model)
                {
                    html += "<h2>" + item.SlideDescription + "</h2>";
                    html += "<table width='95%' align='center'>";
                    if (item.UploadTypeId == 1)
                    {

                        html += "<tr><td align='center'> " + item.ImageDescription + "</td></tr>";
                    }
                    if (item.UploadTypeId == 2)
                    {

                        html += "<table width='95%' align='center'>";
                        html += "<tr><td align='center'><p><img src='../../uploads/" + item.ImagePath + "' /></p></td></tr>";
                        html += "<tr><td align='center'> " + item.ImageDescription + "</td></tr>";
                    }
                    if (item.UploadTypeId == 3)
                    {

                        html += "<video width='320' height='240' controls autoplay>";
                        html += "<source src='../../uploads/" + item.ImagePath + "' type='video/mp4'>";
                        html += "</video>";

                    }
                    if (item.UploadTypeId == 4)
                    {

                        html += " <audio controls>";
                        html += "<source src='../../uploads/" + item.ImagePath + "' type='audio/mpeg'></audio>";
                    }


                    if (item.UploadTypeId == 5) //flsash
                    {
                        html += "<OBJECT classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' ";
                        html += "codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0' ";
                        html += "WIDTH='320' HEIGHT='240' id='Puggle' ALIGN=''>";
                        html += "<PARAM NAME=movie VALUE='../../uploads/" + item.ImagePath + "'> ";
                        html += "<PARAM NAME=quality VALUE=high>";
                        html += "<PARAM NAME=bgcolor VALUE=#333399>";
                        html += "<EMBED src='../../uploads/" + item.ImagePath + "' quality=high bgcolor=#333399 WIDTH='520' HEIGHT='440' NAME='Yourfilename' ALIGN='' TYPE='application/x-shockwave-flash' PLUGINSPAGE='http://www.macromedia.com/go/getflashplayer'></EMBED> </OBJECT>";
                    }
                }
                html += "</table>";
            }
            else
            {

                html = "<h2>Slide not found</h2>";

            }
            ViewData["slidedata"] = html;

            return View();
        }
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

        }
        private string getString(Int32 lessonId)
        {
            string result = "";

            var tb = db.tb_ThemeMaster.ToList();
            string strtables = "";
            string strtables1 = "";
            Int32 id = 0;
            
            foreach (var items1 in tb)
            {
                if (id == 0)
                {
                    strtables += "<tr>";
                }
                id += 1;
                
                strtables += "<td width='15%'  align='center'><a href='/Slides/create/" + lessonId + "?themeid=" + items1.ThemeId + "'>";
                strtables += "<img src='../../uploads/" + items1.ImagePath + "' border='0'.   alt='Image' style='width:200px;Height:150px;'/></a><br /><a href='/theme/detail/" + items1.ThemeId + "'></a><br />";
                strtables += "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/theme/detail/" + items1.ThemeId + "&#34;,&#34;Browser" + items1.ThemeId.ToString() + "&#34;);' />Instruction</a></td>";
                if (id == 3)
                {
                    id = 0;
                    strtables += "</tr>";
                    strtables += "<br /><br /><tr><td colspan='3' style='border-bottom:1px solid #c2c2c2;'><img src='../../Images/clr.gif' alt='' width='1' height='15' /></td> </tr>";
                }
    

            }

            if (id == 2)
            {
                id = 0;
                strtables += "</tr>";
            }

            result = strtables;
            return result;
        }
        public ActionResult ThemeMain(Int32 id)
        {
            ViewData["themes"] = getString(id);
            
            return View();
        }
        public ActionResult Index1()
        {
            Int32 LessonId = 0;
            if (Request.QueryString["LessonId"] != null)
            {
                LessonId = Convert.ToInt32(Request.QueryString["LessonId"].ToString());
                Session.Add("LessonIdP", LessonId);
            }
            if (Session["LessonIdP"] != null)
            {
                LessonId = Convert.ToInt32(Session["LessonIdP"].ToString());
            }
            var model = db.tb_QuizMaster.ToList().Where(x => x.CourseId == LessonId);
            if (model.Count() > 0)
            {
                var model1 = db.tb_QuizMaster.ToList().Where(x => x.CourseId == LessonId).Single();
                return View(model1);
            }
            return View();
        }
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Lesson Information");
            Int32 lessonid = 0;
            if (Request.QueryString["LessonId"] != null)
            {
                lessonid = Convert.ToInt32(Request.QueryString["LessonId"].ToString());
                Session.Add("clessionid", lessonid);    
            }
            ViewData["screate"] = " <a href='javascript:OpenPopup(&#34;/Slides/thememain/" + lessonid + "&#34;);' id='A1' runat='server' >";
            var Llist = db.tb_LessionMasterSlides.ToList().Where(x => x.LessionId == lessonid);
            string strTable = "";
            Int32 mcounter = 0;
            foreach (var item in Llist)
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
                strTable += "<td><b><a  href='javascript:OpenPopup(&#34;/SlideShow/Index/" + item.LessionId + "?SlideId=" + item.AutoId + "&#34;);' />" + item.SlideDescription + "</a></b></td>";
                strTable += "<td>" + item.DispOrder + "</td>";
                strTable += "<td align='center' valign='top'><a href='/Exercise/index/?SlideId=" + item.AutoId + "' id='A2' runat='server' ><img src='../../SiteImages/show.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/slides/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/slides/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";

                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mc/Index/?SlideId=" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/add.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mCorrect/Index/?SlideId=" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/badd.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/truefalse/Index/?SlideId=" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/add.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/imgchoice/Index/?SlideId=" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/badd.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mcImage/Index/?SlideId=" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/add.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
       
            }
            ViewData["data"] = strTable;

            return View();
        }
        // GET: /Subject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        private string getButton(Int32 SlideId, Int32 Buttonid)
        {
            string result = "";
            var model = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == Convert.ToInt32(Buttonid)).Single();
            if (SlideId > 0)
            {
                var model1 = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == Convert.ToInt32(SlideId)).Single();
                if (Buttonid == 1 || Buttonid == 2 || Buttonid == 3 || Buttonid == 4 || Buttonid == 8 || Buttonid == 29)
                {
                    if (Buttonid == 1)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slides/popupHelp/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 3 )
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slides/popupUsefulTips/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 2 )
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slides/popupSolution/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 4 )
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slides/popupQuestion/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 8 )
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slides/popupFormula/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath1 + "' /><br />" + model.ButtonName + "</a>";
                    }

                    else if (Buttonid == 29)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/slides/popupspeech/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
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
            var model = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == id).Single();
            string result = "";

            if (buttonid == 1) { result = model.HelpSlide; };
            if (buttonid == 2) { result = model.UsefulTips; };
            if (buttonid == 3) { result = model.Solution; };
            if (buttonid == 4) { result = model.Question; };
            if (buttonid == 8) { result = model.Formula; };

            ViewData["results"] = result;
            return View();
        }
        private void displaybutton(Int32 SlideId)
        {
            String Buttons = "";
            Buttons += getButton(SlideId, 29);
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
    
        private Boolean ValidateData(tb_LessionMasterSlides model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.SlideDescription))
                ViewData.ModelState.AddModelError("SlideDescription", "Please enter   Slide Description !");

            //if (string.IsNullOrEmpty(model.ImagePath))
            //    ViewData.ModelState.AddModelError("ImagePath", "Please enter   Image Not found !");
            //if (string.IsNullOrEmpty(model.ImagePath1))
            //    ViewData.ModelState.AddModelError("ImagePath", "Please enter   Image Not found !");
            //if (string.IsNullOrEmpty(model.ImagePath2))
            //    ViewData.ModelState.AddModelError("ImagePath", "Please enter   Image Not found !");
            //if (string.IsNullOrEmpty(model.ImagePath3))
            //    ViewData.ModelState.AddModelError("ImagePath", "Please enter   Image Not found !");
            //if (string.IsNullOrEmpty(model.ImagePath4))
            //    ViewData.ModelState.AddModelError("ImagePath", "Please enter   Image Not found !");

            if (model.UploadTypeId == 0)
                ViewData.ModelState.AddModelError("UploadTypeId", "Please select a Upload Type Missing !");
            if (model.UploadTypeId1 == 0)
                ViewData.ModelState.AddModelError("UploadTypeId", "Please select a Upload Type Missing !");
            if (model.UploadTypeId2 == 0)
                ViewData.ModelState.AddModelError("UploadTypeId", "Please select a Upload Type Missing !");
            if (model.UploadTypeId3 == 0)
                ViewData.ModelState.AddModelError("UploadTypeId", "Please select a Upload Type Missing !");
            if (model.UploadTypeId4 == 0)
                ViewData.ModelState.AddModelError("UploadTypeId", "Please select a Upload Type Missing !");

            if (model.DispOrder == null)
            {
                ViewData.ModelState.AddModelError("DispOrder", "Please Select Display Order !");
            }
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
        public ActionResult Create(Int32 id)
        {
            displaybutton(0);
            ViewData["selectTheme"] = " <a href='javascript:OpenPopup(&#34;/Slides/thememain/" + Session["clessionid"] + "&#34;);' class='btn-grey' runat='server' >Select Theme</a>";

            setViews();
            Int32 themeid = Convert.ToInt32(Request.QueryString["themeid"]);
            ViewData["themeid"] = themeid;
            Session.Add("themeid", themeid);
            ViewData["buttonname"] = 1;

            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Int32 id, tb_LessionMasterSlides model)
        {
            ViewData["selectTheme"] = " <a href='javascript:OpenPopup(&#34;/Slides/thememain/" + Session["clessionid"] + "&#34;);' class='btn-grey' runat='server' >Select Theme</a>";

            setViews();
            ViewData["buttonname"] = 1;
            try
            {
                ViewData["themes"] = getString(id);
                Int32 themeid = Convert.ToInt32(Session["themeid"]);
                ViewData["themeid"] = themeid;

                string filename1 = "";
                string filename2 = "";
                string filename3 = "";
                string filename4 = "";
                string filename5 = "";
            
                string mystring = "";
                Int32 usermaincateid = 0;
                model.ThemeId = Convert.ToInt32(Session["themeid"]);

              


                if (ValidateData(model))
                {


                    HttpPostedFileBase file = Request.Files[0]; //For Images
                    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (file.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename1 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                        file.SaveAs(filePath);
                    }

                    HttpPostedFileBase file2 = Request.Files[1];
                    FileExtension = Path.GetExtension(file2.FileName).ToLower();
                    if (file2.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename2 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                        file2.SaveAs(filePath);
                    }

                    HttpPostedFileBase file3 = Request.Files[2];
                    FileExtension = Path.GetExtension(file3.FileName).ToLower();
                    if (file3.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename3 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename3);
                        file3.SaveAs(filePath);
                    }

                    HttpPostedFileBase file4 = Request.Files[3];
                    FileExtension = Path.GetExtension(file4.FileName).ToLower();
                    if (file4.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename4 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename4);
                        file4.SaveAs(filePath);
                    }

                    HttpPostedFileBase file5 = Request.Files[4];
                    FileExtension = Path.GetExtension(file5.FileName).ToLower();
                    if (file5.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename5 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename5);
                        file5.SaveAs(filePath);
                    }

                    /**********************************************************************************************/
                    model.SlideDescription = model.SlideDescription;
                    model.DispOrder = model.DispOrder;
                    model.ImageDescription = model.ImageDescription;
                    model.ImagePath = filename1;
                    model.ImagePath1 = filename2;
                    model.ImagePath2 = filename3;
                    model.ImagePath3 = filename4;
                    model.ImagePath4 = filename5;

                    model.Mp3Files = "";
                    model.Mp3Files1 = "";

                    model.LessionId = id;
                    model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                    model.SystemDate = DateTime.Now;
                    model.Ipaddress = Request.ServerVariables["remote_address"];

                    db.tb_LessionMasterSlides.Add(model);
                    db.SaveChanges();
                    ViewData["ShowSlide"] = " <a href='javascript:OpenPopup(&#34;/Slides/SlideShow/" + model.AutoId + "&#34;);' class='btn-grey' runat='server' >Select Theme</a>";

                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);

                }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();
        }
        // GET: /Subject/Edit/5
        [ValidateInput(false)]
        public ActionResult PopupHelp(int id, tb_LessionMasterSlides model)
        {   var model1 = (from m in db.tb_LessionMasterSlides  where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.HelpSlide = model.HelpSlide;db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupFormula(int id, tb_LessionMasterSlides model)
        {
            var model1 = (from m in db.tb_LessionMasterSlides where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.Formula = model.Formula; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupUsefulTips(int id, tb_LessionMasterSlides model)
        {
            var model1 = (from m in db.tb_LessionMasterSlides where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.UsefulTips = model.UsefulTips; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupSolution(int id, tb_LessionMasterSlides model)
        {
            var model1 = (from m in db.tb_LessionMasterSlides where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.Solution = model.Solution; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupQuestion(int id, tb_LessionMasterSlides model)
        {
            var model1 = (from m in db.tb_LessionMasterSlides where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.Question = model.Question; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }

        public ActionResult PopupSpeech(int id, tb_LessionMasterSlides model)
        {
            var model1 = (from m in db.tb_LessionMasterSlides where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.SpeechText = model.SpeechText; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }

        public ActionResult Edit(int id)
        {
            setViews();
            displaybutton(id);
          
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_LessionMasterSlides
                         where m.AutoId == id
                         select m).Single();
           
            Int32 themeid = Convert.ToInt32(model.ThemeId);
            ViewData["themeid"] = themeid;
            Session.Add("themeid", themeid);
            ViewData["uploadtypeid"] = model.UploadTypeId;
            ViewData["uploadtypeid1"] = model.UploadTypeId1;

       
            return View(model);
        }

        //
        // POST: /Subject/Edit/5

        private Int32 getLimiOfSize(string FileExtension)
        {
            Int32 result = 0;
            if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
            {
                result = 5 * 1024 * 1024;
            }
            if (FileExtension == ".swf")
            {
                result = 2 * 1024 * 1024;
            }
            if (FileExtension == ".mp4")
            {
                result = 2 * 1024 * 1024;
            }
            if (FileExtension == ".mp3")
            {
                result = 2 * 1024 * 1024;
            }
            return result;
        }
         [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_LessionMasterSlides model)
        {
            try
            {
                setViews();
                displaybutton(0);
                ViewData["themes"] = getString(id);
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                string filename3 = "";
                string filename4 = "";
                string filename5 = "";
              
                var tb = (from m in db.tb_LessionMasterSlides
                          where m.AutoId == id
                          select m).Single();

                ViewData["themeid"] = tb.ThemeId;
                ViewData["uploadtypeid"] = tb.UploadTypeId;
                ViewData["uploadtypeid1"] = tb.UploadTypeId1;

                //if (filename1 != "") { model.ImagePath = filename1; }
                //if (filename2 != "") { model.ImagePath1 = filename2; }
                //if (filename3 != "") { model.ImagePath2 = filename3; }
                //if (filename4 != "") { model.ImagePath3 = filename4; }
                //if (filename5 != "") { model.ImagePath4 = filename5; }

                if (ValidateData(model))
                {
                    HttpPostedFileBase file = Request.Files[0]; //For Images
                    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (file.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename1 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                        file.SaveAs(filePath);
                    }

                    HttpPostedFileBase file2 = Request.Files[1];
                    FileExtension = Path.GetExtension(file2.FileName).ToLower();
                    if (file2.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename2 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                        file2.SaveAs(filePath);
                    }

                    HttpPostedFileBase file3 = Request.Files[2];
                    FileExtension = Path.GetExtension(file3.FileName).ToLower();
                    if (file3.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename3 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename3);
                        file3.SaveAs(filePath);
                    }

                    HttpPostedFileBase file4 = Request.Files[3];
                    FileExtension = Path.GetExtension(file4.FileName).ToLower();
                    if (file4.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename4 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename4);
                        file4.SaveAs(filePath);
                    }

                    HttpPostedFileBase file5 = Request.Files[4];
                    FileExtension = Path.GetExtension(file5.FileName).ToLower();
                    if (file5.ContentLength < getLimiOfSize(FileExtension))
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        string randName1 = emailSystem.CreateRandomPassword(8);
                        filename5 = randName + "_" + randName1 + FileExtension;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename5);
                        file5.SaveAs(filePath);
                    }

                    /**********************************************************************************************/
                    tb.SlideDescription = model.SlideDescription;
                    tb.DispOrder = model.DispOrder;
                    tb.ImageDescription = model.ImageDescription;

                    if (filename1 != "") { tb.ImagePath = filename1; }
                    if (filename2 != "") { tb.ImagePath1 = filename2; }
                    if (filename3 != "") { tb.ImagePath2 = filename3; }
                    if (filename4 != "") { tb.ImagePath3 = filename4; }
                    if (filename5 != "") { tb.ImagePath4 = filename5; }


                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
                    return View();
                }
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
            var tb = (from m in db.tb_LessionMasterSlides
                      where m.AutoId == id
                      select m).Single();

            ViewData["themeid"] = tb.ThemeId;
            ViewData["uploadtypeid"] = tb.UploadTypeId;
            ViewData["uploadtypeid1"] = tb.UploadTypeId1;

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
                var model = db.tb_QuizDetail.ToList().Where(x => x.SlideId == id);
                if (model.Count() == 0)
                {
                    var tb = (from m in db.tb_LessionMasterSlides
                              where m.AutoId == id
                              select m).Single();
                    ViewData["themeid"] = tb.ThemeId;
                    ViewData["uploadtypeid"] = tb.UploadTypeId;
                    db.tb_LessionMasterSlides.Remove(tb);
                    db.SaveChanges();

                    ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
                    ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                }
                else
                {
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(4);
                    ViewData["errormsg"] = clsCommon.ErrorMessage(4);
                
                }



                var tb1 = new tb_LessionMasterSlides();
                return View(tb1); 
            }
            catch
            {
                return View();
            }
        }
    }
}
