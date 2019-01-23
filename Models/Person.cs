using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NSIX.Models
{
    public class Person
    {


        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Suffix")]
        public string Suffix { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Age")]
        public string Age { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Height")]
        public int? HeightID { get; set; }

        [DisplayName("Weight")]
        public int? WeightID { get; set; }

        [DisplayName("Hair Color")]
        public int? HairColorID { get; set; }

        [DisplayName("Eye Color")]
        public int? EyeColorID { get; set; }

        [DisplayName("Gender")]
        public int? GenderID { get; set; }

        [DisplayName("Ethnicity")]
        public int? EthnicityID { get; set; }

        [DisplayName("Race")]
        public int? RaceID { get; set; }

        [DisplayName("Nationality")]
        public int? NationalityID { get; set; }

        [DisplayName("Skin Tone")]
        public int? SkinToneID { get; set; }

        [DisplayName("Eyewear")]
        public string Eyewear { get; set; }

        [DisplayName("Facial Hair")]
        public string FacialHair { get; set; }

        [DisplayName("Physical Description")]
        public string PhysicalDescription { get; set; }

        [DisplayName("Any Alias or Previous Names")]
        public string Alias { get; set; }

        [DisplayName("Other Information")]
        public string OtherInformation { get; set; }

        //--- Foreign keys
        [ForeignKey("HeightID")]
        public virtual Height Height { get; set; }

        [ForeignKey("WeightID")]
        public virtual Weight Weight { get; set; }

        [ForeignKey("HairColorID")]
        public virtual HairColor HairColor { get; set; }

        [ForeignKey("EyeColorID")]
        public virtual EyeColor EyeColor { get; set; }

        [ForeignKey("SkinToneID")]
        public virtual SkinTone SkinTone { get; set; }

        [ForeignKey("NationalityID")]
        public virtual Nationality Nationality { get; set; }

        [ForeignKey("EthnicityID")]
        public virtual Ethnicity Ethnicity { get; set; }

        [ForeignKey("GenderID")]
        public virtual Gender Gender { get; set; }

        [ForeignKey("RaceID")]
        public virtual Race Race { get; set; }

        public virtual SAR SAR { get; set; }





    }
}