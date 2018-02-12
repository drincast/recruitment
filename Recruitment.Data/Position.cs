using System.ComponentModel.DataAnnotations;

namespace Recruitment.Data
{
    /// <summary>
    /// Class for the applying for position
    /// </summary>
    public class Position
    {
        public int id { get; set; }
        [Required]
        [MaxLength(200)]
        public string name { get; set; }

        public bool noActive { get; set; }
    }
}
