//Index View
@model IEnumerable<ScheduleUsers.ViewModels.TimeOffViewModel>
@{
    ViewBag.Title = "Index";
}
<h2 class="text-center">Create Request For: </h2>
<div class="container text-center">
    @{Html.RenderPartial("~/Views/TimeOffEvent/Create.cshtml");}  //Partial replacement
</div>
    <h2 class="text-center">Pending Requests</h2>
    @{Html.RenderAction("ProcessedIndex", new { data = "index" });}
    <h2 class="text-center">Approved Requests</h2>
    @{Html.RenderAction("ProcessedIndex", new { data = "processsed" });}

//Added to Create View to include dropdown 
      @if (User.IsInRole("Admin"))
    {
        @Html.DropDownList("accountid", (SelectList)ViewBag.Id)
    }

//Methods in the TimeOffEventController
     // GET: TimeOffEvent/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin") || User.IsInRole("User"))
            {
                ViewBag.Id = new SelectList(db.Users, "Id", "FirstName");
                return PartialView("Create");
            }
            else
            {
                return new EmptyResult();
            }
        }
//This method was mostly copied from main controller
         [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create([Bind(Include = "EventID,Start,End,Note,ActiveSchedule,Submitted,Id")] TimeOffEvent timeOffEvent)
        {
            //update model with current user so that it doesn't have to be passed through the view.
            var userid = User.Identity.GetUserId();
            timeOffEvent.User = db.Users.Where(w => w.Id == userid).First();
            //Clear usre provided by default binding provider
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                timeOffEvent.EventID = Guid.NewGuid();
                timeOffEvent.Submitted = DateTime.Now;
                db.TimeOffEvents.Add(timeOffEvent);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "FirstName", timeOffEvent.Id);
            return RedirectToAction("Index");

        }