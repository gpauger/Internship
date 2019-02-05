@model IEnumerable<ScheduleUsers.ViewModels.TimeOffViewModel>
@{
    ViewBag.Title = "Index";
}

<h2 class="text-center">Create Request For: </h2>

<div class="container text-center">
    @{Html.RenderPartial("~/Views/TimeOffEvent/Create.cshtml");}
</div>



    <h2 class="text-center">Pending Requests</h2>

    @{Html.RenderAction("ProcessedIndex", new { data = "index" });}

    <h2 class="text-center">Approved Requests</h2>

    @{Html.RenderAction("ProcessedIndex", new { data = "processsed" });}