using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.DAL;
using OLProject.ViewModels;

using OLProject.Models;
namespace OLProject.Controllers
{
    public class HomeController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        // private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {


            //var toprec = (from m in db.tb_SubjectMaster where m.Publish == true && m.PublishAdmin== true select m).Take(8);

            // var toprec = db.tb_SubjectMaster.Where(x => x.Publish == true && x.PublishAdmin == true && x.SubjectId!= 26 && x.SubjectId != 27 && x.SubjectId != 28   && x.SubjectId != 46 && x.SubjectId != 51).Select(x => new { x.SubjectName, x.Price, x.SubjectImge, x.SubjectId, x.ShortDescription });

            string strQuery = "select * from tb_SubjectMaster where Publish = 1 and PublishAdmin = 1  and SubjectId <> 26 and SubjectId  <> 27 and SubjectId <> 28 and SubjectId <> 46 and SubjectId <> 51 ";

            //    select* from tb_SubjectMaster where Publish == 1 and PublishAdmin = 1 && x.SubjectId!= 26 && x.SubjectId != 27 && x.SubjectId != 28   && x.SubjectId != 46 && x.SubjectId != 51 ";//
            IEnumerable<tb_SubjectMaster> toprec = db.Database.SqlQuery<tb_SubjectMaster>(strQuery);


            //var toprec = from m in db.tb_SubjectMaster where m.Publish == true select m;
            string topcours = "";
            string ForNextCouse = "";
            int countno = 0;
            foreach (var item in toprec)
            {

                string price = String.Format("{0:0}", item.Price);

                topcours += "  <div class='course'>";
                topcours += "    <div class='thumb'>";
                topcours += "      <a href='#'>";
                topcours += "      <img alt='' src='../uploads/" + item.SubjectImge + "' style='width:100%;Height:200px;'  /> </a>";
                topcours += "     <div class='price'><span>$</span> " + price + "</div> ";
                topcours += "   </div>";
                topcours += "    <div class='text'>";
                topcours += "       <div class='header'>";
                topcours += "          <h4>" + item.SubjectName + "</h4>";
                topcours += "     </div>";
                topcours += "  <div class='course-name'>";
                topcours += "            <div class='rating2'>";
                topcours += "        <span1>☆</span1><span1>☆</span1><span1>☆</span1><span1>☆</span1><span1>☆</span1><span>$" + price + "</span>";
                topcours += "     </div>";
                topcours += "   </div>";
                topcours += "  <div class='course-detail-btn'>";
                topcours += "  <a href='/register/signin/?courseid=" + item.SubjectId + "&&cattype=9'>Subscribe</a> ";
                topcours += "  <a href='/course/coursedetail/" + item.SubjectId + "'> Detail </a>   ";
                topcours += " </div>";
                topcours += "  </div>";
                topcours += "  </div>";

                countno += 1;
                if (countno > 4)
                {
                    /////// for our next courses
                    ForNextCouse += " <li>";
                    ForNextCouse += "                    <div class='thumb'>";
                    ForNextCouse += "                       <a href='#'>";
                    ForNextCouse += "                            <img alt='' src='../uploads/" + item.SubjectImge + "' style='width:96px;Height:96px;'  />  </a>";
                    ForNextCouse += "                </div>";
                    ForNextCouse += "             <div class='text'>";
                    ForNextCouse += "              <h4><a href='/course/coursedetail/" + item.SubjectId + "'>" + item.SubjectName + "</a></h4>";
                    ForNextCouse += "            <p>" + item.ShortDescription + "</p>";
                    ForNextCouse += "         <span class='rate'><small>$</small> " + price + "</span>";
                    ForNextCouse += "   </div>";
                    ForNextCouse += "  </li>";
                }
                ////



            }
            ViewBag.topcours = topcours;
            ViewBag.ForNextCouse = ForNextCouse;


            //var toprec2 = (from m in db.tb_SubjectMaster where m.Publish == true && m.PublishAdmin == true select m).Take(2);
            //var toprec2 = db.tb_SubjectMaster.Where(x => x.Publish == true && x.PublishAdmin == true).Select(x => new { x.SubjectName,  x.SubjectImge, x.SubjectId, x.SubjectDesc });

            IEnumerable<tb_SubjectMaster> toprec2 = db.Database.SqlQuery<tb_SubjectMaster>("select * from tb_SubjectMaster where Publish = 1 and PublishAdmin = 1");

            string topcours2 = "";
            foreach (var item in toprec2)
            {





                topcours2 += "    <li>";
                topcours2 += " <h4>" + item.SubjectName + "</h4>";

                topcours2 += "   <div class='thumb'>";
                topcours2 += "   <a href='#'>";
                topcours2 += " <img alt='' src='../uploads/" + item.SubjectImge + "' style='width:100px;Height:100px;'  />";
                topcours2 += " </a>  </div>";
                topcours2 += "   <div class='text'>";


                int lenth1 = item.SubjectDesc.Length;
                if (lenth1 > 150)
                {
                    topcours2 += item.SubjectDesc.Substring(0, 150) + "</p>";
                }
                else
                {
                    topcours2 += item.SubjectDesc + "....";

                    //html = html.Replace("xx-small", "8pt");
                    //html = html.Replace("small", "9pt");
                    //html = html.Replace("x-large", "18pt");
                    //html = html.Replace("large", "18pt");

                    //html = html.Replace("medium", "12pt");
                }

                topcours2 += "   </div>";
                topcours2 += "   </li>";
            }
            ViewBag.Mosttopcours = topcours2;


            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm, string buttonName, int? page, string searchString, int id = 23)
        {

            if (buttonName == "haveaquestion")
            {
                string name = Request.Form["Name"];
                string emailid = Request.Form["emailid"];
                string phonenuber = Request.Form["phonenuber"];
                string course = Request.Form["course"];

                tb_HaveAQuestion have = new tb_HaveAQuestion();
                have.Name = name;
                have.Emailid = emailid;
                have.phoneno = phonenuber;
                have.course = course;
                have.SystemDate = DateTime.Now;
                db.tb_HaveAQuestion.Add(have);
                db.SaveChanges();


                String desc = "Dear " + name + ",<br /> <br /> Email Id " + emailid + "<br /> <br /> Phone No " + phonenuber + "<br /> <br /> Course " + course + "<br/> <br/> Thanks for your information we will contact you soon. ";

                //  desc = desc.Replace("DearClient", "Dear " + model.LastName + " <br /> Email : " + model.EmailID);

                
                string strSUbject = "Have a Question";
                emailSystem.sendNewFormat(emailid, strSUbject, desc);

                return RedirectToAction("thanks", new { formtype = "haveaquestion" });

            }

       



            if (buttonName == "subscribe")
            {
                tb_subscribe subs = new tb_subscribe();
                subs.EMailID = Request.Form["subscribemail"];
                subs.CreationDate = System.DateTime.Now;
                db.tb_subscribe.Add(subs);
                db.SaveChanges();

                string strSUbject = "Thanks for Subscribe";
                string desc = "Thank you to Subscribe at Kin Zin Digital Media Inc. <br /> <br />  ";


                emailSystem.sendNewFormat(subs.EMailID, strSUbject, desc);

                return RedirectToAction("thanks", new { formtype = "subscribe" });
             }
            


            if (searchString != null)
            {
                return RedirectToAction("Coursesearch", "course", new { searchString = searchString });

            }
            return View();
        }

        public ActionResult Index2()
        {
            return View();

        }

        public ActionResult test1()
        {
            return View();
        }

        public ActionResult test2()
        {
            return View();
        }
        public ActionResult About()
        {
            // Commenting out LINQ to show how to do the same thing in SQL.
            //IQueryable<EnrollmentDateGroup> = from student in db.Students
            //           group student by student.EnrollmentDate into dateGroup
            //           select new EnrollmentDateGroup()
            //           {
            //               EnrollmentDate = dateGroup.Key,
            //               StudentCount = dateGroup.Count()
            //           };

            // SQL version of the above LINQ code.
            //string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
            //    + "FROM Person "
            //    + "WHERE Discriminator = 'Student' "
            //    + "GROUP BY EnrollmentDate";
            //IEnumerable<EnrollmentDateGroup> data = db.Database.SqlQuery<EnrollmentDateGroup>(query);

            ViewBag.Message = "Your contact page.";

            var apppage = (from m in db.tb_ApplicationPage where m.PageRefId == 23 select m).Single();

            // var apppage = (from m in db.tb_ApplicationPage where m.PageRefId == 23 select m).Single();

            ViewBag.about = apppage.Description;

            return View();

            // return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ContactNew(FormCollection frm, string buttonName)
        {
            if (buttonName == "contact")
            {
                string name = Request.Form["name"];
                string emailid = Request.Form["emailid"];
                string phonenuber = Request.Form["contactno"];
                string comment = Request.Form["comments"];

                tb_Contactus conUs = new tb_Contactus();

                conUs.FirstName = name;
                conUs.EmailId = emailid;
                conUs.ContactNo = phonenuber;
                conUs.Comments = comment;
                db.tb_Contactus.Add(conUs);
                //  db.SaveChanges();

                String desc = "Dear " + name + ",<br /> <br /> Email Id " + emailid + "<br /> <br /> Phone No " + phonenuber + "<br /> <br /> Course " + comment + "<br/> <br/> Thanks for your informatin Our team will contact you soon. ";

                //  desc = desc.Replace("DearClient", "Dear " + model.LastName + " <br /> Email : " + model.EmailID);

                string strSUbject = "Contact Us";
                emailSystem.sendNewFormat(emailid, strSUbject, desc);
                return RedirectToAction("thanks");

            }
            return View();

        }

        public ActionResult ContactList()
        {
            var Llist = from m in db.tb_Contactus select m;



            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.FirstName + "</td>";
                strTable += "<td>" + item.EmailId + "</td>";
                strTable += "<td>" + item.ContactNo + "</td>";
                strTable += "<td>" + item.Comments + "</td>";
                strTable += "</tr>";
            }
            ViewData["data"] = strTable;

            return View();
        }

        public ActionResult HaveaQuestionList()
        {
            var Llist = from m in db.tb_HaveAQuestion orderby m.AutoId descending select m ;

       


            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.Name + "</td>";
                strTable += "<td>" + item.Emailid + "</td>";
                strTable += "<td>" + item.phoneno + "</td>";
                strTable += "<td>" + item.course + "</td>";
                strTable += "</tr>";
            }
            ViewData["data"] = strTable;

            return View();
        }


        public ActionResult subscribeList()
        {
            var Llist = from m in db.tb_subscribe orderby m.AutoID descending select m;




            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.EMailID + "</td>";
                strTable += "<td>" + item.CreationDate + "</td>";
         
                strTable += "</tr>";
            }
            ViewData["data"] = strTable;

            return View();
        }


        public ActionResult ContactNew()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult thanks()
        {
            ViewBag.Message = "Your contact page.";

            if (Request.QueryString["formtype"] == "haveaquestion")
            {
                ViewBag.formtypemsg = "haveaquestion";

            }

            if (Request.QueryString["formtype"] == "subscribe")
            {
                ViewBag.formtypemsg = "subscribe";

            }

            return View();
        }

        public ActionResult services()
        {
            ViewBag.Message = "Your contact page.";

            var apppage = (from m in db.tb_ApplicationPage where m.Pageid == 24 select m).Single();

            // var apppage = (from m in db.tb_ApplicationPage where m.PageRefId == 23 select m).Single();

            ViewBag.service = apppage.Description;

            return View();
        }

        public ActionResult howitworks()
        {
            ViewBag.Message = "Your contact page.";

            var apppage = (from m in db.tb_ApplicationPage where m.Pageid == 27 select m).Single();

            // var apppage = (from m in db.tb_ApplicationPage where m.PageRefId == 23 select m).Single();

            ViewBag.howitworks = apppage.Description;

            return View();
        }



        public ActionResult faq()
        {

            ViewBag.Message = "Your contact page.";

            var apppage = (from m in db.tb_ApplicationPage where m.Pageid == 25 select m).Single();

            // var apppage = (from m in db.tb_ApplicationPage where m.PageRefId == 23 select m).Single();

            ViewBag.faq = apppage.Description;



            return View();
        }
        public ActionResult aboutnew()
        {
            ViewBag.Message = "Your contact page.";
            var apppage = (from m in db.tb_ApplicationPage where m.Pageid == 23 select m).Single();

            // var apppage = (from m in db.tb_ApplicationPage where m.PageRefId == 23 select m).Single();

            ViewBag.about = apppage.Description;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}