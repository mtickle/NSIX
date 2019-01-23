using System.Collections.Generic;

namespace NSIX.Models
{
    public class SuperIndexData
    {
        public IEnumerable<SAR> SARs { get; set; }
        public IEnumerable<SarVehicle> SarVehicles { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}