namespace NSIX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Poo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ethnicity",
                c => new
                    {
                        EthnicityID = c.Int(nullable: false, identity: true),
                        EthnicityCode = c.String(),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EthnicityID);
            
            CreateTable(
                "dbo.EyeColor",
                c => new
                    {
                        EyeColorID = c.Int(nullable: false, identity: true),
                        EyeColorCode = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EyeColorID);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        LicencePlate = c.String(),
                        StateAbbrev = c.String(maxLength: 128),
                        VehicleColorID = c.Int(nullable: false),
                        VehicleMakeID = c.Int(nullable: false),
                        VehicleModelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.State", t => t.StateAbbrev)
                .ForeignKey("dbo.VehicleColor", t => t.VehicleColorID)
                .ForeignKey("dbo.VehicleMake", t => t.VehicleMakeID)
                .ForeignKey("dbo.VehicleModel", t => t.VehicleModelID)
                .Index(t => t.StateAbbrev)
                .Index(t => t.VehicleColorID)
                .Index(t => t.VehicleMakeID)
                .Index(t => t.VehicleModelID);
            
            CreateTable(
                "dbo.SarVehicle",
                c => new
                    {
                        SarVehicleID = c.Int(nullable: false, identity: true),
                        SarID = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SarVehicleID)
                .ForeignKey("dbo.SAR", t => t.SarID)
                .ForeignKey("dbo.Vehicle", t => t.VehicleID)
                .Index(t => t.SarID)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.SAR",
                c => new
                    {
                        SarID = c.Int(nullable: false, identity: true),
                        ActivityDate = c.DateTime(nullable: false),
                        ActivityTime = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        StateAbbrev = c.String(nullable: false, maxLength: 128),
                        ZipCode = c.String(nullable: false),
                        FullAddress = c.String(),
                        Description = c.String(nullable: false),
                        SuspiciousActivityCodeSimpleTypeID = c.Int(),
                        TargetSectorCodeSimpleTypeID = c.Int(),
                        TipClassCodeSimpleTypeID = c.Int(),
                        TipDomainCodeSimpleTypeID = c.Int(),
                        CreatedByName = c.String(),
                        CreatedByID = c.String(),
                        CreatedDate = c.DateTime(),
                        UpdatedByName = c.String(),
                        UpdatedByID = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SarID)
                .ForeignKey("dbo.State", t => t.StateAbbrev)
                .ForeignKey("dbo.SuspiciousActivityCodeSimpleType", t => t.SuspiciousActivityCodeSimpleTypeID)
                .ForeignKey("dbo.TargetSectorCodeSimpleType", t => t.TargetSectorCodeSimpleTypeID)
                .ForeignKey("dbo.TipClassCodeSimpleType", t => t.TipClassCodeSimpleTypeID)
                .ForeignKey("dbo.TipDomainCodeSimpleType", t => t.TipDomainCodeSimpleTypeID)
                .Index(t => t.StateAbbrev)
                .Index(t => t.SuspiciousActivityCodeSimpleTypeID)
                .Index(t => t.TargetSectorCodeSimpleTypeID)
                .Index(t => t.TipClassCodeSimpleTypeID)
                .Index(t => t.TipDomainCodeSimpleTypeID);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateAbbrev = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StateAbbrev);
            
            CreateTable(
                "dbo.SuspiciousActivityCodeSimpleType",
                c => new
                    {
                        SuspiciousActivityCodeSimpleTypeID = c.Int(nullable: false, identity: true),
                        FacetValue = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SuspiciousActivityCodeSimpleTypeID);
            
            CreateTable(
                "dbo.TargetSectorCodeSimpleType",
                c => new
                    {
                        TargetSectorCodeSimpleTypeID = c.Int(nullable: false, identity: true),
                        FacetValue = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TargetSectorCodeSimpleTypeID);
            
            CreateTable(
                "dbo.TipClassCodeSimpleType",
                c => new
                    {
                        TipClassCodeSimpleTypeID = c.Int(nullable: false, identity: true),
                        FacetValue = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipClassCodeSimpleTypeID);
            
            CreateTable(
                "dbo.TipDomainCodeSimpleType",
                c => new
                    {
                        TipDomainCodeSimpleTypeID = c.Int(nullable: false, identity: true),
                        FacetValue = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipDomainCodeSimpleTypeID);
            
            CreateTable(
                "dbo.VehicleColor",
                c => new
                    {
                        VehicleColorID = c.Int(nullable: false, identity: true),
                        ColorCode = c.String(nullable: false),
                        ColorName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleColorID);
            
            CreateTable(
                "dbo.VehicleMake",
                c => new
                    {
                        VehicleMakeID = c.Int(nullable: false, identity: true),
                        MakeCode = c.String(nullable: false),
                        MakeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleMakeID);
            
            CreateTable(
                "dbo.VehicleModel",
                c => new
                    {
                        VehicleModelID = c.Int(nullable: false, identity: true),
                        VehicleMakeID = c.Int(nullable: false),
                        ModelCode = c.String(nullable: false),
                        ModelName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleModelID)
                .ForeignKey("dbo.VehicleMake", t => t.VehicleMakeID)
                .Index(t => t.VehicleMakeID);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        GenderCode = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.HairColor",
                c => new
                    {
                        HairColorID = c.Int(nullable: false, identity: true),
                        HairColorCode = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HairColorID);
            
            CreateTable(
                "dbo.Height",
                c => new
                    {
                        HeightID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HeightID);
            
            CreateTable(
                "dbo.Nationality",
                c => new
                    {
                        NationalityID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NationalityID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        Suffix = c.String(),
                        LastName = c.String(nullable: false),
                        Age = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        HeightID = c.Int(),
                        WeightID = c.Int(),
                        HairColorID = c.Int(),
                        EyeColorID = c.Int(),
                        GenderID = c.Int(),
                        EthnicityID = c.Int(),
                        RaceID = c.Int(),
                        NationalityID = c.Int(),
                        SkinToneID = c.Int(),
                        Eyewear = c.String(),
                        FacialHair = c.String(),
                        PhysicalDescription = c.String(),
                        Alias = c.String(),
                        OtherInformation = c.String(),
                        SAR_SarID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ethnicity", t => t.EthnicityID)
                .ForeignKey("dbo.EyeColor", t => t.EyeColorID)
                .ForeignKey("dbo.Gender", t => t.GenderID)
                .ForeignKey("dbo.HairColor", t => t.HairColorID)
                .ForeignKey("dbo.Height", t => t.HeightID)
                .ForeignKey("dbo.Nationality", t => t.NationalityID)
                .ForeignKey("dbo.Race", t => t.RaceID)
                .ForeignKey("dbo.SAR", t => t.SAR_SarID)
                .ForeignKey("dbo.SkinTone", t => t.SkinToneID)
                .ForeignKey("dbo.Weight", t => t.WeightID)
                .Index(t => t.HeightID)
                .Index(t => t.WeightID)
                .Index(t => t.HairColorID)
                .Index(t => t.EyeColorID)
                .Index(t => t.GenderID)
                .Index(t => t.EthnicityID)
                .Index(t => t.RaceID)
                .Index(t => t.NationalityID)
                .Index(t => t.SkinToneID)
                .Index(t => t.SAR_SarID);
            
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        RaceID = c.Int(nullable: false, identity: true),
                        RaceCode = c.String(),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RaceID);
            
            CreateTable(
                "dbo.SkinTone",
                c => new
                    {
                        SkinToneID = c.Int(nullable: false, identity: true),
                        SkinToneCode = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SkinToneID);
            
            CreateTable(
                "dbo.Weight",
                c => new
                    {
                        WeightID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.WeightID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "WeightID", "dbo.Weight");
            DropForeignKey("dbo.Person", "SkinToneID", "dbo.SkinTone");
            DropForeignKey("dbo.Person", "SAR_SarID", "dbo.SAR");
            DropForeignKey("dbo.Person", "RaceID", "dbo.Race");
            DropForeignKey("dbo.Person", "NationalityID", "dbo.Nationality");
            DropForeignKey("dbo.Person", "HeightID", "dbo.Height");
            DropForeignKey("dbo.Person", "HairColorID", "dbo.HairColor");
            DropForeignKey("dbo.Person", "GenderID", "dbo.Gender");
            DropForeignKey("dbo.Person", "EyeColorID", "dbo.EyeColor");
            DropForeignKey("dbo.Person", "EthnicityID", "dbo.Ethnicity");
            DropForeignKey("dbo.Vehicle", "VehicleModelID", "dbo.VehicleModel");
            DropForeignKey("dbo.VehicleModel", "VehicleMakeID", "dbo.VehicleMake");
            DropForeignKey("dbo.Vehicle", "VehicleMakeID", "dbo.VehicleMake");
            DropForeignKey("dbo.Vehicle", "VehicleColorID", "dbo.VehicleColor");
            DropForeignKey("dbo.Vehicle", "StateAbbrev", "dbo.State");
            DropForeignKey("dbo.SarVehicle", "VehicleID", "dbo.Vehicle");
            DropForeignKey("dbo.SarVehicle", "SarID", "dbo.SAR");
            DropForeignKey("dbo.SAR", "TipDomainCodeSimpleTypeID", "dbo.TipDomainCodeSimpleType");
            DropForeignKey("dbo.SAR", "TipClassCodeSimpleTypeID", "dbo.TipClassCodeSimpleType");
            DropForeignKey("dbo.SAR", "TargetSectorCodeSimpleTypeID", "dbo.TargetSectorCodeSimpleType");
            DropForeignKey("dbo.SAR", "SuspiciousActivityCodeSimpleTypeID", "dbo.SuspiciousActivityCodeSimpleType");
            DropForeignKey("dbo.SAR", "StateAbbrev", "dbo.State");
            DropForeignKey("dbo.File", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.Person", new[] { "SAR_SarID" });
            DropIndex("dbo.Person", new[] { "SkinToneID" });
            DropIndex("dbo.Person", new[] { "NationalityID" });
            DropIndex("dbo.Person", new[] { "RaceID" });
            DropIndex("dbo.Person", new[] { "EthnicityID" });
            DropIndex("dbo.Person", new[] { "GenderID" });
            DropIndex("dbo.Person", new[] { "EyeColorID" });
            DropIndex("dbo.Person", new[] { "HairColorID" });
            DropIndex("dbo.Person", new[] { "WeightID" });
            DropIndex("dbo.Person", new[] { "HeightID" });
            DropIndex("dbo.VehicleModel", new[] { "VehicleMakeID" });
            DropIndex("dbo.SAR", new[] { "TipDomainCodeSimpleTypeID" });
            DropIndex("dbo.SAR", new[] { "TipClassCodeSimpleTypeID" });
            DropIndex("dbo.SAR", new[] { "TargetSectorCodeSimpleTypeID" });
            DropIndex("dbo.SAR", new[] { "SuspiciousActivityCodeSimpleTypeID" });
            DropIndex("dbo.SAR", new[] { "StateAbbrev" });
            DropIndex("dbo.SarVehicle", new[] { "VehicleID" });
            DropIndex("dbo.SarVehicle", new[] { "SarID" });
            DropIndex("dbo.Vehicle", new[] { "VehicleModelID" });
            DropIndex("dbo.Vehicle", new[] { "VehicleMakeID" });
            DropIndex("dbo.Vehicle", new[] { "VehicleColorID" });
            DropIndex("dbo.Vehicle", new[] { "StateAbbrev" });
            DropIndex("dbo.File", new[] { "VehicleId" });
            DropTable("dbo.Weight");
            DropTable("dbo.SkinTone");
            DropTable("dbo.Race");
            DropTable("dbo.Person");
            DropTable("dbo.Nationality");
            DropTable("dbo.Height");
            DropTable("dbo.HairColor");
            DropTable("dbo.Gender");
            DropTable("dbo.VehicleModel");
            DropTable("dbo.VehicleMake");
            DropTable("dbo.VehicleColor");
            DropTable("dbo.TipDomainCodeSimpleType");
            DropTable("dbo.TipClassCodeSimpleType");
            DropTable("dbo.TargetSectorCodeSimpleType");
            DropTable("dbo.SuspiciousActivityCodeSimpleType");
            DropTable("dbo.State");
            DropTable("dbo.SAR");
            DropTable("dbo.SarVehicle");
            DropTable("dbo.Vehicle");
            DropTable("dbo.File");
            DropTable("dbo.EyeColor");
            DropTable("dbo.Ethnicity");
        }
    }
}
