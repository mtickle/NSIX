using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class EyeColor
    {
        [Key]
        public int EyeColorID { get; set; }

        [Required]
        [DisplayName("Code")]
        public string EyeColorCode { get; set; }

        [Required]
        [DisplayName("EyeColor")]
        public string Description { get; set; }
    }
}