namespace Recruitment.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<Recruitment.Data.ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Recruitment.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            CreatePositiosDemo(context);
        }

        private void CreatePositiosDemo(Recruitment.Data.ApplicationDbContext context)
        {
            try
            {
                //var position = from a in context.positions
                //               where a.noActive == false
                //               select a

                var position = context.positions
                               .Where(a => a.noActive == false)
                               .ToList();

                if (position.Count <= 0)
                {
                    context.positions.Add(new Position()
                    {
                        name = "Web Development (front-end)",
                        noActive = false
                    });

                    context.positions.Add(new Position()
                    {
                        name = "Web Development (back-end)",
                        noActive = false
                    });

                    context.positions.Add(new Position()
                    {
                        name = "API Development",
                        noActive = false
                    });

                    context.positions.Add(new Position()
                    {
                        name = "Mobile Development",
                        noActive = false
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
