  //In ShiftController
  {
            var s = db.ScheduleShiftTemplates.ToList();
            List<SelectListItem> shifts = new List<SelectListItem>();
            // add create new shift option
            shifts.Add(new SelectListItem { Text = "Create New Shift", Value = "1", Selected = true});
            // add all other existing shifts
            foreach (var item in s)

     //In CreateView

             @*Dropdown for shift selection*@
                        @{
                            Html.RenderAction("ShiftModal", "Shift");     
                        }
                    </div>
                    <div class="col-sm-7">
                        <div id="shift-details">   
                        </div>
                    </div>
                </div>
            </div>
                }
            });
        }
    }).change();  //triggers change to dropdown so it will populate modal on first load
   
    /** ajax submit for Create New shift template **/
    $('#shift-details').on("click", "#create-shift-submit", function (e) {
        var form = $('#create-shift-form').serialize();      