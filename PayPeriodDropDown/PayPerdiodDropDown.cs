       ///First I updated viewmodel with 2 new properties and updated constructors (not shown)
       /// <summary>
        ///  Pay period for dropdown
        public string SelectedPayPeriod { get; set; }
        /// <summary>
        ///  Pay period for dropdown
        /// </summary>
        public int SelectedPayYear { get; set; }

///This is the payPerdiod dropdown partial, updated Index view to display this partial, which when selected updates another partial
@model List<ScheduleUsers.Models.PayPeriod>

   <select name="PayPeriod" class="form-control" style="margin-bottom:5px" id="pay-period">
   
    @{var selectedpp = ViewBag.selectedpayperiod; }

    @{foreach (ScheduleUsers.Models.PayPeriod pp in Model)
        {
            var endDate = pp.StartDate.AddDays(pp.PayPeriodLength);
            var ppstring = pp.StartDate.ToShortDateString() + " - " + endDate.ToShortDateString();
            if (ppstring == selectedpp)
            {
                <option selected="selected" id="pay-period-option" data-start="@pp.StartDate.ToString("yyyy-MM-dd")" data-end="@endDate.ToString("yyyy-MM-dd")"> @pp.StartDate.ToShortDateString()  - @endDate.ToShortDateString()  </option>
            }
            else
            {
                <option id="pay-period-option" data-start="@pp.StartDate.ToString("yyyy-MM-dd")" data-end="@endDate.ToString("yyyy-MM-dd")"> @pp.StartDate.ToShortDateString() - @endDate.ToShortDateString() </option>
            }
        }
    }
</select>
///updated the worktime event controller Index method to use new model properties
             var year = PayYear;
            var payYear = PayYear;
            EventListVm EVM = new EventListVm(year, payYear, PayPeriod, workTime: Dates.ToList(), user: user, ClockedIn: ClockedInStatus, Start: EVMView.DisplayBeginDate, End: EVMView.DisplayEndDate);