using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSIX.Models
{
    public class SAR
    {
        

        [Key]
        public int SarID { get; set; }

        //--- Fields for the SAR
        [DataType(DataType.Date)]
        [DisplayName("Activity Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActivityDate { get; set; }
        
        [DataType(DataType.Time)]
        [DisplayName("Activity Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ActivityTime { get; set; }

        [Required]
        [DisplayName("Location Description")]
        public string Location { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("State")]
        //public int StateID { get; set; }
        public string StateAbbrev { get; set; }

        [ForeignKey("StateAbbrev")]
        public virtual State State { get; set; }
        
        [Required]
        [DisplayName("ZIP code")]
        public string ZipCode { get; set; }

        [DisplayName("Full Address")]
        public string FullAddress { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Suspicious Activity")]
        public int? SuspiciousActivityCodeSimpleTypeID { get; set; }

        [DisplayName("Target Sector")]
        public int? TargetSectorCodeSimpleTypeID { get; set; }
        
        [DisplayName("Tip Class")]
        public int? TipClassCodeSimpleTypeID { get; set; }
        
        [DisplayName("Tip Domain")]
        public int? TipDomainCodeSimpleTypeID { get; set; }

        //--- Foreign keys
        [ForeignKey("SuspiciousActivityCodeSimpleTypeID")]
        public virtual SuspiciousActivityCodeSimpleType SuspiciousActivityCodeSimpleType { get; set; }

        [ForeignKey("TargetSectorCodeSimpleTypeID")]
        public virtual TargetSectorCodeSimpleType TargetSectorCodeSimpleType { get; set; }

        [ForeignKey("TipClassCodeSimpleTypeID")]
        public virtual TipClassCodeSimpleType TipClassCodeSimpleType { get; set; }

        [ForeignKey("TipDomainCodeSimpleTypeID")]
        public virtual TipDomainCodeSimpleType TipDomainCodeSimpleType { get; set; }

        //public virtual ICollection<SarVehicle> SarVehicles { get; set; }
        //public virtual ICollection<Vehicle> Vehicles { get; set; }

        //public IEnumerable<SarVehicle> SarVehicles { get; set; }
        //public IEnumerable<Vehicle> Vehicles { get; set; }

        //--- Audit information

        [DisplayName("Created By")]
        [ReadOnly(true)]
        public string  CreatedByName { get; set; }

        [ReadOnly(true)]
        public string CreatedByID { get; set; }

        [DataType(DataType.DateTime)]
        [ReadOnly(true)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("Updated By")]
        [ReadOnly(true)]
        public string UpdatedByName { get; set; }

        [ReadOnly(true)]
        public string UpdatedByID { get; set; }

        [DataType(DataType.DateTime)]
        [ReadOnly(true)]
        [DisplayName("Updated Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedDate { get; set; }
       
    }
}