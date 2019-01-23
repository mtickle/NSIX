using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSIX.Models
{
    public class VehicleColor
    {

        [Key]
        public int VehicleColorID { get; set; }

        [Required]
        [DisplayName("Color Code")]
        public string ColorCode { get; set; }

        [Required]
        [DisplayName("Color Name")]
        public string ColorName { get; set; }
    }
}