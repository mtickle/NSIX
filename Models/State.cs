using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSIX.Models
{
    public class State
    {

        [Key]       
        [Required]
        [DisplayName("State Abbreviation")]
        public string StateAbbrev { get; set; }

        [Required]
        [DisplayName("State Name")]
        public string Name { get; set; }

    }
}