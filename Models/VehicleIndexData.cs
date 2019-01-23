using System.Collections.Generic;

namespace NSIX.Models
{
    public class VehicleIndexData
    {
        public IEnumerable<SAR> SARs { get; set; }
        public IEnumerable<SarVehicle> SarVehicles { get; set; }
        public Vehicle Vehicle { get; set; }
        public IEnumerable<File> Files { get; set; }
    }
}