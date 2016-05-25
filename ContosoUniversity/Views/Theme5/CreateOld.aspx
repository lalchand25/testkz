@@ Page Title="" Language="C#"   MasterPageFile="~/Views/Shared/Security.Master" Inherits="System.Web.Mvc.ViewPage<OLProject.Models.tb_LessionMasterSlides>" 


	@Session["projectmetatags"]



<script>
window.onunload = function () {
            window.opener.location.href = window.opener.location;
}

 </script>

    <h1>Create New Slide</h1>
   @Html.Partial("BaseSlides"); 

  



