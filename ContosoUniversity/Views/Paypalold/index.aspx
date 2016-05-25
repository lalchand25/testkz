@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/home.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 

@@ Register src="../Shared/tabsforRegisteration.ascx" tagname="tabsforRegisteration" tagprefix="uc1" 


	@Session["projectmetatags"]



    <form id="Paypal" runat="server" action="/paypal/paySend">
       <div class="searchList">
      <h3>Packages</h3><br />
           <uc1:tabsforRegisteration ID="tabsforRegisteration1" runat="server" />

         <div class='package1'><div class='offer' style='padding-top:20px'>FREE</div> <h2>Schools</h2>
         <div class="offer">@Html.Raw(ViewData["package0"]<br />off</div>
           @Html.Raw(ViewData["package00"]<br />
<ul>
	@Html.Raw(ViewData["Schoolssoffer"]

</ul>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="middle"><input name="" class="btn" type="submit" value="buy now" /></td>
  </tr>
</table>

      
      </div>


   
      
      <div class="package1">
      <div class="offer">@Html.Raw(ViewData["package1"]<br />off</div>
      <h2>Colleges</h2>
      @Html.Raw(ViewData["package11"]


<ul>
	 @Html.Raw(ViewData["collegesoffers"]

</ul>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="middle"><input name="" class="btn" type="submit" value="buy now" /></td>
  </tr>
</table>
    </div>
      <div class="package1">
      <div class="offer">@Html.Raw(ViewData["package2"]<br />off</div>
      <h2>Universities</h2>
       @Html.Raw(ViewData["package22"] 
<ul>
	@Html.Raw(ViewData["universityoffers"]
</ul>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="middle"><input  class="btn" type="submit" value="buy now" /></td>
  </tr>
</table>

      
      </div>
      
    </div>

   <div class="refineSearch">
    <h3> Working with us</h3><br />

    <div style="width:100%;height:520px;overflow:auto;">
@Html.Raw(ViewData["pagedescription"]
</div>
  </div>
    
 
    </form>

