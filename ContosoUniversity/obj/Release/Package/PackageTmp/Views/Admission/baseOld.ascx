<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<wtfProject.Models.tb_ModuleMaster>" %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
         <table style="width: 100%;">
        
        <tr>
            <td valign="top" style="width: 30%">
                <div class="editor-label">
                    Module Name:
                </div>
            </td>
            <td valign="top" style="width: 70%">
                <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ModuleName) %>
                <%: Html.ValidationMessageFor(model => model.ModuleName) %>
            </div>
            </td>

            </tr>
                <tr>
            <td valign="top"  >
                URL:</td>
            <td valign="top"  >
                 <%: Html.TextBoxFor(model => model.Urlpath) %>
                <%: Html.ValidationMessageFor(model => model.Urlpath)%></td>

            </tr>


                <tr>
            <td valign="top"  >
                This is for Home Page:</td>
            <td valign="top"  >
                <div class="editor-field">
                <%: Html.CheckBox("ForHomePage")%>
            
            </div></td>

            </tr>


        <tr>
            <td valign="top"  >
                 Display Order No.:</td>
            <td valign="top" >
                <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Displayorderno, new  { Style="width:50px;" })%>
                <%: Html.ValidationMessageFor(model => model.Displayorderno) %>
            </div></td>

            </tr>
             <tr>
            <td valign="top" >
                <div class="editor-label">
                    Description
                </div>
            </td>
            <td  align="left">
                <div class="editor-field">
                   

                    <%: Html.TextArea("ModuleInstruction", new { style = "width:95%;Height:300px" })%>
                </div>
            </td>
        </tr>
       

        <tr>
    <td align="left" ></td>
    <td align="left">
            <%if (Convert.ToInt32( ViewData["buttonname"]) == 1)
              { %>
               <input type="image" src="../../siteimages/submit.png" /><br />
               <%} %>
             <%if (Convert.ToInt32( ViewData["buttonname"]) == 2)
              { %>
               <input type="image" src="../../siteimages/update.png" /><br />
               <%} %>
            <%if (Convert.ToInt32( ViewData["buttonname"]) == 3)
              { %>
                 <input type="image" src="../../siteimages/Delete.png" /><br />
               <%} %>
              

         <%} %>
           </td>
    </tr>         

       

            </table>
      
         