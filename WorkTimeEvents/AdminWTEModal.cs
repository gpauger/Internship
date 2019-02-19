    //GET: Create/CreateScheduleForUser
        //This populates the dropdownlist with shifts in the Edit Shift Modal.
        
        public ActionResult ShiftModal([Bind(Include = "Id,StartTime,EndTime")] ScheduleShiftTemplate shift)
        { 
            var s = db.ScheduleShiftTemplates.ToList();
            List<SelectListItem> shifts = new List<SelectListItem>();
            
            // add create new shift option
            
            shifts.Add(new SelectListItem { Text = "Create New Shift", Value = "1" });
            // add all other existing shifts
            foreach (var item in s)
            {
                //if item being added to dropdown is the new item, it is passed through as selected 
                if (item.Id == shift.Id)  
                {
                    string timeString = item.StartTime.Value.ToShortTimeString() + " - " + item.EndTime.Value.ToShortTimeString();
                    shifts.Add(new SelectListItem { Text = timeString, Value = item.Id, Selected = true });
                }
                else
                {
                    string timeString = item.StartTime.Value.ToShortTimeString() + " - " + item.EndTime.Value.ToShortTimeString();
                    shifts.Add(new SelectListItem { Text = timeString, Value = item.Id });
                }
               
            }
            return PartialView("_ModalShifts", shifts);
        }