using EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Models
{
    public class ChoiceViewModel
    {
        [Required(ErrorMessage = "Student Number is required.")]
        [RegularExpression(@"^A00\d{6}$")]
        [StringLength(9, ErrorMessage = "Format A00######")]
        public string StudentNumber { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(40, ErrorMessage = "First name cannot be longer than 40 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(40, ErrorMessage = "Last name cannot be longer than 40 characters.")]
        public string LastName { get; set; }

        public int Term { get; set; }

        public string FirstChoice { get; set; }

        public string SecondChoice { get; set; }

        public string ThirdChoice { get; set; }

        public string FourthChoice { get; set; }


        public Choice toChoice()
        {
            DiplomaContext ctx = new DiplomaContext();

            Choice choice = new Choice
            {
                StudentNumber = this.StudentNumber,
                FirstName = this.FirstName,
                LastName = this.LastName,
                //Term = ctx.Terms.Find(this.Term),
                Term_TermCode = ctx.Terms.Find(this.Term).TermCode,
                //FirstChoice = ctx.Options.Find(this.FirstChoice),
                FirstChoice_Title = ctx.Options.Find(this.FirstChoice).Title,
                //SecondChoice = ctx.Options.Find(this.SecondChoice),
                SecondChoice_Title = ctx.Options.Find(this.SecondChoice).Title,
                //ThirdChoice = ctx.Options.Find(this.ThirdChoice),
                ThirdChoice_Title = ctx.Options.Find(this.ThirdChoice).Title,
                //FourthChoice = ctx.Options.Find(this.FourthChoice),
                FourthChoice_Title = ctx.Options.Find(this.FourthChoice).Title
            };

            return choice;
        }

    }
}