 [HttpGet]
        public ActionResult RetrieveUserImage(string id)
        {
            var f = db.Users.Find(id);
            if (f != null)
            {
                if (f.Image != null)
                {
                    return File(f.Image.Photo, f.Image.ContentType);
                }
                else
                {
                    return File("~/Images/silhouette.png", "image/png");
                }
            }
            return View();
        }
