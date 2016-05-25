using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class UsefulTipsController : Controller
    {
        //
        // GET: /Subject/


        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            var Llist = (from m in db.tb_UsefulTips 
                         from t in db.tb_SubjectMaster
                         from k in db.tb_LessionMaster
                         from u in db.tb_UserMaster
                         where m.SubjectId == t.SubjectId && k.LessionId == m.LessonId
                         && u.UserId == m.UserId
                         select new
                         {
                             subjectname = m.Subject,
                             desc = m.Description,
                             subject = t.SubjectName,
                             classid = m.ClassId,
                             lesson = k.LessionHeading,
                             username = u.UserName
                            
                         });

            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.username + "</td>";
                strTable += "<td>" + item.subjectname + "</td>";
                strTable += "<td>" + item.desc + "</td>";
                strTable += "<td>" + item.subject + "</td>";
              //  strTable += "<td>" + clsCommon.getClassNameProduct(Convert.ToInt32(item.classid)) + "</td>";
                strTable += "<td>" + item.lesson + "</td>";
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

            Int32 subjectid = 0;
            Int32 lessionid = 0;
            Int32 classid = 0;
            var modelSlide = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == id);
            if (modelSlide.Count() > 0)
            {
                var modelSlide1 = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == id).Single();
                var Lesson = db.tb_LessionMaster.ToList().Where(x => x.LessionId == modelSlide1.LessionId).Single();
                subjectid = Convert.ToInt32(Lesson.SubjectId);
                lessionid = Convert.ToInt32(Lesson.LessionId);
                classid = Convert.ToInt32(Lesson.ClassId);
            }

            var Llist = (from m in db.tb_UsefulTips
                         from t in db.tb_SubjectMaster
                         from k in db.tb_LessionMaster
                         from u in db.tb_UserMaster
                         where m.SubjectId == t.SubjectId && k.LessionId == m.LessonId
                         && u.UserId == m.UserId && k.LessionId == lessionid
                         select new
                         {
                             subjectname = m.Subject,
                             desc = m.Description,
                             Course = t.SubjectName,
                           //  classid = m.ClassId,
                             lesson = k.LessionHeading,
                             username = u.UserName

                         });

            string strTable = "";
            int countrow = 0;
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
                strTable += "<td>" + item.username + "</td>";
                strTable += "<td>" + item.subjectname + "</td>";
                strTable += "<td>" + item.desc + "</td>";
                strTable += "<td>" + item.Course + "</td>";
                //  strTable += "<td>" + clsCommon.getClassNameProduct(Convert.ToInt32(item.classid)) + "</td>";
                strTable += "<td>" + item.lesson + "</td>";
                strTable += "</tr>";
            }
            ViewData["data"] = strTable;

            Session.Add("ModuleName0", "Feedback");
            ViewData["buttonname"] = 1;

            return View();
        }
        private Boolean ValidateData(tb_UsefulTips model)
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
        public ActionResult Create(tb_UsefulTips model, Int32 id)
        {
            ViewData["buttonname"] = 1;
            try
            {

                Int32 subjectid = 0;
                Int32 lessionid = 0;
               // Int32 classid = 0;
                var modelSlide = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == id);
                if (modelSlide.Count() > 0)
                {
                    var modelSlide1 = db.tb_LessionMasterSlides.ToList().Where(x => x.AutoId == id).Single();
                    var Lesson = db.tb_LessionMaster.ToList().Where(x => x.LessionId == modelSlide1.LessionId).Single();
                    subjectid = Convert.ToInt32(Lesson.SubjectId);
                    lessionid = Convert.ToInt32(Lesson.LessionId);
                   // classid = Convert.ToInt32(Lesson.ClassId);
                }
                else
                {
                    var Lesson = db.tb_LessionMaster.ToList().Where(x => x.LessionId == id).Single();
                    subjectid = Convert.ToInt32(Lesson.SubjectId);
                    lessionid = Convert.ToInt32(Lesson.LessionId);
                  //  classid = Convert.ToInt32(Lesson.ClassId);
                }
                string filename1 = "";
                string filename2 = "";

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
                        model.SlideId = id;
                        model.LessonId =lessionid;
                        model.SubjectId = subjectid;
                      //  model.ClassId = classid;

                        model.SystemDate = DateTime.Now;
                        model.Ipaddress = Request.ServerVariables["remote_address"];

                        db.tb_UsefulTips.Add(model);
                        db.SaveChanges();
                        ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                        ViewData["msgStatus"] = clsCommon.ErrorMessage(1);


                        //If Subject is done

                        Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
                        var modelUser = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();

                        var item3 = (from m in db.tb_emailsDescription
                                     where m.Autoid == 35
                                     select m).Single();
                        String desc = "";
                        desc = item3.Description;
                        String ProductDetail = "";

                        ProductDetail += "<br />Description: <b>";
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


                        var tb = new tb_UsefulTips();
                        return View(tb);
                    }
                }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
                ViewData["msgStatus"] = ce.Message;
            }
            return View();
        }


        //
        // GET: /Subject/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_UsefulTips
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_UsefulTips model)
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

        //
        // GET: /Subject/Delete/5
 
        public ActionResult Delete(int id)
        {
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_UsefulTips
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
                var tb = (from m in db.tb_UsefulTips
                          where m.AutoId == id
                          select m).Single();

                db.tb_UsefulTips.Remove(tb);
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
