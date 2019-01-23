using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class VehicleMake
    {
        [Key]
        public int VehicleMakeID { get; set; }

        [Required]
        [DisplayName("Make Code")]
        public string MakeCode { get; set; }

        [Required]
        [DisplayName("Make")]
        public string MakeName { get; set; }


    }
}