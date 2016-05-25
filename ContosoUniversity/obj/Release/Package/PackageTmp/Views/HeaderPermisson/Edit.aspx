@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/QuizSecurity.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" 


	@Session["projectmetatags"]
    <style type="text/css">
        #s
        {
            width: 350px;
        }
        #d
        {
            width: 350px;
        }
        #SelectLeft
        {
            width: 336px;
        }
        #SelectRight
        {
            width: 324px;
        }
        .style1
        {
            color: #FF0000;
            font-size: x-large;
        }
    </style>


<asp:Content ID="Content12" ContentPlaceHolderID="MainContent" runat="server"> 
 <script src="../../Custom-Jquiery/js/jquery-1.5.1.min.js" type="text/javascript"></script> 
  <script language="javascript" type="text/javascript">
      $(function () {
          $("#MoveRight,#MoveLeft").click(function (event) {
              var id = $(event.target).attr("id");
              var selectFrom = id == "MoveRight" ? "#SelectLeft" : "#SelectRight";
              var moveTo = id == "MoveRight" ? "#SelectRight" : "#SelectLeft";

              var selectedItems = $(selectFrom + " :selected").toArray();
              $(moveTo).append(selectedItems);
              selectedItems.remove;
          });
      });
    </script>   

@--
 
<br/><br/>
Move <a href="#" onclick="listbox_move('a', 'up')">up</a>,
<a href="#" onclick="listbox_move('a', 'down')">down</a>

&nbsp;&nbsp;&nbsp;
 
Select
<a href="#" onclick="listbox_selectall('a', true)">all</a>,
<a href="#" onclick="listbox_selectall('a', false)">none</a>
</td>--


 

@ if (ViewData["msstatus"] == null)
   { 
 <form method="post" id="form1">
    @Html.Raw(ViewData["permissionlist2"]
       
<table width="40%" align='center'>
<tr valign="top">

 
<td width="40%" class="style1"> 

    <strong>Available</strong></td>
<td valign="center" width="20%"> 
    &nbsp;</td>
<td width="40%" class="style1">


 

    <strong>Existing</strong></td>
</tr>
<tr valign="top">

 
<td width="40%"> 

  <select id="SelectLeft" multiple="multiple" size="20">
          @Html.Raw(ViewData["permissionlist1"]
        </select>
</td>
<td valign="center" width="20%">    <input id="MoveRight" type="button" value=" >> " /><br />
        <input id="MoveLeft" type="button" value=" << " />
</td>
<td width="40%">

 

 <select id="SelectRight" name="SelectRight" multiple="multiple" size="20">           
          @Html.Raw(ViewData["permissionlist"] </select>
</td>
</tr>
<tr valign="top">

 
<td width="40%">
     <input type="image" src="../../siteimages/Update.png" /><br /></td>
<td valign="center" width="20%">
    &nbsp;</td>
<td width="40%">
    &nbsp;</td>
</tr>
</table>
  



     </form>   
     }
   else
   {
   <h1>@Html.Raw(ViewData["msstatus"]</h1>
  }

        


