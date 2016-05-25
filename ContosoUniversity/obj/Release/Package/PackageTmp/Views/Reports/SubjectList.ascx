@@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" 
 @Html.DropDownList("SubjectId", (SelectList)ViewData["SubjectList"], "Select", new { style = "width: 200px;Height:25px", onchange = "UpdateClassList();" })
  
