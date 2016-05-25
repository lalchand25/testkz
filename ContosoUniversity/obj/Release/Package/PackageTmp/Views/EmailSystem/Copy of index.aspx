@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/profileMaster.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GCL_PMS_MVC.Models.tb_emailsDescription>


	index



   
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
            @Html.Raw(ViewData["script"]
         
              $("#opener").click(function (id) {
                  LoadData(id);
                  $("#dialog").dialog("open");


                  return false;
              });
          });

   
     function UpdateTaskList()
     {
         destElement = document.getElementById("pageid");
       
        id= destElement.value
   
           var url = '/pages/detail/' +id;
        
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

   <h2>Email System for websites</h2>
   <br />
    <table width="706" border="0" cellspacing="0" cellpadding="0"> 
    
    
       <tr>
          <td width="100%" colspan="6" align="right"  >
             
              @Html.ActionLink("Create New", "Create") </td>
              </tr>
            <tr>
              <td colspan="6" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>  

                  <tr>
           <th width="25%" align="left">
               Module Name / Order
            </th>
          <th width="10%" align="left">
               Group
            </th>
             <th width="50%" align="left">
                Subject / Email Body
            </th>
            
            <th width="5%" align="center">
                Edit
            </th>
            <th width="5%" align="center">
                Delete
            </th>
          <th width="5%" align="center">
                Test
            </th>
         

                  
        </tr>
         <tr>
              <td colspan="6" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>  
   
    @ foreach (var item in Model) { 
    
        <tr>
            
            <td valign="top">
                @ item.EmailModule_   - @ item.SetModuleID  
                
            </td>
          <td valign="top">
          - @ item.GroupId  
                
            </td>
            <td valign="top">
                <b>@ item.EmailSubject</b><br />
                @item.Description
            </td>
           
              <td align="center" valign="top"> 
               <a href="@ Url.Action("Edit", "emailsystem",new {id=item.Autoid})"><img src="@Url.Content("~/SiteImages/edit.png") "      border="0" alt="edit" style="width:16px;Height:16px;"/></a>
                </td>
              <td align="center" valign="top"> 
               <a href="@ Url.Action("Delete", "emailsystem",new {id=item.Autoid})"><img src="@Url.Content("~/SiteImages/delete.png") " border="0"   alt="Delete" style="width:16px;Height:16px;"/></a>
            </td>
            
               <td align="center" valign="top"> 
               <a href="@ Url.Action("sendEmail", "emailsystem",new {id=item.SetModuleID})"><img src="@Url.Content("~/SiteImages/email.png") "      border="0" alt="edit" style="width:16px;Height:16px;"/></a>
                </td>
          

        </tr>
    
    @ } 
     <tr>
              <td colspan="6" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr> 
    </table>
 



