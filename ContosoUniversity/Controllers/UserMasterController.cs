using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class UserMasterController : Controller
    {
        //
        // GET: /Subject/


        kzonlineEntities db = new kzonlineEntities();
        private void SetViews()
        {
            var ddListy = (from m in db.tb_CountryMaster
                           select new
                           {
                               Name = m.CountryName,
                               ID = m.CountryID
                           });

            var selectList2y = new SelectList(ddListy, "ID", "Name");
            ViewData["countrylist"] = selectList2y;


            var ddList1 = (from m in db.tb_ProductClassMaster
                           select new
                           {
                               Name = m.ClassName,
                               ID = m.AutoId
                           });

            var selectList1 = new SelectList(ddList1, "ID", "Name");
            ViewData["Classlist"] = selectList1;


 
        }

        public ActionResult Index()
        {
            Session.Add("ModuleName0", "User Information");
            Int32 userid = Convert.ToInt32(Session["pmsuserid"]);

            //var model = db.tb_UserMaster.ToList().Where(x => x.ParentId == userid);
            //if (model.Count() == 0)
            //{
            //    tb_UserMaster tb = new tb_UserMaster();
            //    tb.UserName = "Guest";
            //    tb.FirstName = "Gurest";
            //    tb.LastName = "Guest";
            //    tb.MiddleName = "Guest";
            //    tb.ConfirmId = false;
            //    tb.ConfirmDate = DateTime.Now;
            //    tb.Picture = "BlankMan.png";
            //    tb.AvtarName = "BlankMan.png";
            //    tb.ProfileName = "Guest";
            //    tb.ConfirmPassword = emailSystem.CreateRandomPassword(8);
            //    tb.UserPassword = emailSystem.CreateRandomPassword(8);
            //    tb.ParentId = Convert.ToInt32(Session["pmsuserid"]);

            //    db.tb_UserMaster.Add(tb);
            //    db.SaveChanges();
            //}


            var Llist = db.tb_UserMaster.ToList().Where(x => x.ParentId == Convert.ToInt32(Session["pmsuserid"]));
            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.UserName + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/FamilyUser/edit/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/FamilyUser/Delete/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/FamilyUser/Detail/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/show.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "</tr>";
            }
            ViewData["data"] = strTable;

            var model1 = db.tb_UserMaster.ToList().Where(x => x.UserId == Convert.ToInt32(Session["pmsuserid"])).Single();

            ViewData["links"] = "";
            if (model1.PackageId > 0)
            {
                var model2 = db.tb_ProductMaster.ToList().Where(x => x.ProductId == Convert.ToInt32(model1.PackageId)).Single();
                var model3 = db.tb_UserMaster.ToList().Where(x => x.ParentId == Convert.ToInt32(Session["pmsuserid"])).AsEnumerable();
                Int32 total = model3.Count();
                if (total < Convert.ToInt32(model2.NoOfUsers))
                {
                    ViewData["links"] = "<a href='javascript:OpenPopup(&#34;/FamilyUser/create/&#34;);' id='contract' runat='server' ><img src='../../siteImages/create.png' border='0' alt='edit' style='width: 74px;height: 28px;' /></a>";
                }
            }
            return View();
        }

        //
        // GET: /Subject/Details/5

        public ActionResult Detail(Int32 id)
        {
            SetViews();
            var model = (from m in db.tb_UserMaster
                         where m.UserId == id
                         select m).Single();
            return View(model);
        }

        public ActionResult error()
        {
            return View();
        }

        public ActionResult Create()
        {
            SetViews();
            var model1 = db.tb_UserMaster.ToList().Where(x => x.UserId == Convert.ToInt32(Session["pmsuserid"])).Single();
            if (model1.PackageId > 0)
            {
                var model2 = db.tb_ProductMaster.ToList().Where(x => x.ProductId == Convert.ToInt32(model1.PackageId)).Single();
                var model3 = db.tb_UserMaster.ToList().Where(x => x.ParentId == Convert.ToInt32(Session["pmsuserid"])).AsEnumerable();
                Int32 total = model3.Count();
                if (total < Convert.ToInt32(model2.NoOfUsers)) { }
                else
                {
                    return RedirectToAction("error");
                }
                ViewData["buttonname"] = 1;
            }
            else
            {

                ViewData["errormsg"] = "Permission not found to add user";
                ViewData["msgStatus"] = "Permission not found to add user";
            
            }

            return View();
        }
        private Boolean ValidateData(tb_FamilyUser model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.UserName))
                ViewData.ModelState.AddModelError("username", "Please enter   user Name!");
            
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
        private Boolean validateRegisterData(string emailid, string password, string confirmPassword, tb_UserMaster model)
        {
            Boolean validateData = true;
        

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
             
            

            if (!ModelState.IsValid)
            {
                validateData = false;
            }
            return validateData;
        }
    
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_UserMaster model)
        {
            SetViews();
            ViewData["buttonname"] = 1;
            try
            {
                var model1 = db.tb_UserMaster.ToList().Where(x => x.UserId == Convert.ToInt32(Session["pmsuserid"])).Single();
                if (model1.PackageId > 0)
                {
                    var model2 = db.tb_ProductMaster.ToList().Where(x => x.ProductId == Convert.ToInt32(model1.PackageId)).Single();
                    var model3 = db.tb_UserMaster.ToList().Where(x => x.ParentId == Convert.ToInt32(Session["pmsuserid"])).AsEnumerable();
                    Int32 total = model3.Count();
                    if (total < Convert.ToInt32(model2.NoOfUsers)) { }
                    else
                    {
                        return RedirectToAction("error");
                    }

                    string emailid = model.EmailID;
                    string password = model.UserPassword;
                    string ConfirmPassword = model.ConfirmPassword;

                    if (Request.HttpMethod == "POST")
                    {

                        if (validateRegisterData(emailid, password, ConfirmPassword, model) == true)
                        {
                            string filename1 = "";
                            string filename2 = "";
                            string filename3 = "";

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


                            file = Request.Files[1];
                            if (file.ContentLength < 2000000)
                            {
                                String FileExtension = Path.GetExtension(file.FileName).ToLower();
                                if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                                {
                                    string randName = emailSystem.CreateRandomPassword(8);
                                    filename2 = randName + "_" + file.FileName;
                                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                                    file.SaveAs(filePath);
                                }
                            }

                            file = Request.Files[2];
                            if (file.ContentLength < 2000000)
                            {
                                String FileExtension = Path.GetExtension(file.FileName).ToLower();
                                if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                                {
                                    string randName = emailSystem.CreateRandomPassword(8);
                                    filename3 = randName + "_" + file.FileName;
                                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename3);
                                    file.SaveAs(filePath);
                                }
                            }

                            model.Picture = filename1;
                            model.DOBProof = filename2;
                            model.IDProof = filename3;
                            model.ParentId = Convert.ToInt32(Session["pmsuserid"]);
                            model.ConfirmDate = DateTime.Now;
                            model.ConfirmId = true;
                            model.AvtarName = model.Picture;
                            model.ClassId = 0;
                            model.CompanyId = 0;
                            model.Ipaddress = Request.ServerVariables["REMOTE_ADDR"].ToString(); ;
                            model.LastLogin = DateTime.Now;
                            model.LastUpdate = DateTime.Now;
                            model.Terms = true;
                            model.LastLogin = DateTime.Now;
                            model.AgreementEndDate = DateTime.Now;
                            model.AgreementStartDate = DateTime.Now;
                            model.PackageId = model1.PackageId;
                            model.CreateDate = DateTime.Now;

                            if (Convert.ToInt32(Session["cateid"]) == 8)
                            {
                                model.CategoryId = 8; // new admin
                            }
                            else
                            {
                                model.CategoryId = 9; //
                            }

                            model.UserName = model.ProfileName;
                            model.UnitHouseNo = "";
                       
                            db.tb_UserMaster.Add(model);
                            db.SaveChanges();
                            ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                            ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                            var tb = new tb_UserMaster();
                            return View(tb);
                        }
                        else
                        {
                            ViewData["errormsg"] = "Missing Something.......";
                        
                        }
                    }
                }
                else
                {
                    ViewData["errormsg"] = "Permission not found to add user";
                    ViewData["msgStatus"] = "Permission not found to add user";
                }
            }
            catch(Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();
        }

        // GET: /Subject/Edit/5
        public ActionResult Edit(int id)
        {
            SetViews();
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_UserMaster
                         where m.UserId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_UserMaster model)
        {
            try
            {
                SetViews();
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                var tb = (from m in db.tb_UserMaster
                          where m.UserId == id
                          select m).Single();

              
                string filename3 = "";

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


                file = Request.Files[1];
                if (file.ContentLength < 2000000)
                {
                    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        filename2 = randName + "_" + file.FileName;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                        file.SaveAs(filePath);
                    }
                }

                file = Request.Files[2];
                if (file.ContentLength < 2000000)
                {
                    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        filename3 = randName + "_" + file.FileName;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename3);
                        file.SaveAs(filePath);
                    }
                }


                if (filename1 != "")
                {
                    tb.Picture = filename1;
                }
                if (filename2 != "")
                {
                    tb.DOBProof = filename2;
                }

                if (filename3 != "")
                {
                    tb.IDProof = filename3;
                }

                tb.FirstName = model.FirstName;
                tb.MiddleName = model.MiddleName;
                tb.LastName = model.LastName;
                tb.ContactNo = model.ContactNo;
                tb.UserName = model.UserName;
                tb.CountryID = model.CountryID;

                if (model.DistrictId > 0)
                {
                    tb.DistrictId = model.DistrictId;
                }

                if (model.StateID > 0)
                {
                    tb.StateID = model.StateID;
                }
                tb.UserPassword = model.UserPassword;
                tb.ConfirmPassword = model.ConfirmPassword;
                tb.Street = model.Street;
                tb.Address = model.Address;
                tb.UnitHouseNo = model.UnitHouseNo;
                tb.TownCity = model.TownCity;
                tb.ZipCode = model.ZipCode;
                tb.SchoolName = model.SchoolName;
                tb.DOB = model.DOB;
             

                tb.UserName = model.UserName;
                tb.EmailID = model.EmailID;
                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
                var tb1 = new tb_UserMaster();
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
            SetViews();
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_UserMaster
                      where m.UserId == id
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
                SetViews();
                var model = db.tb_UserUnitInformation.ToList().Where(x => x.UserId == id);
                if (model.Count() == 0)
                {
                    //var tb = (from m in db.tb_UserMaster
                    //          where m.UserId == id
                    //          select m).Single();
                    //db.tb_UserMaster.Remove(tb);
                    //db.SaveChanges();
                    //var tb1 = new tb_UserMaster();

                    ViewData["errormsg"] = clsCommon.ErrorMessage(4);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(4);
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
