using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityModels
{
    public class Choice
    {
        [Key]
        [Required]
        public int ChoiceId { get; set; }

        [Required]
        [MaxLength(9)]
        public string StudentNumber { get; set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        public Term Term { get; set; }

        [Required]
        public Option FirstChoice { get; set; }
        [Required]
        public Option SecondChoice { get; set; }

        [Required]
        public Option ThirdChoice { get; set; }

        [Required]
        public Option FourthChoice { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}