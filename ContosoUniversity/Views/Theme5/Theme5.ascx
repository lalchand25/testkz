@model OLProject.Models.tb_LessionMasterSlides>" 
<link href="../../content/NewStyle.css" rel="stylesheet" type="text/css" />
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

    function UpdateList1()
     {
         destElement = document.getElementById("UploadTypeId1");
         id= destElement.value;
         
          var div6 = document.getElementById("div6");
          var div7 = document.getElementById("div7");
          var div8 = document.getElementById("div8");
          var div9 = document.getElementById("div9");
        
         
          
           div6.style.display = 'none';
           div7.style.display = 'none';
           div8.style.display = 'none';
           div9.style.display = 'none';
         
       

        if (id==2)
       {
         div6.style.display = 'block'; //Picture
       }

       if (id==3)
       {
         div7.style.display = 'block'; //Video
       }
       if (id==4)
       {
         div8.style.display = 'block'; //Mp3
       }
       if (id==5)
       {
         div9.style.display = 'block'; //flash
       }
       }

     function UpdateList()
     {
         destElement = document.getElementById("UploadTypeId");
        id= destElement.value;
         
          var div2 = document.getElementById("div2");
          var div3 = document.getElementById("div3");
          var div4 = document.getElementById("div4");
          var div5 = document.getElementById("div5");
        
         
          
           div2.style.display = 'none';
           div3.style.display = 'none';
           div4.style.display = 'none';
           div5.style.display = 'none';
         
       

        if (id==2)
       {
         div2.style.display = 'block'; //Picture
       }

       if (id==3)
       {
         div3.style.display = 'block'; //Video
       }
       if (id==4)
       {
         div4.style.display = 'block'; //Mp3
       }
       if (id==5)
       {
         div5.style.display = 'block'; //flash
       }
      
      
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
 
<script type= "text/javascript">
    onload = function () {

        id =@Html.Raw(ViewData["uploadtypeid"] 
        var div2 = document.getElementById("div2");
        var div3 = document.getElementById("div3");
        var div4 = document.getElementById("div4");
        var div5 = document.getElementById("div5");
        div2.style.display = 'none';
        div3.style.display = 'none';
        div4.style.display = 'none';
        div5.style.display = 'none';
        if (id == 2) {
            div2.style.display = 'block'; //Picture
        }

        if (id == 3) {
            div3.style.display = 'block'; //Video
        }
        if (id == 4) {
            div4.style.display = 'block'; //Mp3
        }
        if (id == 5) {
            div5.style.display = 'block'; //flash
        }



        id =@Html.Raw(ViewData["uploadtypeid1"] 
        var div6 = document.getElementById("div6");
        var div7 = document.getElementById("div7");
        var div8 = document.getElementById("div8");
        var div9 = document.getElementById("div9");
        div6.style.display = 'none';
        div7.style.display = 'none';
        div8.style.display = 'none';
        div9.style.display = 'none';
        if (id == 2) {
            div6.style.display = 'block'; //Picture
        }

        if (id == 3) {
            div7.style.display = 'block'; //Video
        }
        if (id == 4) {
            div8.style.display = 'block'; //Mp3
        }
        if (id == 5) {
            div9.style.display = 'block'; //flash
        }

      

    }
    
</script>
 
 <style type="text/css">
     .style1
     {
         background-color: #66CCFF;
     }
     .style2
     {
         font-weight: bold;
         background-color: #66CCFF;
     }
 </style>
 
 <form  method="post" id="createProp" runat="server">
    
    @using (Html.BeginForm())
       {
        @Html.ValidationSummary(true)
        <table width="100%">
        <tr>
        <td width="20%">  <b>Slide Name</b> </td>
        <td width="80%" colspan='2'> @Html.TextBoxFor(model => model.SlideDescription, new  { style="width:350px" })
                <b> @Html.ValidationMessageFor(model => model.SlideDescription)</b></td>
        </tr>
        
        <tr>
        <td> <b>Description</b>   </td>
        <td colspan='2'>  @Html.TextAreaFor(model => model.ImageDescription)
             <b> @Html.ValidationMessageFor(model => model.ImageDescription)</b>
                 </td>
        </tr>

        <tr>
        <td class="style2">Upload Type </td>
        <td class="style1">Select File</td></tr>
        
        <tr>
        <td valign='top'>@Html.DropDownList("UploadTypeId", (SelectList)ViewData["Typelist"], "Select", new { style = "width: 140px;", onchange = "UpdateList();" })</td>
        <td>@Html.TextBoxFor(model => model.ImagePath) <asp:FileUpload ID="FileUpload0" runat="server" class="multi" accept="png" /><br />Formats : png,jpg,gif,jpeg. Maximum Size : 100kb  
        </td>
        </tr>
        <tr>
        <td valign='top'>@Html.DropDownList("UploadTypeId1", (SelectList)ViewData["Typelist"], "Select", new { style = "width: 140px;", onchange = "UpdateList();" })</td>
        <td>@Html.TextBoxFor(model => model.ImagePath1) <asp:FileUpload ID="FileUpload1" runat="server" class="multi" accept="png" /><br />Formats : png,jpg,gif,jpeg. Maximum Size : 100kb  
        </td>
       </tr>

         <tr>
        <td valign='top'>@Html.DropDownList("UploadTypeId2", (SelectList)ViewData["Typelist"], "Select", new { style = "width: 140px;", onchange = "UpdateList();" })</td>
        <td>@Html.TextBoxFor(model => model.ImagePath2) <asp:FileUpload ID="FileUpload2" runat="server" class="multi" accept="png" /><br />Formats : png,jpg,gif,jpeg. Maximum Size : 100kb  
        </td>
       </tr>

         
  <tr>
        <td valign='top'>@Html.DropDownList("UploadTypeId3", (SelectList)ViewData["Typelist"], "Select", new { style = "width: 140px;", onchange = "UpdateList();" })</td>
        <td>@Html.TextBoxFor(model => model.ImagePath3) <asp:FileUpload ID="FileUpload3" runat="server" class="multi" accept="png" /><br />Formats : png,jpg,gif,jpeg. Maximum Size : 100kb  
        </td>
       </tr>

      
    
       
  <tr>
        <td valign='top'>@Html.DropDownList("UploadTypeId4", (SelectList)ViewData["Typelist"], "Select", new { style = "width: 140px;", onchange = "UpdateList();" })</td>
        <td>@Html.TextBoxFor(model => model.ImagePath4) <asp:FileUpload ID="FileUpload4" runat="server" class="multi" accept="png" /><br />Formats : png,jpg,gif,jpeg. Maximum Size : 100kb  
        </td>
       </tr>


    

    
        
     


       
    
     
     



                <tr>
        <td><b>  <b>  Display Order</b> </b></td>
        <td>     @Html.TextBoxFor(model => model.DispOrder, new { Style = "Width:100px" })
                   <b> @Html.ValidationMessageFor(model => model.DispOrder)</b></td></tr>
         
               
             <tr>
        <td></td>
        <td> <div class="editor-label">
            @if (Convert.ToInt32( ViewData["buttonname"]) == 1)
              { 
               <input type="image" src="../../siteimages/submit.png" /><br />
               }
             @if (Convert.ToInt32( ViewData["buttonname"]) == 2)
              { 
               <input type="image" src="../../siteimages/Update.png" /><br />
               }
            @if (Convert.ToInt32( ViewData["buttonname"]) == 3)
              { 
             <input type="image" src="../../siteimages/Delete.png" /><br />
               }
              

        
   
            @Html.Raw(ViewData["errorMsg"] </td></tr>
          
         
     </table>
      }
    </form>
   