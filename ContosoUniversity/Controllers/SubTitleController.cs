using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class SubTitleController : Controller
    {
        //
        // GET: /Subject/

        kzonlineEntities db = new kzonlineEntities();
       // kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "SubTitle Information");
            var model = db.tb_SubTitleMaster.ToList().AsQueryable();
            model = model.OrderBy(x => x.SubTitle);


           //*****************************************************************
           //*****************************************************************
           int page = 1;
           if (Request.QueryString["pageno"] != null)
           {
               page = Convert.ToInt32(Request.QueryString["pageno"].ToString());
           }

           Int32 offset = 10;
           int totalRecord = model.Count();
           int start;
           start = (page - 1) * offset;
           Int32 totalpage = 0;
           if (totalRecord > offset)
           {
               int totalpage1 = (totalRecord % offset);
               totalpage = (totalRecord / offset);
               if (totalpage1 > 0)
               {
                   totalpage += 1;
               }
           }
           else
           {
               totalpage = 1;
           }
           string pageUrl = "/Subtitle/index/";
           string pageLinks = clsCommon.getPageingInformation(page, totalpage, pageUrl);
           ViewData["totalrecords"] = totalRecord;
           ViewData["pageLinks"] = pageLinks;
           model = model.Skip(start).Take(offset);
           //*****************************************************************



            string strTable = "";
            foreach (var item in model)
            {
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/" + item.SubImage + "' border='0'.   alt='Delete' style='width:44px;Height:44px;'/></td>";
                strTable += "<td>" + item.SubTitle + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/SubTitle/edit/" + item.SubHeadId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/SubTitle/Delete/" + item.SubHeadId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

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
            ViewData["buttonname"] = 1;

            return View();
        }
        private Boolean ValidateData(tb_SubTitleMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.SubTitle))
                ViewData.ModelState.AddModelError("SubTitle", "Please enter   Sub Title !");

             
            return validateData1;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_SubTitleMaster model)
        {
            ViewData["buttonname"] = 1;
            try
            {

                string filename1 = "";

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
                            file.SaveAs(filePath); file.SaveAs(filePath);
                        }
                    }



                    if (filename1 != "")
                    {
                        model.SubImage = filename1;
                    }
                    model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                    model.SystemDate = DateTime.Now;
                    model.IpAddress = Request.ServerVariables["remote_address"];
                    db.tb_SubTitleMaster.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                    var tb1 = new tb_SubTitleMaster();
                    return View(tb1);
                }

            }
            catch(Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();
        }


        //
        // GET: /Subject/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_SubTitleMaster
                         where m.SubHeadId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
         [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_SubTitleMaster model)
        {
            try
            {
                ViewData["buttonname"] = 2;


                if (ValidateData(model))
                {
                    string filename1 = "";
                    var tb = (from m in db.tb_SubTitleMaster
                              where m.SubHeadId == id
                              select m).Single();

                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength < 2000000)
                    {
                        String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (FileExtension == ".png")
                        {

                            string randName = emailSystem.CreateRandomPassword(8);

                            filename1 = randName + "_" + file.FileName;
                            string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                            file.SaveAs(filePath); file.SaveAs(filePath);
                        }
                    }


                    tb.SubTitle = model.SubTitle;

                    if (filename1 != "")
                    {
                        tb.SubImage = filename1;
                    }

                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
                    var tb1 = new tb_SubTitleMaster();
                    return View(tb1);
                }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;

                return View();
            }

            return View();
        }

        //
        // GET: /Subject/Delete/5
 
        public ActionResult Delete(int id)
        {
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_SubTitleMaster
                      where m.SubHeadId == id
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
                var tb = (from m in db.tb_SubTitleMaster
                          where m.SubHeadId == id
                          select m).Single();

                db.tb_SubTitleMaster.Remove(tb);
                db.SaveChanges();
                var tb1 = new tb_SubTitleMaster();

                ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
                return View(tb1); 
            }
            catch
            {
                return View();
            }
        }
    }
}
