using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSIX.Models
{
    public class TargetSectorCodeSimpleType
    {
        [Key]
        public int TargetSectorCodeSimpleTypeID { get; set; }

        [Required]
        [DisplayName("Target Sector Code")]
        public string FacetValue { get; set; }

        [Required]
        [DisplayName("Target Sector Description")]
        public string Description { get; set; }
    }
}