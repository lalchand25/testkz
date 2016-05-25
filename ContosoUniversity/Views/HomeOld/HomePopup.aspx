@@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" 

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Go Online School.com</title>
    <link href="../../content/style-home.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div class="back_main">
    <div class="entery_back_main">
        <div class="entery_back">
               <form id="Form1" action="/home/HomePopup" method="post"  runat="server">
            <h1>
                Welcome to </h1>
            <h2>
                Education made <span>Easy, Effortless,</span> Accessible!</h2>
            <div class="sign_in">


                <p>
                    <input name="emailid" class="y_email" type="text" /> </p>
                <p>
                    @Html.DropDownList("CountryID", (SelectList)ViewData["CountryList"], "Select", new { style = "width: 160px;Height:20px" })
                </p>
                      @Html.ValidationSummary(true, "Email ID is not correct") 
            </div>
            <div class="button_sign">
                <input type="image" src="../images/sign-up.png" />
              
            </div>
                 </form>
        </div>
    </div>
    </div>
</body>
</html>
