@model OLProject.Models.tb_Help>" 


		@Session["projectmetatags"]




 @if (ViewData["msgStatus"] == null)
     { 
   @Html.Partial("BaseSubject"); 
 }
     else
     {
     <h1>@Html.Raw(ViewData["errorMsg"]</h1>
  }


