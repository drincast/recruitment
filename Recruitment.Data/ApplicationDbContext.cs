using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace Recruitment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public IDbSet<Applicant> applicants { get; set; }

        public IDbSet<Position> positions { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
            //: base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
