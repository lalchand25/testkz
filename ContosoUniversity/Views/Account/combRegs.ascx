<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<lunchpakcerprj.Models.tb_UserMaster>" %>
<%--<script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>--%>

<script type="text/javascript">
    function UpdateCatList() {
        destElement = document.getElementById("CountryID");
        id = destElement.value
        var url = '/VendorMaster/statelist/' + id;

        $("#tasklistResult").load(url);
    }

</script>
<script type="text/javascript" src="../../Jquery_Date/jquery-1.5.1.js"></script>
<script type="text/javascript" src="../../Jquery_Date/jquery.ui.core.js"></script>
<script type="text/javascript" src="../../Jquery_Date/jquery.ui.widget.js"></script>
<script type="text/javascript" src="../../Jquery_Date/jquery.ui.datepicker.js"></script>
<link type="text/css" href="../../Jquery_Date/themes/base/jquery.ui.all.css" rel="stylesheet" />
<script type="text/javascript">
    $(function () {
        $("#ArrivalDate").datepicker({
            changeMonth: true,
            changeYear: true
        });
    });
</script>

<style type="text/css">
    #FirstName
    {
        width: 250px;
    }

    #LastName
    {
        width: 250px;
    }

    #Address
    {
        width: 250px;
    }

    #City
    {
        width: 250px;
    }

    #ContactNo
    {
        width: 250px;
    }

    #UserPassword
    {
        width: 250px;
    }

    #ZipCode
    {
        width: 250px;
    }

    #Phone
    {
        width: 250px;
    }

    #EmailID
    {
        width: 250px;
    }

    #ConfirmPassword
    {
        width: 250px;
    }

    #UserAddress
    {
        width: 250px;
    }

    #WorkAddress
    {
        width: 250px;
    }

    #WorkCity
    {
        width: 250px;
    }

    #WorkZipcode
    {
        width: 250px;
    }

    #WorkContact
    {
        width: 250px;
    }

    #BusinessName
    {
        width: 250px;
    }
</style>


<div class="sidebar_right">
    <h2>Register & Subscribe 1/2 </h2>

    <form id="Form1" method="post" runat="server">
        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>
        <fieldset>
            <legend></legend>
            <div class="row">
                  <div class="col-lg-1 col-md-1 col-sm-1">
                    </div>
                <div class="col-lg-11 col-md-11 col-sm-11">


                    <table width="100%">
                        <tr>
                            <td></td>
                            <td>First Name
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="editor-field">
                                    <%: Html.EditorFor(model => model.FirstName) %>
                                    <span class="style1">
                                        <%: Html.ValidationMessageFor(model => model.FirstName) %>
                                    </span>
                                </div>
                            </td>

                        </tr>

                        <tr>
                            <td></td>
                            <td>Last Name
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="editor-field">
                                    <%: Html.EditorFor(model => model.LastName) %>
                                    <span class="style1">
                                        <%: Html.ValidationMessageFor(model => model.LastName) %>
                                    </span>
                                </div>
                            </td>

                        </tr>

                        <tr>
                            <td></td>
                            <td>Email ID
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="editor-field">
                                    <%: Html.EditorFor(model => model.EmailID) %>
                                    <span class="style1">
                                        <%: Html.ValidationMessageFor(model => model.EmailID) %> </span>
                                </div>
                            </td>

                        </tr>

                        <tr>
                            <td></td>
                            <td>Password
                            </td>

                        </tr>

                        <tr>
                            <td></td>
                            <td>

                                <div class="editor-field">
                                    <%: Html.PasswordFor(model => model.UserPassword) %>
                                    <%: Html.ValidationMessageFor(model => model.UserPassword) %>
                                </div>
                            </td>

                        </tr>

                        <tr>
                            <td></td>
                            <td>Confirm Password
                            </td>

                        </tr>

                        <tr>
                            <td></td>
                            <td>

                                <div class="editor-field">
                                    <%: Html.PasswordFor(model => model.ConfirmPassword) %>
                                    <%: Html.ValidationMessageFor(model => model.ConfirmPassword) %>
                                </div>
                            </td>

                        </tr>

                        <tr>
                            <td colspan="2"><b></b>&nbsp; </td>
                        </tr>
                    </table>
                </div>
                </div>  
                <div class="row">
                    <div class="col-lg-1 col-md-1 col-sm-1">&nbsp;
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <table width="100%">
                            <tr>
                                <td colspan="2"><b>Billing Address  </b>&nbsp; </td>
                            </tr>


                            <tr>
                                <td></td>
                                <td>Home Address
                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="1">
                                    <div class="editor-field">
                                        <%: Html.EditorFor(model => model.UserAddress) %>
                                        <%: Html.ValidationMessageFor(model => model.UserAddress) %>
                                    </div>
                                    <%--    <%: Html.EditorFor(model => model.Country) %>
                    <%: Html.ValidationMessageFor(model => model.Country) %>--%>
              
                                </td>

                            </tr>


                            <tr>
                                <td></td>
                                <td>City
                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div class="editor-field">
                                        <div class="editor-field">
                                            <%: Html.DropDownList("cityID", (SelectList)ViewData["ddCityList"], "Select", new { style = "width: 250px;Height:25px" })%>
                                        </div>

                                    </div>

                                </td>

                            </tr>







                            <tr>
                                <td></td>
                                <td>Postal Code 

                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div class="editor-field">
                                        <%: Html.EditorFor(model => model.ZipCode) %>
                                        <%: Html.ValidationMessageFor(model => model.ZipCode) %>
                                    </div>

                                </td>

                            </tr>




                            <tr>
                                <td></td>
                                <td>Contact No
                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td>

                                    <div class="editor-field">
                                        <%: Html.EditorFor(model => model.ContactNo) %>
                                        <%: Html.ValidationMessageFor(model => model.ContactNo) %>
                                    </div>

                                </td>

                            </tr>


                            <tr>
                                <td></td>
                                <td></td>

                            </tr>
                            <tr>
                                <td></td>
                                <td></td>

                            </tr>


                            <tr>
                                <td></td>
                                <td><%--Image--%>
                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <%--   <asp:FileUpload ID="FileUpload3" runat="server" class="multi" accept="png" />
                    <br />
                    Formats : png,jpg,gif,jpeg. Maximum Size : 1MB--%>
            
                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td></td>

                            </tr>
                        </table>
                    </div>

                    <div class="col-lg-1 col-md-1 col-sm-1">&nbsp;
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4">

                        <table width="100%">
                    

                 


                      

                         
                            <tr>
                                <td colspan="2"><b>Work Address  </b>&nbsp; </td>
                            </tr>


                            <tr>

                                <td></td>
                                <td>Business Name</td>
                            </tr>
                            <tr>
                                <td></td>

                                <td>
                                    <div class="editor-field">
                                        <div class="editor-field">
                                            <%: Html.EditorFor(model => model.BusinessName) %>
                                            <span class="style1">
                                                <%: Html.ValidationMessageFor(model => model.BusinessName) %>
                                            </span>
                                        </div>


                                    </div>
                                </td>
                            </tr>


                            <tr>

                                <td></td>
                                <td>Address
                                </td>
                            </tr>
                            <tr>

                                <td></td>
                                <td>
                                    <div class="editor-field">
                                        <%: Html.EditorFor(model => model.WorkAddress) %>
                                        <%: Html.ValidationMessageFor(model => model.WorkAddress) %>
                                    </div>

                                </td>
                            </tr>







                            <tr>

                                <td></td>
                                <td>City
                                </td>
                            </tr>
                            <tr>

                                <td></td>
                                <td>

                                    <div class="editor-field">
                                        <div class="editor-field">
                                            <%: Html.DropDownList("WorkCity", (SelectList)ViewData["ddCityList"], "Select", new { style = "width: 250px;Height:25px" })%>
                                        </div>
                                </td>
                            </tr>




                            <tr>

                                <td></td>
                                <td>Postal Code
                                </td>
                            </tr>
                            <tr>

                                <td></td>
                                <td>
                                    <div class="editor-field">
                                        <%: Html.EditorFor(model => model.WorkZipcode) %>
                                        <%: Html.ValidationMessageFor(model => model.WorkZipcode) %>
                                    </div>
                                </td>
                            </tr>


                            <tr>

                                <td></td>
                                <td>Contact No.
                                </td>
                            </tr>
                            <tr>

                                <td></td>
                                <td>
                                    <div class="editor-field">
                                        <%: Html.EditorFor(model => model.WorkContact) %>
                                        <span class="style1">
                                            <%: Html.ValidationMessageFor(model => model.WorkContact) %>
                                        </span>
                                    </div>
                                </td>
                            </tr>


                            <tr>

                                <td></td>
                                <td>
                                    <%--  Notes--%>
                                </td>
                            </tr>
                            <tr>

                                <td></td>
                                <td>


                                    <%--  <div class="editor-field">
                    <%: Html.EditorFor(model => model.ContactNo ) %>
                    <%: Html.ValidationMessageFor(model => model.Note ) %>
                </div>--%>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>

                            </tr>
                        </table>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">&nbsp;
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1">
                        &nbsp;
                    </div>
                    <div class="col-lg-11 col-md-11 col-sm-11 col-xs-11">
                        <input type="image" src="../../siteimages/submit.png" />
                    </div>
                 
        </fieldset>
        <% } %>
    </form>
</div>
