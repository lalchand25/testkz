@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/QuizSecurity.Master" Inherits="System.Web.Mvc.ViewPage" 


	@Session["projectmetatags"]




    <h2>Quiz - Multiple Correct</h2>
    
   
             <table style="width:100%;">
             <tr>
              <td colspan="9" align="right"><a href="javascript:OpenPopup1('/mc/create/');" id='contract' runat='server' > <img src="@Url.Content("~/siteImages/create.png")" border="0" alt="edit" style="width: 74px;height: 28px;" /></a></td>
            </tr>

                     <tr>
              <td colspan="9" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
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

      

    
        
   
    

      
      
         
        
         
           
            
     


