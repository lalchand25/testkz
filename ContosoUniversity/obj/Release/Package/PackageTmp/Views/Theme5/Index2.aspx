@model OLProject.Models.tb_QuizMaster>" 


	Index



     <h2>Quiz Detail</h2>
      <table style="width: 100%;">
 <tr>
              <td colspan="4" align="right"><a href="javascript:OpenPopup('/quizeditor/create/');" id='contract' runat='server' > <img src="@Url.Content("~/siteImages/create.png")" border="0" alt="edit" style="width: 74px;height: 28px;" /></a></td>
            </tr>
 <tr>
              <td colspan="4" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr> 
        
   @ if (Model != null)
      {  
          
                <tr>
                <td>
                    <strong>Quiz Heading:</strong></td>
                <td colspan="3">
                   <h3> @ Model.QuizHeading</h3></td>
                
                     
            </tr>
           
          
      <tr>
                <td>
                    <strong>Course Name:</strong></td>
                <td>
                    @ Model.CourseId</td>
                <td>
                    &nbsp;</td>
            
            <td>
                    &nbsp;</td>
            </tr>
         
       
    


       <tr>
                <td>
                    <strong>Quiz Description:</strong></td>
                <td colspan="3">
                    @ Model.QuizDesc</td>
                
                     
            </tr>
        
      <tr>
                <td>
                    <strong>IF Pass:</strong></td>
                <td colspan="3">
                    @ Model.IfPass</td>
                
                     
            </tr>
         <tr>
                <td>
                    <strong>If Fail:</strong></td>
                <td colspan="3">
                    @ Model.IfFail</td>
         
            </tr>

                <tr>
                <td>
                    <strong>Random Order:</strong></td>
                <td>
                    @ Model.RandomOrder</td>
                <td>
                    <strong>Show Correct Ans:</strong></td>
            
            <td>
                    @ Model.ShowCorrectAns</td>
            </tr>
      
         
        
         
          
                 <tr>
                <td>
                    <strong>Quiz Passing Score:</strong></td>
                <td>
                    @ Model.QuizPassingScore</td>
                <td>
                    &nbsp;</td>
            <td>
                    &nbsp;</td>
            </tr>
      
       
         
          
                 <tr>
                <td colspan="4">
                    <table style="width:100%;">
                     <tr>
              <td colspan="9" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>   
            <tr>
                            <th style="text-align: left">
                                &nbsp;</th>
                            <th style="text-align: left">
                                &nbsp;</th>
                            <th style="text-align: left">&nbsp;</th>
                            <th style="text-align: left">&nbsp;</th>
                            <th style="text-align: left">&nbsp;</th>
                           
                            
        <th><a href="javascript:OpenPopup('/mc/create/');" id='A4' runat='server' > <img src="../../siteImages/mc.png" border="0" alt="edit" style="width: 110px;height: 31px;" /></a></th>
       <th><a href="javascript:OpenPopup('/mCorrect/create/');" id='A1' runat='server' > <img src="../../siteImages/mcorrect.png" border="0" alt="edit" style="width: 110px;height: 31px;" /></a></th>
       <th><a href="javascript:OpenPopup('/truefalse/create/');" id='A2' runat='server' > <img src="../../siteImages/truefalse.png" border="0" alt="edit" style="width: 110px;height: 31px;" /></a></th>
       <th><a href="javascript:OpenPopup('/imgchoice/create/');" id='A3' runat='server' > <img src="../../siteImages/imgchoice.png" border="0" alt="edit" style="width: 110px;height: 31px;" /></a></th>

                        </tr>
                 <td colspan="9" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
        <tr>
                            <th style="text-align: left">
                                Image</th>
                            <th style="text-align: left">
                                Description</th>
                            <th style="text-align: left">Ans-1</th>
                            <th style="text-align: left">Ans-2</th>
                            <th style="text-align: left">Ans-3</th>
                            <th style="text-align: left">Ans-4</th>
                            <th>Answer</th>
                            <th>Edit</th>
                            <th>Delete</th>

                        </tr>
                         <tr>
              <td colspan="9" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>     @Html.Raw(ViewData["data"]
                    </table>
                     </td>
            </tr>

          }
      else
      { 
      
      <h3>Please create quiz first</h3>
      }
          <tr>
              <td colspan="4" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>  
        
         
          
                 <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
      
                 </table>
            
     


