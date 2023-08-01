@ModelType MyBankAppvb.MyBankAppvb.Models.BankAccount
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>BankAccount</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Password)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Password)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Balance)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Balance)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.AccountId }) |
    @Html.ActionLink("Back to List", "Index")
</p>
