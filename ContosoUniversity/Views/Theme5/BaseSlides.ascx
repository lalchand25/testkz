@model OLProject.Models.tb_LessionMasterSlides>" 
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
 
 <br /><b>@Html.Raw(ViewData["lstatus"]</b><br />
 <form  method="post" id="createProp" runat="server">
    <table width="99%" align="center">
    <tr style='background-color:#e8e8e8'>
    <td style="Width:20%">
    </td>
     <td style="Width:80%">
      </td>
    
    </tr>
    @using (Html.BeginForm())
       {
        @Html.ValidationSummary(true)
       

        
          
    
        
            <tr>
    <td valign="top" align='left'>            <b>Slide Name</b>  </td> <td  align='left'>  
               @Html.TextBoxFor(model => model.SlideDescription, new  { style="width:250px" })
                <b> @Html.ValidationMessageFor(model => model.SlideDescription)</b>
               </td>
    </tr>

    
            <tr>
    <td valign="top" align='left'>             <b>Update Image</b> </td> <td align='left'>  
                
             
                  @Html.TextBoxFor(model => model.ImagePath)  
               <asp:FileUpload ID="FileUpload0" runat="server" class="multi" accept="png" /><br /> <br />
              Formats : png,jpg,gif,jpeg. 
                Maximum Size : 100kb  

               </td>
    </tr>
      
           
            <tr>
    <td valign="top" align='left'>            <b>Image Description</b>   </td> <td align='left'>  
                 @Html.TextAreaFor(model => model.ImageDescription)
             <b> @Html.ValidationMessageFor(model => model.ImageDescription)</b>
                 </td>
    </tr>
            
              
            <tr>
    <td valign="top" align='left'>             <b> Mp3 Files</b>  </td> <td align='left'>  
               @Html.TextBoxFor(model => model.ImagePath)  
               <asp:FileUpload ID="FileUpload1" runat="server" class="multi" accept="mp3" /><br />  
              Formats : mp3. 
                Maximum Size : 1MB  
                  
                  
                  </td>
    </tr>
             
             
               
            <tr>
    <td valign="top" align='left'>            <b>Video Files</b>  </td> <td align='left'>  
                      @Html.TextBoxFor(model => model.VideoFiles)
                      <asp:FileUpload ID="FileUpload2" runat="server" class="multi" accept="mp3" /><br />
                        Formats : mp4. 
                        Maximum Size : 2MB  
                </td>
    </tr>
    
      
            <tr>
    <td valign="top" align='left'>            <b>Game Files</b>  </td> <td align='left'>  
                 @Html.TextBoxFor(model => model.GameFiles)
                   <asp:FileUpload ID="FileUpload3" runat="server" class="multi" accept="SWF" /><br />
                        Formats : SWF 
                        Maximum Size : 2MB  
                 
                 </td>
    </tr>  
             
                
            <tr>
    <td align='left'>            <b>  Display Order</b></td> <td align='left'>  
                  @Html.TextBoxFor(model => model.DispOrder, new { Style = "Width:100px" })
                   <b> @Html.ValidationMessageFor(model => model.DispOrder)</b>

           </td>
    </tr>  
               
            <tr>
    <td align='left'>                &nbsp;</td> <td>  
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
              

         }
   
    @Html.Raw(ViewData["errorMsg"] </td>
    </tr>
            
               
    </table>

    
    </form>
   