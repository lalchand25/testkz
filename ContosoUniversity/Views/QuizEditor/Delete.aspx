@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/QuizSecurity.Master" Inherits="System.Web.Mvc.ViewPage" 


	@Session["projectmetatags"]



<script>
    window.onunload = function () {
        window.opener.location.href = window.opener.location;
    }

 </script>
  
  
  @if (ViewData["msgStatus"] == null)
     { 
    <h2>Are your Sure to delete this?</h2>
   @Html.Partial("BaseTest"); 
 }
     else
     {

     <h1>@Html.Raw(ViewData["errorMsg"]</h1>
   
   }
   
     
     


