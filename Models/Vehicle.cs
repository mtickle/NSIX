using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSIX.Models
{
    public class Vehicle
    {


        [Key]
        public int VehicleID { get; set; }

        [DisplayName("License Plate")]
        public string LicencePlate { get; set; }

        [DisplayName("State of Registration")]
        public string StateAbbrev { get; set; }

        [DisplayName("Vehicle Color")]
        public int VehicleColorID { get; set; }

        [DisplayName("Vehicle Make")]
        public int VehicleMakeID { get; set; }

        [DisplayName("Vehicle Model")]
        public int VehicleModelID { get; set; }

        [ForeignKey("StateAbbrev")]
        public virtual State State { get; set; }

        [ForeignKey("VehicleColorID")]
        public virtual VehicleColor VehicleColor { get; set; }

        [ForeignKey("VehicleMakeID")]
        public virtual VehicleMake VehicleMake { get; set; }

        [ForeignKey("VehicleModelID")]
        public virtual VehicleModel VehicleModel { get; set; }

        public virtual ICollection<SarVehicle> SarVehicles { get; set; }
        public virtual ICollection<File> Files { get; set; }
      
    }
}