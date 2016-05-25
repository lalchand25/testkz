<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/admin.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GABA_281.Models.tb_InnerPages>>" %>
<%@ Import Namespace="GABA_281.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Session["projectmetatags"]%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <h2>State Information</h2>

  
     <table border="0" style="width: 100%" cellpadding="0" cellspacing="0">
        <tr>
              <td colspan="5" align="right" style="border-bottom: 1px solid #c2c2c2;">
                <a href='javascript:OpenPopup("/innerpage/create");'>
              <img src="<%=Url.Content("~/siteImages/create.png")%>" border="0" alt="edit" style="width: 50px;height: 50px;" /><br /> Create</a> </td>
            </tr>

        <tr>
            <td colspan="5" style="border-bottom: 1px solid #c2c2c2;">
                <img src="../../Images/clr.gif" alt="" width="1" height="15" />
            </td>
        </tr>
        
           <tr>   <td>  Icon    </td>  <td>   Name </td> 
           
           <td> Edit</td> <td>Delete</td></tr>
   
        <tr>
            <td colspan="5" style="border-bottom: 1px solid #c2c2c2;">
                <img src="../../Images/clr.gif" alt="" width="1" height="15" />
            </td>
        </tr>


   

    <% foreach (var item in Model) { %>
    
        <tr>
    
       <td align="center" width="5%">
                <img src="<%=Url.Content("~/Images/object_02.ico")%>" border="0" alt="edit" style="width: 22px;
                    height: 22px;" /> </td>
            
            <td>
                <%: item.PageHeader %>
            </td>
<%--              <td>

               <%=clsCommon.getCountryName(Convert.ToInt32(item.CountryID))%>
                
            </td>
--%>      
           
                <td align="center" width="5%">
               
                    <a href='javascript:OpenPopup("/innerpage/edit/<%=item.AutoId%>");'>
                    <img src="<%=Url.Content("~/SiteImages/edit.png") %>" border="0" alt="edit" style="width: 50px;
                        height: 50px;" /></a>
            </td>
            <td align="center" width="5%">
                  <a href='javascript:OpenPopup("/innerpage/delete/<%=item.AutoId%>");'>
                    <img src="<%=Url.Content("~/SiteImages/delete.png") %>" border="0" alt="Delete" style="width: 50px;
                        height: 50px;" /></a>
            </td>

   
        </tr>
    
    <% } %>

    </table>


</asp:Content>

