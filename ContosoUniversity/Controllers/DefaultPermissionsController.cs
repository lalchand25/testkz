using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLProject.Models;

namespace OLProject.Controllers
{
    public class DefaultPermissionsController : Controller
    {
        //
        // GET: /Permissions/
        kzonlineEntities db = new kzonlineEntities();

        public void setViews()
        {
            var ddList1 = from c in db.tb_RegCategory
                          select new { ID = c.RegTypeId, Name = c.RegTypeName };
            var selectList1 = new SelectList(ddList1, "ID", "Name");
            ViewData["userList"] = selectList1;
        }
        public ActionResult Index1()
        {
            var ddList1 = db.tb_RegCategory.ToList();
            string dataper = "";
            foreach (var item in ddList1)
            {
                dataper += "<tr><td style='width: 20%;' align='left'><a href='/defaultPermissions/index1?usertypeid=" + item.RegTypeId + "'>" + item.RegTypeName + "</a></td></tr>";
            }


            ViewData["dataper"] = dataper;



            Int32 usertypeid = 0;
            if (Request.QueryString["usertypeid"] != null)
            {
                usertypeid = Convert.ToInt32(Request.QueryString["usertypeid"]);

                if (usertypeid > 0)
                {
                    string query = "delete  from tb_taskDetail where userid in (select userid from tb_usermaster where categoryid=" + usertypeid + ")";
                    // db.ExecuteStoreCommand(query);
                    db.Database.ExecuteSqlCommand(query);

                    ViewData["msg"] = "Error found during Processing";

                    //Picking Users
                    var model1 = (from m in db.tb_UserMaster
                                  where m.CategoryId == usertypeid
                                  select m);

                    //Deafult Permissions
                    var model = (from m in db.tb_DefaultPermission
                                 where m.CategoryId == usertypeid
                                 select m);

                    foreach (var item in model1)
                    {
                        foreach (var item1 in model)
                        {
                            tb_TaskDetail td = new tb_TaskDetail();
                            td.UserID = item.UserId;
                            td.TaskID = item1.TaskId;
                            td.ModuleID = item1.ModuleId;
                            td.CreatedBy = Convert.ToInt32(Session["pmsuserid"]).ToString();
                            td.DeleteStatus = "N";
                            td.DeletionDate = DateTime.Now;
                            td.DeletedBy = "0";
                            db.tb_TaskDetail.Add(td);

                        }

                    }
                    db.SaveChanges();
                    ViewData["msg"] = "Permission Granted";
                }

            }


            return View();
        }

        private void CreatePermission(Int32 userTypeid)
        {
            var detail = from m in db.tb_DefaultPermission
                         where m.CategoryId == userTypeid
                         select m;

            foreach (var detail1 in detail)
            {
                db.tb_DefaultPermission.Remove(detail1);
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


                    tb_DefaultPermission sb = new tb_DefaultPermission();
                    sb.CategoryId = Convert.ToInt32(userTypeid);
                    sb.TaskId = Convert.ToInt32(taskid);
                    sb.ModuleId = tb.ModuleID;
                    sb.SystemDate = DateTime.Now;
                    db.tb_DefaultPermission.Add(sb);
                    db.SaveChanges();
                }

                //delete all permission from the database

            
            }


        }

       
        public string GetPermission(Int32 id)
        {
            // Int32 userid = Convert.ToInt32(Session["pmsuerid"]);
            Int32 usertypeid = id;

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
            strtables += "<tr>";
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
                             from a in db.tb_DefaultPermission
                             where m.ModuleID == t.ModuleId
                             && m.TaskID == a.TaskId
                             && a.CategoryId == usertypeid && m.TaskID == items.taskid

                             select new
                             {
                                 taskname = m.TaskName,
                                 taskid = m.TaskID
                             };


                if (model2.Count() > 0)
                {
                    var model1 = from m in db.tb_TaskMaster
                                 from t in db.tb_ModuleMaster
                                 from a in db.tb_DefaultPermission
                                 where m.ModuleID == t.ModuleId
                                 && m.TaskID == a.TaskId
                                 && a.CategoryId == usertypeid && m.TaskID == items.taskid
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
            //ViewData["permissionlist"] = strtables;
            return strtables;

        }


        public ActionResult Index()
        {
            setViews();

            if (Request.HttpMethod == "POST")
            {
                Int32 userid = 0;
                if (Request.Form["usertypeid"] != null)
                {
                    userid = Convert.ToInt32(Request.Form["usertypeid"]);

                }
                CreatePermission(userid);
            }
            return View();
        }

    }
}
