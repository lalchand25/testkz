@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<OLProject.Models.LogOnModel>" 


    @Session["projectmetatags"]


    <link href="../../Content/Login_files_asis/login.css" rel="stylesheet" type="text/css" />
    @using (Html.BeginForm())
       { 
    @Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.")
    @Html.Hidden("returnurl", ViewData["returnurl"])
    <div class="main">
        <div class="left_right">
        </div>
        <div class="center_body">
            <div class="login_wrap">
                <div class="logo">
                    <img src="../../Content/Login_files_asis/logo.png" />
                </div>
                <div class="vform">
                    <form>
                    <fieldset class="float">
                        <label>
                            Username</label>
                        @Html.TextBoxFor(m => m.UserName, new { style = "width:250px:Height:25px" })<br>
                        <label class="clear">
                            Password</label>
                        @Html.PasswordFor(m => m.Password, new { style = "width:250px:Height:52px" })<br>
                        <label class="clear">
                        </label>
                        <input id="tsubmit" class="cute_button" type="submit" style="clear: none;" value="Login"
                            s>
                        <img id="loadeux" src="loader.gif" width="25" height="25" style="display: none; position: relative;
                            top: 5px; left: 70px">
                    </fieldset>
                    <div class="clear">
                    </div>
                    <div style="text-align: center;">
                        <label>
                            <input type="checkbox" name="doRememberUsername">
                            Remember me |</label>
                        <label>
                            <a href="/login/forgotpassword/">Forgot password?</a></label>
                        <div class="clear">
                        </div>
                        <br>
                        <br>
                        <br>
                    </div>
                    </form>
                    <div class="get_started">
                        <a href="#">Don't have a login? Get Started!</a></div>
                </div>
                <div id="me_box">
                </div>
            </div>
        </div>
        <div class="left_right">
        </div>
    </div>
    }

