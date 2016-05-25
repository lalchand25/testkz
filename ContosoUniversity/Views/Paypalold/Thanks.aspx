@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/home.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 

@@ Register src="../Shared/tabsforRegisteration.ascx" tagname="tabsforRegisteration" tagprefix="uc1" 


	@Session["projectmetatags"]




<div class="searchList1">
    <uc1:tabsforRegisteration ID="tabsforRegisteration1" runat="server" />
   <br /><br />
You have successfully completed LMSOS registration process.<br />
<br />
Thanks for completing the registration process, <br />
<br />
Please login to your account and start using our services.<br />
<br />
Enjoy our services.<br />
<br />
    goonlineschool.com Team<br />

    <a href="/profile/profile">Click Here to go in profile area</a>
    </div>

