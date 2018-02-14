using System;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Data
{
    public class Applicant
    {
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string firstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string lastName { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [Phone]
        public string phone { get; set; }

        [Required]
        public DateTime birtdate;
        
        [Required]
        [MaxLength(500)]
        public string biography { get; set; }

        [Required]
        [MaxLength(200)]
        public string streetAddress { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string country { get; set; }

        public string postalCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string position { get; set; }

        public byte[] photoData { get; set; }
        public string photoMimeType { get; set; }
    }
}
