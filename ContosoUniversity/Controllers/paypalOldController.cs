using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class paypalOldController : Controller
    {
        //
        // GET: /paypal/

        kzonlineEntities db = new kzonlineEntities();
        //private string getOffer(Int32 cateid)
        //{
        //    string result = "";

        //    var tb1 = (from m in db.tb_OffersMasters
        //              where m.CategoryID == cateid
        //              select m);
        //    if (tb1.Count() > 0)
        //    {
        //        var tb = (from m in db.tb_OffersMasters
        //                  where m.CategoryID == cateid
        //                  select m).Single();
        //        if (cateid == 1)
        //        {
        //            ViewData["package0"] = tb.OfferHead;
        //            ViewData["package00"] = tb.OfferDesc;
        //        }
        //        if (cateid == 3)
        //        {
        //            ViewData["package1"] = tb.OfferHead;
        //            ViewData["package11"] = tb.OfferDesc;
        //        }
        //        if (cateid == 7)
        //        {
        //            ViewData["package2"] = tb.OfferHead;
        //            ViewData["package22"] = tb.OfferDesc;
        //        }
        //    }
        //    return result;
        //}
        //private string getString(Int32 id)
        //{
        //    string result = "";

        //    var tb = (from m in db.tb_OffersMasters
        //              from t in db.pms_UserMainCategories
        //              where m.CategoryID == t.MainCateid
        //              && m.CategoryID == id
        //              select new AllProperties
        //              {
        //                  OfferName = m.OfferDuration,
        //                  OfferPrice = m.OfferPrice.ToString(),
        //                  OfferFor = t.MainCateName,
        //                  OfferPriceDis = m.OfferDiscounted.ToString(),
        //                  OfferId = m.ID.ToString()

        //              }
        //    );

        //    string strtables = "";
         
          
        //    foreach (var items1 in tb)
        //    {
        //        strtables += "<li><table width='100%' border='0' cellspacing='0' cellpadding='0'>";
        //        strtables += "<tr>";
        //        if (id == 1)

        //        {
        //            strtables += "<td width='10%' align='left' valign='top'><input type='radio' checked='checked' name='groups' value='" + items1.OfferId + "'> </td>";
        //        }
        //        if (id == 7)
        //        {
        //            strtables += "<td width='10%' align='left' valign='top'><input type='radio' checked='checked' name='groups' value='" + items1.OfferId + "'> </td>";
        //        }
        //        if (id == 3)
        //        {
        //            strtables += "<td width='10%' align='left' valign='top'><input type='radio' checked='checked' name='groups' value='" + items1.OfferId + "'> </td>";
        //        }
        //        strtables += "   <td width='33%' align='left' valign='top'>" + items1.OfferName + "</td>";
        //        strtables += "   <td width='57%' align='left' valign='top' class='rate'><span>$" + items1.OfferPrice + "*</span><br />$" + items1.OfferPriceDis + "*</span></td>";
        //        strtables += " </tr>";
        //        strtables += "</table>";
        //        strtables += "</li>";

        //    }
        //    if (id == 1)
        //    {
        //        ViewData["Schoolssoffer"] = strtables;
        //    }
        //    if (id == 7)
        //    {
        //        ViewData["collegesoffers"] = strtables;
        //    }
        //    if (id == 3)
        //    {
        //        ViewData["universityoffers"] = strtables;
        //    }
        //    result = strtables;

        //    return result;
        //}
        //public ActionResult Index()
        //{
        //    ViewData["showGoogleAd"] = "Yes";

        //    var model = (from m in db.tb_pageDescriptions
        //                 where
        //                     m.Pageid == 14
        //                 select m).Single();

        //    ViewData["pagedescription"] = model.Description;
        //    Session.Add("activestep", 0);

        //    getOffer(1);
        //    getOffer(3);
        //    getOffer(7);

        //    getString(1);
        //    getString(7);
        //    getString(3);
        //    return View();
        //}
        //public ActionResult token()
        //{
          
        //    return View();
        //}


        public ActionResult Thanks()
        {
            string token = "";
            string item_name = "";
            string item_number = "";
            string payer_id = "0";
            string status = "";
            string amt = "0";
            Session.Add("activestep", 4);

            if (Request.QueryString["tx"] != null)
            {
                token = Request.QueryString["tx"];
            }
            if (Request.QueryString["st"] != null)
            {
                status = Request.QueryString["st"];
            }

            if (Request.QueryString["item_number"] != null)
            {
                item_number = Request.QueryString["item_number"];
            }

            if (Session["offername"] != null)
            {
                item_name = Session["offername"].ToString();
            }

            if (Request.QueryString["amt"] != null)
            {
                amt = Request.QueryString["amt"];
            }
            if (Session["regswiuserid"] != null)
            {
                payer_id = Session["regswiuserid"].ToString();
            }


            if (token != "")
            {

                var model21 = (from m in db.tb_PayPaPaymentHistory
                             where m.TokenNo.Contains(token)
                             select m);
                if (model21.Count() == 0)
                {
                    tb_PayPaPaymentHistory model = new tb_PayPaPaymentHistory();
                    model.TokenNo = token;
                    model.item_name = Session["itemname"].ToString();
                    model.item_number = Session["productid"].ToString();
                    model.payer_status = status;
                    model.payer_id = payer_id.ToString();
                    model.address_name = "Test"; 
                    model.handling_amount = amt;
                    model.SystemDate = DateTime.Now;

                    db.tb_PayPaPaymentHistory.Add(model);
                    db.SaveChanges();
                    //buyProduct(Convert.ToInt32(Session["projectid"]), item_name);

                    Int32 userid = Convert.ToInt32(Session["PayPalUserId"]);
                    var model2 = db.tb_UserMaster.ToList().Where(x => x.UserId == userid).Single();
                    Int32 ProductId = Convert.ToInt32(model2.PackageId);
                    var Productmodel = db.tb_ProductMaster.ToList().Where(x => x.ProductId == ProductId).Single();

                    //Product Detail
                    var item = (from m in db.tb_emailsDescription
                                where m.Autoid == 6
                                select m).Single();
                    string desc = item.Description;
                    desc = desc.Replace("UserName", model2.ProfileName);
                    String ProductDetail = "";
                    ProductDetail += "<br /> Product Name: <b>" + Productmodel.ProductName + "</b>";
                    ProductDetail += "<br /> Description: " + Productmodel.Description;
                    ProductDetail += "<br /> Price: " + Productmodel.PriceDis;
                    ProductDetail += "<br /> User Licence : " + Productmodel.NoOfUsers;
                    desc = desc.Replace("ProductDetail", ProductDetail);
                    emailSystem.sendNewFormat(model2.EmailID, item.EmailSubject, desc);

                    var item1 = (from m in db.tb_emailsDescription
                                 where m.Autoid == 7
                                 select m).Single();
                    desc = item1.Description;
                    desc = desc.Replace("UserName", model2.ProfileName);
                    emailSystem.sendNewFormat(model2.EmailID, item1.EmailSubject, desc);

                }
            }


            return View();
        }
        //protected void buyProduct(Int32 productid, String strClientName)
        //{
        //    try
        //    {

        //        Int32 intRefidUser;
        //        Int32 intClientID = 0;
        //        intClientID = Convert.ToInt32(Session["pmsuserid"]);
        //        intRefidUser = intClientID;

        //        var tm = (from m in db.tb_ProjectMasters
        //                  from a in db.tb_ProjectDetails
        //                  where m.ProjectID == a.ProjectID
        //                  && m.ProjectID == productid && m.DeleteStatus=="N"
        //                  select
        //                 new
        //                 {
        //                     m.ProjectID,
        //                     a.TaskID,
        //                     m.ProjectCost,
        //                     m.Description,
        //                     m.CategoryID,
        //                     m.ProjectName,
        //                     m.AssociateID,
        //                     m.ProjectCode
        //                 }
        //                   );

        //        DateTime startdate = DateTime.Now.Date;
        //        DateTime enddate = DateTime.Now.Date;

        //        if (tm.Count() > 0)
        //        {
        //            Int32 i = 0;
        //            Int32 refid = 0;
        //            Int32 lastAsso = 0;
        //            foreach (var item in tm)
        //            {
        //                if (i == 0)
        //                {
        //                    tb_ProjectClientMaster tbs = new tb_ProjectClientMaster();
        //                    tbs.createdDate = DateTime.Now;

        //                    tbs.ProjectID = Convert.ToInt32(Convert.ToInt32(productid));
        //                    tbs.ProjectCode = item.ProjectCode;
        //                    tbs.ProjectName = item.ProjectName;
        //                    tbs.ProjectCost = item.ProjectCost;
        //                    tbs.Description = item.Description;
        //                    tbs.PaymentAmount = 0;
        //                    tbs.PaymentChqDD = "";
        //                    tbs.PaymentDescription = "";
        //                    tbs.FinalClientView = "";
        //                    tbs.DemoLink1 = "";
        //                    tbs.DemoLink2 = "";
        //                    tbs.Priority = "Normal";
        //                    tbs.ClientStatus = false;
        //                    tbs.CategoryID = item.CategoryID;
        //                    tbs.ClientID = intClientID;
        //                    tbs.ReferenceIDUser = intRefidUser;
        //                    tbs.Remarks = "";
        //                    tbs.StatusOfProject = 0;
        //                    tbs.PaymentStatus = "O";
        //                    db.tb_ProjectClientMasters.InsertOnSubmit(tbs);
        //                    db.SubmitChanges();
        //                    refid = tbs.ProjectID;
        //                    i += 1;

        //                }

        //                tb_SubProjectDetail sb4 = (from p in db.tb_SubProjectDetails
        //                                           where
        //                                           p.SubProjectID == item.TaskID
        //                                           select p).Single();

        //                tb_ProjectClientDetail sb = new tb_ProjectClientDetail();
        //                int associate = 0;
        //                if (item.AssociateID != null)
        //                {
        //                    associate = Convert.ToInt32(item.AssociateID);
        //                }
        //                sb.ProjectID = Convert.ToInt32(refid);
        //                sb.OfferID = Convert.ToInt32(item.TaskID);
        //                sb.OfferName = sb4.TaskName;
        //                sb.Status = 'F';
        //                sb.PaymentStatus = 'F';
        //                sb.Remarks = "N/A";
        //                sb.Wdays = sb4.WorkingDays;

        //                sb.StartDateActual = startdate;
        //                sb.StartDate = startdate;

        //                sb.Amount = 0;
        //                sb.AssociateID = item.AssociateID;

        //                enddate = startdate;
        //                enddate = Convert.ToDateTime(enddate.AddDays(Convert.ToDouble(sb4.WorkingDays)));

        //                sb.EndDate = enddate;
        //                sb.EndDateActual = enddate;

        //                startdate = enddate;
        //                sb.ClientID = intClientID;
        //                sb.ClientName = strClientName;
        //                sb.RefID = intRefidUser;




        //                sb.DateOfRecieved = DateTime.Now;
        //                db.tb_ProjectClientDetails.InsertOnSubmit(sb);
        //                db.SubmitChanges();

        //                if (lastAsso != associate)
        //                {
        //                    string associateEmail = getEmailid(associate);
        //                    emailSystem.sendEmail(associateEmail, "", 11);
        //                    lastAsso = associate;
        //                }

        //            }
        //            string clientEmail = getEmailid(intClientID);
        //            Int32 UpUserid = getUplineid(intClientID);
        //            string UpEmailAddress = getEmailid(UpUserid);

        //          ///  emailSystem.sendEmail(clientEmail, "", 9);
        //           /// emailSystem.sendEmail(UpEmailAddress, "", 10);




        //        }
        //        else
        //        {


        //        }

        //    }
        //    catch (Exception exc)
        //    {
        //        Response.Write(exc.Message);
        //        //lblmessage.Text = exc.Message;
        //    }

        //}
        //private string getEmailid(Int32 userid)
        //{
        //    string emailaddress = "";
        //    var client11 = (from m in db.pms_UserMasters
        //                    where m.UserID == userid
        //                    select m);
        //    if (client11.Count() > 0)
        //    {
        //        var client1 = (from m in db.pms_UserMasters
        //                       where m.UserID == userid
        //                       select m).Single();
        //        emailaddress = client1.EmailID;
        //    }
        //    return emailaddress;

        //}
        //private Int32 getUplineid(Int32 userid)
        //{
        //    Int32 upUserID = 0;
        //    var client11 = (from m in db.pms_UserMasters
        //                    where m.UserID == userid
        //                    select m);
        //    if (client11.Count() > 0)
        //    {
        //        var client1 = (from m in db.pms_UserMasters
        //                       where m.UserID == userid
        //                       select m).Single();
        //        upUserID = Convert.ToInt32(client1.ReferUserID);
        //    }
        //    return upUserID;

        //}
        ////
        // GET: /paypal/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }
        //public ActionResult Paysend()
        //{
        //    Int32 offerid = 0;
        //    String mystring = "";

        //    if (Request.Form.GetValues("groups") != null)
        //    {
        //        int total = Convert.ToInt32(Request.Form.GetValues("groups").Count());



        //        for (int i = 0; i < total; i++)
        //        {
        //            mystring = Request.Form.GetValues("groups")[i].ToString();
        //            offerid = Convert.ToInt32(mystring);
        //        }
        //    }
        //    var tb = (from m in db.tb_OffersMasters
        //              from t in db.pms_UserMainCategories
        //              where m.CategoryID == t.MainCateid
        //              && m.ID == offerid
        //              select new AllProperties
        //              {
        //                  OfferName = m.OfferDuration,
        //                  OfferPrice = m.OfferPrice.ToString(),
        //                  OfferFor = t.MainCateName,
        //                  OfferPriceDis = m.OfferDiscounted.ToString(),
        //                  OfferCatid = Convert.ToInt32(t.MainCateid),
        //                  OfferId = m.ID.ToString()

        //              }
        //   ).Single();
        //    String offername = "";
            

        //    Session.Add("discountedamount", tb.OfferPriceDis.ToString());
        //    Session.Add("OfferName", tb.OfferName + " Registeration for " + tb.OfferFor);
        //    Session.Add("Offerid", tb.OfferPriceDis.ToString());
        //    Session.Add("activestep", 2);

        //    return RedirectToAction("create", "register", new { id = 1, regid = tb.OfferCatid });
            
        //}

        //
        // GET: /paypal/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /paypal/Create

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
        // GET: /paypal/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /paypal/Edit/5

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
        // GET: /paypal/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /paypal/Delete/5

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
