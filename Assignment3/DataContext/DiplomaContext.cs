using EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment3.DataContext
{
    public class DiplomaContext : DbContext
    {
        public DiplomaContext() : base("DefaultConnection") { }

        public DbSet<Term> Terms { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Choice> Choices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Choice>().
            //    HasMany(p => p.Option).
                
            //    Map(
            //        m =>
            //        {
            //            m.ToTable("Option");
            //            m.MapLeftKey("Choice");
                        
            //        });
            // modelBuilder.Entity<User>().HasRequired(u => u.Role);
            modelBuilder.Entity<Choice>().HasRequired(p => p.Term);
        }
    }
}