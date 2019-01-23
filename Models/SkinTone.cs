using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class SkinTone
    {
        [Key]
        public int SkinToneID { get; set; }

        [Required]
        [DisplayName("Code")]
        public string SkinToneCode { get; set; }

        [Required]
        [DisplayName("SkinTone")]
        public string Description { get; set; }
    }
}