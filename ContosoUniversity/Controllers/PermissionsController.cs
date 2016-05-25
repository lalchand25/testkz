using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;

namespace OLProject.Controllers
{
    public class PermissionsController : Controller
    {
        //
        // GET: /Permissions/
        kzonlineEntities db = new kzonlineEntities();
        
        public void setViews()
        {
            var ddList1 = (from c in db.tb_UserMaster select new { ID = c.UserId, Name = c.ProfileName + " - " + c.EmailID }).OrderBy(x => x.Name);


            var selectList1 = new SelectList(ddList1, "ID", "Name");
            ViewData["userList"] = selectList1;
        }
        private void CreatePermission(Int32 userid)
        {
          
           var detail = from m in db.tb_TaskDetail
                        where m.UserID == userid
                        select m;

           foreach (var detail1 in detail)
            {
                db.tb_TaskDetail.Remove(detail1);
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

                        var tb = (from m in db.tb_TaskMaster
                                  where m.TaskID == taskid
                                  select m).Single();


                        tb_TaskDetail sb = new tb_TaskDetail();
                        sb.UserID = Convert.ToInt32(userid);
                        sb.TaskID = Convert.ToInt32(taskid);
                        sb.ModuleID = tb.ModuleID;
                        db.tb_TaskDetail.Add(sb);
                        db.SaveChanges();
                    }
                
            }



        }
        public string GetPermission(Int32 id)
        {
            // Int32 userid = Convert.ToInt32(Session["pmsuerid"]);

            var model = (from m in db.tb_TaskMaster
                         from t in db.tb_ModuleMaster
                         where m.ModuleID == t.ModuleId
                         orderby t.ModuleName, m.TaskName
                         select new
                         {
                             taskname = m.TaskName,
                             taskid = m.TaskID,
                             moduleid = t.ModuleId,
                             modulename = t.ModuleName
                         }).ToList();

            string strtables = "<table width='100%' border='0'>";
            Int32 icnt = 0;
            Int32 moduleid = 0;
            foreach (var items in model)
            {

                if (items.moduleid != moduleid)
                {
                    if (moduleid > 0)
                    {

                        strtables += "</tr>";
                    }
                    strtables += "<tr><td colspan='4'><h3>" + items.modulename + "</h3></td></tr>";
                    moduleid = items.moduleid;
                    icnt = 0;

                }
                icnt += 1;
                if (icnt == 1)
                {
                    strtables += "<tr>";

                }
                var model2 = from m in db.tb_TaskMaster
                             from t in db.tb_ModuleMaster
                             from a in db.tb_TaskDetail
                             where m.ModuleID == t.ModuleId
                             && m.TaskID == a.TaskID
                             && a.UserID == id && m.TaskID == items.taskid

                             select new
                             {
                                 taskname = m.TaskName,
                                 taskid = m.TaskID
                             };


                if (model2.Count() > 0)
                {
                    var model1 = from m in db.tb_TaskMaster
                                 from t in db.tb_ModuleMaster
                                 from a in db.tb_TaskDetail
                                 where m.ModuleID == t.ModuleId
                                 && m.TaskID == a.TaskID
                                 && a.UserID == id && m.TaskID == items.taskid

                                 select new
                                 {
                                     taskname = m.TaskName,
                                     taskid = m.TaskID
                                 };
                    if (model1 != null)
                    {

                        strtables += "<td><input type='checkbox' checked='checked' name='selectedObjects' value='" + items.taskid + "'>" + items.taskname + "</td>";

                    }

                }
                else
                {

                    strtables += "<td><input type='checkbox' name='selectedObjects' value='" + items.taskid + "'>" + items.taskname + "</td>";


                }
                if (icnt == 3)
                {
                    icnt = 0;
                    strtables += "</tr>";
                }
            }
            strtables += "</table>";
            ViewData["permissionlist"] = strtables;
            return strtables;

        }


        public ActionResult Index()
        {
            setViews();
            string selectall = "";
            if (Request.Form["selectall"] != null)
            {

                selectall = Request.Form["selectall"].ToString();
            }

            if (Request.HttpMethod == "POST")
            {
                Int32 userid = 0;
                if (Request.Form["userid"] != null)
                {
                    userid = Convert.ToInt32(Request.Form["userid"]);

                }
                CreatePermission(userid);
            }
            return View();
        }

    }
}
