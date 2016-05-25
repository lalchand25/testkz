@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 


	@Session["projectmetatags"]



 <div id="body-text">
<div class="left">
    <form id="Form1"   method="post"  runat="server" action="/speech/index" > 
    <table width="95%" align="center" class='form2'>
    
    <tr>
    <td align="left">
         <b>Subject</b></td>
    <td>
       @Html.TextBox("Subject")
        <input id="Submit1" type="submit" value="Submit" /></td>

    </tr> 
   
           
            </table>
    </form>    
    </div></div>

    <input type="text" x-webkit-speech="x-webkit-speech" />

