<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/popadmin.Master" Inherits="System.Web.Mvc.ViewPage<GABA_281.Models.tb_InnerPages>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%=Session["projectmetatags"]%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script>
         window.onunload = function () {
             window.opener.location.href = window.opener.location;
         }
 </script>
   <h2> Create State </h2>
   <%if (ViewData["msgStatus"] == null)
     { %>
   <% Html.RenderPartial("base"); %>
    
   <%}
     else
     {%>
     <h1><%=ViewData["errorMsg"]%></h1>
  <%} %>

</asp:Content>
