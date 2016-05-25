@@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ReportsMaster.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<OLProject.Models.tb_LessionMasterSlides>


	@Session["projectmetatags"]



    <h2>List Of Slides</h2>
    <table width="100%">

    <tr>
              <td colspan="11" align="right">@Html.Raw(ViewData["screate"]  <img src="@Url.Content("~/siteImages/create.png")" border="0" alt="edit" style="width: 74px;height: 28px;" /></a></td>
            </tr>
 <tr>
              <td colspan="11" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr> 

        <tr>
            
            <td>
                Description
            </td>
            <td>
                Display Order
            </td>
           
      
          
          <td align="center">
              Quiz Show
            </td>
       
        <td align="center">
              Edit
            </td>
            <td align="center">
              Delete
            </td> 
                <td align="center">
             One Correct
            </td>
                <td align="center">
             Multiple Correct
            </td>
                <td align="center">
             True False
            </td>

             <td align="center">
              Image Choice
            </td>
                <td align="center">
             Select from Image
            </td>


        </tr>
        <tr>
              <td colspan="11" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr> 
   @Html.Raw(ViewData["data"]
    </table>




