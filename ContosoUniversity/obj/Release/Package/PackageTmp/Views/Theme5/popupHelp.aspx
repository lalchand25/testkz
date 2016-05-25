﻿@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Security.Master"  Inherits="System.Web.Mvc.ViewPage<OLProject.Models.tb_LessionMasterSlides>" 
@using OLProject.Models;

	@Session["projectmetatags"]



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
  <div class="Courses">
     	<div class="topdiv">
                 <div class="clr"></div>
        </div>
        
        
        
        <div class="middiv" style="text-align:center">
  @using (Html.BeginForm())
       {
        @Html.ValidationSummary(true)
       
 <br /><b>@Html.Raw(ViewData["lstatus"]</b><br />
 
    <table width="95%" align="center">
   
            <tr>
    <td valign="top" align='left'>            <b>Help</b>   </td>    </tr>
           <tr>
    <td align='left'>  
                 @Html.TextAreaFor(model => model.HelpSlide)
             <b> @Html.ValidationMessageFor(model => model.HelpSlide)</b>
                 </td>
    </tr>
           <tr>
    <td align='left'>  
                    <input type="image" src="../../siteimages/Submit.png" /><br /></td>
    </tr>
    </table>
  }

   <div class="bottomdiv" style="background:#9A0201;">
        <div class="clr"></div>
        </div>
 </div>
 </div>

