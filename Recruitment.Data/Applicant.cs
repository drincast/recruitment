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

        public DateTime birtdate;
        
        [MaxLength(500)]
        public string biography { get; set; }

        public int idPosition { get; set; }
    }
}
