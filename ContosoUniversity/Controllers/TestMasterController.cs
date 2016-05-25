using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
 
using System.Web.Mvc;
using OLProject.Models;
namespace OLProject.Controllers
{
    public class TestMasterController : Controller
    {
        //
        // GET: /Subject/


        kzonlineEntities db = new kzonlineEntities();

        private void setdata(Int32 id)
        {
            var model = (from m in db.tb_QuizTestMaster
                         where m.AutoId == id
                         select m).Single();

            ViewData["Subjectid"] = model.SubjectId;
            
            //var model1 = (from m in db.tb_ClassMaster
            //              where m.ClassesId == model.ClassId
            //              select m).Single();
            
            //var model2 = (from m in db.tb_UnitMaster
            //              where m.UnitId == model.UnitId
            //              select m).Single();

          //  ViewData["classname"] = model1.ClassName;
          //  ViewData["Unitname"] = model2.UnitName;
            ViewData["classid"] = model.ClassId;
            ViewData["UnitId"] = model.UnitId;

        }
        public ActionResult UnitList(Int32 id)
        {
            Int32 id1 = 0;
            var ddList = (from m in db.tb_UnitMaster
                          where m.ClassesId == id
                          select new
                          {
                              Name = m.UnitName,
                              ID = m.UnitId
                          });

            var selectList = new SelectList(ddList, "ID", "Name", id1);
            ViewData["Unitlist"] = selectList;
            return View();
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
            return View();
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
        public ActionResult Index()
        {
            Int32 SubjectId = 0;
            Int32 ClassesId = 0;
            Int32 unitid = 0;
            SubjectList();

            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["ClassId"] != null)
                {
                    ClassesId = Convert.ToInt32(Request.Form["ClassId"].ToString());
                    Session.Add("ClassesId", ClassesId);
                }
                if (Request.Form["unitid"] != null)
                {
                    unitid = Convert.ToInt32(Request.Form["unitid"].ToString());
                    Session.Add("unitid", unitid);
                }
                if (Request.Form["SubjectId"] != null)
                {
                    SubjectId = Convert.ToInt32(Request.Form["SubjectId"].ToString());
                    Session.Add("SubjectId", SubjectId);
                }
            }
            if (Session["SubjectId"] != null)
            {
                SubjectId = Convert.ToInt32(Session["SubjectId"].ToString());
            }

            if (Session["unitid"] != null)
            {
                unitid = Convert.ToInt32(Session["unitid"].ToString());
            }

            if (Session["ClassId"] != null)
            {
                ClassesId = Convert.ToInt32(Session["ClassId"].ToString());
            }


            //*****************************************************************
            //*****************************************************************
            var model = db.tb_QuizTestMaster.ToList().AsQueryable();
            if (SubjectId > 0)
            {
                if (SubjectId > 0)
                {
                    model = model.Where(x => x.SubjectId == SubjectId);

                    var model1 = db.tb_SubjectMaster.ToList().Where(x => x.SubjectId == SubjectId).Single();
                    ViewData["subjectname"] = model1.SubjectName.ToString();

                }

                if (ClassesId > 0)
                {
                    model = model.Where(x => x.ClassId == ClassesId);
                    var model1 = db.tb_ClassMaster.ToList().Where(x => x.ClassesId == ClassesId).Single();
                    ViewData["classname"] = model1.ClassName.ToString();
                }

                if (unitid > 0)
                {
                    model = model.Where(x => x.UnitId == unitid);
                    var model1 = db.tb_UnitMaster.ToList().Where(x => x.UnitId == unitid).Single();
                    ViewData["UnitName"] = model1.UnitName.ToString();
                }
            }
            
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
            string pageUrl = "/testmaster/index/";
            string pageLinks = clsCommon.getPageingInformation(page, totalpage, pageUrl);
            ViewData["totalrecords"] = totalRecord;
            ViewData["pageLinks"] = pageLinks;
            model = model.Skip(start).Take(offset);
            //*****************************************************************

            string strTable = "";
            Int32 mcounter = 0;
            string status = "";
            foreach (var item in model)
            {
                status = "Hide";
                if (item.Publish == true) 
                {
                    status = "Show";
                }
                var model21 = db.tb_QuizTestMasterDetail.ToList().Where(x => x.TestRefId == item.AutoId);
                Int32 avlTotal = model.Count();
                mcounter += 1;

                if (mcounter % 2 == 0)
                {
                    strTable += "<tr  bgcolor='#DDEEEE'>";
                }
                else
                {
                    strTable += "<tr bgcolor='#EEFFFF'>";
                }
                strTable += "<td valign='top'><img src='../../uploads/" + item.TestImage + "' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
               // strTable += "<td valign='top'>" + item.TestHeading + "<br /><br /><b> Subject:" + clsCommon.getSubjectName(Convert.ToInt32(item.SubjectId)) + "</b><br /><br /><b>Class:" + clsCommon.getClassNameProduct(Convert.ToInt32(item.ClassId)) + "</b></td>";
                strTable += "<td valign='top'>" + item.TestHeading + "<br /><b> " + clsCommon.getSubjectName(Convert.ToInt32(item.SubjectId)) + "</b></td>";

                strTable += "<td valign='top'>" + status + "</td>";
                strTable += "<td valign='top'>" + item.totalQues + "</td>";
                strTable += "<td valign='top'>" + item.Duration + "</td>";
                strTable += "<td valign='top'>" + avlTotal + "</td>";

                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/testmaster/edit/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/testmaster/Delete/" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/testcreation/index/?SubjectId=" + item.SubjectId + "&testid=" + item.AutoId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/bAdd.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/testcreation/detail/?subjectid=" + item.SubjectId + "&testid=" + item.AutoId +  "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/ViewB.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
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
            SubjectList();
            ViewData["buttonname"] = 1;
            //SubjectList();
            return View();
        }
        private Boolean ValidateData(tb_QuizTestMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.TestHeading))
                ViewData.ModelState.AddModelError("TestHeading", "Please Enter   Name!");

            if (string.IsNullOrEmpty(model.TestDesc))
                ViewData.ModelState.AddModelError("TestDesc", "Please Enter  Description!");

            if (string.IsNullOrEmpty(model.IfFail))
                ViewData.ModelState.AddModelError("IfFail", "Please enter If Fail!");

            if (string.IsNullOrEmpty(model.IfPass))
                ViewData.ModelState.AddModelError("IfPass", "Please enter If Pass!");

            if (model.TestPassingScore == null || model.TestPassingScore == 0)
                ViewData.ModelState.AddModelError("TestPassingScore", "Please enter Test Passing Score!");


            if (model.SubjectId == null || model.SubjectId == 0)
                ViewData.ModelState.AddModelError("SubjectId", "Please enter Subject!");

            //if (model.ClassId == null || model.ClassId == 0)
            //    ViewData.ModelState.AddModelError("ClassId", "Please enter Class!");

            //if (model.UnitId == null || model.UnitId == 0)
            //    ViewData.ModelState.AddModelError("UnitId", "Please enter Unit!");

            if (model.Duration == null || model.Duration == 0)
                ViewData.ModelState.AddModelError("Duration", "Please enter Duration!");

          
            if (!ModelState.IsValid)
            {
                validateData1 = false;
            }
            return validateData1;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(tb_QuizTestMaster model)
        {
            SubjectList();
            ViewData["buttonname"] = 1;
            try
            {
                string filename1 = "";
                if (ValidateData(model))
                {

                    //HttpPostedFileBase file = Request.Files[0];
                    //if (file.ContentLength < 1000000)
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
                        model.TestImage = filename1;
                    }

                    model.CompanyId = 0;
                    model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                    model.SystemDate = DateTime.Now;
                    model.isShow = true;

                    model.IpAddress = Request.ServerVariables["remote_address"];
                    db.tb_QuizTestMaster.Add(model);
                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                    
                    var tb1 = new tb_QuizTestMaster();
                    return View(tb1);

                }
            }

            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            SubjectList();
            ViewData["buttonname"] = 2;
            setdata(id);
            var model = (from m in db.tb_QuizTestMaster
                         where m.AutoId == id
                         select m).Single();

            return View(model);
        }
         [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_QuizTestMaster model)
        {
            try
            {
                setdata(id);
                SubjectList();
                ViewData["buttonname"] = 2;
                string filename1 = "";

                if (ValidateData(model))
                {

                    var tb = (from m in db.tb_QuizTestMaster
                              where m.AutoId == id
                              select m).Single();

                    //HttpPostedFileBase file = Request.Files[0];
                    //if (file.ContentLength < 100000)
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


                    tb.TestHeading = model.TestHeading;
                    tb.TestDesc = model.TestDesc;
                    tb.totalQues = model.totalQues;
                    tb.IfFail = model.IfFail;
                    tb.IfPass = model.IfPass;
                    tb.RandomOrder = model.RandomOrder;
                    tb.ShowIntroPage = model.ShowIntroPage;
                    tb.TestPassingScore = model.TestPassingScore;
                    tb.Publish = model.Publish;

                    tb.Duration = model.Duration;

                    if (filename1 != "")
                    {
                        tb.TestImage = filename1;
                    }

                    db.SaveChanges();
                    ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                    ViewData["msgStatus"] = clsCommon.ErrorMessage(2);
                    var tb1 = new tb_QuizTestMaster();
                    return View(tb1);
                }
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;
            }
            return View();
        }
        public ActionResult Delete(int id)
         {
             SubjectList();
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_QuizTestMaster
                      where m.AutoId == id
                      select m).Single();
            return View(tb);
        }
 
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try 
            {
                SubjectList();
                var tb = (from m in db.tb_QuizTestMaster
                          where m.AutoId  == id
                          select m).Single();
                db.tb_QuizTestMaster.Remove(tb);
               
                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(3);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(3);

                var tb1 = new tb_QuizTestMaster();
                return View(tb1);
                 
            }
            catch
            {
                return View();
            }
        }
    }
}
