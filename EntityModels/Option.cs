using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityModels
{
    public class Option
    {
        [Key]
        [Required(ErrorMessage="Title is required")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name="Active")]
        public bool IsActive { get; set; }
    }
}