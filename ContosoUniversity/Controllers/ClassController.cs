using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class ClassController : Controller
    {
        //
        // GET: /Subject/


        kzonlineEntities db = new kzonlineEntities();


        private void SubjectList()
        {
            var ddList = (from m in db.tb_SubjectMaster
                          select new
                          {
                              Name = m.SubjectName,
                              ID = m.SubjectId
                          });

            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["Subjectlist"] = selectList;

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
            Session.Add("ModuleName0", "Class Information");
            SubjectList();
            Int32 SubjectId = 0;
            var model = db.tb_ClassMaster.ToList().AsQueryable();

            int catid = 0;
            if (Session["cateid"] != null)
            {
                catid = Convert.ToInt32(Session["cateid"]);
            }

            if (catid != 8)
            {
                Int32 userid = Convert.ToInt32(Session["pmsuserid"]);

                model = model.Where(x => x.UserId == userid);
            }

            model = model.OrderBy(x => x.DisplayOrder);




            //*****************************************************************
            int page = 1;
            if (Request.QueryString["pageno"] != null)
            {
                page = Convert.ToInt32(Request.QueryString["pageno"].ToString());
            }

            if (Request.Form["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Request.Form["SubjectId"].ToString());
                Session.Add("SubjectId", SubjectId);
            }
            if (Session["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Session["SubjectId"].ToString());
            }

            if (SubjectId > 0)
            {
                model = model.Where(x => x.SubjectId == SubjectId);

                var model1 = db.tb_SubjectMaster.ToList().Where(x => x.SubjectId == SubjectId).Single();
                ViewData["subjectname:"] = model1.SubjectName.ToString();

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
            string pageUrl = "/class/index/";
            string pageLinks = clsCommon.getPageingInformation(page, totalpage, pageUrl);
            ViewData["totalrecords"] = totalRecord;
            ViewData["pageLinks"] = pageLinks;
            model = model.Skip(start).Take(offset);
            //*****************************************************************
            string strTable = "";
            foreach (var item in model)
            {
                var model1 = db.tb_ProductClassMaster.ToList().Where(x => x.AutoId == item.ClassId).Single();
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/" + item.ClassImage + "' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
                strTable += "<td><a href='javascript:OpenPopup(&#34;/class/detail/" + item.ClassesId + "&#34;);' id='A2' runat='server' >" + model1.ClassName + "</a></td>";
                strTable += "<td>" + item.DisplayOrder + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/class/edit/" + item.ClassesId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/class/Delete/" + item.ClassesId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
            }
            ViewData["data"] = strTable;

            return View();
        }

        //
        // GET: /Subject/Details/5

        //
        // GET: /Subject/Edit/5
        public ActionResult Detail(int id)
        {

            var model = (from m in db.tb_ClassMaster
                         where m.ClassesId == id
                         select m).Single();
            ViewData["desc"] = model.ClasssDescription;
            return View(model);
        }


        public ActionResult Create()
        {
            ViewData["buttonname"] = 1;
            SubjectList();
            return View();
        }
        private Boolean ValidateData(tb_ClassMaster model)
        {
            Boolean validateData1 = true;
            if (model.ClassId == null || model.ClassId == 0)
                ViewData.ModelState.AddModelError("ClassId", "Please select  Class Name!");
            if (string.IsNullOrEmpty(model.ClasssDescription))
                ViewData.ModelState.AddModelError("ClasssDescription", "Please enter  Class Description!");

            if (model.SubjectId == null || model.SubjectId == 0)
            {
                ViewData.ModelState.AddModelError("SubjectId", "Please Select Subject  !");
            }
            if (model.DisplayOrder == null)
            {
                ViewData.ModelState.AddModelError("DisplayOrder", "Please Select DisplayOrder !");
            }
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_ClassMaster model)
        {
            SubjectList();
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
                        model.ClassImage = filename1;
                    }

                    if (Request.Form["ClassId"] != null && Request.Form["ClassId"] != "")
                    {
                        int clssid = Convert.ToInt32(Request.Form["ClassId"]);
                        var ddList1 = (from m in db.tb_ProductClassMaster where m.AutoId == clssid select m).Single();
                        model.ClassName = ddList1.ClassName;
                    }

                    model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                    model.SystemDate = DateTime.Now;
                    model.IpAddress = Request.ServerVariables["remote_address"];
                    db.tb_ClassMaster.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);

                    var tb1 = new tb_ClassMaster();
                    return View(tb1);

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
            SubjectList();
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_ClassMaster
                         where m.ClassesId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_ClassMaster model)
        {
            try
            {
                SubjectList();
                ViewData["buttonname"] = 2;
                string filename1 = "";

                if (ValidateData(model))
                {

                    var tb = (from m in db.tb_ClassMaster
                              where m.ClassesId == id
                              select m).Single();
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


                    if (Request.Form["ClassId"] != null && Request.Form["ClassId"] != "")
                    {
                        int clssid = Convert.ToInt32(Request.Form["ClassId"]);
                        var ddList1 = (from m in db.tb_ProductClassMaster where m.AutoId == clssid select m).Single();
                        tb.ClassName = ddList1.ClassName;
                    }

          
                    tb.ClasssDescription = model.ClasssDescription;
                    tb.DisplayOrder = model.DisplayOrder;
                    tb.Publish = model.Publish;
                    if (filename1 != "")
                    {
                        tb.ClassImage = filename1;
                    }

                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
                    var tb1 = new tb_ClassMaster();
                    return View(tb1);
                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        //
        // GET: /Subject/Delete/5

        public ActionResult Delete(int id)
        {
            SubjectList();
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_ClassMaster
                      where m.ClassesId == id
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

                SubjectList();
                var model = db.tb_LessionMaster.ToList().Where(x => x.ClassId == id);
                if (model.Count() == 0)
                {
                    var tb = (from m in db.tb_ClassMaster
                              where m.ClassesId == id
                              select m).Single();
                    db.tb_ClassMaster.Remove(tb);

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
