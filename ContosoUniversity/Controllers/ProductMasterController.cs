using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class ProductMasterController : Controller
    {
        //
        // GET: /Subject/

        kzonlineEntities db = new kzonlineEntities();
        private void displayTopbutton(Int32 ProductId)
        {  
            var model = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId ==1).Single();
            String Buttons = "<a  style='float:right;' class='btn-grey' href='javascript:OpenPopup1(&#34;/ProductMaster/Permission/" + ProductId + "?buttonid=" + ProductId + "&#34;,&#34;Browser" + ProductId.ToString() + "&#34;);' /><img  width='60px' height='60px' src='../../uploads/" + model.ImagePath + "' /><br />" + model.ButtonName + "</a>";
            ViewData["topbuttons"] = Buttons;
        }

        private void pkglist()
        {
            var ddList = (from m in db.tb_Subscription
                          select new
                          {
                              Name = m.SubsName,
                              ID = m.Duration
                          });

            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["pkglist"] = selectList;

        }
        private void CreatePermission(Int32 ProductId)
        {

            var detail = from m in db.tb_ProductLinkedClass
                         where m.ProductId == ProductId
                         select m;

            foreach (var detail1 in detail)
            {
                db.tb_ProductLinkedClass.Remove(detail1);
            }
            db.SaveChanges();



            if (Request.Form.GetValues("selectedObjects") != null)
            {
                int total = Convert.ToInt32(Request.Form.GetValues("selectedObjects").Count());
                Int32 ClassId = 0;
                string mystring = "";
                for (int i = 0; i < total; i++)
                {
                    mystring = Request.Form.GetValues("selectedObjects")[i].ToString();
                    ClassId = Convert.ToInt32(mystring);

                    tb_ProductLinkedClass sb = new tb_ProductLinkedClass();

                    sb.UserId = Convert.ToInt32(Session["pmsuserid"]);
                    sb.ProductId = Convert.ToInt32(ProductId);
                    sb.ClassId = ClassId;
                    sb.SystemDate = DateTime.Now;

                    db.tb_ProductLinkedClass.Add(sb);
                    db.SaveChanges();
                }

            }



        }
        public ActionResult Permission(Int32 id)
        {
            if (Request.HttpMethod == "POST")
            {
                CreatePermission(id);
                ViewData["msg"] = clsCommon.ErrorMessage(5);
            }
            string strtables = "<table width='100%' border='0'>";



            var model2 = db.tb_ProductClassMaster.ToList().OrderBy(x => x.ClassName);

            Int32 counter = 0;
            foreach (var item in model2)
            {
                var model = db.tb_ProductLinkedClass.ToList().Where(x => x.ProductId == id && x.ClassId == item.AutoId);
                counter += 1;
                if (counter == 1)
                {
                    strtables += "<tr>";
                }
                if (model.Count() > 0)
                {
                
                    strtables += "<td width='33%'><input type='checkbox' checked='checked' name='selectedObjects' value='" + item.AutoId + "'>" + item.ClassName + "</td>";
                    
                }
                else
                {
                    strtables += "<td width='33%'><input type='checkbox' name='selectedObjects' value='" + item.AutoId + "'>" + item.ClassName + "</td>";
                }

                if (counter == 3)
                {
                    counter = 0;
                    strtables += "</tr>";
                }

            }
            if (counter == 1)
            {
                counter = 0;
                strtables += "</tr>";
            }
            strtables += "</table>";
            ViewData["permissionlist"] = strtables;

            return View();
        }
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Product Information");
           var Llist = db.tb_ProductMaster.ToList();
           string strTable = "";
            string status="";
            foreach (var item in Llist)
            {
                status = "Hide";
                if (item.Publish == true)
                {
                    status = "Show";
                }
                strTable += "<tr>";
                strTable += "<td>" + item.ProductName + "</td>";
                strTable += "<td>" + item.ShortName + "</td>";
                strTable += "<td>" + item.NoOfUsers + "</td>";
                strTable += "<td>" + item.Price + "</td>";
                strTable += "<td>" + item.Discount + "</td>";
                strTable += "<td>" + item.PriceDis + "</td>";

                strTable += "<td>" + status + "</td>";


                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/productmaster/edit/" + item.ProductId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/productmaster/Delete/" + item.ProductId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/productmaster/Permission/" + item.ProductId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/badd.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

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


        public ActionResult Create()
        {
            pkglist();
            ViewData["buttonname"] = 1;

            return View();
        }
        private Boolean ValidateData(tb_ProductMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.ProductName))
                ViewData.ModelState.AddModelError("ProductName", "Please enter   Product Name!");
            if (string.IsNullOrEmpty(model.ShortName))
                ViewData.ModelState.AddModelError("ShortName", "Please enter  Short Name!");

            if (model.NoOfUsers == 0 || model.NoOfUsers == null)
                ViewData.ModelState.AddModelError("NoOfUsers", "Please enter  No Of Users!");

           
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
    
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_ProductMaster model)
        {
            pkglist();
            ViewData["buttonname"] = 1;
            try
            {
                if (Request.HttpMethod == "POST")
                {
                    if (ValidateData(model))
                    {
                        //model.CompanyId = 0;
                        //model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                        //model.SystemDate = DateTime.Now;
                        //model.IpAddress = Request.ServerVariables["remote_address"];
                        db.tb_ProductMaster.Add(model);
                        db.SaveChanges();
                        ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                        ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                        return View();
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
            pkglist();
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_ProductMaster
                         where m.ProductId == id
                         select m).Single();
            Session.Add("ModuleName0", "Product Information :" + model.ProductName);
            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_ProductMaster model)
        {
            try
            {
                pkglist();
                ViewData["buttonname"] = 2;
            
                var tb = (from m in db.tb_ProductMaster
                          where m.ProductId == id
                          select m).Single();
                tb.NoOfUsers = model.NoOfUsers;
                tb.ProductName = model.ProductName;
                tb.ShortName = model.ShortName;
                tb.Description = model.Description;
                tb.SubsId = model.SubsId;
                tb.Publish = model.Publish;
                tb.Price = model.Price;
                tb.PriceDis = model.PriceDis;
                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);

                var tb1 = new tb_ProductMaster();
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
            pkglist();
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_ProductMaster
                      where m.ProductId == id
                      select m).Single();
            return View(tb);
        }

        //
        // POST: /Subject/Delete/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            pkglist();
            try
            {
                var model = db.tb_UserMaster.ToList().Where(x => x.PackageId == id);
                if (model.Count() == 0)
                {
                    var tb = (from m in db.tb_ProductMaster
                              where m.ProductId == id
                              select m).Single();

                    db.tb_ProductMaster.Remove(tb);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
                }
                else
                {
                    ViewData["errormsg"] = clsCommon.ErrorMessage(4);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(4);
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
