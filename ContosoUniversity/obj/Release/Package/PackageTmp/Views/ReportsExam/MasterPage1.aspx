@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ReportsMaster.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 


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

       var url = '/reports/todayreport/?classid='+classid+'&reportid='+groupid+'&userid='+userid+'&subjectid='+id;
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
       
    
    <table style="width: 100%;" >
      
       <tr>
            <td colspan='6' bgcolor="#66CCFF" style="font-size: large">
                <strong>User Diary : Family&nbsp;: @Session["pmsusername"]</strong><br /></td>
          
        </tr>
        <tr  bgcolor='#DDEEEE'>
            <td  ><strong>Child&nbsp; </strong></td>
            <td style="width: 33%;"  >
                  @Html.DropDownList("userid", (SelectList)ViewData["userList"], "Select", new { title = "Select", maxlength = 150, style = "width: 240px;Height:25px" })
            </td>
         
          <td  ><strong>Subject</strong></td>
          <td style="width: 33%;"  >
                    
                    @Html.DropDownList("SubjectId", (SelectList)ViewData["SubjectList"], "Select", new { style = "width: 140px;Height:25px", onchange = "UpdateClassList();" })
            
            </td>
             <td  ><strong>Level</strong></td>
             <td style="width: 33%;"  >
             
                      <div id="tasklistResult" title="Inner Container">
                <select id="ClassesId" style = "width: 200px;Height:25px">
                    <option>Select</option>
                    </select></div> 
           
            </td>


        </tr>
       
        
         <tr>
            <td colspan='6' align='center' bgcolor='#DDEEEE'> 
                <table style="width:80%;">
                    <tr>
                       <td style="width:25%;" align='left' >@Html.RadioButton("groups",1) <strong><span style="font-size: medium">Today</span></strong></td>
                       <td style="width:25%;" align='left'>@Html.RadioButton("groups",2) <strong><span style="font-size: medium">This Week</span></strong></td>
                       <td style="width:25%;" align='left'>@Html.RadioButton("groups",3) <strong><span style="font-size: medium">This Month</span></strong></td>
                       <td style="width:25%;" align='left'>@Html.RadioButton("groups",4) <strong><span style="font-size: medium">All</span></strong></td>
                    </tr>
                  
                 <tr>
                       <td style="width:25%;" align='left'>@Html.RadioButton("groups",5) <strong><span style="font-size: medium">Yesterday</span></strong></td>
                       <td style="width:25%;" align='left'>@Html.RadioButton("groups",6) <strong><span style="font-size: medium">Last Week</span></strong></td>
                       <td style="width:25%;" align='left'>@Html.RadioButton("groups",7) <strong><span style="font-size: medium">Last Month</span></strong></td>
                       <td style="width:25%;" align='left'>@Html.RadioButton("groups",8) <strong><span style="font-size: medium">Period</span></strong></td>
                    </tr>
                  
                   
                </table>
                </td>
          
        </tr>
      
        
        
        <tr>
            <td colspan='6' align="right" bgcolor='#DDEEEE'>
               <a href="#" onclick="javascript:Generate();">
                 <input type="image" src="../../siteimages/submit.png" /><br /></a></td>
        </tr>

        <tr>
            <td colspan='6' align="right">
            
                 <div id="results1" title="Inner Container">
             </div> 

    </td>
          
        </tr>
        
    </table>
  
 


