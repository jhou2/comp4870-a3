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
        [Required]
        public int TermCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}