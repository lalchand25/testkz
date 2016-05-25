using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
using System.Text.RegularExpressions;
namespace OLProject.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Image()
        {
            var builder = new XCaptcha.ImageBuilder();
            var result = builder.Create();
            Session.Add("captcha", result.Solution);

            return new FileContentResult(result.Image, result.ContentType);

        }
        public ActionResult forgotpassword()
        {
            //var model = (from m in db.tb_ApplicationPage
            //             where
            //                 m.Pageid == 35
            //             select m).Single();

            //ViewData["pagedescription"] = model.Description;
            //ViewData["PageTitle"] = model.Title;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult forgotpassword(String UserName, String captchatext)
        {
            //Please correct the following errors. Fields with errors are highlighted.<br />&nbsp;You have entered an Invalid Email Address. Please try again. 
            //var model = (from m in db.tb_ApplicationPage
            //             where
            //                 m.Pageid == 35
            //             select m).Single();

            //ViewData["pagedescription"] = model.Description;
            //ViewData["PageTitle"] = model.Title;

            try
            {
                String sessionCap = Session["captcha"].ToString();
                var pdEmail = from c in db.tb_UserMaster where c.EmailID == UserName select c;
                if (pdEmail.Count() == 0)
                    ViewData.ModelState.AddModelError("EmailID", " Please enter a the valid e-mail ID!");
                const string emailregex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                if (string.IsNullOrEmpty(UserName) || !Regex.IsMatch(UserName, emailregex))
                    ViewData.ModelState.AddModelError("email", " Please enter a the valid e-mail ID!");
                if (string.IsNullOrEmpty(UserName))
                    ViewData.ModelState.AddModelError("EmailID", " Please enter a the valid e-mail ID!");
                if (string.IsNullOrEmpty(captchatext))
                    ViewData.ModelState.AddModelError("captchatext", " Please enter the image in Red Color text !");
                if (!String.Equals(captchatext, sessionCap, StringComparison.CurrentCultureIgnoreCase))
                    ViewData.ModelState.AddModelError("captchatext", " Please enter the image in Red Color text !");
                if (!ViewData.ModelState.IsValid)
                {
                    return View();
                }
                var pd = db.tb_UserMaster.Single(a => a.EmailID == UserName);
                String password = "";
                if (pd != null)
                {
                    password = pd.UserPassword;

                    var modelg = (from m in db.tb_emailsDescription
                                  where m.Autoid == 3
                                  select m).Single();

                    string emailbody1 = modelg.Description;
                    emailbody1 = emailbody1.Replace("profilename", pd.ProfileName);
                    emailbody1 = emailbody1.Replace("sUserID", pd.EmailID);
                    emailbody1 = emailbody1.Replace("sPassWord", pd.UserPassword);



                    // emailSystem.sendComments(pd.EmailID, modelg.EmailSubject, emailbody1, "");

                    //clsCommon.SendEmailCurrentFormat(pd.EmailID, 3, 99999, Convert.ToInt32(pd.UserID), 0, 0, 0, emailbody1, modelg.EmailSubject, Request.ServerVariables["REMOTE_ADDR"].ToString());

                    emailSystem.sendNewFormat(pd.EmailID, modelg.EmailSubject, emailbody1);
                    ViewData["error"] = "Sent";
                    ViewData["message"] = "Thank you<br /><br />Dear Member,<br />We have sent you an email on " + UserName + " with your password.<br /><br />";


                    return RedirectToAction("emailsent");
                }

                else
                {
                    ViewData["message"] = "invalid Emailid";
                }
            }
            catch (Exception ce)
            {
                String message = ce.Message;
                ViewData["message"] = message;
            }
            return View();
        }

        public ActionResult emailsent()
        {

            //var model1 = (from m in db.tb_ApplicationPage
            //              where
            //                  m.Pageid == 24
            //              select m).Single();
            //ViewData["PageHeading"] = model1.PageName;
            //ViewData["PageLeftData"] = model1.Description;

            return View();
        }

        public ActionResult LogOn()
        {
            Session.Abandon();
            //Session.Add("siteurl","http://localhost:52878/ClientBin/OLSilverlight.xap";
            // Session.Add("siteurl", "http://silverapp.goeoffice.com/ClientBin/OLSilverlight.xap");

            return View();
        }

        public ActionResult confirm(Int32 id)
        {
            try
            {
                String results = "";
                string productDetail = "";
                var tb1 = (from c in db.tb_UserMaster where c.UserId == id && c.ConfirmId == false select c);
                if (tb1.Count() > 0)
                {
                    var tb = (from c in db.tb_UserMaster where c.UserId == id && c.ConfirmId == false select c).Single();

                    if (tb != null)
                    {

                        tb_UserMaster pms = (from m in db.tb_UserMaster where m.UserId == id select m).Single();
                        if (pms.PackageId > 0)
                        {
                            Int32 productid = Convert.ToInt32(pms.PackageId);

                            var hmodel = (from m in db.tb_ProductMaster
                                          from t in db.tb_Subscription
                                          where m.SubsId == t.SubsId && m.ProductId == productid
                                          select new
                                          {
                                              m.ProductName,
                                              m.PriceDis,
                                              t.Duration
                                          }).Single();
                            productDetail = hmodel.ProductName + " - " + hmodel.PriceDis.ToString();

                            pms.AgreementEndDate = DateTime.Now.AddYears(Convert.ToInt32(hmodel.Duration));
                        }
                        else
                        {
                            pms.AgreementEndDate = DateTime.Now.AddYears(1);
                        }

                        pms.ConfirmId = true;
                        pms.ConfirmDate = DateTime.Now;
                        pms.AgreementStartDate = DateTime.Now;

                        pms.AvtarName = "default_avtar1.jpg";

                        db.SaveChanges();


                        // set default permission

                        Int32 cateid = 0;
                        if (tb.CategoryId > 0)
                        {
                            cateid = Convert.ToInt32(tb.CategoryId);
                        }
                        else
                        {
                            cateid = 9;
                        }
                        clsCommon.SetDefaultPermissions(cateid, id);



                        //
                        results = "User ID has been confirmed";


                        var tmodel = (from m in db.tb_emailsDescription
                                      where m.Autoid == 5
                                      select m).Single();

                        string desc = tmodel.Description;
                        desc = desc.Replace("UserID", pms.EmailID);
                        desc = desc.Replace("PassWord", pms.UserPassword);
                        desc = desc.Replace("UserName", "Dear " + pms.FirstName );
                        emailSystem.sendNewFormat(pms.EmailID, tmodel.EmailSubject, desc);

                        //**********************************************************Parent Agrement
                        // admin 8, stu 9, parent2 , teach 3

                        Session.Add("pmsuserid", pms.UserId);
                        Session.Add("pmsusername", pms.FirstName);
                        Session.Add("cateid", pms.CategoryId);
                        Session.Add("moduleid", 0);
                        Session.Add("Imagepath", pms.AvtarName);
                        Session.Add("emailid", pms.EmailID);


                        if (tb.CategoryId == 2) // parent
                        {
                            var model = (from m in db.tb_emailsDescription
                                         where m.Autoid == 19
                                         select m).Single();

                            desc = model.Description;
                            desc = desc.Replace("UserFirstName", pms.FirstName);
                            desc = desc.Replace("UserMiddleName", pms.MiddleName);
                            desc = desc.Replace("UserLastName", pms.LastName);
                            desc = desc.Replace("UserEmailAddress", pms.EmailID);
                            desc = desc.Replace("UserCellNumber", pms.ContactNo);
                            desc = desc.Replace("UserAddress", pms.Address);
                            desc = desc.Replace("UserProductBought", productDetail);
                            desc = desc.Replace("createdate", pms.CreateDate.ToString());
                            desc = desc.Replace("AgreementStartDate", pms.AgreementStartDate.ToString());
                            desc = desc.Replace("AgreementEndDate", pms.AgreementEndDate.ToString());
                            emailSystem.sendNewFormat(pms.EmailID, model.EmailSubject, desc);
                        }

                        if (tb.CategoryId == 3) //Teacher
                        {
                            var model = (from m in db.tb_emailsDescription
                                         where m.Autoid == 20
                                         select m).Single();
                            desc = model.Description;
                            desc = desc.Replace("UserName", "Dear " + pms.FirstName );
                            desc = desc.Replace("UserFirstName", pms.FirstName);
                            desc = desc.Replace("UserMiddleName", pms.MiddleName);
                            desc = desc.Replace("UserLastName", pms.LastName);
                            desc = desc.Replace("UserEmailAddress", pms.EmailID);
                            desc = desc.Replace("UserCellNumber", pms.ContactNo);
                            desc = desc.Replace("UserAddress", pms.Address);
                            desc = desc.Replace("createdate", pms.CreateDate.ToString());
                            desc = desc.Replace("AgreementStartDate", pms.AgreementStartDate.ToString());
                            desc = desc.Replace("AgreementEndDate", pms.AgreementEndDate.ToString());
                            emailSystem.sendNewFormat(pms.EmailID, model.EmailSubject, desc);
                            return RedirectToAction("Indexteacher", "Profile");
                 

                        }
                        //************************************************************************



                        if (tb.CategoryId == 9) //Student
                        {
                          

                            return RedirectToAction("studentProfile", "Profile");
                        }


           

                      



                    }

                }
                else
                {
                    ViewData["results"] = "User not found already confirmed";

                }

            }
            catch (Exception ce)
            {
                //emailSystem.errorLog(ce.Message, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Confirmation", id);
                var model111 = (from m in db.tb_emailsDescription
                                where
                                    m.Autoid == 33
                                select m).Single();


                ViewData["results"] = model111.Description;
            }
            return View();
        }


        private Boolean checkUser(string emailid, string password)
        {
            // admin 8, stu 9, parent 2 , teach 3
            Boolean loginstatus = false;

            IEnumerable<tb_UserMaster> tb = db.Database.SqlQuery<tb_UserMaster>("select * from tb_UserMaster where ConfirmId = 1 and EmailID = '"+emailid+"'");


         //   var tb = db.tb_UserMaster.ToList().Where(m => m.EmailID == emailid && m.ConfirmId== true);

            if (tb != null && tb.Count() > 0)
            {
                

             //   var tb1 = db.tb_UserMaster.ToList().Where(m => m.EmailID == emailid).Single();
                tb_UserMaster tb1 = db.Database.SqlQuery<tb_UserMaster>   ("Select *  from tb_UserMaster where EmailID ='" +  emailid +"'").FirstOrDefault<tb_UserMaster>  ();

                string password1 = tb1.UserPassword.ToString();
                if (String.Equals(password1, password, StringComparison.Ordinal))
                {
                    Session.Add("pmsuserid", tb1.UserId);

                    // Session.Add("pmsusername", tb1.ProfileName);
                    Session.Add("pmsusername", tb1.FirstName);
                    Session.Add("cateid", tb1.CategoryId);
                    Session.Add("moduleid", 0);
                    Session.Add("Imagepath", tb1.Picture);
                    Session.Add("emailid", tb1.EmailID);
                    Session.Add("ProductId", tb1.PackageId);
                    Session.Add("teacheridassined", tb1.TeacherAssginedID);

                    //var model111 = (from m in db.tb_ApplicationPage
                    //                where
                    //                    m.Pageid == 4
                    //                select m).Single();

                    //Session.Add("marqmessage", model111.Description);

                    tb1.LastLogin = DateTime.Now;
                    db.SaveChanges();
                    loginstatus = true;

                    //var tbCat = (from m in db.tb_UserCategory where m.GroupId == tb1.CategoryId select m);

                    IEnumerable<tb_UserCategory> tbCat = db.Database.SqlQuery<tb_UserCategory>("select * from tb_UserCategory where GroupId = " + tb1.CategoryId);


                    if (tbCat.Count() > 0)
                    {
                        var tbCat2 = (from m in db.tb_UserCategory where m.GroupId == tb1.CategoryId select m).Single();
                        Session.Add("cateName", tbCat2.MainCateName);

                    }
                }

            }
            return loginstatus;

        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                // var tb = db.tb_UserMaster.ToList().Where(m => m.EmailID == model.UserName && m.ConfirmId !=tr);

                if (checkUser(model.UserName, model.Password))
                {
                    Session.Add("moduleid", 0);
                    clsCommon.setUserPageAccessHistory(Convert.ToInt32(Session["pmsuserid"]), "Login", Request.ServerVariables["REMOTE_ADDR"], Request.ServerVariables["URL"]);
                 
                    // admin 8, stu 9, parent2 , teach 3
                    if (Convert.ToInt32(Session["cateid"]) == 8) // ADMIN
                    {

                        return RedirectToAction("Index", "Profile");
                    }
                    else if (Convert.ToInt32(Session["cateid"]) == 3)    // TEACHER 
                    {
                        return RedirectToAction("IndexTeacher", "Profile");
                    }

                    else
                    {
                        return RedirectToAction("studentProfile", "Profile");
                    }
                }
                else
                {
                    ViewBag.msg = "Please check user Name and Password";
                    return View();
                    //return RedirectToAction("logon", "login");

                }

            }
            else
            {
                ViewBag.msg = "Please check user Name and Password";
                return View();
                //return RedirectToAction("logon", "login");


            }


        }


        public ActionResult LogOff()
        {

            Session.Abandon();
            return RedirectToAction("index", "home");
        }
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Login/Create

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
        // GET: /Login/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Login/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Login/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Login/Delete/5

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
    }
}
