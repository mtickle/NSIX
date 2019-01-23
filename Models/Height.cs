using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class Height
    {
        [Key]
        public int HeightID { get; set; }

        [Required]
        [DisplayName("Height")]
        public string Description { get; set; }
    }
}