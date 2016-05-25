using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
using OLProject.Models;
namespace OLProject.Controllers
{
    public class HeaderPermissonController : Controller
    {

        kzonlineEntities db = new kzonlineEntities();

        private void CreatePermission(Int32 TaskId,FormCollection form)
        {

            var detail = from m in db.tb_HeaderDetail
                         where m.TaskId == TaskId
                         select m;
            foreach (var detail1 in detail)
            {
                db.tb_HeaderDetail.Remove(detail1);
            }
            
            db.SaveChanges();
            //dselected
            if (form["SelectRight"] != null)
            {
                //int total = Convert.ToInt32(form["SelectRight"].Count());
                int total = Convert.ToInt32(form.GetValues("SelectRight").Count());
                Int32 headerid = 0;
                string mystring = "";
                for (int i = 0; i < total; i++)
                {
                    mystring = form.GetValues("SelectRight")[i].ToString();
                    headerid = Convert.ToInt32(mystring);

                    tb_HeaderDetail sb = new tb_HeaderDetail();
                    sb.SystemDate = DateTime.Now;
                    sb.TaskId = TaskId;
                    sb.HeaderId = headerid;
                    sb.UserID = Convert.ToInt32(Session["pmsuserid"]);
                    sb.IpAddress = Request.ServerVariables["remote_address"];
                    db.tb_HeaderDetail.Add(sb);

                    db.SaveChanges();
                }

            }

        }
        public string GetPermission(Int32 id)
        {
            Int32 TaskId = Convert.ToInt32(Session["pTaskId"]);
            //string strtables = "<table width='100%' border='0'>";
            //string strtables1 = "<table width='100%' border='0'>";
            string strtables = "";
            string strtables1 = "";
            string strtables2 = "";
            strtables2 = "<input type='hidden' value='" + id + "'>";
            var model2 = from m in db.tb_HeaderMaster
                         select new
                         {
                             taskname = m.HeadingName,
                             taskid = m.AutoId
                         };
            foreach (var item in model2)
            {

                var model1 = from m in db.tb_HeaderMaster
                             from t in db.tb_HeaderDetail
                             where t.HeaderId == m.AutoId && t.TaskId == TaskId && m.AutoId == item.taskid 
                             select new
                             {
                                 taskname = m.HeadingName,
                                 taskid = m.AutoId
                             };


                if (model1.Count() > 0)
                {
                    strtables += "<option value='" + item.taskid + "'>" + item.taskname + "</option>";
                }
                else
                {
                    strtables1 += "<option value='" + item.taskid + "'>" + item.taskname + "</option>";
                }

            }
            //strtables += "</table>";
            //strtables1 += "</table>";
            ViewData["permissionlist1"] = strtables1;
            ViewData["permissionlist"] = strtables;
            ViewData["permissionlist2"] = strtables2;
            return strtables;
        }
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Header Information");
            var Llist = db.tb_TaskMaster.ToList().AsQueryable();
            string strTable = "";
            foreach (var item in Llist)
            {
                strTable += "<tr>";
                strTable += "<td>" + item.TaskName + "</td>";
                strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/HeaderPermisson/edit/" + item.TaskID + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                strTable += "</tr>";
            }
            ViewData["userlist"] = strTable;

            return View();
        }
        public ActionResult Edit(Int32 id, FormCollection form)
        {
            Session.Add("pTaskId", id);
            if (Request.HttpMethod == "POST")
            {
                CreatePermission(id,form);
                ViewData["msstatus"] = "Header Permission Created";
            }
            GetPermission(id);
            return View();
        }










    }
}
