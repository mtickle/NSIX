using NSIX.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NSIX.DAL
{
    public class NSIXContext : DbContext
    {

        //--- This sets the connection string
        public NSIXContext() : base("NSIXContext")
        {
        }

        public DbSet<SAR> SarActivities { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<SuspiciousActivityCodeSimpleType> SuspiciousActivityCodeSimpleType { get; set; }
        public DbSet<TargetSectorCodeSimpleType> TargetSectorCodeSimpleType { get; set; }
        public DbSet<TipClassCodeSimpleType> TipClassCodeSimpleType { get; set;  }
        public DbSet<TipDomainCodeSimpleType> TipDomainCodeSimpleType { get; set; }
        public DbSet<Height> Height { get; set; }
        public DbSet<Weight> Weight { get; set; }
        public DbSet<EyeColor> EyeColor { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<HairColor> HairColor { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<SkinTone> SkinTone { get; set; }
        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<VehicleColor> VehicleColor { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Ethnicity> Ethnicity { get; set; }
        public DbSet<SarVehicle> SarVehicles { get; set; }
        public DbSet<File> Files { get; set; }
        //public DbSet<FilePath> FilePaths { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
    
    }