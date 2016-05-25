﻿<%@ Page Title="" Language="C#" validateRequest="false" MasterPageFile="~/Views/Shared/profileMaster.Master" Inherits="System.Web.Mvc.ViewPage<go_eoffice_pms.Models.tb_TaskMaster>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%=Session["projectmetatags"]%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
<form runat="server">
  <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
          <table style="width: 100%;">
          <%=Html.HiddenFor(model => model.TaskID)%>
          <tr><td valign="top" style="width:20%"><div class="editor-label">
               Module Name:
            </div></td>  <td style="width:80%" align="left"> <div class="editor-field">
                          <%=Html.DropDownList("moduleid", (SelectList)ViewData["modulelist"],"Select", new {style = "width: 215px;"})%>
            </div></td></tr>

           <tr><td valign="top" style="width:20%"><div class="editor-label">
                Task Name:
            </div></td>  <td style="width:80%" align="left">  <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TaskName, new { style = "width:215px;" })%>
                <%: Html.ValidationMessageFor(model => model.TaskName)%>
            </div></td></tr>

          <tr><td valign="top" style="width:20%">
            <div class="editor-label">
                Upload Icon:
            </div></td>  <td style="width:80%" align="left">   <div class="editor-field">
                 <asp:FileUpload ID="FileUpload10" runat="server" class="multi" accept="png|jpg|gif" /><br />
                   <img src="../../Uploads/<%=ViewData["ImagePath"]%>" border="0" alt="edit" style="width: 22px;
                height: 22px;" />
            </div>
            </td></tr>

          <tr><td valign="top" style="width:20%">  <div class="editor-label">
           Change Order:
            </div></td>  <td style="width:80%" align="left">
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DispOrder, new { style = "width:50px;" })%>
                <%: Html.ValidationMessageFor(model => model.DispOrder) %>
            </div>
            </td></tr>

          <tr><td valign="top" style="width:20%">
            <div class="editor-label">
              Show:
            </div></td>  <td style="width:80%" align="left"><div class="editor-field">
                <%: Html.CheckBox("Status") %>
            </div></td></tr>

          <tr><td valign="top" style="width:20%">
               <div class="editor-label">
                URL:
            </div></td>  <td style="width:80%" align="left">
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.urlmvc, new { style = "width:215px;" })%>
                <%: Html.ValidationMessageFor(model => model.urlmvc) %>
            </div>
            </td></tr>
                    <tr>
            <td valign="top" style="width: 20%">
                <div class="editor-label">
                    Task Description
                </div>
            </td>
            <td style="width: 80%" align="left">
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.TaskDesc , new { style = "width:215px;" })%>
                    <%: Html.ValidationMessageFor(model => model.TaskDesc)%>
                </div>
            </td>
        </tr>
        
                        <tr>
            <td valign="top" style="width: 20%" valign="top" colspan="2">
                <div class="editor-label">
                    Instructions
                </div>
            </td>
            </tr>
<tr>

            <td style="width: 80%" align="left" colspan="2">
                <div class="editor-field">
                 <%: Html.TextArea("TaskInstruction", new { style = "width:95%;Height:300px" })%>
                </div>
            </td>
        </tr>


          <tr><td valign="top" style="width:20%">
              &nbsp;</td>  <td style="width:80%" align="left"> <p>
                <input type="submit" value="Save" />
            </p></td></tr>

        
            </table>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
   </form>
</asp:Content>

