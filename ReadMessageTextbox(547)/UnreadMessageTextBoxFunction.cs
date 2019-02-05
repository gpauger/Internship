 // POST: Message/Details/5
        [HttpPost]
        [Authorize(Roles = "Admin, User")]

        public ActionResult UpdateUnreadMessage(bool check, Guid? id)
        {
            Message message = db.Messages.Find(id);
            if (check == true)
            {
                message.UnreadMessage = true;
                //added by GA to clear 'date-read' if unread box is checked
                message.DateRead = null;
            }
            else
            {
                message.UnreadMessage = false;
                message.DateRead = DateTime.Now;
            }
            db.SaveChanges();
            return Content("Successful Update ");
        }