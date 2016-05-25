using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class paypalController : Controller
    {
        //
        // GET: /paypal/


        kzonlineEntities db = new kzonlineEntities();


        public ActionResult Thanks()
        {
            string token = "";
            string item_name = "";
            string item_number = "";
            int payer_id = 0;
            string status = "";
            string amt = "0";
            Int32 orderno = 0;

            string MonthlySubFee = "";
            String mc_currency = "";


            if (Request.QueryString["item_number"] != null)
            {
                item_number = Request.QueryString["item_number"];
            }



            if (Request.QueryString["tx"] != null)
            {
                token = Request.QueryString["tx"];
            }
            if (Request.QueryString["st"] != null)
            {
                status = Request.QueryString["st"];
            }

            if (Request.QueryString["mc_currency"] != null)
            {
                mc_currency = Request.QueryString["mc_currency"];
            }


            if (Session["offername"] != null)
            {
                item_name = Session["offername"].ToString();
            }

            if (Request.QueryString["amt"] != null)
            {
                amt = Request.QueryString["amt"];
            }



            if (Session["pmsuserid"] != null)
            {
                payer_id = Convert.ToInt16(Session["pmsuserid"].ToString());
            }

            if (Session["pmsuserid"] != null)
            {
                MonthlySubFee = Session["MonthlySubFee"].ToString();
            }





            if (token != "")
            {
                //var model2 = (from m in db.tb_PayPaPaymentHistory
                //              where m.TokenNo.Contains(token)
                //              select m);
                //if (model2.Count() == 0)
                //{
                tb_PayPaPaymentHistory model = new tb_PayPaPaymentHistory();
                model.TokenNo = token;
                model.item_name = item_name;
                model.item_number = item_number;
                model.payer_status = status;
                model.payer_id = payer_id.ToString();
                model.address_name = "Test";
                model.handling_amount = amt;
                model.SystemDate = DateTime.Now;

                model.CreatedBy = payer_id.ToString();
                model.CreationDate = DateTime.Now;
                model.DeletedBy = "0";
                model.DeletionDate = DateTime.Now;
                model.discount = 0;
                model.mc_currency = mc_currency;
                model.Gross_ms = Convert.ToDecimal(amt);
                model.insurance_amount = "0";
                model.discount = 0;

                db.tb_PayPaPaymentHistory.Add(model);
                db.SaveChanges();

                var usermaster22 = from t in db.tb_UserMaster
                                   where t.UserId == payer_id
                                   select t;
                string useremail = "";
                int userid = 0;


                string emailSubject = "";
                string emailDesc = "";

                if (usermaster22.Count() > 0)
                {
                    var usermaster = (from t in db.tb_UserMaster
                                      where t.UserId == payer_id
                                      select t).Single();
                    useremail = usermaster.EmailID;

                    userid = usermaster.UserId;


                    //if (item_name == "MonthlySubFee")

                    //if (MonthlySubFee == "MonthlySubFee")
                    //{
                    //    usermaster.MonthlyDeliveryFree = true;
                    //    usermaster.MonthlyDeliveryDate = System.DateTime.Now;
                    //    usermaster.MonthlyValidTill = System.DateTime.Now.AddYears(1);
                    //    usermaster.PaymentTokenNo = token;
                    //    // date need to add
                    //    // token no need to add
                    //    // may be some other detail
                    //    db.SaveChanges();
                    //    var emailModel = (from m in db.tb_EmailsDescription
                    //                      where m.Autoid == 4
                    //                      select m).Single();
                    //    emailSubject = emailModel.EmailSubject;
                    //    emailDesc = emailModel.Description;
                    //    return RedirectToAction("Index", "Home");

                    //    //return RedirectToAction("Index", "Viewcart");
                    //}
                    //else
                    //{
                    //    var emailModel = (from m in db.tb_EmailsDescription
                    //                      where m.Autoid == 3
                    //                      select m).Single();
                    //    emailSubject = emailModel.EmailSubject + "&nbsp; Lunchpacker";
                    //    emailDesc = emailModel.Description;

                    //    Session.Remove("currSession");
                    //}
                }

                // emailDesc = emailDesc.Replace("ProductName", item_name);
                // emailDesc = emailDesc.Replace("ProductCost", amt);
                // emailDesc = emailDesc.Replace("PaymentDate", DateTime.Now.ToString());
                //emailSystem.sendEmailold(useremail, emailDesc, emailSubject, Request.ServerVariables["REMOTE_ADDR"].ToString());

                //if (Session["pmsuserid"] != null)
                //{
                //    payer_id = Convert.ToInt16(Session["pmsuserid"].ToString());
                //}
                //setorderStatus(payer_id);

                if (item_number != null)
                {
                    orderno = Convert.ToInt32(item_number);
                }
                setorderStatus(orderno, "Paypal");
                setOrderMasterForEmail(orderno, "Paypal");


                emailSubject = "Payment Confirmation - Lunchpacker";
                //string strbody = "Hi " + model.LastName + ", <br/> <br/> Please your login informaiton for order online <br /> <br /> User Name  " + model.EmailID + "<br />";
                //strbody += "Password  " + model.UserPassword + "<br /> <br /> Thanks  <br /> <br /> Lunchpacker.ca ";

                //  emailDesc = "Hi  " + emailDesc + "<br /> <br /> Thanks  <br /> <br />  &nbsp; Lunchpacker.ca ";

                emailDesc = "Hi  <br /> <br />  Payment Confirmation <br /> <br /> Thanks  <br /> <br />  &nbsp; Lunchpacker.ca ";
              //  emailSystem.sendEmailold(useremail, emailSubject, emailDesc);
            }


            return View();
        }

        private void setorderStatus(int order_id, string paymentType)
        {

            //var order = from m in db.tb_OrderMaster where m.OrderAutoID == order_id && m.OrderStatus == null select m;
            //foreach (var item in order)
            //{

            //    var orderMas = (from m in db.tb_OrderMaster where m.OrderAutoID == item.OrderAutoID select m).Single(); ;

            //    orderMas.OrderStatus = "Y";
            //    orderMas.PaymentType = paymentType;

            //    var orderItemdetail = from m in db.tb_OrderItemDetail where m.OrderNumber == item.OrderAutoID select m;
            //    foreach (var item2 in orderItemdetail)
            //    {
            //        var itemdetail = (from m in db.tb_OrderItemDetail where m.OrderAuotID == item2.OrderAuotID select m).Single();
            //        itemdetail.OrderStatusDetail = "Y";
            //    }



            //    var shipdetail = from m in db.tb_ShoppingCart where m.OrderNumber == item.OrderAutoID select m;
            //    foreach (var item3 in shipdetail)
            //    {
            //        var shitemdetail = (from m in db.tb_ShoppingCart where m.CartID == item3.CartID select m).Single();
            //        shitemdetail.Status = "O";
            //    }


            //}
            //db.SaveChanges();
        }



        public ActionResult subscription(string emailid)
        {

            if (Request.QueryString["couseid"] != null)
            {
                Int32 idCourse = Convert.ToInt32(Request.QueryString["couseid"]);
                var tbsub = (from m in db.tb_SubjectMaster where m.SubjectId == idCourse select m).Single();

                ViewBag.Course = tbsub.SubjectName;

            }

            //var user = (from m in db.tb_UserMaster where m.EmailID == emailid select m).Single();

            //ViewBag.firstName = user.FirstName;
            //ViewBag.lastName = user.LastName;
            //ViewBag.payer_email = user.EmailID;
            //ViewBag.address1 = user.UserAddress;
            ////ViewBag.address2 = user.user;       

            //ViewBag.state = "BC";
            //ViewBag.zip = user.ZipCode;
            //string cityName = "";
            //if (user.CityID != null)
            //{
            //    Int32 cityID = Convert.ToInt32(user.CityID);
            //    var city = (from m in db.tb_CityMaster where m.CityID == cityID select m).Single();
            //    cityName = city.CityName;
            //}

            //ViewBag.city = cityName;
            //ViewBag.email = user.EmailID;
            //Session.Add("pmsUserID", user.UserID);
            //Session.Add("MonthlySubFee", "MonthlySubFee");
            //Session.Add("pmsusername", user.EmailID);
            //Session.Add("cateid", user.UserCateID);
            //Session.Add("moduleid", 0);
            ////  Session.Add("Imagepath", tb1.Picture);
            //Session.Add("emailid", user.EmailID);
            //Session.Add("LastName", user.LastName);

            ////<input type="hidden" name="night_phone_a" value="610">
            ////<input type="hidden" name="night_phone_b" value="555">
            ////<input type="hidden" name="night_phone_c" value="1234">

            //return View(user);
            return View();




        }

        //==============
        public ActionResult subscriptionpay(string emailid)
        {
            // CUSTOMIZE THIS: This is the seller's Payment Data Transfer authorization token.
            // Replace this with the PDT token in "Website Payment Preferences" under your account.
            string authToken = "Dc7P6f0ZadXW-U1X8oxf8_vUK09EHBMD7_53IiTT-CfTpfzkN0nipFKUPYy";
            string txToken = Request.QueryString["tx"];
            string query = "cmd=_notify-synch&tx=" + txToken + "&at=" + authToken;

            //Post back to either sandbox or live
            string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            string strLive = "https://www.paypal.com/cgi-bin/webscr";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSandbox);

            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = query.Length;


            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(query);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            Dictionary<string, string> results = new Dictionary<string, string>();
            if (strResponse != "")
            {
                StringReader reader = new StringReader(strResponse);
                string line = reader.ReadLine();

                if (line == "SUCCESS")
                {

                    while ((line = reader.ReadLine()) != null)
                    {
                        results.Add(line.Split('=')[0], line.Split('=')[1]);

                    }
                    Response.Write("<p><h3>Your order has been received.</h3></p>");
                    Response.Write("<b>Details</b><br>");
                    Response.Write("<li>Name: " + results["first_name"] + " " + results["last_name"] + "</li>");
                    Response.Write("<li>Item: " + results["item_name"] + "</li>");
                    Response.Write("<li>Amount: " + results["payment_gross"] + "</li>");
                    Response.Write("<hr>");
                }
                else if (line == "FAIL")
                {
                    // Log for manual investigation
                    Response.Write("Unable to retrive transaction detail");
                }
            }
            else
            {
                //unknown error
                Response.Write("ERROR");
            }
            return View();
        }
        //=============


        public void setOrderMasterForEmail(int orderid, string paymentType)
        {
            //string sessid = this.Session.SessionID;
            //string sessid = (Session["currSession"]).ToString();
            //var tbOrderMaster = (from m in db.tb_OrderMaster where m.SessionID == sessid && m.OrderStatus == null select m).Single();

            //var tbOrderMaster = (from m in db.tb_OrderMaster where m.OrderAutoID == orderid select m).Single();


            //string invMaster = "";

            //invMaster += "<body id='top' style='margin: 0;'> ";
            //invMaster += "<div id='white' style='width: 800px; margin: 0 auto;'> ";
            //invMaster += "<div class='background' style='width: 800px; margin: 0; padding: 0 0 5px 0; float: left;    background: url(http://lunchpacker.ca/SiteImages/background.png) repeat-y;'> ";
            ////            invMaster += "<div id='header' style='width: 767px; height: 127px; background: url(http://lunchpacker.ca/SiteImages/header.jpg);                   margin: 0 0 0 16px; float: left;'>";
            //invMaster += "<div id='header' style='width: 767px; height: 127px;                margin: 0 0 0 16px; float: left;'>";

            //invMaster += "<div class='logo' style='width: 200px; height: 85px; margin: 17px 0 0 10px; float: left;'>";
            //invMaster += "   <p style='text-align:center;'>    <img src='http://lunchpacker.ca/SiteImages/logo5.png' /></p></div> ";
            //invMaster += "</div>";
            //invMaster += "<h1 style='font-size: 18px; font-family: Arial; color: #c4110a; margin: 0px 0 5px 35px; font-weight: bold; float: left;'>         Your Order Details:</h1>";

            //invMaster += "<div id='tablebox' style='margin:10px 0 20px 30px; float:left; width:780px; '>";

            //invMaster += "<table >";
            //invMaster += "         <tr> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'>  </td>  <td width='10%'>         </td> </tr>";
            //invMaster += " <tr> <td width='10%'> Order Number   </td>    <td width='10%'> " + tbOrderMaster.OrderAutoID + " </td>   <td width='10%'> </td>  <td width='10%'> Order Date     </td> <td width='10%'>    " + string.Format("{0:d}", tbOrderMaster.OrderDate) + "  </td>      </tr>";
            //invMaster += "  <tr> <td width='10%'> </td> <td width='10%'> &nbsp;</td> <td width='10%'> </td> <td width='10%'>  </td>  <td width='10%'>         </td> </tr>";
            //invMaster += "  <tr> <td width='10%'> FROM </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> TO  </td>  <td width='10%'>         </td> </tr>";
            //invMaster += "  <tr> <td width='10%'> Lunchpacker,Delta BC  </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> Name </td>  <td width='10%'>      " + tbOrderMaster.FirstName + "&nbsp;&nbsp;" + tbOrderMaster.LastName + "    </td> </tr>";
            //if (tbOrderMaster.Address != null && tbOrderMaster.Address != "")
            //{
            //    invMaster += "  <tr> <td width='10%'> Phone no:- 778 897 0171 </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> Address </td>  <td width='10%'>      " + tbOrderMaster.Address + "    </td> </tr>";
            //}
            //else
            //{
            //    invMaster += "  <tr> <td width='10%'> Phone no:- 778 897 0171 </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'>  </td>  <td width='10%'>       </td> </tr>";
            //}
            //if (tbOrderMaster.CityName != null && tbOrderMaster.CityName != "")
            //{

            //    invMaster += "  <tr> <td width='10%'>  </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> City Name </td>  <td width='10%'>   " + tbOrderMaster.CityName + "   </td> </tr>";
            //}
            //if (tbOrderMaster.ContactNo != null && tbOrderMaster.ContactNo != "")
            //{
            //    invMaster += "  <tr> <td width='10%'>  </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> Contact No </td>  <td width='10%'>  " + tbOrderMaster.ContactNo + "  </td> </tr>";
            //}
            //invMaster += " <tr> <td width='10%'>  </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'>  </td>  <td width='10%'>   </td> </tr>";
            //invMaster += "         <tr> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'>  </td>  <td width='10%'>         </td> </tr>";
            //invMaster += "      <tr> <td width='10%'> </td> <td width='10%'> &nbsp;</td> <td width='10%'> </td> <td width='10%'>  </td>  <td width='10%'>         </td> </tr>";

            //invMaster += " <tr> <td width='10%'>  </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> <b> Shipping Address </b>  </td>  <td width='10%'>         </td> </tr>";
            //invMaster += " <tr> <td width='10%'>  </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> Address </td>  <td width='10%'>     " + tbOrderMaster.ShipAddress + "    </td> </tr>";
            //invMaster += " <tr> <td width='10%'>    </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> City Name </td>  <td width='10%'>    " + tbOrderMaster.ShipCityName + "   </td> </tr>";

            //invMaster += " <tr> <td width='10%'>    </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> Postal Code  </td>  <td width='10%'>   " + tbOrderMaster.ShipZipCode + "      </td> </tr>";
            //invMaster += " <tr> <td width='10%'>    </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> Contact No  </td>  <td width='10%'>   " + tbOrderMaster.ShipContactNo + "      </td> </tr>";

            //invMaster += "  <tr> <td width='10%'>      </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'>   </td>  <td width='10%'>   </td> </tr>";
            //invMaster += "       <tr> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'>  </td>  <td width='10%'>         </td> </tr>";
            //invMaster += " <tr> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'> </td> <td width='10%'>  </td>  <td width='10%'>         </td> </tr>";
            //invMaster += "</table>";


            //var tbInvDetail = from m in db.tb_OrderItemDetail where m.OrderNumber == orderid select m;
            //string InvDetail = "";
            //int count = 1;
            //decimal GrandTotal = 0;
            //decimal deliveryCharges = 0;
            //int totalqty = 0;
            //decimal gst = 0;
            //decimal pst = 0;
            //DateTime delDate = System.DateTime.Now;
            //string delTime = "";

            //InvDetail += " <table >   <tr>  <td>   </td>   <td>    </td>  <td>      <div align='center'><h2 style='font-size: 18px; font-family: Arial; color: #c4110a; margin: 0px 0 5px 0; font-weight: bold; text-align:center;'>ITEM DETAILS </h2> </div>  </td>  <td> </td>   <td>    </td>   </tr> ";

            //InvDetail += "              <tr> <td  colspan='5'>  ______________________________________________________________________________________________________  </td> </tr> ";

            //InvDetail += "           <tr>  <td>   </td>   <td>    </td>  <td>          &nbsp;             </td>  <td> </td>   <td>    </td>   </tr> ";
            //InvDetail += "    <td width='11%'>   S. No.</td>   <td width='11%'> &nbsp; Quantity  </td>    <td width='38%'> &nbsp; Product Name    </td> <td width='21%'>  &nbsp; Price CAD $  </td> <td width='19%'>  &nbsp; Amount  </td>  </tr>";
            //InvDetail += "           <tr>  <td>   </td>   <td>    </td>  <td>          &nbsp;             </td>  <td> </td>   <td>    </td>   </tr> ";
            //foreach (var item in tbInvDetail)
            //{
            //    InvDetail += " <tr> <td> &nbsp;" + count + " </td> <td> &nbsp; " + item.Quantity + " </td> <td> &nbsp;" + item.Name + "&nbsp;" + item.size + "&nbsp; <br/> " + item.ToppingDescription +" &nbsp; "+item.ToppingPrice+" </td> <td> &nbsp;" + item.Price + "  </td> <td> " + item.TotalAmount + " </td>  </tr>";
            //    count += 1;
            //    GrandTotal += Convert.ToDecimal(item.TotalAmount);
            //    totalqty += Convert.ToInt32(item.Quantity);
            //    // pst = (GrandTotal * 7) / 100;
            //    gst = (GrandTotal * 5 / 100);
            //    delDate = Convert.ToDateTime(item.deliveryDateTime);
            //    delTime = item.delTime;

            //    if (item.DeliveryCharges > 0)
            //    {
            //        deliveryCharges = Convert.ToDecimal(item.DeliveryCharges);
            //    }
            //}

            //InvDetail += "              <tr> <td  colspan='5'>  ______________________________________________________________________________________________________ </td> </tr> ";
            //InvDetail += "           <tr>  <td> Total  </td>   <td> " + totalqty + "  </td>  <td>          &nbsp;             </td>  <td> </td>   <td> " + GrandTotal + "  </td>   </tr> ";
            //InvDetail += "              <tr> <td  colspan='5'> ______________________________________________________________________________________________________ </td> </tr> ";
            //InvDetail += "           <tr>  <td>   </td>   <td>   GST   </td>  <td>          &nbsp;             </td>  <td> </td>   <td> " + string.Format("{0:F}", gst) + "  </td>   </tr> ";
            //InvDetail += "           <tr>  <td>   </td>   <td>   Delivery Charges   </td>  <td>          &nbsp;             </td>  <td> </td>   <td> " + string.Format("{0:F}", deliveryCharges) + "  </td>   </tr> ";

            ////InvDetail += "           <tr>  <td> Total  </td>   <td>   PST   </td>  <td>          &nbsp;             </td>  <td> </td>   <td> " + pst + "  </td>   </tr> ";
            //InvDetail += "           <tr>  <td> Total  </td>   <td>   Grand Total   </td>  <td>  CAD $        &nbsp;             </td>  <td> </td>   <td> " + string.Format("{0:F}", (GrandTotal + gst + deliveryCharges)) + "  </td>   </tr>";

            //InvDetail += "           <tr>  <td> Deleviery Date   </td>   <td> " + string.Format("{0:d}", delDate) + " </td>  <td>          Time        " + delTime + "     </td>  <td colspan='5'> " +paymentType +" </td>   </tr>";

            //InvDetail += "  </table> ";
            ////InvDetail += "           <tr>  <td> Total  </td>   <td>   Grand Total   </td>  <td>          &nbsp;             </td>  <td> </td>   <td> " + (GrandTotal + pst) + "  </td>   </tr>  
            //InvDetail += "  </table> ";

            //InvDetail += " </div>";
            //InvDetail += "       <div class='footer' style='width: 771px; height: 36px; margin: 0 0 0 15px; float: left;                    background: url(http://lunchpacker.ca/SiteImages/footer.png);'>";
            //InvDetail += "  <h2 style='font-size: 12px; margin: 10px 0 0 20px; float: left; color: #FFFFFF; font-family: Arial;'>                        Copyright © 2015 Lunchpacker All Rights Reserved.</h2>";
            //InvDetail += " </div>";
            //InvDetail += " </div>";
            //InvDetail += " </div>";
            //InvDetail += " </body>";


            //string emailbody = invMaster + InvDetail;

            //emailSystem.sendEmailold(tbOrderMaster.EmailID, "Your Order from Lunchpacker.ca", emailbody);


        }


        public ActionResult payondelivery(Int32 id)
        {

            setorderStatus(id,"Pay on Delivery");
            setOrderMasterForEmail(id, "Pay on Delivery");
            return View();

        }
    }

}

