using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityModels
{
    public class Choice
    {
        [Key]
        [Required]
        public int ChoiceId { get; set; }

        [Required(ErrorMessage = "Student Number is required.")]
        [RegularExpression(@"^A00\d{6}$")]
        [StringLength(9, ErrorMessage = "Format A00######")]
        [DisplayName("Student Number")]
        // [Remote("CheckStudentNumber", "Choice")]  // Remote check for uniqueness
        public string StudentNumber { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(40, ErrorMessage = "First name cannot be longer than 40 characters.")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name="Last Name")]
        [StringLength(40, ErrorMessage = "Last name cannot be longer than 40 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Term is required.")]
        //[ForeignKey("Term")]
        public virtual Term Term { get; set; }

        [Required(ErrorMessage = "First Choice is required.")]
        [Display(Name = "First Choice")]
        //[ForeignKey("Option")]
        public virtual Option FirstChoice { get; set; }

        [Required(ErrorMessage = "Second Choice is required.")]
        [Display(Name = "Second Choice")]
        //[ForeignKey("Option")]
        public virtual Option SecondChoice { get; set; }

        [Required(ErrorMessage = "Third Choice is required.")]
        [Display(Name = "Third Choice")]
        //[ForeignKey("Option")]
        public virtual Option ThirdChoice { get; set; }

        [Required(ErrorMessage = "Fourth Choice is required.")]
        [Display(Name = "Fourth Choice")]
        //[ForeignKey("Option")]
        public virtual Option FourthChoice { get; set; }

        [Required(ErrorMessage = "Date Created is required.")]
        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
    }
}