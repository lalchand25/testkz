using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class NotePadController : Controller
    {
        //
        // GET: /Subject/


        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Int32 UserId = Convert.ToInt32(Session["pmsuserid"]);

            var Llist = (from m in db.tb_NotePadMaster
                         from t in db.tb_LessionMasterSlides
                         from p in db.tb_UserMaster
                         where m.SlideId == t.AutoId
                         && m.UserId == UserId && p.UserId == m.StudentId
                         select new
                         {
                             SlideName = t.SlideDescription,
                             AutoId = m.AutoId,
                             SlideId = t.SlideId,
                             Comments = m.Comments,
                             UserName = p.UserName
                         }
                        );



            string strTable = "";
            int countrow = 0;
            foreach (var item in Llist)
            {
                if (countrow == 0)
                {
                    strTable += "<tr>";
                    countrow = 1;
                }
                if (countrow == 1)
                {
                    strTable += "<tr class='table_col'>";
                    countrow = 0;
                }
                strTable += "<td>" + item.Comments + "</td>";
                strTable += "<td>" + item.SlideName + "</td>";
                strTable += "<td>" + item.UserName + "</td>";
                strTable += "</tr>";

                //    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/subject/edit/" + item.SubjectId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                //    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/subject/Delete/" + item.SubjectId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
            }
            ViewData["data"] = strTable;

            return View();
        }

        //
        // GET: /Subject/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create(Int32 id)
        {
            CommentsSetting(id);
            Session.Add("ModuleName0", "NotePad");
            ViewData["buttonname"] = 1;
            return View();
        }
        private Boolean ValidateData(tb_NotePadMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.Comments))
                ViewData.ModelState.AddModelError("Comments", "Please enter   Comments!");


            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_NotePadMaster model, Int32 id)
        {
            ViewData["buttonname"] = 1;
            try
            {
                if (Request.HttpMethod == "POST")
                {
                    if (ValidateData(model))
                    {
                        model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                        model.StudentId = Convert.ToInt32(Session["StudentId"]);

                        model.SlideId = id;
                        model.CompanyId = 0;
                        model.LessonId = 0;
                        model.SystemDate = DateTime.Now;
                        model.IpAddress = Request.ServerVariables["remote_address"];
                        db.tb_NotePadMaster.Add(model);
                        db.SaveChanges();
                        ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                        ViewData["msgStatus"] = clsCommon.ErrorMessage(1);

                    }
                }
            }
            catch
            {

            }
            var tb = new tb_NotePadMaster();
            return View(tb);
        }


        //
        // GET: /Subject/Edit/5

        public ActionResult Edit(int id)
        {
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_Feedback
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_Feedback model)
        {
            try
            {
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                var tb = (from m in db.tb_Feedback
                          where m.SubjectId == id
                          select m).Single();

                HttpPostedFileBase file = Request.Files[0];
                String FileExtension = Path.GetExtension(file.FileName).ToLower();
                if (file.ContentLength < 2000000)
                {

                    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                    {

                        string randName = emailSystem.CreateRandomPassword(8);

                        filename1 = randName + "_" + file.FileName;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                        file.SaveAs(filePath);
                    }
                }






                if (filename1 != "")
                {
                    tb.ImagePath = filename1;
                }

                tb.Description = model.Description;


                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);

                var tb1 = new tb_Feedback();
                return View(tb1);
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;

                return View();
            }
        }

        private void CommentsSetting(Int32 SlideId)
        {
            var userid = Convert.ToInt32(Session["pmsuserid"]);

            //var model = db.tb_NotePadMaster.ToList().Where(x => x.SlideId == SlideId && x.StudentId == userid);
            var model = db.tb_NotePadMaster.ToList().Where(x => x.UserId == userid);
            model = model.OrderByDescending(x => x.AutoId);

            string html = "";
            // html += "<table width='100%' align='' style='background-color:white;'>";
            //  html += "<tr><td align='left' valign='top' colspan='2'><h3>User Comments:-<h3></td></tr>";
            int countrow = 0;
            foreach (var item in model)
            {
                if (countrow == 0)
                {
                    html += "<tr>";
                    countrow = 1;
                }
                else
                {
                    html += "<tr class='table_col'>";
                    countrow = 0;
                }

                html += " <td align='left' valign='top'>" + item.Comments + "</td><td align='left' valign='top'>" + item.SystemDate + "</td></tr>";
            }
            //  html += "</table>";
            ViewData["comments"] = html;

        }

        //
        // GET: /Subject/Delete/5

        public ActionResult Delete(int id)
        {
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_Feedback
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
                var tb = (from m in db.tb_Feedback
                          where m.AutoId == id
                          select m).Single();

                db.tb_Feedback.Remove(tb);
                db.SaveChanges();
                var tb1 = new tb_Feedback();

                ViewData["errormsg"] = clsCommon.ErrorMessage(3);

                return View(tb1);
            }
            catch
            {
                return View();
            }
        }
    }
}
