using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class HairColor
    {
        [Key]
        public int HairColorID { get; set; }

        [Required]
        [DisplayName("Code")]
        public string HairColorCode { get; set; }

        [Required]
        [DisplayName("Hair Color")]
        public string Description { get; set; }
    }
}