@model OLProject.Models.tb_LessionMasterSlides>" 
<link href="../../content/NewStyle.css" rel="stylesheet" type="text/css" />
    <script src="../../jscripts/tiny_mce/tiny_mce_src.js" type="text/javascript"></script>
<script type="text/javascript">
    tinyMCE.init({
        // General options
        mode: "textareas",
        theme: "advanced",
        plugins: "autolink,lists,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,wordcount,advlist,autosave",

        // Theme options
        paste_retain_style_properties: "margin, padding, width, height, font-size, font-weight, font-family, color, text-align, ul, ol, li, text-decoration, border, background, float, display",
   
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
 
 <form  method="post" id="createProp" runat="server">
    
    @using (Html.BeginForm())
       {
        @Html.ValidationSummary(true)
        
    
          <br />
         <div class="editor-label">        <b>Slide Name</b> 
         </div> 
          <div class="editor-label">
               @Html.TextBoxFor(model => model.SlideDescription, new  { style="width:350px" })
                <b> @Html.ValidationMessageFor(model => model.SlideDescription)</b>
                </div>

            <br />
             <div class="editor-label">
                 <b>Description Other</b>   
    </div>
     <div class="editor-label">
                 @Html.TextAreaFor(model => model.ImageDescription)
             <b> @Html.ValidationMessageFor(model => model.ImageDescription)</b>
                 
                 </div>
 
                <br />
             <div class="editor-label">
                 <b>Description</b>   
    </div>
     <div class="editor-label">
                 @Html.TextAreaFor(model => model.Description2)
             <b> @Html.ValidationMessageFor(model => model.Description2)</b>
                 
                 </div>

 
    <div class="editor-label">
        <b> Upload Type </b>
        </div>
  
        <div class="editor-label">
            @Html.DropDownList("UploadTypeId", (SelectList)ViewData["Typelist"], "Select", new { style = "width: 140px;", onchange = "UpdateList();" })
        </div>

         <div id="div2" style="display:none;">
             <br />
               <div class="editor-label">
                     <b>Update Image</b> 
                     </div>
                
               <div class="editor-label">
                  @Html.TextBoxFor(model => model.ImagePath)  
               <asp:FileUpload ID="FileUpload0" runat="server" class="multi" accept="png" /><br /> 
              Formats : png,jpg,gif,jpeg. 
                Maximum Size : 100kb  
                </div>

            </div>
         <div id="div3" style="display:none;">  
         <br />
              <div class="editor-label">
               <b>Video Files</b>  
               </div>
                 <div class="editor-label">
                      @Html.TextBoxFor(model => model.VideoFiles)
                      <asp:FileUpload ID="FileUpload2" runat="server" class="multi" accept="mp3" /><br />
                        Formats : mp4. 
                        Maximum Size : 2MB  
                </div>
    </div>
         <div id="div4" style="display:none;">      
         <br />
  <div class="editor-label">
               <b> Mp3 Files</b></div>

  <div class="editor-label">
                 @Html.TextBoxFor(model => model.Mp3Files)  
               <asp:FileUpload ID="FileUpload1" runat="server" class="multi" accept="mp3" /><br />  
              Formats : mp3. 
                Maximum Size : 1MB  
                  
  </div>                
             </div>
         <div id="div5" style="display:none;">  
         <br />
              <div class="editor-label">          <b>Game Files</b>  </div>
                <div class="editor-label">
                 @Html.TextBoxFor(model => model.GameFiles)
                   <asp:FileUpload ID="FileUpload3" runat="server" class="multi" accept="SWF" /><br />
                        Formats : SWF 
                        Maximum Size : 2MB  
                 
             </div>
             </div>


        <div class="editor-label">
        <b> Upload Type </b>
        </div>
  
        <div class="editor-label">
            @Html.DropDownList("UploadTypeId1", (SelectList)ViewData["Typelist"], "Select", new { style = "width: 140px;", onchange = "UpdateList1();" })
        </div>

           <div id="div6" style="display:none;">
             <br />
               <div class="editor-label">
                     <b>Update Image</b> 
                     </div>
                
               <div class="editor-label">
                  @Html.TextBoxFor(model => model.ImagePath1) 
               <asp:FileUpload ID="FileUpload4" runat="server" class="multi" accept="png" /><br /> 
              Formats : png,jpg,gif,jpeg. 
                Maximum Size : 100kb  
                </div>

            </div>
         <div id="div7" style="display:none;">  
         <br />
              <div class="editor-label">
               <b>Video Files</b>  
               </div>
                 <div class="editor-label">
                      @Html.TextBoxFor(model => model.ImagePath1)
                      <asp:FileUpload ID="FileUpload5" runat="server" class="multi" accept="mp3" /><br />
                        Formats : mp4. 
                        Maximum Size : 2MB  
                </div>
    </div>
         <div id="div8" style="display:none;">      
         <br />
  <div class="editor-label">
               <b> Mp3 Files</b></div>

  <div class="editor-label">
                 @Html.TextBoxFor(model => model.ImagePath1) 
               <asp:FileUpload ID="FileUpload6" runat="server" class="multi" accept="mp3" /><br />  
              Formats : mp3. 
                Maximum Size : 1MB  
                  
  </div>                
             </div>
         <div id="div9" style="display:none;">  
         <br />
              <div class="editor-label">          <b>Game Files</b>  </div>
                <div class="editor-label">
                 @Html.TextBoxFor(model => model.ImagePath1)
                   <asp:FileUpload ID="FileUpload7" runat="server" class="multi" accept="SWF" /><br />
                        Formats : SWF 
                        Maximum Size : 2MB  
                 
             </div>
             </div>



                <br />
            <div class="editor-label">
            <b>  Display Order</b> </div>

             <div class="editor-label">
                  @Html.TextBoxFor(model => model.DispOrder, new { Style = "Width:100px" })
                   <b> @Html.ValidationMessageFor(model => model.DispOrder)</b>

          </div> 
               
            
           <div class="editor-label">
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
              

       
   
            @Html.Raw(ViewData["errorMsg"] 
            </div>
    
      }
    </form>
   