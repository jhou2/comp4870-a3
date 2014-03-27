namespace Assignment3.Migrations
{
    using Assignment3.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment3.Models.ApplicationDbContext context)
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

            /*
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "student" };

            manager.Create(role1);
            manager.Create(role2);

            var stre = new UserStore<ApplicationUser>(context);
            var manger = new UserManager<ApplicationUser>(stre);
            var user1 = new ApplicationUser { UserName = "Admin1" };
            var user2 = new ApplicationUser { UserName = "Admin2" };
            var user3 = new ApplicationUser { UserName = "Student1" };

            manger.Create(user1, "P@$$w0rd");
            manger.Create(user2, "P@$$w0rd");
            manger.Create(user3, "P@$$w0rd");
            manger.AddToRole(user1.Id, "admin");
            manger.AddToRole(user2.Id, "admin");
            manger.AddToRole(user3.Id, "student");
            */
        }
    }
}
