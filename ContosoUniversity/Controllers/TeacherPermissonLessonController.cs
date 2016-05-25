using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
using OLProject.Models;
namespace OLProject.Controllers
{
    public class TeacherPermissonLessonController : Controller
    {
        kzonlineEntities db = new kzonlineEntities();
        private void CreatePermission(Int32 userid)
        {
            Int32 unitid = 0;
            if (Request.Form["UnitId"] != null)
            {
                unitid = Convert.ToInt32(Request.Form["UnitId"]);
            }
            if (unitid > 0)
            {

                var detail = from m in db.tb_TeacherPermissionLesson
                             where m.TeacherId == userid && m.UnitId == unitid
                             select m;
                foreach (var detail1 in detail)
                {
                    db.tb_TeacherPermissionLesson.Remove(detail1);
                }

                db.SaveChanges();

                if (Request.Form.GetValues("selectedObjects") != null)
                {
                    int total = Convert.ToInt32(Request.Form.GetValues("selectedObjects").Count());
                    Int32 taskid = 0;
                    string mystring = "";


                    for (int i = 0; i < total; i++)
                    {

                        mystring = Request.Form.GetValues("selectedObjects")[i].ToString();
                        taskid = Convert.ToInt32(mystring);

                        var tb = (from m in db.tb_LessionMaster
                                  where m.LessionId == taskid
                                  select m).Single();


                        tb_TeacherPermissionLesson sb = new tb_TeacherPermissionLesson();
                        sb.TeacherId = Convert.ToInt32(userid);
                        sb.LessonId = Convert.ToInt32(taskid);
                        sb.SubjectId = Convert.ToInt32(tb.SubjectId);
                        sb.UnitId = Convert.ToInt32(tb.UnitId);
                        sb.SystemDate = DateTime.Now;
                        sb.ClassId = Convert.ToInt32(tb.ClassId);
                        sb.CreatedBy = Convert.ToInt32(Session["pmsuserid"]);
                        sb.Ipaddress = Request.ServerVariables["remote_address"];

                        db.tb_TeacherPermissionLesson.Add(sb);

                        db.SaveChanges();
                    }

                }

            }

        }
        public string GetPermission(Int32 id)
        {

            Int32 TeacherId = Convert.ToInt32(Session["TeacherID"]);

            string strtables = "<table width='100%' border='0'>";
            strtables += "<input type='hidden' value='" + id + "'>";
            var model2 = from m in db.tb_LessionMaster
                         where m.UnitId == id
                         select new
                         {
                             taskname = m.LessionHeading,
                             taskid = m.LessionId
                         };
            foreach (var item in model2)
            {

                var model1 = from m in db.tb_LessionMaster
                             from t in db.tb_TeacherPermissionLesson
                             where m.UnitId == id && t.LessonId == m.LessionId && t.TeacherId == TeacherId
                             select new
                             {
                                 taskname = m.LessionHeading,
                                 taskid = m.LessionId
                             };
                strtables += "<tr>";
                if (model1.Count() > 0)
                {

                    strtables += "<td><input type='checkbox' checked='checked' name='selectedObjects' value='" + item.taskid + "'>" + item.taskname + "</td>";

                }
                else
                {

                    strtables += "<td><input type='checkbox' name='selectedObjects' value='" + item.taskid + "'>" + item.taskname + "</td>";


                }
                strtables += "</tr>";
            }
            strtables += "</table>";


            ViewData["permissionlist"] = strtables;
            return strtables;
        }
        // ****************************************************************************
        public ActionResult ClassList(Int32 id)
        {
            Int32 ClassesId = 0;
            Int32 UnitId = 0;

            if (Session["unitid"] != null)
            {
                UnitId = Convert.ToInt32(Session["unitid"]);
            }
            ViewData["UnitId"] = UnitId;

            if (Request.QueryString["id1"] != null)
            {

                ClassesId = Convert.ToInt32(Request.QueryString["id1"].ToString());
            }


            var ddList = (from m in db.tb_ClassMaster
                          where m.SubjectId == id
                          select new
                          {
                              Name = m.ClassName,
                              ID = m.ClassesId
                          });


            var selectList = new SelectList(ddList, "ID", "Name", Convert.ToInt32(ClassesId));
            //var selectList = new SelectList(ddList, "ID", "Name");
            ViewData["Classlist"] = selectList;

            return View();
        }
        public ActionResult UnitList(Int32 id)
        {
            Int32 id1 = 0;

            if (Request.QueryString["id1"] != null)
            {

                id1 = Convert.ToInt32(Request.QueryString["id1"].ToString());
            }

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
            Session.Add("ModuleName0", "Teacher Lesson  Help Menu");
            var Llist = db.tb_UserMaster.ToList().AsQueryable();
            Llist = Llist.Where(x => x.CategoryId == 3);
            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.EmailID + "</td>";
                strTable += "<td>" + item.FirstName + " " + item.MiddleName + "" + item.LastName + "</td>";
                strTable += "<td>" + item.ProfileName + "</td>";
                strTable += "<td>" + item.ContactNo + "</td>";
                strTable += "<td>" + item.Address + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/TeacherPermissonLesson/edit/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/TeacherPermissonLesson/SendEmail/" + item.UserId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/send.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "</tr>";
            }
            ViewData["userlist"] = strTable;

            return View();
        }
        // GET: /admin/Create
        public ActionResult SendEmail(Int32 id)
        {
            string strtables = "<table width='100%' border='0'>";
            var model2 = from m in db.tb_LessionMaster
                         from t in db.tb_TeacherPermissionLesson
                         where t.TeacherId == id && t.LessonId == m.LessionId
                         select new
                         {
                             taskname = m.LessionHeading,
                             taskid = m.LessionId,
                             SubjectId = m.SubjectId
                         };
            foreach (var item in model2)
            {
                strtables += "<tr>";
                strtables += "<td>" + item.taskname + " [ " + clsCommon.getSubjectName(Convert.ToInt32(item.SubjectId)) + "]</td>";
                strtables += "</tr>";
            }
            strtables += "</table>";

            tb_UserMaster pms = (from m in db.tb_UserMaster where m.UserId == id select m).Single();

            var model = (from m in db.tb_emailsDescription
                         where m.Autoid == 21
                         select m).Single();

            string desc = model.Description;


            desc = desc.Replace("UserName", pms.FirstName);
            desc = desc.Replace("Detail", strtables);
            emailSystem.sendNewFormat(pms.EmailID, model.EmailSubject, desc);


            ViewData["msstatus"] = "Email has been sent";

            return View();
        }

        public ActionResult Edit(Int32 id)
        {
            SubjectList();
            Session.Add("TeacherID", id);
            if (Request.HttpMethod == "POST")
            {
                CreatePermission(id);
                ViewData["msstatus"] = "Lesson Permission Created";
            }

            return View();
        }










    }
}
