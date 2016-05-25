using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class UnitController : Controller
    {
        //
        // GET: /Subject/
        kzonlineEntities db = new kzonlineEntities();
        //
        // GET: /Subject/Edit/5
        public ActionResult Detail(int id)
        {
            var model = (from m in db.tb_UnitMaster
                         where m.UnitId == id
                         select m).Single();
            ViewData["desc"] = model.UnitDesc;
            return View(model);
        }

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
        }
        public ActionResult ClassList(Int32 id)
        {
            var ddList = (from m in db.tb_ClassMaster
                          from t in db.tb_ProductClassMaster
                          where m.SubjectId == id && m.ClassId == t.AutoId
                          select new
                          {
                              Name = t.ClassName,
                              ID = m.ClassesId
                          });

            var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["Classlist"] = selectList;
            
            return PartialView();
        }

        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Unit Information");
            SubjectList();
            Int32 SubjectId = 0;

            Int32 ClassesId = 0;
            if (Request.Form["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Request.Form["SubjectId"].ToString());
                Session.Add("SubjectId", SubjectId);
            }
            if (Session["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Session["SubjectId"].ToString());
            }

            //if (Request.Form["ClassesId"] != null)
            //{
            //    ClassesId = Convert.ToInt32(Request.Form["ClassesId"].ToString());
            //    Session.Add("ClassesId", ClassesId);
            //}
            //if (Session["ClassesId"] != null)
            //{
            //    ClassesId = Convert.ToInt32(Session["ClassesId"].ToString());
            //}


            var model = db.tb_UnitMaster.ToList().AsQueryable();


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
           //*****************************************************************
           if (SubjectId > 0)
           {
               model = model.Where(x => x.SubjectId == SubjectId);

               var model1 = db.tb_SubjectMaster.ToList().Where(x => x.SubjectId == SubjectId).Single();
               ViewData["subjectname:"] = model1.SubjectName.ToString();

           }
           if (ClassesId > 0)
           {
               model = model.Where(x => x.ClassesId == ClassesId);

               ViewData["classname:"] = clsCommon.getClassNameProduct(ClassesId);

           }
            
           int page = 1;
           if (Request.QueryString["pageno"] != null)
           {
               page = Convert.ToInt32(Request.QueryString["pageno"].ToString());
           }

           Int32 offset = 15;
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
           string pageUrl = "/unit/index/";
           string pageLinks = clsCommon.getPageingInformation(page, totalpage, pageUrl);
           ViewData["totalrecords"] = totalRecord;
           ViewData["pageLinks"] = pageLinks;
           model = model.Skip(start).Take(offset);
           //*****************************************************************

            string strTable = "";
            foreach (var item in model)
            {
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/" + item.UnitImage + "' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
                strTable += "<td><a href='javascript:OpenPopup(&#34;/unit/detail/" + item.UnitId + "&#34;);' id='A2' runat='server' >" + item.UnitName + "</a></td>";

             

                //if (item.UnitDesc.Length <= 50)
                //{
                //    strTable += "<td>" + item.UnitDesc + "</td>";
                //}
                //else
                //{
                //    strTable += "<td>" + item.UnitDesc.Substring(1, 50) + "...more</td>";
                //}

                strTable += "<td>" + item.DisplayOrder + "</td>";
               
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/unit/edit/" + item.UnitId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/unit/Delete/" + item.UnitId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

            }
            ViewData["data"] = strTable;

            return View();
        }

        


        public ActionResult Create()
        {
            SubjectList();
            ViewData["buttonname"] = 1;

            return View();
        }
        private Boolean ValidateData(tb_UnitMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.UnitName))
                ViewData.ModelState.AddModelError("UnitName", "Please enter   Unit Name!");
            //if (string.IsNullOrEmpty(model.UnitDesc))
            //    ViewData.ModelState.AddModelError("UnitDesc", "Please enter  Unit Description!");

            if (model.SubjectId == null || model.SubjectId == 0)
            {
                ViewData.ModelState.AddModelError("SubjectId", "Please Select Subject  !");
            }

            //if (model.ClassesId == null || model.ClassesId == 0)
            //{
            //    ViewData.ModelState.AddModelError("ClassId", "Please Select Class   !");
            //}

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
        public ActionResult Create(tb_UnitMaster model)
        {
            SubjectList();
            ViewData["buttonname"] = 1;
            try
            {

                string filename1 = "";


                if (ValidateData(model))
                {
                     
                        //HttpPostedFileBase file = Request.Files[0];
                        //if (file.ContentLength < 2000000)
                        //{
                        //    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        //    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                        //    {
                        //        string randName = emailSystem.CreateRandomPassword(8);
                        //        filename1 = randName + "_" + file.FileName;
                        //        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                        //        file.SaveAs(filePath);
                        //    }

                        //}


                    if (filename1 != "")
                    {
                        model.UnitImage = filename1;
                    }

                    model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                    model.SystemDate = DateTime.Now;
                    model.IpAddress = Request.ServerVariables["remote_address"];
                    db.tb_UnitMaster.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                    var tb1 = new tb_UnitMaster();
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
            var model = (from m in db.tb_UnitMaster
                         where m.UnitId == id
                         select m).Single();


            var model1 = db.tb_ClassMaster.ToList().Where(x => x.ClassesId == model.ClassesId).Single();
            ViewData["UnitClassName"] = model1.ClassName;

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
         [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_UnitMaster model)
        {
            try
            {
                SubjectList();
                ViewData["buttonname"] = 2;
                string filename1 = "";
                var tb = (from m in db.tb_UnitMaster
                          where m.UnitId == id
                          select m).Single();
                if (ValidateData(model))
                {
                    //HttpPostedFileBase file = Request.Files[0];
                    //if (file.ContentLength < 2000000)
                    //{
                    //    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                    //    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                    //    {
                         

                    //        string randName = emailSystem.CreateRandomPassword(8);

                    //        filename1 = randName + "_" + file.FileName;
                    //        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                    //        file.SaveAs(filePath); file.SaveAs(filePath);
                    //    }
                    //}


                    tb.UnitName = model.UnitName;
                    tb.UnitDesc = model.UnitDesc;
                    tb.DisplayOrder = model.DisplayOrder;
                    tb.Publish = model.Publish;
                    if (filename1 != "")
                    {
                        tb.UnitImage = filename1;
                    }

                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
                    var tb1 = new tb_UnitMaster();
                    return View(tb1);

                }
            }
            catch
            {
               
            }
            return View();
        }

        //
        // GET: /Subject/Delete/5
 
        public ActionResult Delete(int id)
         {
             SubjectList();
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_UnitMaster
                      where m.UnitId == id
                      select m).Single();
            var model1 = db.tb_ClassMaster.ToList().Where(x => x.ClassesId == tb.ClassesId).Single();
            ViewData["UnitClassName"] = model1.ClassName;
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
                 var model = db.tb_LessionMaster.ToList().Where(x => x.UnitId == id);
                 if (model.Count() == 0)
                 {
                     var tb = (from m in db.tb_UnitMaster
                               where m.UnitId == id
                               select m).Single();

                     db.tb_UnitMaster.Remove(tb);
                     db.SaveChanges();

                     ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                     ViewData["msgStatus"] = clsCommon.ErrorMessage(3);
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
