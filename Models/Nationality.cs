using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class Nationality
    {
        [Key]
        public int NationalityID { get; set; }

        [Required]
        [DisplayName("Nationality")]
        public string Description { get; set; }
    }
}