@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 


	@Session["projectmetatags"]




    <div id="body-text"> 
  <div id="contactus"> 
<div class="form">
<h2>Terms & Conditions</h2>
@Html.Raw(ViewData["pagedescription"]
  </div>

  <div class="map">
   @Html.Raw(ViewData["PageLeftData"]
  </div>
  
  </div>
 </div>

