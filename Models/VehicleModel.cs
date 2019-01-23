using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class VehicleModel
    {
        [Key]
        public int VehicleModelID { get; set; }

        [Required]
        [DisplayName("Vehicle Make")]
        public int VehicleMakeID { get; set; }

        [Required]
        [DisplayName("Model Code")]
        public string ModelCode { get; set; }

        [Required]
        [DisplayName("Vehicle Model")]
        public string ModelName { get; set; }


        [ForeignKey("VehicleMakeID")]
        public virtual VehicleMake VehicleMake { get; set; }

    }
}