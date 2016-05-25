using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
using System.Text.RegularExpressions;
using System.IO;
namespace OLProject.Controllers
{
    public class RegisterController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        //
        // GET: /Register/
        public ActionResult myimage()
        {
            var builder = new XCaptcha.ImageBuilder();
            var result = builder.Create();
            Session.Add("captcha", result.Solution);
            return new FileContentResult(result.Image, result.ContentType);
        }
        // GET: /Register/Details/5
        // GET: /Register/Create
        public ActionResult package()
        {
            var model = db.tb_Subscription.ToList();
            string strTable = "";
            foreach (var item1 in model)
            {
                var Llist = db.tb_ProductMaster.ToList().Where(x => x.SubsId == item1.SubsId && x.Publish == true);
                if (Llist.Count() > 0)
                {
                    //strTable += "<tr class='bg-drkgrey color-white'><td colspan='6'><strong>" + item1.SubsName + "</strong></td></tr>";
                    strTable += "<tr class='odd'><td colspan='6'><strong>" + item1.SubsName + "</strong></td></tr>";
                    Int32 inct = 0;
                    foreach (var item in Llist)
                    {

                        strTable += "<tr class='even'>";
                        strTable += "<td align='left' width='20%'> " + item.ProductName + "</td>";
                        strTable += "<td align='left' width='20%'><div align='center'> " + item.ShortName + "</div></td>";
                        strTable += "<td align='center' width='20%'><div align='center'> " + item.NoOfUsers + "</div></td>";
                        strTable += "<td align='right' width='20%'><div align='center'>" + item.Price + "</div></td>";
                        strTable += "<td width='10%'><div align='center'><a  href='/register/demo/" + item.ProductId + "'  /><img src='../../images/demo.png'  width='50' height='50'/></a></div></td>";
                        strTable += "<td width='10%'><div align='center'><a  href='/register/index?regtype=2&pkgid=" + item.ProductId + "'  /><img src='../../images/buy.png'  width='50' height='50'/></a></div></td>";
                        strTable += "</tr>";
                    }
                }
            }
            ViewData["data"] = strTable;
            return View();
        }
        public ActionResult Demo()
        {
            return View();
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpGet]
        public ActionResult signin()
        {
            if (Request.QueryString["catype"] != null)
            {
                Int32 cattype = Convert.ToInt32(Request.QueryString["catype"]);
                if (cattype == 2)
                {
                    ViewBag.catname = "Parent";
                }

                if (cattype == 3)
                {
                    ViewBag.catname = "Teacher";
                }

                if (cattype == 8)
                {
                    ViewBag.catname = "Admin";
                }

                if (cattype == 9)
                {
                    ViewBag.catname = "Student";
                }

            }
            return View();
        }





        //
        //
        // POST: /Register/Create
        private void catlist()
        {
            var ddListy = (from m in db.tb_CountryMaster
                           select new
                           {
                               Name = m.CountryName,
                               ID = m.CountryID
                           });

            var selectList2y = new SelectList(ddListy, "ID", "Name");
            ViewData["countrylist"] = selectList2y;

            var ddList = (from m in db.tb_RegCategory
                          select new
                          {
                              Name = m.RegTypeName,
                              ID = m.RegTypeId
                          });

            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["categorylist"] = selectList;

        }
        private Boolean validateRegisterData(string emailid, string password, string confirmPassword, bool terms, tb_UserMaster model, String captchatext)
        {
            Boolean validateData = true;
            String sessionCap = Session["captcha"].ToString();

            var pdEmail = from c in db.tb_UserMaster where c.EmailID == emailid select c;
            if (pdEmail.Count() > 0)
                ViewData.ModelState.AddModelError("Emailid", "E-mailid already found!");
            const string emailregex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (!string.IsNullOrEmpty(emailid) && !Regex.IsMatch(emailid, emailregex))
                ViewData.ModelState.AddModelError("Emailid", "Please enter a valid e-mail!");
            if (string.IsNullOrEmpty(emailid))
                ViewData.ModelState.AddModelError("Emailid", "Please enter your e-mail!");
            if (string.IsNullOrEmpty(password))
                ViewData.ModelState.AddModelError("userPassword", "Password Required !");

            if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
                ModelState.AddModelError("confirmPassword", "The  password and confirmation password do not match.");


            if (string.IsNullOrEmpty(model.FirstName))
                ViewData.ModelState.AddModelError("FirstName", "Please enter a FirstName!");

            if (model.DistrictId == null)
            {
                ViewData.ModelState.AddModelError("DistrictId", "Please Select District !");
            }

            if (model.CategoryId == 0)
            {
                ViewData.ModelState.AddModelError("CategoryId", "Please Select CategoryId !");
            }

            if (model.StateID == null)
            {
                ViewData.ModelState.AddModelError("StateID", "Please Select State !");
            }

            if (model.CountryID == null)
            {
                ViewData.ModelState.AddModelError("CountryID", "Please Select Country !");
            }


            if (string.IsNullOrEmpty(model.ProfileName))
                ViewData.ModelState.AddModelError("ProfileName", "Please enter a Profile Name!");

            //if (!DateTime.TryParse(dob, out birthDate))
            //    ViewData.ModelState.AddModelError("birthdate", "Invalid Birth Date !!!");
            //if (string.IsNullOrEmpty(countryname))
            //    ViewData.ModelState.AddModelError("countryname", "Select country !");
            //if (string.IsNullOrEmpty(Religion))
            //    ViewData.ModelState.AddModelError("Religion", "Select Religion !");
            //if (string.IsNullOrEmpty(MotherTongue))
            //    ViewData.ModelState.AddModelError("MotherTongue", "Select Mothertongue!");

            if (string.IsNullOrEmpty(captchatext))
                ViewData.ModelState.AddModelError("captchatext", "please enter image text !");
            if (!String.Equals(captchatext, sessionCap, StringComparison.CurrentCultureIgnoreCase))
                ViewData.ModelState.AddModelError("captchatext", "Image text mismatched !");
            if (!terms)
                ViewData.ModelState.AddModelError("terms", "Please check terms & conditions");
            if (!terms)
                ViewData.ModelState.AddModelError("agreement", "Please check agreement");

            if (!ModelState.IsValid)
            {
                validateData = false;
            }
            return validateData;
        }

        private Boolean validateRegisterDataNew(string emailid, string password, string confirmPassword, tb_UserMaster usermaster)
        {
            Boolean validateData = true;
            //  String sessionCap = Session["captcha"].ToString();

            var pdEmail = from c in db.tb_UserMaster where c.EmailID == emailid select c;
            if (pdEmail.Count() > 0)
                ViewData.ModelState.AddModelError("Emailid", "E-mailid already found!");
            const string emailregex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (!string.IsNullOrEmpty(emailid) && !Regex.IsMatch(emailid, emailregex))
                ViewData.ModelState.AddModelError("Emailid", "Please enter a valid e-mail!");
            if (string.IsNullOrEmpty(emailid))
                ViewData.ModelState.AddModelError("Emailid", "Please enter your e-mail!");
            if (string.IsNullOrEmpty(password))
                ViewData.ModelState.AddModelError("userPassword", "Password Required !");

            if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
                ModelState.AddModelError("confirmPassword", "The  password and confirmation password do not match.");

            if (string.IsNullOrEmpty(usermaster.FirstName))
                ViewData.ModelState.AddModelError("FirstName", "First Name Required !");

            if (string.IsNullOrEmpty(usermaster.LastName))
                ViewData.ModelState.AddModelError("LastName", "Last Name Required !");

            if (!ModelState.IsValid)
            {
                validateData = false;
            }
            return validateData;
        }

        public ActionResult terms()
        {
            var model = (from m in db.tb_ApplicationPage
                         where
                             m.Pageid == 3
                         select m).Single();
            ViewData["terms1"] = model.Description;
            return View();
        }

        public ActionResult Index()
        {
            //if (Request.QueryString["pkgid"] != null)
            // {
            //    Int32 pkgid = Convert.ToInt32(Request.QueryString["pkgid"]);
            //    Session.Add("pkgid", pkgid);
            //}
            //else
            //{
            //    Session.Add("pkgid", 0);
            //}

            //string regiserType = "Not Found";
            //if (Request.QueryString["regtype"] != null)
            //{
            //    Int32 regtype = Convert.ToInt32(Request.QueryString["regtype"]);
            //    if (regtype > 0)
            //    {
            //        Session.Add("regtype", regtype);
            //        var model1 = db.tb_RegCategory.ToList().Where(x => x.RegTypeId == regtype);
            //        if (model1.Count() > 0)
            //        {
            //            var model = db.tb_RegCategory.ToList().Where(x => x.RegTypeId == regtype).Single();
            //            regiserType = "You are registering as  : " + model.RegTypeName;
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");

            //        }
            //    }
            //    else
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //ViewData["regstype"] = regiserType;


            terms();
            catlist();
            return View();
        }

        [HttpPost]
        public ActionResult Index(tb_UserMaster model, String captchatext)
        {
            try
            {
                terms();
                catlist();
                string emailid = model.EmailID;
                string password = model.UserPassword;
                string ConfirmPassword = model.ConfirmPassword;
                string filename1 = "";
                model.CategoryId = Convert.ToInt32(Session["regtype"]);

                if (validateRegisterData(emailid, password, ConfirmPassword, Convert.ToBoolean(model.Terms), model, captchatext) == true)
                {
                    string imagepath = "";
                    foreach (string inputTagName in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[inputTagName];
                        if (file.ContentLength < 5000000)
                        {
                            String FileExtension = Path.GetExtension(file.FileName).ToLower();
                            if (FileExtension == ".png" || FileExtension == ".jpeg" || FileExtension == ".jpg" || FileExtension == ".gif")
                            {

                                string randName = emailSystem.CreateRandomPassword(5);

                                filename1 = randName + "_" + file.FileName;
                                string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                                file.SaveAs(filePath);
                                imagepath = filename1;
                            }
                        }
                    }

                    model.CreateDate = DateTime.Now;
                    model.Ipaddress = Request.ServerVariables["REMOTE_ADDR"].ToString();

                    model.LastLogin = DateTime.Now;
                    model.ConfirmDate = DateTime.Now;
                    model.ConfirmId = false;
                    model.CompanyId = 0;
                    model.LastUpdate = DateTime.Now;

                    model.PackageId = Convert.ToInt32(Session["pkgid"]);

                    if (imagepath == "")
                    {
                        model.Picture = "BlankMan.png";
                        model.AvtarName = "BlankMan.png";
                    }
                    else
                    {
                        model.Picture = imagepath;
                        model.AvtarName = imagepath;
                    }
                    db.tb_UserMaster.Add(model);
                    db.SaveChanges();

                    Int32 userid = model.UserId;

                    if (Convert.ToInt32(model.PackageId) > 0)
                    {
                        var vmodel = db.tb_ProductMaster.ToList().Where(x => x.ProductId == model.PackageId).Single();
                        Session.Add("amt", vmodel.PriceDis.ToString());
                        Session.Add("item", vmodel.ProductName);
                        Session.Add("ProductId", vmodel.ProductId);
                        Session.Add("PayPalUserId", model.UserId);
                    }

                    var model90 = (from m in db.tb_UserMaster
                                   from t in db.tb_RegCategory
                                   where m.CategoryId == t.RegTypeId
                                   && m.UserId == userid
                                   select new
                                   {
                                       profilename = m.ProfileName,
                                       category = t.RegTypeName,
                                       ProuctId = m.PackageId
                                   }
                               ).Single();

                    Session.Add("category", model90.category);

                    String strbody = "<br /><a href='http://kzonline.org/login/confirm/" + userid + "'>Click here for Confirmation</a> ";

                    var tmodel = (from m in db.tb_emailsDescription
                                  where m.Autoid == 1
                                  select m).Single();

                    String desc = tmodel.Description;
                    desc = desc.Replace("Clickhere", strbody);
                    desc = desc.Replace("UserName", "Dear " + model.FirstName);
                    //emailSystem.sendComments(emailid, tmodel.EmailSubject, desc, "");
                    string strSUbject = tmodel.EmailSubject + " of " + model.ProfileName;
                    //clsCommon.SendEmailCurrentFormat(emailid, 1, 99999, Convert.ToInt32(userid), 0, 0, 0, desc, strSUbject, Request.ServerVariables["REMOTE_ADDR"].ToString());
                    emailSystem.sendNewFormat(model.EmailID, strSUbject, desc);
                    //return RedirectToAction("PaymentMode");

                    return RedirectToAction("Thanks", new { id = 4 });

                }

            }
            catch
            {

            }


            return View();
        }

        [HttpPost]
        public ActionResult signin(tb_UserMaster model)
        {
            try
            {
                // terms();
                //  catlist();
                string emailid = model.EmailID;
                string password = model.UserPassword;
                string ConfirmPassword = model.ConfirmPassword;

                model.CategoryId = Convert.ToInt32(Session["regtype"]);

                if (validateRegisterDataNew(emailid, password, ConfirmPassword, model) == true)
                {
                    string imagepath = "";


                    model.CreateDate = DateTime.Now;
                    model.Ipaddress = Request.ServerVariables["REMOTE_ADDR"].ToString();

                    model.LastLogin = DateTime.Now;
                    model.ConfirmDate = DateTime.Now;
                    model.ConfirmId = false;
                    model.CompanyId = 0;
                    model.LastUpdate = DateTime.Now;

                    if (Request.QueryString["courseid"] != null)
                    {
                        Int32 couseid1 = Convert.ToInt32(Request.QueryString["courseid"]);
                        model.ClassId = couseid1;
                        model.TeacherAssginedID = 3;

                    }


                    if (Request.QueryString["cattype"] != null)
                    {
                        Int32 cattype = Convert.ToInt32(Request.QueryString["cattype"]);
                        model.CategoryId = cattype;

                    }




                    db.tb_UserMaster.Add(model);
                    db.SaveChanges();

                    Int32 userid = model.UserId;


                    //var model90 = (from m in db.tb_UserMaster
                    //               from t in db.tb_RegCategory
                    //               where m.CategoryId == t.RegTypeId
                    //               && m.UserId == userid
                    //               select new
                    //               {
                    //                   profilename = m.ProfileName,
                    //                   category = t.RegTypeName,
                    //                   ProuctId = m.PackageId
                    //               }
                    //           ).Single();

                    // Session.Add("category", model90.category);

                    String strbody = "Name: " + model.FirstName + "<br /><br /><a href='http://kzonline.org/login/confirm/" + userid + "'>Click here for Confirmation</a> ";

                    var tmodel = (from m in db.tb_emailsDescription
                                  where m.Autoid == 1
                                  select m).Single();

                    String desc = tmodel.Description;
                    desc = desc.Replace("Clickhere", strbody);
                    desc = desc.Replace("UserName", "Dear " + model.FirstName);
                    //emailSystem.sendComments(emailid, tmodel.EmailSubject, desc, "");
                    string strSUbject = tmodel.EmailSubject + " of " + model.LastName;
                    //clsCommon.SendEmailCurrentFormat(emailid, 1, 99999, Convert.ToInt32(userid), 0, 0, 0, desc, strSUbject, Request.ServerVariables["REMOTE_ADDR"].ToString());
                    emailSystem.sendNewFormat(model.EmailID, strSUbject, desc);
                    //return RedirectToAction("PaymentMode");

                    //student-login

                    if (Request.QueryString["courseid"] != null)
                    {

                        Int32 couseid1 = Convert.ToInt32(Request.QueryString["courseid"]);
                        /// //////////////////////////////////////////// paypal
                        // Session.Add("MonthlySubFee", "MonthlySubFee");
                        //  return RedirectToAction("subscription", "paypal", new { emailid = model.EmailID, couseid = couseid1 });
                        return RedirectToAction("studentlogin", new { id = userid, emailid = model.EmailID, couseid = couseid1 });

                        ///
                    }


                    return RedirectToAction("studentlogin", new { id = userid });


                }

            }
            catch
            {

            }


            return View();
        }

        public ActionResult studentlogin(Int32 id)
        {




            setView();
            var tbadd = (from m in db.tb_UserMaster where m.UserId == id select m).Single();
            ViewBag.cattype = tbadd.CategoryId;

            return View(tbadd);

            //return View();

        }

        [HttpPost]
        public ActionResult studentlogin(tb_UserMaster model, Int32 id)
        {
            setView();
            var tbadd = (from m in db.tb_UserMaster where m.UserId == id select m).Single();


            tbadd.ContactNo = model.ContactNo;

            tbadd.FirstName = model.FirstName;
            tbadd.LastName = model.LastName;
            tbadd.TownCity = model.TownCity;
            tbadd.Address = model.Address;
            if (model.ClassId !=null)
            {
                tbadd.ClassId = model.ClassId;
                tbadd.TeacherAssginedID = 3;
            }
            db.SaveChanges();

            if (tbadd.ClassId > 0)
            {
                return RedirectToAction("subscription", "paypal", new { emailid = model.EmailID, couseid = tbadd.ClassId });
            }
            return RedirectToAction("Thanks", new { id = 4 });

            //return View(tbadd);



            //return View();

        }
        public ActionResult Thanks(Int32 id)
        {


            var item = (from m in db.tb_emailsDescription
                        where m.Autoid == id
                        select m).Single();

            string desc = item.Description;
            desc = desc.Replace("UserName", "Dear " + Session["category"]);

            ViewData["emaildata"] = desc;

            return View();
        }


        public void setView()
        {
            var CourseSub = (from m in db.tb_SubjectMaster where m.Publish == true select m).ToList();

            var ddlist = new SelectList(CourseSub, "SubjectId", "SubjectName");
            ViewBag.CourseSubjectList = ddlist;



        }
        public ActionResult PayPalThanks()
        {
            //Thanks Email for Buy Product
            Int32 userid = Convert.ToInt32(Session["pmsuserid"]);
            var model = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();
            Int32 ProductId = Convert.ToInt32(model.PackageId);
            var Productmodel = db.tb_ProductMaster.ToList().Where(x => x.ProductId == ProductId).Single();

            //Product Detail
            var item = (from m in db.tb_emailsDescription
                        where m.Autoid == 6
                        select m).Single();
            string desc = item.Description;
            desc = desc.Replace("UserName", model.ProfileName);
            String ProductDetail = "";
            ProductDetail += "<br /> Product Name: <b>" + Productmodel.ProductName + "</b>";
            ProductDetail += "<br /> Description: " + Productmodel.Description;
            ProductDetail += "<br /> Price: " + Productmodel.PriceDis;
            ProductDetail += "<br /> User Licence : " + Productmodel.NoOfUsers;
            desc = desc.Replace("ProductDetail", ProductDetail);
            emailSystem.sendNewFormat(model.EmailID, item.EmailSubject, desc);

            var item1 = (from m in db.tb_emailsDescription
                         where m.Autoid == 7
                         select m).Single();
            desc = item1.Description;
            desc = desc.Replace("UserName", model.ProfileName);
            emailSystem.sendNewFormat(model.EmailID, item1.EmailSubject, desc);

            //*************************************************************************

            ViewData["emaildata"] = desc;

            return View();
        }



        //
        // GET: /Register/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Register/Edit/5

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
        // GET: /Register/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Register/Delete/5

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
