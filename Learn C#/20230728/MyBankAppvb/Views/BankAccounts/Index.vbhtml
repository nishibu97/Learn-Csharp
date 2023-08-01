@ModelType IEnumerable(Of MyBankAppvb.MyBankAppvb.Models.BankAccount)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Password)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Balance)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Password)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Balance)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.AccountId }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.AccountId }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.AccountId })
        </td>
    </tr>
Next

</table>
