@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<OLProject.Models.tb_WebMasterInfo>" 


	@Session["projectmetatags"]




 <div id="body-text"> 
 <div id="contactus"> 
 <div class="form">
 @Html.Raw(ViewData["pagedescription"]
 <br /> <br /> <br />


   <form runat="server" method="post" id="form1">

  @ if (ViewData["msg1"] == null)
     { 
    <h2>Intimate On Error - Area</h2>

    @using (Html.BeginForm())
       {
        @Html.ValidationSummary(true)
             Email Id :
            
            <div class="editor-field">
                @Html.TextBoxFor(model => model.EmailId, new { style = "width:350px;" })
                @Html.ValidationMessageFor(model => model.EmailId)
            </div>
            
            <div class="editor-label">
              Name:
            </div>
            <div class="editor-field">
                @Html.TextBoxFor(model => model.FirstName, new { style = "width:350px;" })
                @Html.ValidationMessageFor(model => model.FirstName)
            </div>
             
            <div class="editor-label">
               Error Description
            </div>
            <div class="editor-field">
                @Html.TextAreaFor(model => model.Comments, new { style = "width:600px;Height:100px" })
                @Html.ValidationMessageFor(model => model.Comments)
            </div>

            <div class="editor-label">
               Image of ERROR:
            </div>
                     <div class="editor-field">
              <asp:FileUpload ID="FileUpload10" runat="server" class="multi" accept="png|jpg|gif" />
            </div>
            <br />
            <br />
            <p>
                 <input type="image" src="../../siteimages/submit.png" /><br />
            </p>
        

    @ } 
   
 }
     else
     { 

     <h1> Thanks for contacting us..</h1>
   }
    </form>
    </div>


    
  <div class="map">
   @Html.Raw(ViewData["PageLeftData"]
  </div>


     </div>


    

    </div>


