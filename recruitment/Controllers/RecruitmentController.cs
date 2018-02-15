using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using recruitment.Models;
using Recruitment.Data;

namespace recruitment.Controllers
{
    public class RecruitmentController : BaseController
    {
        static async Task SendMail(string message)
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("drincast@gmail.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("coinrocrypto@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        // GET: Recruitment
        public ActionResult Create(RecruitmentInputModel model)
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

                //IEnumerable<SelectListItem> lstPositions = new SelectList(positions, "id", "name");
                //ViewData["lstPositions"] = lstPositions;

                var recruitment = new RecruitmentInputModel()
                {
                    lstPositions = new SelectList(positions, "name", "name")
                };

                if(model != null)
                {

                }

                return View(recruitment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FileContentResult GetImage()
        {
            var obj = (from e in this.db.applicants
                       where !e.photoMimeType.Equals("")
                       select new RecruitmentInputModel
                       {
                           biography = e.biography,                           
                           email = e.email,
                           firstName = e.firstName,
                           lastName = e.lastName,
                           phone = e.phone,
                           city = e.city,
                           country = e.country,
                           position = e.position,
                           postalCode = e.postalCode,
                           streetAddress = e.streetAddress,
                           photoMimeType = e.photoMimeType,
                           photoData = e.photoData
                       }).FirstOrDefault();

            if (obj != null)
            {
                return File(obj.photoData, obj.photoMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult MessajeApplying(string email)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecruitmentInputModel model, HttpPostedFileBase image = null)
        {
            if (model != null && this.ModelState.IsValid)
            {
                if(image != null)
                {
                    if(image.ContentLength <= 1000000)
                    {
                        var e = new Applicant()
                        {
                            biography = model.biography,
                            birtdate = model.birtdate,
                            email = model.email,
                            firstName = model.firstName,
                            lastName = model.lastName,
                            phone = model.phone,
                            city = model.city,
                            country = model.country,
                            position = model.position,
                            postalCode = model.postalCode,
                            streetAddress = model.streetAddress,
                            photoMimeType = image.ContentType,
                            photoData = new byte[image.ContentLength]
                        };

                        image.InputStream.Read(e.photoData, 0, image.ContentLength);

                        this.db.applicants.Add(e);
                        this.db.SaveChanges();

                        try
                        {
                            SendMail("w").Wait();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        

                        

                        //return this.RedirectToAction("GetImage");
                        TempData["applyEmail"] = e.email;
                        return this.RedirectToAction("MessajeApplying");
                    }
                    else
                    {
                        TempData["msj01"] = "The file size must be less than or equal to 1 mb";
                        return this.RedirectToAction("Create", model);
                    }
                }
            }

            return this.View(model);
        }
    }
}