using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityModels
{
    public class Term
    {
        [Key]
        [Required(ErrorMessage = "Term Code is required.")]
        [Display(Name="Term Code")]
        public int TermCode { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }


    }
}