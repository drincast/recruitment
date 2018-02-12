using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recruitment.Models
{
    public class RecruitmentViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string lastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address")]
        public string email { get; set; }

        [Display(Name = "Phone")]
        [Phone]
        public string phone { get; set; }

        [Display(Name = "Birtdate")]
        public DateTime birtdate;

        [MaxLength(500)]
        [Display(Name = "Biography")]
        public string biography { get; set; }
    }
}