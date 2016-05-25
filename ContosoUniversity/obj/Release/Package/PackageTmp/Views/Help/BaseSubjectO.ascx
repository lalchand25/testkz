@model OLProject.Models.tb_Help>" 
  
   
    <form id="Form1"   method="post"  runat="server" > 
    <table width="95%" align="center">
    @using (Html.BeginForm())
       {
         @Html.ValidationSummary(true)

          <tr><td align="left" style="Width:100%"><b>Subject</b></td></tr> 

    <tr> <td>
       @Html.TextBoxFor(model => model.Subject, new { Style = "Width:50%;" })
   <b><span style="color:Red"> @Html.ValidationMessageFor(model => model.Subject)</span></b></td>
    </tr> 


     <tr><td align="left"><b>Description</b></td></tr> 
    
    <tr> <td>@Html.TextAreaFor(model => model.Description, new { Style = "Width:90%;Height:100px" })
   <b><span style="color:Red"> @Html.ValidationMessageFor(model => model.Description)</span></b></td>
    </tr>
                       
        <tr>
    <td align="left">
         <b>Image Path</b></td></tr> 

     <tr> 
    <td align="left">
         <div>
               <asp:FileUpload ID="FileUpload0" runat="server" class="multi" accept="png" /> <br />
             Formats : png,jpg,gif,jpeg. 
             Maximum Size : 2MB
             </div>
             </td>
    </tr>
              
       
                      
 
        <tr>
     
    <td align="left"><br /><br /><br />
            @if (Convert.ToInt32( ViewData["buttonname"]) == 1)
              { 
               <input type="image" src="../../siteimages/submit.png" /><br />
               }
             @if (Convert.ToInt32( ViewData["buttonname"]) == 2)
              { 
               <input type="image" src="../../siteimages/update.png" /><br />
               }
            @if (Convert.ToInt32( ViewData["buttonname"]) == 3)
              { 
                 <input type="image" src="../../siteimages/Delete.png" /><br />
               }
              

         }
  </td>
    </tr>                  
            </table>
    </form>    