using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class Gender
    {
        [Key]
        public int GenderID { get; set; }

        [Required]
        [DisplayName("Code")]
        public string GenderCode { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Description { get; set; }
    }
}