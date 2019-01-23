using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSIX.Models
{
    public class TipDomainCodeSimpleType
    {
        [Key]
        public int TipDomainCodeSimpleTypeID { get; set; }

        [Required]
        [DisplayName("Tip Domain Code")]
        public string FacetValue { get; set; }

        [Required]
        [DisplayName("Tip Domain Description")]
        public string Description { get; set; }
    }
}