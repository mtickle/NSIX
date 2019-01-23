using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSIX.Models
{
    public class SuspiciousActivityCodeSimpleType
    {
        [Key]
        public int SuspiciousActivityCodeSimpleTypeID { get; set; }
        
        [Required]
        [DisplayName("Suspicious Activity Code")]
        public string FacetValue { get; set; }

        [Required]
        [DisplayName("Suspicious Activity Description")]
        public string Description { get; set; }
    }
}