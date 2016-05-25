@@ Page Title="" Language="C#"   MasterPageFile="~/Views/Shared/SlideSecurity.Master" Inherits="System.Web.Mvc.ViewPage<OLProject.Models.tb_LessionMasterSlides>" 


	@Session["projectmetatags"]






     @if (ViewData["msgStatus"] == null)
     { 
     
<h3>Are you sure you want to delete this?</h3>


    @ if (Convert.ToInt32(ViewData["themeid"]) == 1)
       { 
            @Html.Partial("Theme1");  
    @ }  
   
  @ if (Convert.ToInt32(ViewData["themeid"]) == 2)
       { 
            @Html.Partial("Theme2");  
    @ }  
   
  
  @ if (Convert.ToInt32(ViewData["themeid"]) == 3)
       { 
            @Html.Partial("Theme3");  
    @ }  
   

   
   
  @ if (Convert.ToInt32(ViewData["themeid"]) == 4)
       { 
            @Html.Partial("Theme4");  
    @ }  
   

  
   
  @ if (Convert.ToInt32(ViewData["themeid"]) == 5)
       { 
            @Html.Partial("Theme5");  
    @ }  
   
 


 
   
  @ if (Convert.ToInt32(ViewData["themeid"]) == 6)
       { 
            @Html.Partial("Theme6");  
    @ }  



   }
     else
     {

     <h2>@Html.Raw(ViewData["errormsg"]</h2>
   
   }



