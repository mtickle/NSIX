using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSIX.Models
{
    public class SarVehicle
    {
        [Key]
        public int SarVehicleID { get; set; }
        public int SarID { get; set; }
        public int VehicleID { get; set; }

        [ForeignKey("SarID")]
        public virtual SAR SAR { get; set; }

        [ForeignKey("VehicleID")]
        public virtual Vehicle Vehicle { get; set; }

    }
}