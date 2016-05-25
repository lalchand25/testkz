@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/QuizSecurity.Master" Inherits="System.Web.Mvc.ViewPage" 


	@Session["projectmetatags"]



<script>
    window.onunload = function () {
        window.opener.location.href = window.opener.location;
    }

 </script>
  
  
  @if (ViewData["msgStatus"] == null)
     { 
    
   @Html.Partial("BaseTest"); 
 }
     else
     {

     <h1>@Html.Raw(ViewData["errorMsg"]</h1>
   
   }
   
     


