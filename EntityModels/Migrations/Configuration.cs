namespace EntityModels.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityModels.DiplomaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityModels.DiplomaContext context)
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

            Option option1 = new Option { Title = "Data Communications", IsActive = true };
            Option option2 = new Option { Title = "Client Server", IsActive = true };
            Option option3 = new Option { Title = "Digital Processing", IsActive = true };
            Option option4 = new Option { Title = "Information Systems", IsActive = true };
            Option option5 = new Option { Title = "Database", IsActive = false };

            context.Options.AddOrUpdate(option1);
            context.Options.AddOrUpdate(option2);
            context.Options.AddOrUpdate(option3);
            context.Options.AddOrUpdate(option4);
            context.Options.AddOrUpdate(option5);
            context.SaveChanges();

            // TermCode PK is not inserted because IDENTITY_INSERT is off.  I think this is ok though.
            Term term1 = new Term { TermCode = 201410, Description = "Winter 2014", IsActive = false };
            Term term2 = new Term { TermCode = 201420, Description = "Spring/Summer 2014", IsActive = true };
            Term term3 = new Term { TermCode = 201430, Description = "Fall 2014", IsActive = false };
            Term term4 = new Term { TermCode = 201510, Description = "Winter 2015", IsActive = false };
            Term term5 = new Term { TermCode = 201520, Description = "Spring/Summer 2015", IsActive = false };

            context.Terms.AddOrUpdate(term1);
            context.Terms.AddOrUpdate(term2);
            context.Terms.AddOrUpdate(term3);
            context.Terms.AddOrUpdate(term4);
            context.Terms.AddOrUpdate(term5);
            context.SaveChanges();

            context.Choices.AddOrUpdate(new Choice { StudentNumber = "A00123122", FirstName = "Joe", LastName = "Smith", Term = term1, FirstChoice = option1, SecondChoice = option2, ThirdChoice = option3, FourthChoice = option4, CreateDate = new DateTime(2014, 1, 1) });
            context.Choices.AddOrUpdate(new Choice { StudentNumber = "A00123222", FirstName = "Bob", LastName = "Scott", Term = term2, FirstChoice = option4, SecondChoice = option3, ThirdChoice = option2, FourthChoice = option1, CreateDate = new DateTime(2014, 2, 2) });
            context.Choices.AddOrUpdate(new Choice { StudentNumber = "A00123322", FirstName = "Jane", LastName = "Doe", Term = term1, FirstChoice = option1, SecondChoice = option3, ThirdChoice = option2, FourthChoice = option4, CreateDate = new DateTime(2014, 3, 3) });
            context.Choices.AddOrUpdate(new Choice { StudentNumber = "A00123422", FirstName = "Sarah", LastName = "Black", Term = term3, FirstChoice = option3, SecondChoice = option1, ThirdChoice = option4, FourthChoice = option2, CreateDate = new DateTime(2014, 4, 4) });
            context.Choices.AddOrUpdate(new Choice { StudentNumber = "A00123522", FirstName = "Bill", LastName = "White", Term = term4, FirstChoice = option2, SecondChoice = option1, ThirdChoice = option3, FourthChoice = option4, CreateDate = new DateTime(2014, 5, 5) });
            context.Choices.AddOrUpdate(new Choice { StudentNumber = "A00123622", FirstName = "John", LastName = "Brown", Term = term5, FirstChoice = option1, SecondChoice = option2, ThirdChoice = option4, FourthChoice = option3, CreateDate = new DateTime(2014, 6, 6) });
            context.SaveChanges();
        }
    }
}
