using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportManagement;
using iTextSharp;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
 
using iTextSharp.text.html;
 

namespace OLProject.Controllers
{
    using OLProject.Models;
    public class PdfReportsController : PdfViewController
    {
        //
        // GET: /PdfReport/
        kzonlineEntities db = new kzonlineEntities();
        public string PrintSlide(Int32 id)
        {
            var model = db.tb_LessionMasterSlides.ToList().AsQueryable().Where(x => x.AutoId == id);
            var modelg = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 10).Single();

            string html = "";
            if (model.Count() > 0)
            {
                foreach (var item in model)
                {

                    var gmodel = db.tb_LessionMaster.ToList().Where(x => x.LessionId == item.LessionId).Single();
                    ViewData["LessionName"] = gmodel.LessionHeading;

//                    ViewData["classname"] = clsCommon.getClassNameProduct(Convert.ToInt32(gmodel.ClassId));
  //                  ViewData["uname"] = clsCommon.getUnitName(Convert.ToInt32(gmodel.UnitId));
                    ViewData["subjectname"] = clsCommon.getSubjectName(Convert.ToInt32(gmodel.SubjectId));
                    html += "<h2>" + ViewData["subjectname"] + "</h2> <br />";
                    html += "<h2>" + item.SlideDescription + "</h2> <br />";
                    #region "Theme- 1"
                    if (item.ThemeId == 1)
                    {
                        if (item.UploadTypeId == 1) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImageDescription, Convert.ToInt32(item.ThemeId)); } //text
                        if (item.UploadTypeId == 2) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Image
                        if (item.UploadTypeId == 3) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Video
                        if (item.UploadTypeId == 4) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Video
                        if (item.UploadTypeId == 5) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); } //Video
                    }
                    #endregion
                    #region "Theme- 2"
                    if (item.ThemeId == 2)
                    {
                        if (item.UploadTypeId == 2) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Image
                        if (item.UploadTypeId == 3) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 4) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 5) { html += getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)); html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                    }
                    #endregion
                    #region "Theme- 3"
                    if (item.ThemeId == 3) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        html += "</table>";
                    }
                    #endregion
                    #region "Theme- 4"
                    if (item.ThemeId == 4)
                    {
                        html += "<div class='box4'>";

                        if (item.UploadTypeId == 2) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Image
                        if (item.UploadTypeId == 3) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 4) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        if (item.UploadTypeId == 5) { html += "<div class='box5'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + "</div>"; html += getHtml1(Convert.ToInt32(item.UploadTypeId), item.ImageDescription); } //Video
                        html += "</div>";
                    }
                    #endregion
                    #region "Theme- 5"
                    if (item.ThemeId == 5) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        //First Row
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td><td align='left' valign='top' width='60%' rowspan='5'>" + getHtml1(1, item.ImageDescription) + " </td></tr>"; }
                        //*************************************************************
                        //2 Row
                        if (item.UploadTypeId1 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************
                        //3 Row
                        if (item.UploadTypeId2 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId2 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId2 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId2 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId2), item.ImagePath2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************
                        //4 Row
                        if (item.UploadTypeId3 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId3 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId3 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId3 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId3), item.ImagePath3, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************
                        //5 Row
                        if (item.UploadTypeId4 == 2) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId4 == 3) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId4 == 4) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId4 == 5) { html += "<tr><td align='left' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId4), item.ImagePath4, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        //*************************************************************



                        html += "</table>";
                    }
                    #endregion

                    #region "Theme- 6"
                    if (item.ThemeId == 6) //T
                    {

                        html += "<table width='100%' align='center' style='background-color:white;'>";
                        if (item.UploadTypeId == 2) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top' width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 2) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 3) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 3) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 4) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 4) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }

                        if (item.UploadTypeId == 5) { html += "<tr><td align='left' valign='top' width='60%'>" + getHtml1(1, item.ImageDescription) + " </td><td align='left' valign='top'  width='40%'>" + getHtml(Convert.ToInt32(item.UploadTypeId), item.ImagePath, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        if (item.UploadTypeId1 == 5) { html += "<tr><td colspan='2' align='center' valign='top'>" + getHtml(Convert.ToInt32(item.UploadTypeId1), item.ImagePath1, Convert.ToInt32(item.ThemeId)) + " </td></tr><tr><td colspan='2' align='left' valign='top'>" + getHtml(1, item.Description2, Convert.ToInt32(item.ThemeId)) + " </td></tr>"; }
                        html += "</table>";
                    }
                    #endregion

                    //html += "<table width='100%' align='center' style='background-color:white;'>";

                    //html += "<tr><td align='left' valign='top' width='60%'><h3>Help</h3></td></tr>";
                    //html += "<tr><td align='left' valign='top' width='60%'>" + item.HelpSlide + "</td></tr>";

                    //html += "<tr><td align='left' valign='top' width='60%'><h3>Formula</h3></td></tr>";
                    //html += "<tr><td align='left' valign='top' width='60%'>" + item.Formula + "</td></tr>";

                    //html += "<tr><td align='left' valign='top' width='60%'><h3>Usefull Tips</h3></td></tr>";
                    //html += "<tr><td align='left' valign='top' width='60%'>" + item.UsefulTips + "</td></tr>";

                    //html += "<tr><td align='left' valign='top' width='60%'><h3>Question</h3></td></tr>";
                    //html += "<tr><td align='left' valign='top' width='60%'>" + item.Question + "</td></tr>";

                    //html += "<tr><td align='left' valign='top' width='60%'><h3>Solution</h3></td></tr>";
                    //html += "<tr><td align='left' valign='top' width='60%'>" + item.Solution + "</td></tr>";


                    //html += "</table>";
                }
            }

            return html;
        }
        public EmptyResult SlidePDF(Int32 id)
        {
            Int32 UserId = 25;// Convert.ToInt32(Session["pmsuserid"]);
            var pms = db.tb_UserMaster.ToList().Where(x => x.UserId == UserId).Single();

            ViewData["aggment"] = PrintSlide(id);

            var document = new Document(PageSize.A4_LANDSCAPE, 50, 50, 85, 25);
            // Create a new PdfWriter object, specifying the output stream
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);
            //header 
            string fullname = "Kin Zin Digital Media Inc.";
            // Our custom Header and Footer is done using Event Handler
            TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter(fullname);
            writer.PageEvent = PageEventHandler;
            writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;
            // Open the Document for writing
            document.Open();

            var html = RenderRazorViewToString("Detail2", pms);
             html = html.Replace("../../uploads/", "http://kzonline.org/uploads/");
            var worker = new HTMLWorker(document);

            var css = new StyleSheet();
            css.LoadTagStyle(HtmlTags.TH, HtmlTags.BGCOLOR, "#616161");
            css.LoadTagStyle(HtmlTags.TH, HtmlTags.COLOR, "#fff");
            css.LoadTagStyle(HtmlTags.BODY, HtmlTags.FONT, "verdana");
            css.LoadTagStyle(HtmlTags.TH, HtmlTags.FONTWEIGHT, "bold");
            css.LoadStyle("even", "bgcolor", "#EEE");

            worker.SetStyleSheet(css);

            //html = html.Replace("xx-small", "8pt");
            //html = html.Replace("small", "9pt");
            //html = html.Replace("x-large", "18pt");
            //html = html.Replace("large", "18pt");

            //html = html.Replace("medium", "12pt");

           // html = html.Replace();
            var stringReader = new StringReader(html);
            worker.Parse(stringReader);

            document.Close();

            Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "PdfView.pdf");
            Response.BinaryWrite(output.ToArray());

            return new EmptyResult();
        }
        public EmptyResult Lesson(Int32 id)
        {
            Int32 UserId = 25;// Convert.ToInt32(Session["pmsuserid"]);
            var pms = db.tb_UserMaster.ToList().Where(x => x.UserId == UserId).Single();

            var model = db.tb_LessionMasterSlides.ToList().Where(x => x.LessionId == id);
            string desc = "";
            foreach (var item in model)
            {
                desc += PrintSlide(item.AutoId);
            }
            ViewData["aggment"] = desc;

            var document = new Document(PageSize.A4_LANDSCAPE, 50, 50, 85, 25);
            // Create a new PdfWriter object, specifying the output stream
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);
            //header 
            //string fullname = "goonlineschool.com";
            string fullname = "";
            // Our custom Header and Footer is done using Event Handler
            TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter(fullname);
            writer.PageEvent = PageEventHandler;
            writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;
            // Open the Document for writing
            document.Open();

            var html = RenderRazorViewToString("Detail2", pms);

            var worker = new HTMLWorker(document);

            var css = new StyleSheet();
            css.LoadTagStyle(HtmlTags.TH, HtmlTags.BGCOLOR, "#616161");
            css.LoadTagStyle(HtmlTags.TH, HtmlTags.COLOR, "#fff");
            css.LoadTagStyle(HtmlTags.BODY, HtmlTags.FONT, "verdana");
            css.LoadTagStyle(HtmlTags.TH, HtmlTags.FONTWEIGHT, "bold");
            css.LoadStyle("even", "bgcolor", "#EEE");

            worker.SetStyleSheet(css);

            //html = html.Replace("xx-small", "8pt");
            //html = html.Replace("small", "9pt");
            //html = html.Replace("x-large", "18pt");
            //html = html.Replace("large", "18pt");

            //html = html.Replace("medium", "12pt");

            var stringReader = new StringReader(html);
            worker.Parse(stringReader);

            document.Close();

            Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "PdfView.pdf");
            Response.BinaryWrite(output.ToArray());

            return new EmptyResult();
        }
        public EmptyResult Aggreement()
        {
            Int32 UserId = Convert.ToInt32(Session["pmsuserid"]);
            var pms = db.tb_UserMaster.ToList().Where(x => x.UserId == UserId).Single();
            string productDetail = "";
            if (pms.PackageId > 0)
            {
                Int32 productid = Convert.ToInt32(pms.PackageId);

                var hmodel = (from m in db.tb_ProductMaster
                              from t in db.tb_Subscription
                              where m.SubsId == t.SubsId && m.ProductId == productid
                              select new
                              {
                                  m.ProductName,
                                  m.PriceDis,
                                  t.Duration
                              }).Single();
                productDetail = hmodel.ProductName + " - " + hmodel.PriceDis.ToString();
            }
            string desc = "";

            if (pms.CategoryId == 2) //Parents
            {
                var model1 = (from m in db.tb_emailsDescription
                             where m.Autoid == 19
                             select m).Single();

                desc = model1.Description;
                desc = desc.Replace("UserFirstName", pms.FirstName);
                desc = desc.Replace("UserMiddleName", pms.MiddleName);
                desc = desc.Replace("UserLastName", pms.LastName);
                desc = desc.Replace("UserEmailAddress", pms.EmailID);
                desc = desc.Replace("UserCellNumber", pms.ContactNo);
                desc = desc.Replace("UserAddress", pms.Address);
                desc = desc.Replace("UserProductBought", productDetail);
                desc = desc.Replace("createdate", pms.CreateDate.ToString());
                desc = desc.Replace("AgreementStartDate", pms.AgreementStartDate.ToString());
                desc = desc.Replace("AgreementEndDate", pms.AgreementEndDate.ToString());
               
            }

            if (pms.CategoryId == 9) //Student
            {
                var model1 = (from m in db.tb_emailsDescription
                              where m.Autoid == 19
                              select m).Single();

                desc = model1.Description;
                desc = desc.Replace("UserFirstName", pms.FirstName);
                desc = desc.Replace("UserMiddleName", pms.MiddleName);
                desc = desc.Replace("UserLastName", pms.LastName);
                desc = desc.Replace("UserEmailAddress", pms.EmailID);
                desc = desc.Replace("UserCellNumber", pms.ContactNo);
                desc = desc.Replace("UserAddress", pms.Address);
                desc = desc.Replace("UserProductBought", productDetail);
                desc = desc.Replace("createdate", pms.CreateDate.ToString());
                desc = desc.Replace("AgreementStartDate", pms.AgreementStartDate.ToString());
                desc = desc.Replace("AgreementEndDate", pms.AgreementEndDate.ToString());

            }


            if (pms.CategoryId == 3) //Teacher
            {
                var model1 = (from m in db.tb_emailsDescription
                             where m.Autoid == 20
                             select m).Single();
                desc = model1.Description;
                desc = desc.Replace("UserFirstName", pms.FirstName);
                desc = desc.Replace("UserMiddleName", pms.MiddleName);
                desc = desc.Replace("UserLastName", pms.LastName);
                desc = desc.Replace("UserEmailAddress", pms.EmailID);
                desc = desc.Replace("UserCellNumber", pms.ContactNo);
                desc = desc.Replace("UserAddress", pms.Address);
                desc = desc.Replace("createdate", pms.CreateDate.ToString());
                desc = desc.Replace("AgreementStartDate", pms.AgreementStartDate.ToString());
                desc = desc.Replace("AgreementEndDate", pms.AgreementEndDate.ToString());
            }

            ViewData["aggment"] = desc;




            var document = new Document(PageSize.A4_LANDSCAPE, 50, 50, 25, 25);
            // Create a new PdfWriter object, specifying the output stream
            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);
            //header 
            string fullname = "goonlineschool.com";
            // Our custom Header and Footer is done using Event Handler
            TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter(fullname);
            writer.PageEvent = PageEventHandler;
            writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;


            // Open the Document for writing
            document.Open();

            var html = RenderRazorViewToString("Detail2", pms);

            var worker = new HTMLWorker(document);

            var css = new StyleSheet();
            css.LoadTagStyle(HtmlTags.TH, HtmlTags.BGCOLOR, "#616161");
            css.LoadTagStyle(HtmlTags.TH, HtmlTags.COLOR, "#fff");
            css.LoadTagStyle(HtmlTags.BODY, HtmlTags.FONT, "verdana");
            css.LoadTagStyle(HtmlTags.TH, HtmlTags.FONTWEIGHT, "bold");
            css.LoadStyle("even", "bgcolor", "#EEE");

            worker.SetStyleSheet(css);

            //html = html.Replace("xx-small", "8pt");
            //html = html.Replace("small", "9pt");
            //html = html.Replace("x-large", "18pt");
            //html = html.Replace("large", "18pt");

            //html = html.Replace("medium", "12pt");

            var stringReader = new StringReader(html);
            worker.Parse(stringReader);

            document.Close();

            Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "PdfView.pdf");
            Response.BinaryWrite(output.ToArray());

            return new EmptyResult();
        }

        //public EmptyResult Lesson(Int32 id)
        //{
        //    var model = db.tb_LessionMasterSlides.ToList().AsQueryable().Where(x => x.LessionId == id);
        //    var document = new Document(PageSize.A4_LANDSCAPE, 50, 50, 25, 25);

        //    // Create a new PdfWriter object, specifying the output stream
        //    var output = new MemoryStream();
        //    var writer = PdfWriter.GetInstance(document, output);


        //    //header 
        //    string fullname = "goonlineschool.com";
        //    // Our custom Header and Footer is done using Event Handler
        //    TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter(fullname);
        //    writer.PageEvent = PageEventHandler;
        //    writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;


        //    // Open the Document for writing
        //    document.Open();

        //    var html = RenderRazorViewToString("Detail1", model);

        //    var worker = new HTMLWorker(document);

        //    var css = new StyleSheet();
        //    css.LoadTagStyle(HtmlTags.TH, HtmlTags.BGCOLOR, "#616161");
        //    css.LoadTagStyle(HtmlTags.TH, HtmlTags.COLOR, "#fff");
        //    css.LoadTagStyle(HtmlTags.BODY, HtmlTags.FONT, "verdana");
        //    css.LoadTagStyle(HtmlTags.TH, HtmlTags.FONTWEIGHT, "bold");
        //    css.LoadStyle("even", "bgcolor", "#EEE");

        //    worker.SetStyleSheet(css);

        //    //html = html.Replace("xx-small", "8pt");
        //    //html = html.Replace("small", "9pt");
        //    //html = html.Replace("x-large", "18pt");
        //    //html = html.Replace("large", "18pt");

        //    //html = html.Replace("medium", "12pt");

        //    var stringReader = new StringReader(html);
        //    worker.Parse(stringReader);

        //    document.Close();

        //    Response.ContentType = "application/pdf";
        //    //Response.AddHeader("Content-Disposition", "PdfView.pdf");
        //    Response.BinaryWrite(output.ToArray());

        //    return new EmptyResult();
        //}

        private string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
        private string getHtml1(Int32 UploadTypeId, string ImageName)
        {
            string html = "";
            html += "<p  style='background-color:white;'>";
            html += ImageName;
            html += "</p>";
            return html;
        }
        private string getHtml(Int32 UploadTypeId, string ImageName, Int32 ThemeId)
        {
            string imagepath11 = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~")) + "Uploads/";
            string html = "";
            Int32 imgeWidth = 100;
            Int32 imgHeight = 100;
            var model = db.tb_ThemeContent.ToList().Where(x => x.UploadTypeId == UploadTypeId && x.ThemeId == ThemeId);
            if (model.Count() > 0)
            {
                var model1 = db.tb_ThemeContent.ToList().Where(x => x.UploadTypeId == UploadTypeId && x.ThemeId == ThemeId).Single();
                imgeWidth = Convert.ToInt32(model1.intWidth);
                imgHeight = Convert.ToInt32(model1.intHeight);
            }

            if (UploadTypeId == 1) //text
            {
                html += "<table width='100%' align='' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'>" + ImageName + "</td></tr>";
                html += "</table>";
            }

            if (UploadTypeId == 2)
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'><img src='" + imagepath11 + ImageName + "' width='" + imgeWidth + "' height='" + imgHeight + "' /></td></tr>";
                html += "</table>";
            }
            if (UploadTypeId == 3) //Video
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'><img src='" + imagepath11 +  "video.png' width='" + imgeWidth + "' height='" + imgHeight + "' /></td></tr>";
                html += "</table>";
            }

            if (UploadTypeId == 4) // Audio
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'><img src='" + imagepath11 +  "audio.png' width='" + imgeWidth + "' height='" + imgHeight + "' /></td></tr>";
                html += "</table>";
            }
            if (UploadTypeId == 5)
            {
                html += "<table width='100%' align='left' style='background-color:white;'>";
                html += "<tr><td align='left' valign='top'><img src='" + imagepath11 +  "flash.png' width='" + imgeWidth + "' height='" + imgHeight + "' /></td></tr>";
                html += "</table>";
            }
            return html;

        }
      
        //private string getHtml(Int32 UploadTypeId, string ImageName)
        //{
        //    string imagepath11 = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~")) + "Uploads/";
        //    string html = "";
        //    if (UploadTypeId == 1)
        //    {
        //        html += "<table width='100%' align='' style='background-color:white;'>";
        //        html += "<tr><td align='left' valign='top'>" + ImageName + "</td></tr>";
        //        html += "</table>";
        //    }
        //    if (UploadTypeId == 2)
        //    {
        //        html += "<table width='100%' align='left' style='background-color:white;'>";
        //        html += "<tr><td align='left' valign='top'><img src='" + imagepath11 + ImageName + "' /></td></tr>";
        //        html += "</table>";
        //    }
        //    if (UploadTypeId == 3)
        //    {
        //        html += "<table width='100%' align='left' style='background-color:white;'>";
        //        html += "<tr><td align='left' valign='top'>";
        //        html += "<video width='320' height='240' controls autoplay>";
        //        html += "<source src='" + imagepath11 + ImageName + "' type='video/mp4'>";
        //        html += "</video>";
        //        html += "</td></tr>";
        //        html += "</table>";
        //    }

        //    if (UploadTypeId == 4)
        //    {
        //        html += "<table width='100%' align='left' style='background-color:white;'>";
        //        html += "<tr><td align='left' valign='top'>";
        //        html += " <audio controls>";
        //       // html += "<source src='../../uploads/" + ImageName + "' type='audio/mpeg'></audio>";
        //        html += "<source src='" + imagepath11 + ImageName + "' type='audio/mpeg'>";
        //        html += "</td></tr>";
        //        html += "</table>";
        //    }
        //    if (UploadTypeId == 5)
        //    {
        //        html += "<table width='100%' align='left' style='background-color:white;'>";
        //        html += "<tr><td align='left' valign='top'>";
        //        html += "<OBJECT classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' ";
        //        html += "codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0' ";
        //        html += "WIDTH='320' HEIGHT='240' id='Puggle' ALIGN=''>";
        //        html += "<PARAM NAME=movie VALUE='" + imagepath11 + ImageName + "'> ";
        //        html += "<PARAM NAME=quality VALUE=high>";
        //        html += "<PARAM NAME=bgcolor VALUE=#333399>";
        //        html += "<EMBED src='" + imagepath11 + ImageName + "' quality=high bgcolor=#333399 WIDTH='900' HEIGHT='450' NAME='Yourfilename' ALIGN='' TYPE='application/x-shockwave-flash' PLUGINSPAGE='http://www.macromedia.com/go/getflashplayer'></EMBED> </OBJECT>";
        //        html += "</td></tr>";
        //        html += "</table>";
        //    }
        //    return html;
        //}
        //private string getHtml12(Int32 UploadTypeId, string ImageName)
        //{

        //    string html = "";
        //    html += "<p  style='background-color:white;'>";
        //    html += ImageName;
        //    html += "</p>";
        //    return html;
        //}
        public ActionResult Detail1()
        {
            Int32 id = 750;
            var model = db.tb_LessionMasterSlides.ToList().AsQueryable().Where(x => x.LessionId == id);
            //return ViewPdf("Lesson ", "Detail1", model);
            return View(model);
        }
        public ActionResult Detail2()
        {
            Int32 UserId = Convert.ToInt32(Session["pmsuserid"]);
            var model = db.tb_UserMaster.ToList().Where(x => x.UserId == UserId).Single();
            ViewData["Hello1"] = "Hello";
            return View(model);
        }
   
        //public ActionResult index(Int32 id)
        //{
          

        //    var model = (from m in db.tb_QuizResults
        //                 from t in db.tb_QuizDetail
        //                 where m.QuestionId == t.AutoId && m.TestId == id
        //                 select new QuizInformation
        //                 {
        //                     Decription = t.Decription,
        //                     Ans1 = t.Ans1,
        //                     Ans2 = t.Ans2,
        //                     Ans3 = t.Ans3,
        //                     Ans4 = t.Ans4,
        //                     UserAns = (Int32)m.Answer,
        //                     QuesTypeId = (Int32)t.QuesTypeId,
        //                     Check1 = (Boolean)t.Check1,
        //                     Check2 = (Boolean)t.Check2,
        //                     Check3 = (Boolean)t.Check3,
        //                     Check4 = (Boolean)t.Check4,
        //                     ComputerAns = (Int32)m.ActualAns

        //                 });
        //    var model1 = db.tb_OnlineTestMaster.ToList().Where(m => m.TestID == id).Single();
        //    ViewData["SubjectName"] = clsCommon.getSubjectName(Convert.ToInt32(model1.SubjectId));
        //    ViewData["ClassName"] = clsCommon.getClassName(Convert.ToInt32(model1.ClassID));
        //    ViewData["UnitName"] = clsCommon.getUnitName(Convert.ToInt32(model1.UnitID));
        //   // ViewData["StudentName"] = clsCommon.getUserName(Convert.ToInt32(model1.UserID));
        //    ViewData["LessonName"] = clsCommon.getLessonName(Convert.ToInt32(model1.LessonID));

        //    ViewData["Total"] = model1.TotalQuestion;
        //    ViewData["TotalCorrect"] = model1.TotalCorrect;
        //    ViewData["TotalWrong"] = model1.TotalWrong;

        //    return ViewPdf("Customer report", "Detail", model);
        //}

        public ActionResult Detail(Int32 id)
        {
            var model = (from m in db.tb_QuizResults
                         from t in db.tb_QuizDetail
                         where m.QuestionId == t.AutoId && m.TestId == id
                         select new QuizInformation
                         {
                             Decription = t.Decription,
                             Ans1 = t.Ans1,
                             Ans2 = t.Ans2,
                             Ans3 = t.Ans3,
                             Ans4 = t.Ans4,
                             UserAns = (Int32)m.Answer,
                             QuesTypeId = (Int32)t.QuesTypeId,
                             Check1 = (Boolean)t.Check1,
                             Check2 = (Boolean)t.Check2,
                             Check3 = (Boolean)t.Check3,
                             Check4 = (Boolean)t.Check4,
                             ComputerAns = (Int32)m.ActualAns

                         });

            ViewData["testid"] = id;
            return View(model);
        }

        //public ActionResult Lesson()
        //{
        //    //var customerList = db.tb_LessionMaster.ToList();
        //    var model = db.tb_QuizResults.ToList().Where(x => x.AutoId == 137).Single();

        //    //FillImageUrl(customerList, "report.jpg");

        //    //return ViewPdf("Customer report", "Detail", model);

        //    return View(model);
        //}


        //public ActionResult Index1()
        //{
        //    var customerList = db.tb_LessionMaster.ToList();




        //    return View(customerList);
        //}

        //
        // GET: /PdfReport/Details/5

       
        // GET: /PdfReport/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PdfReport/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /PdfReport/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PdfReport/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PdfReport/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PdfReport/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
