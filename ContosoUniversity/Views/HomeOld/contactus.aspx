@@ Page Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<OLProject.Models.tb_Contactus>" 


    @Session["projectmetatags"]


    <div id="body-text">
        <div class="textBox_full2">
            <h2>
                Contact us</h2>
            @Html.Raw(ViewData["pagedescription"]
            <br />
            @Html.Raw(ViewData["tline"] 
            @ if (ViewData["message"] == null)
               { 
            @object objText = new { style = "width:200px;Height:27px" }; 
            @using (Html.BeginForm())
               {
            @Html.ValidationSummary(true)
             @  ViewData["PageLeftData"] 
            <table style="width: 100%;" align="left">
                @--  <tr>
                    <td style="width: 25%;">
                        Select Category:
                    </td>
                    <td style="width: 75%;">
                        @Html.Raw(ViewData["categorygroup"] 
                    </td>
                </tr>--
                <tr>
                    <td style="width: 25%;">
                        Email ID:
                    </td>
                    <td style="width: 75%;">
                        <div class="editor-field">
                            @Html.TextBoxFor(model => model.EmailId, new  { style="Width:220px"})
                            @Html.ValidationMessageFor(model => model.EmailId)
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name:
                    </td>
                    <td>
                        <div class="editor-field">
                            @Html.TextBoxFor(model => model.FirstName, new { style = "Width:220px" })
                            @Html.ValidationMessageFor(model => model.FirstName)
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Last Name:
                    </td>
                    <td>
                        @Html.TextBoxFor(model => model.LastName, new { style = "Width:220px" })
                        @Html.ValidationMessageFor(model => model.LastName)
                    </td>
                </tr>
                <tr>
                    <td>
                        Location:
                    </td>
                    <td>
                        <div class="editor-field">
                            @Html.TextBoxFor(model => model.Location, new { style = "Width:220px" })
                            @Html.ValidationMessageFor(model => model.Location)
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Contact No.:
                    </td>
                    <td>
                        <div class="editor-field">
                            @Html.TextBoxFor(model => model.ContactNo, new { style = "Width:220px" })
                            @Html.ValidationMessageFor(model => model.ContactNo)
                        </div>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Comments:
                    </td>
                    <td>
                        <div class="editor-field">
                            @Html.TextAreaFor(model => model.Comments, new { style = "width:300px;height:80px;" })
                            @Html.ValidationMessageFor(model => model.Comments)
                        </div>
                    </td>
                </tr>
                @--     <tr>
                    <td valign="top">
                        &nbsp;
                    </td>
                    <td>
                        <div class="editor-label">
                            <input type="image" id="image" src="@Url.Action("image")" alt="click to refresh" />
                        </div>
                    </td>
                </tr>--
                @--    <tr>
                    <td valign="top">
                        Enter Text
                    </td>
                    <td>
                        <div class="editor-field">
                            @Html.TextBox("captchatext", "", objText)<span class="txt_red">&nbsp;&nbsp;@Html.ValidationMessage("captchatext")
                        </div>
                    </td>
                </tr>--
                <tr>
                    <td style="height: 30px">
                    </td>
                    <td style="height: 30px">
                        <input type="submit" value="Submit" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            @ } 
          }
               else
               { 
            @Html.Raw(ViewData["message"]
            }
        </div>
        <div class="textBox_full_right">
            <h2>
                &nbsp;
            </h2>
            @Html.Raw(ViewData["PageRightData"]
            @--  <p>
                <span style="font-family: arial, helvetica, sans-serif; color: #ff0000; font-size: medium;">
                    <strong>Join US Today!!!</strong></span></p>
            <p>
                &nbsp;</p>
            <p>
                <a title="Goeoffice Project Management System" href="http://www.studyworkimmigrate.com"
                    target="_blank">
                    <img src="../../uploads/add11.jpg" alt="" /></a></p>
            <p>
                &nbsp;</p>
            <p>
                <a title="Goeoffice Project Management System" href="http://www.goeoffice.com" target="_blank">
                    <img src="../../uploads/add1.jpg" alt="" /></a></p>
            <p>
                &nbsp;</p>
            <p>
                <a title="Goeoffice Project Management System" href="http://www.studyworkimmigrate.com"
                    target="_blank">
                    <img src="../../uploads/add12.jpg.jpg" alt="" /></a></p>
            <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
            <!-- addforGOE -->
            <ins class="adsbygoogle" style="display: inline-block; width: 300px; height: 250px"
                data-ad-client="ca-pub-3017908902490282" data-ad-slot="3764054121"></ins>
            <script>
                (adsbygoogle = window.adsbygoogle || []).push({});
            </script>--
        </div>
    </div>

