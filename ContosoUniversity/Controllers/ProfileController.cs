using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
using System.IO;
namespace OLProject.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        kzonlineEntities db = new kzonlineEntities();

        public ActionResult Edit(tb_UserMaster model)
        {
            setView();
            Int32 id = 0;
            try
            {
                ViewData["controlid"] = 1;


                string filename1 = "";
                string filename2 = "";
                string filename3 = "";

                if (Session["pmsuserid"] != null)
                {
                    id = Convert.ToInt32(Session["pmsuserid"]);
                    if (Request.HttpMethod == "POST")
                    {
                        // setViews();

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


                        //file = Request.Files[1];
                        //if (file.ContentLength < 2000000)
                        //{
                        //    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        //    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                        //    {
                        //        string randName = emailSystem.CreateRandomPassword(8);
                        //        filename2 = randName + "_" + file.FileName;
                        //        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                        //        file.SaveAs(filePath);
                        //    }
                        //}

                        //file = Request.Files[1];
                        //if (file.ContentLength < 2000000)
                        //{
                        //    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        //    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                        //    {
                        //        string randName = emailSystem.CreateRandomPassword(8);
                        //        filename3 = randName + "_" + file.FileName;
                        //        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename3);
                        //        file.SaveAs(filePath);
                        //    }
                        //}



                        tb_UserMaster tbs = (from m in db.tb_UserMaster where m.UserId == id select m).Single();
                        tbs.FirstName = model.FirstName;
                        tbs.MiddleName = model.MiddleName;
                        tbs.LastName = model.LastName;
                        tbs.ContactNo = model.ContactNo;
                        tbs.ProfileName = model.ProfileName;

                        tbs.Street = model.Street;
                        tbs.Address = model.Address;
                        tbs.UnitHouseNo = model.UnitHouseNo;
                        tbs.TownCity = model.TownCity;
                        tbs.SchoolName = model.SchoolName;
                        tbs.DOB = model.DOB;
                        tbs.Sex = model.Sex;
                        tbs.StateID = model.StateID;
                        tbs.CountryID = model.CountryID;
                        tbs.CityID = model.CityID;
                        tbs.Sex = model.Sex;


                        if (filename1 != "")
                        {
                            tbs.Picture = filename1;
                        }
                        if (filename2 != "")
                        {
                            tbs.DOBProof = filename2;
                        }

                        if (filename3 != "")
                        {
                            tbs.IDProof = filename3;
                        }

                        db.SaveChanges();
                        ViewData["msg"] = "Sucessfully Updated...........";
                        return RedirectToAction("StudentProfile", "Profile");

                    }


                }
                else
                {
                    if (Session["pmsuserid"] == null)
                    {
                        return RedirectToAction("logon", "login", new { action1 = "edit", controller1 = "/profile.aspx" });
                    }
                }

                tb_UserMaster tps = (from m in db.tb_UserMaster where m.UserId == id select m).Single();
                setViewCityModel(tps);
                return View("edit", tps);

            }
            catch (Exception ce)
            {
                ViewData["msg"] = ce.Message;
                tb_UserMaster tps = (from m in db.tb_UserMaster where m.UserId == id select m).Single();

                return View("edit", tps);
                // return View();
            }


        }

        public ActionResult ChangePassword()
        {
            if (Session["pmsuserid"] != null)
            {
                var pd = db.tb_UserMaster.ToList().Where(a => a.UserId == Convert.ToInt32(Session["pmsuserid"])).Single();

                string disprofile = "";

                ViewBag.profiledsip = disprofile;

                Session.Add("modulename", "Change Password");
                return View(pd);
            }
            return RedirectToAction("logon", "login");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChangePassword(String newpassword, string confirmpassword)
        {
            if (string.IsNullOrEmpty(newpassword))
                ViewData.ModelState.AddModelError("Password", "Password Required !");
            if (!String.Equals(newpassword, confirmpassword, StringComparison.Ordinal))
                ModelState.AddModelError("confirmPassword", "The  password and confirmation password do not match.");
            if (!ViewData.ModelState.IsValid)
            {
                if (Session["pmsuserid"] != null)
                {
                    var pd = db.tb_UserMaster.ToList().Where(a => a.UserId == Convert.ToInt32(Session["pmsuserid"])).Single();


                    return View(pd);
                }
                else { return RedirectToAction("logon", "login"); }


            }

            if (Session["pmsuserid"] != null)
            {
                var pd = db.tb_UserMaster.ToList().Where(a => a.UserId == Convert.ToInt32(Session["pmsuserid"])).Single();
                pd.UserPassword = newpassword;
                pd.ConfirmPassword = confirmpassword;
                db.SaveChanges();
                Session.Abandon();

                ViewData["msg"] = "Password Have been changed..Please check your email for reference";
                var modelg = (from m in db.tb_emailsDescription where m.Autoid == 2 select m).Single();

                string emailbody1 = modelg.Description;
                emailbody1 = emailbody1.Replace("profilename", pd.ProfileName);
                emailbody1 = emailbody1.Replace("sUserID", pd.EmailID);
                emailbody1 = emailbody1.Replace("sPassWord", pd.UserPassword);

                emailSystem.sendNewFormat(pd.EmailID, modelg.EmailSubject, emailbody1);
            }
            else
            {
                ViewData["message"] = "You are not log in";
            }

            if (Session["pmsuserid"] != null)
            {
                var pd = db.tb_UserMaster.ToList().Where(a => a.UserId == Convert.ToInt32(Session["pmsuserid"])).Single();

                string disprofile = "";

                ViewBag.profiledsip = disprofile;
                ViewData["msg"] = "Sucessfully Updated...........";
                Session.Add("modulename", "Change Password");
                return View(pd);
            }

            return RedirectToAction("logon", "login");

        }


        public ActionResult studentProfile()
        {


            if (Session["pmsuserid"] != null)
            {
                var pd = db.tb_UserMaster.ToList().Where(a => a.UserId == Convert.ToInt32(Session["pmsuserid"])).Single();

                string disprofile = "";

                ViewBag.profiledsip = disprofile;

                ////// to display courses



                Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
                var ddList = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();

                string strQuery = @"select distinct * from tb_subjectmaster where publish=1 and subjectid=" + Convert.ToInt32(ddList.ClassId); // temrary need to study above
                // admin 8, stu 9, parent2 , teach 3
                if (Convert.ToInt32(Session["cateid"]) == 8)
                {
                    strQuery = @"select distinct * from tb_subjectmaster where publish=1";
                }
                IEnumerable<tb_SubjectMaster> results = db.Database.SqlQuery<tb_SubjectMaster>(strQuery);
                string strTable = "";
                foreach (var item in results)
                {
                    //strTable += "<div class='student-profile'>";
                    //strTable += "<div class='row'>";
                    //strTable += "<div class='span4'>";
                    strTable += "<ul> <li> <h2>" + item.SubjectName;
                
                    strTable += "</h2>";


                    //djfjklds fldskjfklsd flskdjfsd lkfjsdf sdlkjfsd lfkjsdf sdlkjfsd flkjsd 
                    //fjsdlkf dslkfjsdl lkdsfj

                    int lenth1 = item.SubjectDesc.Length;
                    if (lenth1 > 301)
                    {
                        strTable += item.SubjectDesc.Substring(0, 300);
                    }
                    else
                    {
                        strTable += item.SubjectDesc + "....";
                    }

                    strTable += "<a href='/mytraining/courseSubject/" + item.SubjectId + "' class='btn-style'>View Courses</a> </li>";
                    //strTable += "</div>";
                    //strTable += "<div class='span3'>";

                    //strTable += "</div>";
                    //strTable += "</div>";
                    //strTable += "</div>";
                    strTable += " <li> <img alt='' src='../uploads/" + item.SubjectImge + "' style='float:right;Height:227px; width:340px;'  /> </li> </ul>";


                }
                ViewData["data"] = strTable;


                var tb2 = from m in db.tb_OnlineTestMaster where m.UserID == userid select m;


                if (tb2.Count() > 5)
                {
                    tb2 = (from p in db.tb_OnlineTestMaster
                           orderby p.SystemDate descending
                           select p).Take(5);
                }

                string strResult = "";
                foreach (var item2 in tb2)
                {

                    var lession = from m in db.tb_LessionMaster where m.LessionId == item2.LessonID select m;
                    strResult += "  <tr>";
                    if (lession.Count() > 0)
                    {
                        var lession2 = (from m in db.tb_LessionMaster where m.LessionId == item2.LessonID select m).Single();
                        strResult += "          <td>" + lession2.LessionHeading + "</td>";
                    }
                    else
                    {
                        strResult += "          <td>&nbsp;</td>";
                    }
                    // String.Format("{0:d dd ddd dddd}", dt);
                    // tb_LessionMaster
                    strResult += " <td>" + string.Format("{0:d}", Convert.ToDateTime(item2.SystemDate)) + "</td>";
                    strResult += " <td>" + item2.TotalQuestion + "</td>";
                    strResult += " <td>" + item2.TotalCorrect + "</td>";
                    strResult += " <td>" + item2.TotalWrong + "</td>";
                    strResult += " </tr>";

                }

                ViewBag.strResult = strResult;

                ////

                return View(pd);
            }


            return RedirectToAction("logon", "login");

        }
        public ActionResult Index()
        {
            //var model = db.tb_ApplicationPage.ToList().Where(x => x.Pageid == 2).Single();
            //ViewData["PageData"] = model.Description;
            //ViewData["PageName"] = model.Title;

            //Session.Add("moduleid", id);
            //Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
            return View();
        }

        public ActionResult IndexTeacher()
        {
            //var model = db.tb_ApplicationPage.ToList().Where(x => x.Pageid == 2).Single();
            //ViewData["PageData"] = model.Description;
            //ViewData["PageName"] = model.Title;

            //Session.Add("moduleid", id);
            //Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
            return View();
        }

        

        public ActionResult Profile(Int32 id)
        {

            Session.Add("moduleid", id);
            var model = db.tb_ModuleMaster.ToList().Where(x => x.ModuleId == id).Single();
            Session.Add("modulename", model.ModuleName);

            Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
            return View();
        }

        //
        // GET: /Profile/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Profile/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Profile/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Profile/Edit/5


        // GET: /Profile/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Profile/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void setView()
        {
            //var ddCountryList = (from m in db.tb_CountryMaster
            //                     select new
            //                     {
            //                         Name = m.CountryName,
            //                         ID = m.CountryID
            //                     }).OrderBy(x => x.Name);
            //var ddCountryList01 = new SelectList(ddCountryList, "ID", "Name");
            //ViewData["ddCountryList"] = ddCountryList01;

            //var ddStateList0 = (from m in db.tb_StateMaster
            //                    select new
            //                    {
            //                        Name = m.StateName,
            //                        ID = m.StateID
            //                    }).OrderBy(x => x.Name);
            //var selectStateList0 = new SelectList(ddStateList0, "ID", "Name");
            //ViewData["subStateList"] = selectStateList0;

            var ddlist = from m in db.tb_CityMaster select m;
            var slist = new SelectList(ddlist.ToList(), "CityID", "CityName");
            ViewData["ddCityList"] = slist;


        }

        public void setViewCity()
        {
            var ddCountryList = (from m in db.tb_CountryMaster

                                 select new
                                 {
                                     Name = m.CountryName,
                                     ID = m.CountryID
                                 }).OrderBy(x => x.Name);
            var ddCountryList01 = new SelectList(ddCountryList, "ID", "Name");
            ViewData["ddCountryList"] = ddCountryList01;


            var ddStateList0 = (from m in db.tb_StateMaster
                                select new
                                {
                                    Name = m.StateName,
                                    ID = m.StateID
                                }).OrderBy(x => x.Name);
            var selectStateList0 = new SelectList(ddStateList0, "ID", "Name");
            ViewData["subStateList"] = selectStateList0;


            var ddStateList22 = (from m in db.tb_CityMaster

                                 select new
                                 {
                                     Name = m.CityName,
                                     ID = m.CityID
                                 }).OrderBy(x => x.Name);
            var selectStateList22 = new SelectList(ddStateList22, "ID", "Name");
            ViewData["subCity"] = selectStateList22;

        }

        public void setViewCityModel(tb_UserMaster model)
        {

            var ddCountryList = (from m in db.tb_CountryMaster

                                 select new
                                 {
                                     Name = m.CountryName,
                                     ID = m.CountryID
                                 }).OrderBy(x => x.Name);
            var ddCountryList01 = new SelectList(ddCountryList, "ID", "Name");
            ViewData["ddCountryList"] = ddCountryList01;



            int ccurID = 0;

            if (model.CountryID > 0)
            {
                ccurID = Convert.ToInt16(model.CountryID);

            }

            var ddStateList0 = (from m in db.tb_StateMaster
                                where m.CountryID == ccurID
                                select new
                                {
                                    Name = m.StateName,
                                    ID = m.StateID
                                }).OrderBy(x => x.Name);
            var selectStateList0 = new SelectList(ddStateList0, "ID", "Name");
            ViewData["subStateList"] = selectStateList0;


            int ccurID2 = 0;

            if (model.StateID > 0)
            {
                ccurID2 = Convert.ToInt16(model.StateID);

            }

            var ddStateList22 = (from m in db.tb_CityMaster
                                 where m.StateID == ccurID2

                                 select new
                                 {
                                     Name = m.CityName,
                                     ID = m.CityID
                                 }).OrderBy(x => x.Name);
            var selectStateList22 = new SelectList(ddStateList22, "ID", "Name");
            ViewData["subCity"] = selectStateList22;







        }
    }
}
