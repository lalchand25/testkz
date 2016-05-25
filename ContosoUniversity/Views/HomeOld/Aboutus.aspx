@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 


	@Session["projectmetatags"]



<div id="body-text"> 
  <div class="textBox_full2">

                <h2> 
                  @Html.Raw(ViewData["PageHeading"]  
                   </h2>
                       @Html.Raw(ViewData["PageLeftData"]
            
            </div>
          <div class="textBox_full_right">
            <h2>&nbsp; </h2> 
                @Html.Raw(ViewData["PageRightData"]
            </div>
        </div>
 

