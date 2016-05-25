<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GABA_281.Models.tb_InnerPages>" %>
   <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
  
          <div class="editor-label">
            Select Page Name
        </div>
        <div class="editor-field">
            <%=Html.DropDownList("PageId", (SelectList)ViewData["countrylist"], "Select", new { style = "width: 140px;" })%>
        </div>

    
        <div class="editor-label">
           Header
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.PageHeader, new  { Style="Width:250px" })%>
            <%: Html.ValidationMessageFor(model => model.PageHeader)%>
        </div>
          <div class="editor-label">
           Description
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.PageDesc, new  { Style="Width:350px;Height:300px" })%>
           
        </div>
    <br />
<br />
<br />

      
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
         
    
    <% } %>
    

