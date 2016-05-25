<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/profileMaster.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

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
   
     function UpdateProjectList()
     {
        destElement = document.getElementById("userid");
        id= destElement.value
        var url = '/permissions/GetPermission/'+id;
        
        $("#Permissionlist").load(url);
     
       

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
    <form method="post" id="form1">
   <h2><%= Session["menutaskname"]%></h2>
    <table style="width: 100%;">
      
       
        <tr>
            <td style="width: 20%;">
               Select User:</td>
            <td style="width: 80%;">
                     <div class="editor-field">
                    <%=Html.DropDownList("userid", (SelectList)ViewData["userList"], "Select", new { title = "Select", maxlength = 150, style = "width: 240px;", onchange = "UpdateProjectList();" })%>
            </div>
            </td>
         
        </tr>
        <tr>
            <td  style="text-decoration: underline">
                </td>
               
            <td  >
                  <%=Html.CheckBox("selectall",false) %><b>Select All</b>
               </td>
          
        </tr>
        
        
        <tr>
            <td colspan="2" style="text-decoration: underline">
                <b>Existing Permissions:</b></td>
               </tr>

               <tr>
            <td colspan="2">
                 <div id="Permissionlist" title="Inner Container">
               
                </div>
               </td>
          
        </tr>
        
        
        <tr>
            <td>
                &nbsp;</td>
            <td>
                 
                
              <%--  <input type="submit" value="Create" /> --%> </td>
          
        </tr>
        
    </table>
  
</form>
</asp:Content>
