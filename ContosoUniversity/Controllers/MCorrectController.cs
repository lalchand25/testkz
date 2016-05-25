using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;

namespace OLProject.Controllers
{
    public class MCorrectController : Controller
    {
        //
        // GET: /Subject/

        
        kzonlineEntities db = new kzonlineEntities();

        public ActionResult Index()
        {
            Int32 SlideId = 0;
            if (Request.QueryString["SlideId"] != null)
            {
                SlideId = Convert.ToInt32(Request.QueryString["SlideId"].ToString());
                Session.Add("psSlideId", SlideId);
            }

            var model = db.tb_QuizDetail.ToList().Where(x => x.QuesTypeId == 2 && x.SlideId == SlideId);

            String strTable = "";
            foreach (var item in model)
            {
                strTable += "<tr>";
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
                    //strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mc/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                   // strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mc/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";

                    strTable += "<td align='center' valign='top'> <button class='btn btn-success'  onclick='javascript:OpenPopup(\"/mc/edit/" + item.AutoId + "\");' type='button'><i class='fa fa-edit'></i>Edit</button> </td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-danger' onclick='javascript:OpenPopup(\"/mc/delete/" + item.AutoId + "\");' type='button'><i class='fa fa-trash-o'></i>Delete</button> </td>";

                }
                if (item.QuesTypeId == 2)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>" + item.ActualAns + "</td>";
                   // strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mCOrrect/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                   // strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mCOrrect/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-success'  onclick='javascript:OpenPopup(\"/mCOrrect/edit/" + item.AutoId + "\");' type='button'><i class='fa fa-edit'></i>Edit</button> </td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-danger' onclick='javascript:OpenPopup(\"/mCOrrect/delete/" + item.AutoId + "\");' type='button'><i class='fa fa-trash-o'></i>Delete</button> </td>";

                }
                if (item.QuesTypeId == 3)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>" + item.ActualAns + "</td>";
  //                  strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/truefalse/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
//                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/truefalse/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-success'  onclick='javascript:OpenPopup(\"/truefalse/edit/" + item.AutoId + "\");' type='button'><i class='fa fa-edit'></i>Edit</button> </td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-danger' onclick='javascript:OpenPopup(\"/truefalse/delete/" + item.AutoId + "\");' type='button'><i class='fa fa-trash-o'></i>Delete</button> </td>";


                }

                if (item.QuesTypeId == 4)
                {
                    strTable += "<td><img src='../../uploads/" + item.Ans1 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td><img src='../../uploads/" + item.Ans2 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td><img src='../../uploads/" + item.Ans3 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td><img src='../../uploads/" + item.Ans4 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td align='center'>" + item.ActualAns + "</td>";
                   // strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/imgchoice/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                   // strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/imgchoice/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-success'  onclick='javascript:OpenPopup(\"/imgchoice/edit/" + item.AutoId + "\");' type='button'><i class='fa fa-edit'></i>Edit</button> </td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-danger' onclick='javascript:OpenPopup(\"/imgchoice/delete/" + item.AutoId + "\");' type='button'><i class='fa fa-trash-o'></i>Delete</button> </td>";

                }
                if (item.QuesTypeId == 5)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>  " + item.ActualAns + "</td>";
                 //   strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mcImage/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                  //  strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup1(&#34;/mcImage/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";

                    strTable += "<td align='center' valign='top'> <button class='btn btn-success'  onclick='javascript:OpenPopup(\"/mcImage/edit/" + item.AutoId + "\");' type='button'><i class='fa fa-edit'></i>Edit</button> </td>";
                    strTable += "<td align='center' valign='top'> <button class='btn btn-danger' onclick='javascript:OpenPopup(\"/mcImage/delete/" + item.AutoId + "\");' type='button'><i class='fa fa-trash-o'></i>Delete</button> </td>";

                }

                strTable += "</tr>";
            }
            ViewData["data"] = strTable;
            return View();
        }

        // ****************************************************************************
        // ****************************************************************************
        [ValidateInput(false)]
        public ActionResult PopupHelp(int id, tb_QuizDetail model)
        {
            var model1 = (from m in db.tb_QuizDetail where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.HelpQuiz = model.HelpQuiz; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupFormula(int id, tb_QuizDetail model)
        {
            var model1 = (from m in db.tb_QuizDetail where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.Formulas = model.Formulas; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupUsefulTips(int id, tb_QuizDetail model)
        {
            var model1 = (from m in db.tb_QuizDetail where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.UsefulTips = model.UsefulTips; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupSolution(int id, tb_QuizDetail model)
        {
            var model1 = (from m in db.tb_QuizDetail where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.Solution = model.Solution; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupQuestion(int id, tb_QuizDetail model)
        {
            var model1 = (from m in db.tb_QuizDetail where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.Question = model.Question; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        [ValidateInput(false)]
        public ActionResult PopupTutorial(int id, tb_QuizDetail model)
        {
            var model1 = (from m in db.tb_QuizDetail where m.AutoId == id select m).Single();
            if (Request.HttpMethod == "POST") { model1.Tutorial = model.Tutorial; db.SaveChanges(); }
            ViewData["errormsg"] = clsCommon.ErrorMessage(2);
            return View(model1);
        }
        private string getButton(Int32 SlideId, Int32 Buttonid)
        {
            string result = "";
            var model = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == Convert.ToInt32(Buttonid)).Single();
            if (SlideId > 0)
            {
                var model1 = db.tb_QuizDetail.ToList().Where(x => x.AutoId == Convert.ToInt32(SlideId)).Single();
                if (Buttonid == 1 || Buttonid == 2 || Buttonid == 3 || Buttonid == 4 || Buttonid == 8 || Buttonid == 21 || Buttonid == 22 || Buttonid == 23 || Buttonid == 24 || Buttonid == 25 || Buttonid == 26)
                {
                    if (Buttonid == 1)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/MCorrect/popupHelp/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 3)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/MCorrect/popupUsefulTips/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 2)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/MCorrect/popupSolution/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 4)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/MCorrect/popupQuestion/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 8)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/MCorrect/popupFormula/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 21)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/MCorrect/popupTutorial/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 22)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/MCorrect/popupview/" + SlideId + "?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 23)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup(&#34;/mc/create/?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 24)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup(&#34;/mcorrect/create/?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 25)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup(&#34;/imgchoice/create/?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
                    }
                    else if (Buttonid == 26)
                    {
                        result = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup(&#34;/truefalse/create/?buttonid=" + Buttonid + "&#34;,&#34;Browser" + Buttonid.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
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
            if (buttonid == 21) { result = model.Tutorial; };

            ViewData["results"] = result;
            return View();
        }
        private void displaybutton(Int32 SlideId)
        {
            String Buttons = "";
            Buttons += getButton(SlideId, 13);
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
            Buttons += getButton(SlideId, 9);
            Buttons += getButton(SlideId, 10);
            Buttons += getButton(SlideId, 26);
            Buttons += getButton(SlideId, 25);
            Buttons += getButton(SlideId, 24);
            Buttons += getButton(SlideId, 23);
            Buttons += getButton(SlideId, 22);
            ViewData["topbuttons"] = Buttons;

        }
        public ActionResult popupView(int id)
        {
            var model = (from m in db.tb_QuizDetail
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }
        // ****************************************************************************
        // ****************************************************************************

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            Int32 SlideId = 0;
            if (Request.QueryString["SlideId"] != null)
            {
                SlideId = Convert.ToInt32(Request.QueryString["SlideId"].ToString());
                Session.Add("psSlideId", SlideId);
            }
         
            displaybutton(0);
            ViewData["buttonname"] = 1;
            
            return View();
        }
        private Boolean ValidateData(tb_QuizDetail model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.Decription))
                ViewData.ModelState.AddModelError("Decription", "Please enter   Decription!");

            if (string.IsNullOrEmpty(model.Ans1))
                ViewData.ModelState.AddModelError("Ans1", "Please enter   Ans1!");
            if (string.IsNullOrEmpty(model.Ans2))
                ViewData.ModelState.AddModelError("Ans1", "Please enter   Ans2!");
           
            
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_QuizDetail model)
        {
            Int32 SlideId = 0;
            Int32 LessonId = 0;
            Int32 SubjectID = 0;
            Int32 UnitId = 0;
            Int32 Classid = 0;
            if (Session["psSlideId"] != null)
            {
                SlideId = Convert.ToInt32(Session["psSlideId"]);
                var tmodel = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == SlideId).Single();
                LessonId = Convert.ToInt32(tmodel.LessionId);
                var tmodel1 = db.tb_LessionMaster.ToList().Where(x => x.LessionId == LessonId).Single();
                LessonId = Convert.ToInt32(tmodel.LessionId);
                SubjectID = Convert.ToInt32(tmodel1.SubjectId);
                UnitId = Convert.ToInt32(tmodel1.UnitId);
                Classid = Convert.ToInt32(tmodel1.ClassId);
            }
             
            ViewData["buttonname"] = 1;
            try
            {
                displaybutton(0);
                string filename1 = "";
                string filename2 = "";
                string filename3 = "";
                string filename4 = "";

               
                   
                    if (ValidateData(model) && SlideId>0)
                    {

                        model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                        model.SystemDate = DateTime.Now;

                        model.Check1 = model.Check1 == null || model.Check1 == false ? false : true;
                        model.Check2 = model.Check2 == null || model.Check2 == false ? false : true;
                        model.Check3 = model.Check3 == null || model.Check3 == false ? false : true;
                        model.Check4 = model.Check4 == null || model.Check4 == false ? false : true;

                        model.Check5 = false;
                        model.Check6 = false;
                        model.Check7 = false;
                        model.Check8 = false;

                        
                        Int32 total = 0;
                        if (model.Check1 == true) { total += 1; }
                        if (model.Check2 == true) { total += 2; }
                        if (model.Check3 == true) { total += 3; }
                        if (model.Check4 == true) { total += 4; }
                        model.ActualAns = total;               
                        
                        model.NoneOfAbove = "";
                        model.AllOfAbove = "";
                        model.Ans5 = "";
                        model.Ans6 = "";
                        model.QuesTypeId = 2;
                      
                        model.RefId = 0;
                        model.LessonId = LessonId;
                        model.SubjectId = SubjectID;
                        model.ClassId = Classid;
                        model.UnitId = UnitId;
                        model.SlideId = SlideId;
                        model.IpAddress = Request.ServerVariables["remote_address"];
                        db.tb_QuizDetail.Add(model);
                        db.SaveChanges();
                        ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                        ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                        displaybutton(0);
                        //return RedirectToAction("edit", new { id = model.AutoId }); 
                        
                      
                    }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }

            return View();
        }


        //
        // GET: /Subject/Edit/5
 
        public ActionResult Edit(int id)
        {
            displaybutton(id);
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_QuizDetail
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
         [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_QuizDetail model)
        {
            try
            {
                displaybutton(id);
          
               
                ViewData["buttonname"] = 2;

                var model1 = (from m in db.tb_QuizDetail
                             where m.AutoId == id
                             select m).Single();
                
                    
                    if (ValidateData(model))
                    {
                        model1.Check1 = false;
                        model1.Check2 = false;
                        model1.Check3 = false;
                        model1.Check4 = false;
                        model1.Check5 = false;
                        model1.Check6 = false;
                        model1.Check7 = false;
                        model1.Check8 = false;

                        Int32 total = 0;
                        if (model.Check1 == true) { total += 1; }
                        if (model.Check2 == true) { total += 2; }
                        if (model.Check3 == true) { total += 3; }
                        if (model.Check4 == true) { total += 4; }
                        model.ActualAns = total;

                        model1.Check1 = model.Check1;
                        model1.Check2 = model.Check2;
                        model1.Check3 = model.Check3;
                        model1.Check4 = model.Check4;

                        model1.NoTries = model.NoTries;
                        model1.PointValue = model.PointValue;
                        model1.Ans1 = model.Ans1;
                        model1.Ans2 = model.Ans2;
                        model1.Ans3 = model.Ans3;
                        model1.Ans4 = model.Ans4;
                        model1.ActualAns = model.ActualAns;
                        model1.Decription = model.Decription;
                        model1.ShowInExam = model.ShowInExam;
                        db.SaveChanges();
                        ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                        displaybutton(0);
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
            displaybutton(0);
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_QuizDetail
                      where m.AutoId == id
                      select m).Single();
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


                var model = db.tb_QuizTestMasterDetail.ToList().Where(x => x.AutoId == id);
                if (model.Count() == 0)
                {
                    var tb = (from m in db.tb_QuizDetail
                              where m.AutoId == id
                              select m).Single();
                    db.tb_QuizDetail.Remove(tb);

                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                    displaybutton(0);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
                    var tb1 = new tb_QuizDetail();
                    return View(tb1);
                }
                else
                {
                    ViewData["errormsg"] = clsCommon.ErrorMessage(4);
                    displaybutton(0);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(4);

                }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }

            return View();
        }
    }
}
