﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/profileMaster.Master"    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  <%= Session["projectmetatags"]%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Custom-Jquiery/js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../Custom-Jquiery/js/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
          $(document).ready(function () {
              $("#accordion").accordion();
          });

          $(function () 
          {
              $("#tabs").tabs();
          });

          $("#someParentOfA").delegate("#someA", "click", function(){

});

          $.fx.speeds._default = 500;
          $(function () {
              $("#dialog").dialog({
                  autoOpen: false,
                  show: "blind",
                  hide: "explode",
                  height: 320,
                  width: 700,
                  modal: true

              });
            <%=ViewData["script"]%>
         
              $("#opener").click(function (id) {
                  LoadData(id);
                  $("#dialog").dialog("open");


                  return false;
              });
          });

   
     function UpdateTaskList()
     {
         destElement = document.getElementById("moduleid");
       
        id= destElement.value
     
           var url = '/task/tasklist/' +id;
        
        $("#tasklistResult").load(url);
     
       

    }

$(function() {

    $( "#dialog-confirm" ).dialog({
        resizable: false,
        height:140,
        modal: true,
        buttons: {
            "Yes": function() {
                //Function call to commit to database
            },
            "No": function() {
                $( this ).dialog( "close" );
            }
        }
    });
});





    </script>
      <h2><%= Session["menutaskname"]%></h2>
    <table border="0" style="width: 100%" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 90%">
                Select Module:
                <%=Html.DropDownList("moduleid", (SelectList)ViewData["modulelist"],"Select", new {style = "width: 140px;", onchange = "UpdateTaskList();" })%>
            </td>
            <td style="width: 10%" align="center">
                <img src="<%=Url.Content("~/siteImages/new.png")%>" border="0" alt="edit" style="width: 44px;
                    height: 44px;" />
                <br />
                <%= Html.ActionLink("Create New", "Create") %>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="tasklistResult" title="Inner Container">
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
