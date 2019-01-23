using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class Weight
    {
        [Key]
        public int WeightID { get; set; }

        [Required]
        [DisplayName("Weight")]
        public string Description { get; set; }
    }
}