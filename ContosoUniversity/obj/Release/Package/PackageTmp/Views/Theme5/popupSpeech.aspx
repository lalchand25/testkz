@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Security.Master"  Inherits="System.Web.Mvc.ViewPage<OLProject.Models.tb_LessionMasterSlides>" 
@using OLProject.Models;

	@Session["projectmetatags"]



   
<!-- /TinyMCE -->
  <div class="Courses">
     	<div class="topdiv">
                 <div class="clr"></div>
        </div>
        
        
        
        <div class="middiv" >
  @using (Html.BeginForm())
       {
        @Html.ValidationSummary(true)
       
 <br /><b>@Html.Raw(ViewData["lstatus"]</b><br />
 
    <table width="95%" align="center">
   
            <tr>
    <td valign="top" align='left'>            <b>Speech Text</b>   </td>    </tr>
           <tr>
    <td align='left'>  
                 @Html.TextAreaFor(model => model.SpeechText, new  { style="Width:50%;height:200px" })
             <b> @Html.ValidationMessageFor(model => model.SpeechText)</b>
                 </td>
    </tr>
           <tr>
    <td align='left'>  
                    <input type="image" src="../../siteimages/Submit.png" /><br /></td>
    </tr>
    </table>
  }

   <div class="bottomdiv" style="background:#9A0201;">
        <div class="clr"></div>
        </div>
 </div>
 </div>

