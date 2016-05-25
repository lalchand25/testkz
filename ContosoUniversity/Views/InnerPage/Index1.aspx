<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/home.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="GABA_281.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Session["projectmetatags"]%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%=ViewData["pagedata"] %>


</asp:Content>

