@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<OLProject.Models.tb_UserMaster>" 


	Index



<br />
<br />
       <div id="body-text">
<div class="left">

    @using (Html.BeginForm()) {
        @Html.ValidationSummary(true) 

        <h2>Register With us</h2> 
<br />

              
            <div class="editor-label">
               Category:
            </div>
            <div class="editor-field">
              @Html.DropDownList("userGroupId", (SelectList)ViewData["catlist"], "Select", new { style = "width: 140px;" })
            </div>
            <div class="editor-label">
                Email ID :
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(model => model.EmailID, new { style="width:250px" })
                @Html.ValidationMessageFor(model => model.EmailID) 
            </div>
            
            <div class="editor-label">
                User Name:
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(model => model.UserName, new { style = "width:250px" })
                @Html.ValidationMessageFor(model => model.UserName) 
            </div>
            
            <div class="editor-label">
                Password:
            </div>
            <div class="editor-field">
                @Html.PasswordFor(model => model.UserPassword) 
                @Html.ValidationMessageFor(model => model.UserPassword) 
            </div>
            
            <div class="editor-label">
                Confirm Password:
            </div>
            <div class="editor-field">
                @Html.PasswordFor(model => model.ConfirmPassword) 
                @Html.ValidationMessageFor(model => model.ConfirmPassword) 
            </div>
            
            <div class="editor-label">
                Display Name:
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(model => model.DisplayName, new { style = "width:250px" })
                @Html.ValidationMessageFor(model => model.DisplayName) 
            </div>
            
            <div class="editor-label">
                Mobile No:
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(model => model.MobileNo, new { style = "width:150px" })
                @Html.ValidationMessageFor(model => model.MobileNo) 
            </div>
            
            <div class="editor-label">
                Address:
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(model => model.Address, new { style = "width:250px" })
                @Html.ValidationMessageFor(model => model.Address) 
            </div>
            
             
              
            <p>
                <input type="submit" value="Register With us" />
            </p>
    
    @ } 

    
    </div>
    </div>


