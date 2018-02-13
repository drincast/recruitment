
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
            try
            {
                var positions = (from e in this.db.positions
                                 where e.noActive == false
                                 select new
                                 {
                                     id = e.id,
                                     name = e.name
                                 }).ToList()
                                 .Select(x => new Position()
                                 {
                                     id = x.id,
                                     name = x.name
                                 });

                //var positions = this.db.positions
                //.Where(e => e.noActive == false)
                //.Select(e => new Position()
                //{
                //    id = e.id,
                //    name = e.name,
                //    noActive = e.noActive
                //}).ToList();

                var recruitment = new RecruitmentInputModel()
                {
                    lstPositions = new SelectList(positions, "id", "name")
                };
                return View(recruitment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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