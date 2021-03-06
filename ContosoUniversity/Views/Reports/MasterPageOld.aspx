﻿@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ReportsMaster.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 


    MasterPage



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
            @Html.Raw(ViewData["script"]
         
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

    function Generate()
     {
       
       destElement = document.getElementById("SubjectId");
       id= destElement.value
       
       destElement1 = document.getElementById("userid");
       userid= destElement1.value
       
       destElement2 = document.getElementById("ClassesId");
       classid= destElement2.value

       
        var radios = document.getElementsByName('groups');
        for (var i = 0, length = radios.length; i < length; i++) {
        if (radios[i].checked) {
        groupid=radios[i].value;
        }
} 

       var url = '/reports/LearnHistoryReport/?classid='+classid+'&reportid='+groupid+'&userid='+userid+'&subjectid='+id;
       $("#results1").load(url);
     
       

    }

     function UpdateSubjectList()
     {
       userid = document.getElementById("userid");
       var url = '/Reports/SubjectList/'+userid.value;
      
        $("#tasklistResult5").load(url);
    }

     function UpdateClassList()
     {
       destElement = document.getElementById("SubjectId");
       userid = document.getElementById("userid");
       id= destElement.value
       var url = '/Reports/ClassList/' +id+"?StudentID="+userid.value;
      
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
       

       <br />
        
        <fieldset>

	  <legend>User Diary : Family&nbsp;:  @Session["pmsusername"]</legend>


       <table id="resultForm:result_table" class="result_table2" width="100%">

       <thead>
  <tr>
    <th width="3%">&nbsp;</th>
    <th width="10%">Child</th>
    <th width="20%"> @Html.DropDownList("userid", (SelectList)ViewData["userList"], "Select", new { title = "Select", maxlength = 150, style = "width: 240px;Height:25px", onchange = "UpdateSubjectList();" })</th>
    <th width="4%">&nbsp;</th>
    <th width="10%">Subject</th>
    <th width="20%"> <div id="tasklistResult5" title="Inner Container">
                <select id="Select2" style = "width: 200px;Height:25px">
                    <option>Select</option>
                    </select></div> </th>
    <th width="3%">&nbsp;</th>
    <th width="10%">Level</th>
    <th width="20%">       <div id="tasklistResult" title="Inner Container">
                <select id="ClassesId" style = "width: 200px;Height:25px">
                    <option>Select</option>
                    </select></div> </th>
    
      
  </tr>
  </thead>

  <tbody>
         <tr class="even">
         
         	<td colspan="9">
            
            
            	<table id="Table1" class="result_table2" width="100%">
    <table id="Table2" class="result_table2" width="100%">
         <tbody>
         <tr class="even">
         
         	<td width="5%">&nbsp;</td>
            <td width="12%">@Html.RadioButton("groups",1) <strong><span style="font-size: medium">Today</span></strong></td>
            <td width="8%"><img src="../../images/today.png" width="50" height="50" /></td>
            <td width="3%">&nbsp;</td>
            <td width="12%">@Html.RadioButton("groups",2) <strong><span style="font-size: medium">This Week</span></strong></td>
            <td width="8%"><img src="../../images/thisweek.png" width="50" height="50" /></td>
            <td width="4%">&nbsp;</td>
            <td width="13%">@Html.RadioButton("groups",3) <strong><span style="font-size: medium">This Month</span></strong></td>
            <td width="8%"><img src="../../images/this_month.png" width="50" height="50" /></td>
            <td width="3%">&nbsp;</td>
            <td width="12%">@Html.RadioButton("groups",4) <strong><span style="font-size: medium">All</span></strong></td>
            <td width="8%"><img src="../../images/all.png" width="50" height="50" /></td>
            <td width="5%">&nbsp;</td>
         </tr>
         
         
          <tr class="even">
         
         	<td width="5%">&nbsp;</td>
            <td width="12%">@Html.RadioButton("groups",5) 
              <strong><span class="style1">Yesterday</span></strong></td>
            <td width="8%"><img src="../../images/Yesterday.png" width="50" height="50" /></td>
            <td width="3%">&nbsp;</td>
            <td width="12%">@Html.RadioButton("groups",6) 
            <strong><span style="font-size: medium">Last Week</span></strong></td>
            <td width="8%"><img src="../../images/lastweek.png" width="50" height="50" /></td>
            <td width="4%">&nbsp;</td>
            <td width="13%">@Html.RadioButton("groups",7) 
              <strong><span style="font-size: medium">Last Month</span></strong></td>
            <td width="8%"><img src="../../images/last_month.png" width="50" height="50" /></td>
            <td width="3%">&nbsp;</td>
            <td width="12%">@Html.RadioButton("groups",8) 
              <strong><span class="style1">Period</span></strong></td>
            <td width="8%"><img src="../../images/Period.png" width="50" height="50" /></td>
            <td width="5%">&nbsp;</td>
         </tr>
         
         <tr class="even">
         	<td colspan="11">&nbsp;</td>
            <td colspan="2">           
             <a href="#" onclick="javascript:Generate();">
                 <input type="image" src="../../images/submit2.png" /><br /></a>
            </td>
            </tr>
          </tbody></table>   
         <tr class="even">
         
         	<td colspan="9">
            
            
     <div id="results1" title="Inner Container">
             </div> 
          
          
          
           </td></tr></tbody>


       </table>
  
  </fieldset>
 


