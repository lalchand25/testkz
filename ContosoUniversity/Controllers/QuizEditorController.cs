using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
using System.IO;
namespace OLProject.Controllers
{
    public class QuizEditorController : Controller
    {
        // GET: /QuizEditor/
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Quiz Editor");
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

            var model = db.tb_QuizMaster.ToList().Where(x => x.SlideId == LessonId);
            if (model.Count() > 0)
            {
                var model1 = db.tb_QuizMaster.ToList().Where(x => x.SlideId == LessonId).Single();

                GetDetail(model1.AutoId);
                return View(model1);
            }

            return View();
            
        }
        private void GetDetail(Int32 RefId)
        {
            var model = db.tb_QuizDetail.ToList().Where(x => x.RefId == RefId);
            Session.Add("QuizRefId", RefId);
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
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mc/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mc/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }
                if (item.QuesTypeId == 2)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>" + item.ActualAns + "</td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mCOrrect/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mCOrrect/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }
                if (item.QuesTypeId == 3)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>" + item.ActualAns + "</td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/truefalse/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/truefalse/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }

                if (item.QuesTypeId == 4)
                {
                    strTable += "<td><img src='../../uploads/" + item.Ans1 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td><img src='../../uploads/" + item.Ans2 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td><img src='../../uploads/" + item.Ans3 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td><img src='../../uploads/" + item.Ans4 + "' width='32' height='32' alt='img'/></td>";
                    strTable += "<td align='center'>" + item.ActualAns + "</td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/imgchoice/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/imgchoice/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }
                if (item.QuesTypeId == 5)
                {
                    strTable += "<td>" + item.Ans1 + "</td>";
                    strTable += "<td>" + item.Ans2 + "</td>";
                    strTable += "<td>" + item.Ans3 + "</td>";
                    strTable += "<td>" + item.Ans4 + "</td>";
                    strTable += "<td align='center'>  " + item.ActualAns + "</td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mcImage/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/mcImage/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Delete.png' border='0'   alt='Image' style='width:50px;Height:50px;'/></a></td>";
                }

                strTable += "</tr>";
            }
            ViewData["data"] = strTable;
        
        }
        // GET: /QuizEditor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Silverlight(int id)
        { 
            Session.Add("siteurl", "http://demo.gsmmastersonline.com/ClientBin/OLSilverlight.xap");
            //Session.Add("siteurl", "http://localhost:52878/ClientBin/OLSilverlight.xap");
            Session.Add("QuizPagePara", id);
 
            return View();
        }
        public ActionResult Create()
        { 
            ViewData["buttonname"] = 1;
            //SubjectList();
            return View();
        }
        private Boolean ValidateData(tb_QuizMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.QuizHeading))
                ViewData.ModelState.AddModelError("QuizHeading", "Please Enter   Name!");

            if (string.IsNullOrEmpty(model.QuizDesc))
                ViewData.ModelState.AddModelError("QuizDesc", "Please Enter  Description!");

            if (string.IsNullOrEmpty(model.IfFail))
                ViewData.ModelState.AddModelError("IfFail", "Please enter If Fail!");

            if (string.IsNullOrEmpty(model.IfPass))
                ViewData.ModelState.AddModelError("IfPass", "Please enter If Pass!");

            if (model.QuizPassingScore == null || model.QuizPassingScore == 0)
                ViewData.ModelState.AddModelError("TestPassingScore", "Please enter Test Passing Score!");


            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_QuizMaster model)
        {
            
            ViewData["buttonname"] = 1;
            try
            {
                string filename1 = "";
                if (ValidateData(model))
                {
                    model.LessonId = Convert.ToInt32(Session["clessionid"]);
                    model.SlideId = Convert.ToInt32(Session["LessonIdP"]);
                    model.CompanyId = 0;
                    model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                    model.SystemDate = DateTime.Now;
                    model.IpAddress = Request.ServerVariables["remote_address"];
                    db.tb_QuizMaster.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);

                    var tb1 = new tb_QuizMaster();
                    return View(tb1);

                }
            }

            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_QuizMaster
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_QuizMaster model)
        {
            try
            {
                
                ViewData["buttonname"] = 2;
             

                if (ValidateData(model))
                {

                    var tb = (from m in db.tb_QuizMaster
                              where m.AutoId == id
                              select m).Single();
                    


                    tb.QuizHeading = model.QuizHeading;
                    tb.QuizDesc = model.QuizDesc;
                   
                    tb.IfFail = model.IfFail;
                    tb.IfPass = model.IfPass;
                    tb.RandomOrder = model.RandomOrder;
                    tb.ShowIntroPage = model.ShowIntroPage;
                    tb.QuizPassingScore = model.QuizPassingScore;

                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(2);

                    var tb1 = new tb_QuizMaster();
                    return View(tb1);
                }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();
        }
        public ActionResult Delete(int id)
        { 
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_QuizMaster
                      where m.AutoId == id
                      select m).Single();
            return View(tb);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                
                var tb = (from m in db.tb_QuizMaster
                          where m.AutoId == id
                          select m).Single();
                db.tb_QuizMaster.Remove(tb);

                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(3);

                var tb1 = new tb_QuizMaster();
                return View(tb1);

            }
            catch
            {
                return View();
            }
        }
    }
}
