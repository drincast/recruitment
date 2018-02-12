
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using recruitment.Models;
using Recruitment.Data;

namespace recruitment.Controllers
{
    public class RecruitmentController : BaseController
    {
        // GET: Recruitment
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecruitmentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var e = new Applicant()
                {
                    biography = model.biography,
                    birtdate = model.birtdate,
                    email = model.email,
                    firstName = model.firstName,
                    lastName = model.lastName,
                    phone = model.phone                    
                };

                this.db.applicants.Add(e);
                this.db.SaveChanges();

                return this.RedirectToAction("My");
            }

            return this.View(model);
        }
    }
}