using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace recruitment.Models
{
    public class RecruitmentViewModel
    {
        [MaxLength(200)]
        [Display(Name = "Position")]
        public string position { get; set; }

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
        [RegularExpression("^\\d{1,4}-\\d{2,3}-\\d{3,9}$", ErrorMessage = "The phone field does not have a valid number")]
        public string phone { get; set; }

        [Display(Name = "Birtdate")]
        public DateTime birtdate;

        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Biography")]
        public string biography { get; set; }

        [MaxLength(200)]
        [Display(Name = "Street address")]
        public string streetAddress { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

        [Display(Name = "Postal code")]
        public string postalCode { get; set; }

        //campo de imagen 1 mega
        public byte[] photoData { get; set; }
        public string photoMimeType { get; set; }

        //campo de imagen 1 mega

        //archivos 5 megas


    }
}