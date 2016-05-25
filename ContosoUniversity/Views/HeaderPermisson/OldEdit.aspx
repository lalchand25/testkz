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
    </style>


<asp:Content ID="Content12" ContentPlaceHolderID="MainContent" runat="server"> 
 <script src="../../Custom-Jquiery/js/jquery-1.5.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
function listbox_move(listID,direction){var listbox=document.getElementById(listID);var selIndex=listbox.selectedIndex;if(-1==selIndex){alert("Please select an option to move.");return;}
var increment=-1;if(direction=='up')
increment=-1;else
increment=1;if((selIndex+increment)<0||(selIndex+increment)>(listbox.options.length-1)){return;}
var selValue=listbox.options[selIndex].value;var selText=listbox.options[selIndex].text;listbox.options[selIndex].value=listbox.options[selIndex+increment].value
listbox.options[selIndex].text=listbox.options[selIndex+increment].text
listbox.options[selIndex+increment].value=selValue;listbox.options[selIndex+increment].text=selText;listbox.selectedIndex=selIndex+increment;}
function listbox_moveacross(sourceID,destID){var src=document.getElementById(sourceID);var dest=document.getElementById(destID);for(var count=0;count<src.options.length;count++){if(src.options[count].selected==true){var option=src.options[count];var newOption=document.createElement("option");newOption.value=option.value;newOption.text=option.text;newOption.selected=true;try{dest.add(newOption,null);src.remove(count,null);}catch(error){dest.add(newOption);src.remove(count);}
count--;}}}
function listbox_selectall(listID,isSelect){var listbox=document.getElementById(listID);for(var count=0;count<listbox.options.length;count++){listbox.options[count].selected=isSelect;}}

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

 
<td width="40%">
<SELECT id="s" size="25" multiple="multiple">
  @Html.Raw(ViewData["permissionlist1"]
</SELECT>
</td>
<td valign="center" width="20%">
<a href="#" onclick="listbox_moveacross('s', 'd')">&gt;&gt;</a>
<br/>
<a href="#" onclick="listbox_moveacross('d', 's')">&lt;&lt;</a>
</td>
<td width="40%">
<SELECT id="d" size="25" multiple="multiple">
	   @Html.Raw(ViewData["permissionlist"]
</SELECT>
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

        


