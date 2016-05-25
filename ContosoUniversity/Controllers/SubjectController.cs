using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;
using OLProject.Models;

namespace OLProject.Controllers
{
    public class SubjectController : Controller
    {
        //
        // GET: /Subject/


        kzonlineEntities db = new kzonlineEntities();
        public ActionResult Index()
        {
            Session.Add("ModuleName0", "Subject Information");
            // var Llist = db.tb_SubjectMaster.ToList().OrderBy(x => x.DisplayOrder);

            var Llist = db.tb_SubjectMaster.ToList().AsQueryable();
            Llist = Llist.OrderBy(x => x.DisplayOrder);

            int catid = 0;
            if (Session["cateid"] != null)
            {
                catid = Convert.ToInt32(Session["cateid"]);
            }

            if (catid != 8)
            {
                Int32 userid = Convert.ToInt32(Session["pmsuserid"]);

                Llist = Llist.Where(x => x.UserId == userid);
            }


            string strTable = "";
            foreach (var item in Llist)
            {
                var model = db.tb_ClassMaster.ToList().Where(x => x.SubjectId == item.SubjectId);
                strTable += "<tr>";
                strTable += "<td><img src='../../uploads/" + item.SubjectImge + "' border='0'.   alt='Delete' style='width:38px;Height:38px;'/></td>";
                strTable += "<td><a href='javascript:OpenPopup(&#34;/subject/Detail/" + item.SubjectId + "&#34;);' id='A2' runat='server' >" + item.SubjectName + "</a></td>";

                //strTable += "<td>" + item.SubjectDesc + "</td>";
                strTable += "<td>" + model.Count() + "</td>";

                strTable += "<td>" + item.DisplayOrder + "</td>";

                //strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/subject/edit/" + item.SubjectId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/Edit.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";
                //strTable += "<td align='center' valign='top'><a href='javascript:OpenPopup(&#34;/subject/Delete/" + item.SubjectId + "&#34;);' id='A2' runat='server' ><img src='../../SiteImages/delete.png' border='0'   alt='Delete' style='width:50px;Height:50px;'/></a>";

                strTable += "<td align='center' valign='top'> <button class='btn btn-success'  onclick='javascript:OpenPopup(\"/subject/edit/" + item.SubjectId + "\");' type='button'> <i class='fa fa-edit'></i>    Edit       </button> </td>";
                strTable += "<td align='center' valign='top'> <button class='btn btn-danger' onclick='javascript:OpenPopup(\"/subject/delete/" + item.SubjectId + "\");' type='button'> <i class='fa glyphicon-remove'></i>    Delete       </button> </td>";



            }
            ViewData["data"] = strTable;

            return View();
        }

        //
        // GET: /Subject/Details/5



        public ActionResult Create()
        {
            ViewData["buttonname"] = 1;

            return View();
        }
        private Boolean ValidateData(tb_SubjectMaster model)
        {
            Boolean validateData1 = true;
            if (string.IsNullOrEmpty(model.SubjectName))
                ViewData.ModelState.AddModelError("SubjectName", "Please enter   Subject Name!");
            if (string.IsNullOrEmpty(model.SubjectDesc))
                ViewData.ModelState.AddModelError("SubjectDesc", "Please enter   Description!");

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
        public ActionResult Create(tb_SubjectMaster model)
        {
            ViewData["buttonname"] = 1;
            try
            {

                string filename1 = "";
                string filename2 = "";

                if (Request.HttpMethod == "POST")
                {
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
                                file.SaveAs(filePath);
                            }
                        }


                        //Big Image

                        //file = Request.Files[1];
                        //if (file.ContentLength < 2000000)
                        //{
                        //    String FileExtension = Path.GetExtension(file.FileName).ToLower();
                        //    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                        //    {

                        //        string randName = emailSystem.CreateRandomPassword(8);

                        //        filename2 = randName + "_" + file.FileName;

                        //        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                        //        file.SaveAs(filePath);
                        //    }
                        //}



                        if (filename1 != "")
                        {
                            model.SubjectImge = filename1;
                        }
                        if (filename2 != "")
                        {
                            model.BigImage = filename2;
                        }
                        model.CompanyId = 0;
                        model.UserId = Convert.ToInt32(Session["pmsuserid"]);
                        model.SystemDate = DateTime.Now;
                        model.IpAddress = Request.ServerVariables["remote_address"];
                        db.tb_SubjectMaster.Add(model);
                        if (Session["pmsuserid"] != null)
                        {
                            db.SaveChanges();
                        }
                        ViewData["errormsg"] = clsCommon.ErrorMessage(1);
                        ViewData["msgStatus"] = clsCommon.ErrorMessage(1);
                        var tb = new tb_SubjectMaster();

                        return View(tb);
                    }
                }
            }
            catch
            {

            }
            return View();
        }


        //
        // GET: /Subject/Edit/5
        public ActionResult Detail(int id)
        {

            var model = (from m in db.tb_SubjectMaster
                         where m.SubjectId == id
                         select m).Single();
            ViewData["desc"] = model.SubjectDesc;
            ViewData["bigimage"] = model.BigImage;
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewData["buttonname"] = 2;
            var model = (from m in db.tb_SubjectMaster
                         where m.SubjectId == id
                         select m).Single();

            return View(model);
        }

        //
        // POST: /Subject/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, tb_SubjectMaster model)
        {
            try
            {
                ViewData["buttonname"] = 2;
                string filename1 = "";
                string filename2 = "";
                var tb = (from m in db.tb_SubjectMaster
                          where m.SubjectId == id
                          select m).Single();


                HttpPostedFileBase file = Request.Files[0];
                String FileExtension = Path.GetExtension(file.FileName).ToLower();
                if (file.ContentLength < 2000000)
                {
                    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                    {
                        string randName = emailSystem.CreateRandomPassword(8);
                        filename1 = randName + "_" + file.FileName;
                        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename1);
                        file.SaveAs(filePath);
                    }
                }
                //file = Request.Files[1];
                //FileExtension = Path.GetExtension(file.FileName).ToLower();
                //if (file.ContentLength < 2000000)
                //{
                //    if (FileExtension == ".png" || FileExtension == ".jpg" || FileExtension == ".jpeg" || FileExtension == ".gif")
                //    {
                //        string randName = emailSystem.CreateRandomPassword(8);

                //        filename2 = randName + "_" + file.FileName;
                //        string filePath = Path.Combine(HttpContext.Server.MapPath("~/uploads/"), filename2);
                //        file.SaveAs(filePath);
                //    }
                //}






                if (filename1 != "")
                {
                    tb.SubjectImge = filename1;
                }

                if (filename2 != "")
                {
                    tb.BigImage = filename2;
                }
                tb.SubjectName = model.SubjectName;
                tb.SubjectDesc = model.SubjectDesc;
                tb.DisplayOrder = model.DisplayOrder;
                tb.Publish = model.Publish;
                tb.ShortDescription = model.ShortDescription;


                tb.Price = model.Price;
                tb.Duration = model.Duration;

                db.SaveChanges();
                ViewData["errormsg"] = clsCommon.ErrorMessage(2);
                ViewData["msgStatus"] = clsCommon.ErrorMessage(2);

                var tb1 = new tb_SubjectMaster();
                return View(tb1);
            }
            catch (Exception ce)
            {
                ViewData["errormsg"] = ce.Message;

                return View();
            }
        }

        //
        // GET: /Subject/Delete/5

        public ActionResult Delete(int id)
        {
            ViewData["buttonname"] = 3;

            var tb = (from m in db.tb_SubjectMaster
                      where m.SubjectId == id
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

                var model = db.tb_LessionMaster.ToList().Where(x => x.SubjectId == id);
                if (model.Count() == 0)
                {
                    var tb = (from m in db.tb_SubjectMaster
                              where m.SubjectId == id
                              select m).Single();

                    db.tb_SubjectMaster.Remove(tb);
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
                return View();
            }

            return View();
        }

        public ActionResult publishCourse(string sortOrder, string currentFilter, string searchString, int? page, string MainCategoryID, string CategoryID)
        {


            var tbProduct = from m in db.tb_SubjectMaster select m;

            tbProduct = tbProduct.OrderBy(x => x.SubjectName);



            int pageSize = 1000;
            int pageNumber = (page ?? 1);
            return View(tbProduct.ToPagedList(pageNumber, pageSize));
        }


        [HttpPost]
        public ActionResult publishCourse(string sortOrder, string currentFilter, string searchString, int? page, string MainCategoryID, string CategoryID, tb_SubjectMaster model)
        {

            if (Request.Form.GetValues("selectedobjects") != null)
            {
                // for set availabilty false
                var tbCatalog = (from m in db.tb_SubjectMaster where m.PublishAdmin == true select m).ToList();
                foreach (var item in tbCatalog)
                {
                    var varCatlog = (from m in db.tb_SubjectMaster where m.SubjectId == item.SubjectId select m).Single();
                    varCatlog.PublishAdmin = false;
                }


                int auotid = 0;
                string mystring = "";
                int totalcount = Convert.ToInt16(Request.Form.GetValues("selectedobjects").Count());

                for (int i = 0; i < totalcount; i++)
                {
                    mystring = Request.Form.GetValues("selectedobjects")[i].ToString();
                    auotid = Convert.ToInt32(mystring);
                    var plantfinal = (from m in db.tb_SubjectMaster where m.SubjectId == auotid select m).Single();
                    plantfinal.PublishAdmin = true;
                }
                db.SaveChanges();
            }
            else
            { // unpublish all itmes
                var tbCatalog = (from m in db.tb_SubjectMaster where m.PublishAdmin == true select m).ToList();
                foreach (var item in tbCatalog)
                {
                    var varCatlog = (from m in db.tb_SubjectMaster where m.SubjectId == item.SubjectId select m).Single();
                    varCatlog.PublishAdmin = false;
                }

            }

            db.SaveChanges();



            var tbProduct = from m in db.tb_SubjectMaster select m;

            tbProduct = tbProduct.OrderBy(x => x.SubjectName);

            // tbProduct = tbProduct.Where(s => s.Picture == null); 


            int pageSize = 1000;
            int pageNumber = (page ?? 1);
            return View(tbProduct.ToPagedList(pageNumber, pageSize));

        }

    }
}
