@@ Control Language="C#"   Inherits="System.Web.Mvc.ViewUserControl<OLProject.Models.tb_QuizMaster>"   
 

<script src="../../FileUploadJquery/jquery-1.4.min.js" type="text/javascript"></script>
<script src="../../FileUploadJquery/jquery.MultiFile.pack.js" type="text/javascript"></script>


<link href="../../Content/style.css" rel="stylesheet" type="text/css" />
<script src="../../jscripts/tiny_mce/tiny_mce_src.js" type="text/javascript"></script>

<script type="text/javascript">
    tinyMCE.init({
        // General options
        mode: "textareas",
        theme: "advanced",
        plugins: "autolink,lists,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,wordcount,advlist,autosave",

        // Theme options
        theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
        theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
        theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
        theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: true,

        // Example content CSS (should be your site CSS)
        content_css: "css/content.css",

        // Drop lists for link/image/media/template dialogs
        template_external_list_url: "lists/template_list.js",
        external_link_list_url: "lists/link_list.js",
        external_image_list_url: "lists/image_list.js",
        media_external_list_url: "lists/media_list.js",

        // Style formats
        style_formats: [
			{ title: 'Bold text', inline: 'b' },
			{ title: 'Red text', inline: 'span', styles: { color: '#ff0000'} },
			{ title: 'Red header', block: 'h1', styles: { color: '#ff0000'} },
			{ title: 'Example 1', inline: 'span', classes: 'example1' },
			{ title: 'Example 2', inline: 'span', classes: 'example2' },
			{ title: 'Table styles' },
			{ title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
		],

        // Replace values for the template plugin
        template_replace_values: {
            username: "Some User",
            staffid: "991234"
        }
    });
</script>
<!-- /TinyMCE -->

<script src="../../jscripts/jquery-1.5.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
    window.onunload = function () {
        window.opener.location.href = window.opener.location;
    }



    
          $(document).ready(function () {
              $("#accordion").accordion();
          });

          $(function () 
          {
              $("#tabs").tabs();
          });

          $("#someParentOfA").delegate("#someA", "click", function(){

});

          $.fx.speeds._default = 500;
          $(function () {
              $("#dialog").dialog({
                  autoOpen: false,
                  show: "blind",
                  hide: "explode",
                  height: 320,
                  width: 700,
                  modal: true

              });
            @Html.Raw(ViewData["script"]
         
              $("#opener").click(function (id) {
                  LoadData(id);
                  $("#dialog").dialog("open");


                  return false;
              });
          });

   
     function UpdateClassList()
     {
       destElement = document.getElementById("SubjectId");
       id= destElement.value
       var url = '/TestMaster/ClassList/' +id;
      
        $("#tasklistResult").load(url);
    }
     


$(function() {

    $( "#dialog-confirm" ).dialog({
        resizable: false,
        height:140,
        modal: true,
        buttons: {
            "Yes": function() {
                //Function call to commit to database
            },
            "No": function() {
                $( this ).dialog( "close" );
            }
        }
    });
});
</script>
<script>
    window.onunload = function () {
        window.opener.location.href = window.opener.location;
    }

 </script>
  
 

 <br /><b>@Html.Raw(ViewData["lstatus"]</b><br />
 <form   method="post" runat="server" enctype="multipart/form-data"> 
    <table width="95%" align="center" >
    <tr>
    <td style="Width:20%">
     </td>
    <td style="Width:80%" class="style1">
        </td>
    
    </tr>

    @using (Html.BeginForm()) {
        @Html.ValidationSummary(true) 

                     
          <tr>
    <td>   <b>  
               Name:
           </b>
            
    </td>
            <td>   
                @Html.TextBoxFor(model => model.QuizHeading, new { Style = "Width:300px" })
                @Html.ValidationMessageFor(model => model.QuizHeading)
          </td>
           </tr>

              
           <tr>
    <td>   <div class="editor-label">
                <strong>Introduction Page:</strong>
            </div></td>
            <td>   
            <div class="editor-field">
                @Html.TextAreaFor(model => model.QuizDesc, new { Style = "Width:100%" }) 
                @Html.ValidationMessageFor(model => model.QuizDesc)
            </div></td>
           </tr>
              <tr>
    <td>   <div class="editor-label">
                <strong>Show Introduction Page: 
            </strong> 
            </div></td>
            <td>    <div class="editor-field">
                @Html.CheckBox("ShowIntroPage",false) 
                @Html.ValidationMessageFor(model => model.ShowIntroPage) 
            </div></td>
           </tr>
           
              <tr>
    <td>   <div class="editor-label">
                <strong>Random Order:</strong>
            </div></td>
            <td>    <div class="editor-field">
                @Html.CheckBox("RandomOrder",false)
                @Html.ValidationMessageFor(model => model.RandomOrder) 
            </div></td>
           </tr>
            
           
              <tr>
    <td>  <div class="editor-label">
                 <em><strong>Test Passing Score:
            </strong></em>
            </div></td>
            <td>   <div class="editor-field">
                @Html.TextBoxFor(model => model.QuizPassingScore) 
                @Html.ValidationMessageFor(model => model.QuizPassingScore)
            </div></td>
           </tr>
            
           
            
            
           
              <tr>
    <td>   <div class="editor-label">
                 <strong>If Pass :
            </strong>
            </div></td>
            <td>  <div class="editor-field">
                @Html.TextAreaFor(model => model.IfPass, new { Style = "Width:100%" }) 
                @Html.ValidationMessageFor(model => model.IfPass) 
            </div></td>
           </tr>
            
           
              <tr>
    <td>    <div class="editor-label">
                 <strong>If Fail:
            </strong>
            </div></td>
            <td>  <div class="editor-field">
                @Html.TextAreaFor(model => model.IfFail, new { Style = "Width:100%" }) 
                @Html.ValidationMessageFor(model => model.IfFail) 
            </div></td>
           </tr>
           
      
        
                   <tr>
    <td>   &nbsp;</td>
    <td> 
            @if (Convert.ToInt32( ViewData["buttonname"]) == 1)
              { 
               <input type="submit" value="Save" /><br />
               }
             @if (Convert.ToInt32( ViewData["buttonname"]) == 2)
              { 
               <input type="submit" value="Update" /><br />
               }
            @if (Convert.ToInt32( ViewData["buttonname"]) == 3)
              { 
               <input type="submit" value="Delete" /><br />
               }
              

         }
     @Html.Raw(ViewData["errorMsg"] 
  
  
            
          
         
            
            
            
            </td>
    </tr>
         
            
            
            
            </table>

    
  </form> 
