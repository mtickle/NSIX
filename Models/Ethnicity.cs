using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class Ethnicity
    {
        [Key]
        public int EthnicityID { get; set; }

        [DisplayName("Code")]
        public string EthnicityCode { get; set; }

        [Required]
        [DisplayName("Ethnicity")]
        public string Description { get; set; }
    }
}