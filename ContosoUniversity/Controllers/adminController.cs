using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class adminController : Controller
    {
        //
        // GET: /admin/
        kzonlineEntities db = new kzonlineEntities();
        private void SetViews()
        {

            var ddList = (from m in db.tb_RegCategory
                          select new
                          {
                              Name = m.RegTypeName,
                              ID = m.RegTypeId
                          });
            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["categorylist"] = selectList;

            var ddListy = (from m in db.tb_CountryMaster
                           select new
                           {
                               Name = m.CountryName,
                               ID = m.CountryID
                           });

            var selectList2y = new SelectList(ddListy, "ID", "Name");
            ViewData["countrylist"] = selectList2y;

        }
        public ActionResult edit(int id, tb_UserMaster model2)
        {
            SetViews();
            
            if (Request.HttpMethod == "POST")
            {
                Int32 categoryid = 0;
                if (Request.Form["CategoryId"] != null)
                {
                    categoryid = Convert.ToInt32(Request.Form["CategoryId"]);
                }
                
                var model05 = db.tb_UserMaster.ToList().Where(m => m.EmailID == model2.EmailID);
                var model1 = db.tb_UserMaster.ToList().Where(m => m.UserId == id).Single();

                model1.FirstName = model2.FirstName;
                model1.MiddleName = model2.MiddleName;
                model1.LastName = model2.LastName;
                model1.ContactNo = model2.ContactNo;


                model1.ZipCode = model2.ZipCode;
                model1.Street = model2.Street;
                model1.Address = model2.Address;
                model1.UnitHouseNo = model2.UnitHouseNo;
                model1.TownCity = model2.TownCity;



                if (model1.ConfirmId != model2.ConfirmId)
                {
                    model1.ConfirmId = model2.ConfirmId;
                    model1.ConfirmDate = DateTime.Now;
                }


                ViewData["emailstatus"] = "";
                if (model05.Count() == 0)
                {
                    model1.EmailID = model2.EmailID;
                }
                else
                {
                    ViewData["emailstatus"] = "Email address can not change, Already Exists....";
                }

                model1.ProfileName = model2.ProfileName;
                model1.CategoryId = categoryid;
                model1.UserPassword = model2.UserPassword;
                model1.ConfirmPassword = model2.UserPassword;

                if (Request.Form["StateID"] != null)
                {
                    model1.StateID = Convert.ToInt32(Request.Form["StateID"]);
                }

                model1.DistrictId = model2.DistrictId;
                model1.CountryID = model2.CountryID;


                db.SaveChanges();
                ViewData["msg"] = "User Information updated successfully..";
            }
            var model11 = db.tb_UserMaster.ToList().Where(m => m.UserId == id).Single();

            return View(model11);

        }

        public ActionResult Tracking()
        {
            var Llist = (from m in db.tb_UserPageHistory
                         from t in db.tb_UserMaster
                         where m.UserID == t.UserId
                         select new
                         {
                             t.ProfileName,
                             t.EmailID,
                             m.IpAddress,
                             m.AccessDate,
                             m.PageName
                         }
                        ).OrderByDescending(x => x.AccessDate);



            Int32 mcounter = 0;
            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr class='even'>";
                strTable += "<td>" + item.EmailID + "</td>";
                strTable += "<td>" + item.ProfileName + "</td>";
                strTable += "<td>" + item.IpAddress + "</td>";
                strTable += "<td>" + item.AccessDate + "</td>";
                strTable += "<td>" + item.PageName + "</td>";
                strTable += "</tr>";
            }
            ViewData["userlist"] = strTable;

            return View();
        }

        public ActionResult userlist()
        {
            Int32 CatId = 8;
            ViewData["links"] = "<a href='javascript:OpenPopup(&#34;/usermaster/create/&#34;);' id='contract' runat='server' ><img src='../../Images/createnew.png' border='0' alt='edit' style='width: 50px;height: 50px;' /></a>";
     
            if (Request.QueryString["catid"] != null)
            {
                CatId =Convert.ToInt32(Request.QueryString["catid"]);
            }

            var gmodel = db.tb_RegCategory.ToList().Where(x => x.RegTypeId == CatId).Single();
            ViewData["category"] = gmodel.RegTypeName;


            var Llist = db.tb_UserMaster.ToList().AsQueryable();
            if (CatId>0)
            {
                Llist = Llist.Where(x => x.CategoryId == CatId);
            }
            string strTable = "";

            strTable += "<tr class='odd'>";
            strTable += "<td><a href='/admin/userlist/?catid=8' ><b>Admin</b></a></td>";
            strTable += "<td><a href='/admin/userlist/?catid=2' ><b>Parents</b></a></td>";
            strTable += "<td><a href='/admin/userlist/?catid=3' ><b>Teachers</b></a></td>";
            strTable += "<td><a href='/admin/userlist/?catid=9' ><b>Student</b></a></td>";
            strTable += "<td></td>";
            strTable += "<td></td>";
            strTable += "<td></td>";
            strTable += "</tr>";
            Int32 mcounter = 0;

            foreach (var item in Llist)
            {
                mcounter += 1;
                if (mcounter % 2 == 0)
                {
                   // strTable += "<tr  bgcolor='#DDEEEE'>";
                }
                else
                {
                   
                }
                strTable += "<tr class='even'>";
                strTable += "<td>" + item.EmailID + "</td>";
                strTable += "<td>" + item.FirstName + " " + item.MiddleName + "" + item.LastName + "</td>";
                strTable += "<td>" + item.UserPassword + "</td>";
                strTable += "<td>" + item.ProfileName + "</td>";
                //strTable += "<td>" + item.ContactNo + "</td>";
                //strTable += "<td>" + item.Address + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/usermaster/edit/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/usermaster/Delete/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/admin/ViewSubDetail/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Viewb.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "</tr>";
            }
            ViewData["userlist"] = strTable;

            return View();
        }
        public ActionResult ViewSubDetail(Int32 id)
        {
            var model = db.tb_UserMaster.ToList().Where(x => x.ParentId == id);
            string strTable = "";
            foreach (var item in model)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.UserName + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/FamilyUser/edit/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/FamilyUser/Delete/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/FamilyUser/Detail/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/show.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "</tr>";
            }

            ViewData["data"] = strTable;

            return View();
        }

        //
        // GET: /admin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /admin/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /admin/Create

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
        // GET: /admin/Edit/5
   

        //
        // GET: /admin/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /admin/Delete/5

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
