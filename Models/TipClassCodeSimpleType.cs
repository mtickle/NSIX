using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSIX.Models
{
    public class TipClassCodeSimpleType
    {
        [Key]
        public int TipClassCodeSimpleTypeID { get; set; }

        [Required]
        [DisplayName("Tip Class Code")]
        public string FacetValue { get; set; }

        [Required]
        [DisplayName("Tip Class Description")]
        public string Description { get; set; }
    }
}