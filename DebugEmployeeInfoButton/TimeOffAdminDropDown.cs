 //TimeOffEventController
 public ActionResult Index()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "FirstName");
            List<SelectListItem> FullNames = new List<SelectListItem>();
           
           
            foreach (ApplicationUser person in db.Users)
            {
                string FullName = person.FirstName + " " + person.LastName;
                string ID = person.Id;
                FullNames.Add(new SelectListItem() { Text = FullName, Value = ID });
            }
            ViewBag.Id = new SelectList(FullNames, "Value", "Text");
            //ViewBag.Id = new SelectList(db.Users, "ID", "FirstName");
            return View("Index");
        }
        // GET: Employer/TimeOffEvent