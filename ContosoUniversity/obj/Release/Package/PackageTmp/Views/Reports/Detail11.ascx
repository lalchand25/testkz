@@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<OLProject.Models.QuizInformation>

<p>
    @Html.ActionLink("Create New", "Create") 
</p>
<table>
    <tr>
        <th>
            QuizId
        </th>
        <th>
            Decription
        </th>
        <th>
            Ans1
        </th>
        <th>
            Ans2
        </th>
        <th>
            Ans3
        </th>
        <th>
            Ans4
        </th>
        <th>
            UserAns
        </th>
        <th>
            ComputerAns
        </th>
        <th></th>
    </tr>

@ foreach (var item in Model) { 
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.QuizId) 
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Decription) 
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Ans1) 
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Ans2) 
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Ans3) 
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Ans4) 
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.UserAns) 
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.ComputerAns) 
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ })  |
            @Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })  |
            @Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }) 
        </td>
    </tr>
@ } 

</table>
