@model IEnumerable<OLProject.Models.LessonInformation>


	@Session["projectmetatags"]




    <h2>LessonList</h2>

    <table width="100%">
     <tr>
              <td colspan="4">
                  Total Records:@Html.Raw(ViewData["totalrecords"]    <br />
                  @Html.Raw(ViewData["pageLinks"] </td>
        </tr>

      

       <tr>
              <td colspan="4" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>
            
             <tr>
           
           
            <td>
                Lesson Name
            </td>
            <td>
                UnitN ame
            </td>
            <td>
                Class Name
            </td>
            <td>
                Subject Name
            </td>
        </tr>
          <tr>
              <td colspan="4" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>
            

    @ foreach (var item in Model) { 
    
        <tr>
           
            <td>
                @ item.LessonName 
            </td>

            <td>
                @ item.UnitName 
            </td>
            <td>
                @ item.ClassName 
            </td>
            <td>
                @ item.SubjectName 
            </td>
        </tr>
    
    @ } 

    </table>
 


