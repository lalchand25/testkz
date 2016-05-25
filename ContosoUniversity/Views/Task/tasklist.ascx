<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<go_eoffice_pms.Models.tb_TaskMaster>>" %>

<table border="0" style="width: 100%" cellpadding="0" cellspacing="0">
<tr>
              <td colspan="7" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>
    <tr>
        <th>Icon
        </th>
        <th align="left">
            Task Name
        </th>
        <th align="left">
            URL
        </th>
        <th align="center">
            Order
        </th>
        <th align="left">
            Status
        </th>
        <th>
            Edit
        </th>
        <th>
            Delete
        </th>
    </tr>
  <%--  <tr>
              <td colspan="7" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>--%>
    <% 
        int mcnt = 0;
        int balt = 0;
        string row = "";
        foreach (var item in Model)
       {
                mcnt += 1;
                balt = mcnt % 2;

                if (balt == 0)
                {
                    row = "<tr style='background-color:#e8e8e8'>";
                }
                else
                {
                    row = "<tr>";
                }
                Response.Write(row);   
            %>
        <td align="center" width="5%">
            <img src="../../Uploads/<%= item.image %>" border="0" alt="edit" style="width: 22px;
                height: 22px;" />
        </td>
        <td width="25%">
            <%= item.TaskName %>
        </td>
        <td width="10%">
            <%= item.urlmvc %>
        </td>
        <td width="5%">
            <%= item.DispOrder %>
        </td>
        <td width="5%">
            <%--<%= item.taskstatus %>--%>
        </td>
        <td align="center" width="5%">
            <a href="<%= Url.Action("Edit", "task",new {id=1,taskid=item.TaskID})%>">
                <img src="<%=Url.Content("~/SiteImages/edit.png") %>" border="0" alt="edit" style="width: 44px;
                    height: 44px;" /></a>
        </td>
        <td align="center" width="5%">
            <a href="<%= Url.Action("Delete", "task",new {id=1,taskid=item.TaskID})%>">
                <img src="<%=Url.Content("~/SiteImages/delete.png") %>" border="0" alt="Delete" style="width: 44px;
                    height: 44px;" /></a>
        </td>
    </tr>
    <% } %>
     <tr>
              <td colspan="7" style="border-bottom:1px solid #c2c2c2;"><img src="../../Images/clr.gif" alt="" width="1" height="15" /></td>
            </tr>
</table>
