@@ Page Title="" Language="C#"   MasterPageFile="~/Views/Shared/SlideSecurity.Master" Inherits="System.Web.Mvc.ViewPage<OLProject.Models.tb_LessionMasterSlides>" 


	@Session["projectmetatags"]



<script>
window.onunload = function () {
            window.opener.location.href = window.opener.location;
}

 </script>
    @if (ViewData["msgStatus"] == null)
     { 
        @Html.Partial("Theme5");  
   }
     else
     {

     <h2>@Html.Raw(ViewData["errormsg"]</h2>
   
   }


