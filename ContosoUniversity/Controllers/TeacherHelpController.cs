using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class TeacherHelpController : Controller
    {
        //
        // GET: /Subject/


        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Int32 teacherid = 0;

            Int32 UserId = Convert.ToInt32(Session["pmsuserid"]);
            if (Session["teacheridassined"] != null)
            {
                teacherid = Convert.ToInt32(Session["teacheridassined"]);
            }

            var Llist = db.tb_TeacherHelp.ToList().AsQueryable();
            // admin 8, stu 9, parent 2 , teach 3
            if (Convert.ToInt32(Session["cateid"]) == 9)
            {
                Llist = Llist.Where(x => x.UserId == UserId && x.TeacherId == teacherid);
            }
            if (Convert.ToInt32(Session["cateid"]) == 3)
            {
                Llist = Llist.Where(x => x.UserId == UserId || x.TeacherId == UserId);
            }


            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.Subject + "</td>";
                strTable += "<td>" + item.Description + "</td>";
                strTable += "<td>" + item.Teacherreply + "</td>";

                if (item.StatusReply == true)
                {
                    strTable += "<td align='center' valign='top'>Replied</td>";
                }
                else
                {
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/TeacherHelp/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                }
                strTable += "</tr>";
            }
            ViewData["data"] = strTable;
            return View();
        }


        public ActionResult IndexTeacher(Int32 id)
        {


            Int32 UserId = Convert.ToInt32(Session["pmsuserid"]);


            var Llist = db.tb_TeacherHelp.ToList().AsQueryable();
            // admin 8, stu 9, parent 2 , teach 3
            if (Convert.ToInt32(Session["cateid"]) == 9)
            {
                // Llist = Llist.Where(x => x.UserId == UserId || x.TeacherId == teacherid);
            }
            if (Convert.ToInt32(Session["cateid"]) == 3)
            {
                Llist = Llist.Where(x => (x.TeacherId == UserId && x.UserId == id));
            }


            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.Subject + "</td>";
                strTable += "<td>" + item.Description + "</td>";
                strTable += "<td>" + item.Teacherreply + "</td>";

                if (item.StatusReply == true)
                {
                    strTable += "<td align='center' valign='top'>Replied</td>";
                }
                else
                {
                    strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/TeacherHelp/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                }
                strTable += "</tr>";
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
            Session.Add("ModuleName0", "Teacher Help Menu");
            ViewData["buttonname"] = 1;

            Int32 teacherid = 0;

            Int32 UserId = Convert.ToInt32(Session["pmsuserid"]);
            //if (Session["teacheridassined"] != null)
            if (Session["teacheridSub"] != null)
            {
                //teacherid = Convert.ToInt32(Session["teacheridassined"]);
                teacherid = Convert.ToInt32(Session["teacheridSub"]);


            }

            var Llist = db.tb_TeacherHelp.ToList().AsQueryable();
            // admin 8, stu 9, parent 2 , teach 3
            if (Convert.ToInt32(Session["cateid"]) == 9)
            {
                Llist = Llist.Where(x => x.UserId == UserId && x.TeacherId == teacherid);
            }
            if (Convert.ToInt32(Session["cateid"]) == 3)
            {
                Llist = Llist.Where(x => x.TeacherId == UserId);
            }

            int countrow = 0;
            string strTable = "";
            foreach (var item in Llist)
            {

                if (countrow == 0)
                {
                    strTable += "<tr>";
                    countrow = 1;
                }
                else
                {
                    strTable += "<tr class='table_col'>";
                    countrow = 0;
                }
                strTable += "<td>" + item.Subject + "</td>";
                strTable += "<td>" + item.Description + "</td>";
                strTable += "<td>" + item.Teacherreply + "</td>";

                if (item.StatusReply == true)
                {
                    strTable += "<td align='center' valign='top'>Replied</td>";
                }
                else
                {
                    if (Convert.ToInt32(Session["cateid"]) == 3)
                    {
                        strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/TeacherHelp/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a></td>";
                    }
                    else
                    {
                        strTable += "<td> </td>";
                    }
                }
                strTable += "</tr>";
            }
            ViewData["data"] = strTable;


            return View();
        }
        private Boolean ValidateData(tb_TeacherHelp model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.Subject))
                ViewData.ModelState.AddModelError("Subject", "Please enter   Subject!");
            if (string.IsNullOrEmpty(model.Description))
                ViewData.ModelState.AddModelError("Description", "Please enter   Description!");

            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_TeacherHelp model, Int32 id)
        {
            Int32 subjectid = 0;
            Int32 lessionid = 0;
            ViewData["buttonname"] = 1;
            try
            {
                Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
                var modelUser = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();
              //  var modelSlide2 = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == id);
                string strQuery = "select * from tb_LessionMasterSlides where autoid = "+ id  ;
                IEnumerable<tb_LessionMasterSlides> modelSlide = db.Database.SqlQuery<tb_LessionMasterSlides>(strQuery);

                if (modelSlide.Count() > 0)
                {
                    var modelSlide1L = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == id).Single();
                    //int LessionId = db.Database.SqlQuery<int>("Select LessionId  from tb_LessionMasterSlides where AutoId ="+id).FirstOrDefault<int>();
                    tb_LessionMasterSlides Lessiontb = db.Database.SqlQuery<tb_LessionMasterSlides>("Select *  from tb_LessionMasterSlides where AutoId =" + id).FirstOrDefault<tb_LessionMasterSlides>();

                    tb_LessionMaster Lesson = db.Database.SqlQuery<tb_LessionMaster>("Select *  from tb_LessionMaster where LessionId =" + Lessiontb.LessionId).FirstOrDefault<tb_LessionMaster>();

                   // var Lesson = db.tb_LessionMaster.ToList().Where(x => x.LessionId == LessionId.LessionId).Single();
                    subjectid = Convert.ToInt32(Lesson.SubjectId);
                    lessionid = Convert.ToInt32(Lesson.LessionId);
                }

                string filename1 = "";

                if (Request.HttpMethod == "POST")
                {
                    if (ValidateData(model))
                    {
                        HttpPostedFileBase file = Request.Files[0];
                        if (file.ContentLength < 2000000)
                        {
                            String FileExtension = Path.GetExtension(file.FileName).ToLower();
                            if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                            {
                                string randName = emailSystem.CreateRandomPassword(8);

                                filename1 = randName + "_" + file.FileName;
                                string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                                file.SaveAs(filePath);
                            }
                        }




                        model.ImagePath = filename1;

                        model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                        model.StudentId = Convert.ToInt32(Session["StudentId"]);
                        model.SlideId = id;
                        model.TeacherId = Convert.ToInt32(Session["teacheridSub"]);
                        model.SubjectId = subjectid;
                        model.LessonId = lessionid;
                        //     model.ClassId = classid;
                        model.StatusReply = false;
                        model.SystemDate = DateTime.Now;
                        model.Ipaddress = Request.ServerVariables["remote_address"];
                        db.tb_TeacherHelp.Add(model);
                        db.SaveChanges();



                        //If Subject is done
                        var item3 = (from m in db.tb_emailsDescription
                                     where m.Autoid == 22
                                     select m).Single();
                        String desc = "";
                        desc = item3.Description;
                        String ProductDetail = "";

                        ProductDetail += "<br /> Student Name : <b>" + modelUser.UserName + "</b>";
                        ProductDetail += "<br /> Student ID : <b>" + modelUser.UserId + "@Student</b>";

                        ProductDetail += "<br /> Help Description: <b>";
                        ProductDetail += "<br /> " + model.Description;
                        ProductDetail += "<br /> Course : <b>" + clsCommon.getSubjectName(Convert.ToInt32(subjectid)) + "</b>";


                        ProductDetail += "<br /> Lesson: <b>" + clsCommon.getLessonName(Convert.ToInt32(lessionid)) + "</b>";
                        if (model.ImagePath != null && model.ImagePath != "")
                        {
                            ProductDetail += "<br /> Image Description<br /><img src='http://www.kzonline.org/uploads/" + model.ImagePath + "' border='0'   alt='Delete' style='width:50px;Height:50px;'/> ";
                        }
                        desc = desc.Replace("UserName", "Hi " + modelUser.FirstName);
                        desc = desc.Replace("Detail", ProductDetail);
                        emailSystem.sendNewFormat(modelUser.EmailID, item3.EmailSubject, desc);

                        Int32 teacherid = 3;

                        if (Session["teacheridSub"] != null)
                        {
                            teacherid = Convert.ToInt32(Session["teacheridassined"]);
                        }

                        if (teacherid > 0)
                        {
                            var modelUser1 = db.tb_UserMaster.ToList().Where(x => x.UserId == teacherid).Single();
                            emailSystem.sendNewFormat(modelUser1.EmailID, item3.EmailSubject, desc);
                        }

                        ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                        ViewData["msgStatus"] = clsCommon.ErrorMessage(1);



                        var tb = new tb_TeacherHelp();
                        return View(tb);
                    }
                }
            }
            catch
            {

            }
            return View();
        }


        //
        // GET: /Subject/Edit/5

        public ActionResult Edit(int id)
        {
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_TeacherHelp
                         where m.AutoId == id
                         select m).Single();
            ViewData["subject"] = model.Subject;
            ViewData["desc"] = model.Description;
            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_TeacherHelp model)
        {
            try
            {
                Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
                var modelUser = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();
                ViewData["buttonname"] = 2;

                var tb = (from m in db.tb_TeacherHelp
                          where m.AutoId == id
                          select m).Single();
                tb.Teacherreply = model.Teacherreply;
                tb.ReplyDate = DateTime.Now;
                tb.StatusReply = true;

                tb.Ipaddress = Request.ServerVariables["remote_address"]; ;
                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);

                Int32 SlideId = Convert.ToInt32(tb.SlideId);

                var modelSlide = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == SlideId).Single();
                var Lesson = db.tb_LessionMaster.ToList().Where(x => x.LessionId == modelSlide.LessionId).Single();

                var item3 = (from m in db.tb_emailsDescription
                             where m.Autoid == 22
                             select m).Single();
                String desc = "";
                desc = item3.Description;
                String ProductDetail = "";
                ProductDetail += "<br /> Help Description: <b>";
                ProductDetail += "<br /> " + model.Description;
                ProductDetail += "<br />Reply: " + model.Teacherreply;
                ProductDetail += "<br /> Subject : <b>" + clsCommon.getSubjectName(Convert.ToInt32(Lesson.SubjectId)) + "</b>";
                ProductDetail += "<br /> Class : <b>" + clsCommon.getClassNameProduct(Convert.ToInt32(Lesson.ClassId)) + "</b>";
                ProductDetail += "<br /> Unit: <b>" + clsCommon.getUnitName(Convert.ToInt32(Lesson.UnitId)) + "</b>";
                ProductDetail += "<br /> Lesson: <b>" + clsCommon.getLessonName(Convert.ToInt32(Lesson.LessionId)) + "</b>";

                desc = desc.Replace("UserName", modelUser.ProfileName);
                desc = desc.Replace("Detail", ProductDetail);

                emailSystem.sendNewFormat(modelUser.EmailID, item3.EmailSubject, desc);
                Int32 StudentId = Convert.ToInt32(tb.StudentId);

                if (StudentId > 0)
                {
                    var modelUser1 = db.tb_UserMaster.ToList().Where(x => x.UserId == StudentId).Single();
                    emailSystem.sendNewFormat(modelUser1.EmailID, item3.EmailSubject, desc);
                }

                ViewData["buttonname"] = 2;

                ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);


                var tb1 = new tb_TeacherHelp();

                return View(tb1);

            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
                ViewData["msgStatus"] = ce.Message;

                return View();
            }
        }

        //
        // GET: /Subject/Delete/5

        public ActionResult Delete(int id)
        {
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_TeacherHelp
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
                var tb = (from m in db.tb_TeacherHelp
                          where m.AutoId == id
                          select m).Single();

                db.tb_TeacherHelp.Remove(tb);
                db.SaveChanges();
                var tb1 = new tb_TeacherHelp();

                ViewData["errormsg"] = clsCommon.ErrorMessage(3);

                return View(tb1);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult myStudents()
        {
            int useridn = 0;
            var model = from m in db.tb_SubjectMaster select m;

            if (Convert.ToInt32(Session["cateid"]) == 3)
            {
                useridn = Convert.ToInt32(Session["pmsuserid"]);

                model = model.Where(x => x.UserId == useridn);

            }





            return View(model.ToList());
        }


    }
}
