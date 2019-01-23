using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class Race
    {
        [Key]
        public int RaceID { get; set; }


        [DisplayName("Code")]
        public string RaceCode { get; set; }

        [Required]
        [DisplayName("Race")]
        public string Description { get; set; }
    }
}