using Microsoft.EntityFrameworkCore;
using MunicipalitiesTax.DataEF.Configurations;
using MunicipalitiesTax.Domain.Entities;

namespace MunicipalitiesTax.DataEF.Context
{
    public class MunicipalityContext : DbContext
    {
        public static long InstanceCount;

        public virtual DbSet<Municipality> Municipalities { get; set; }

        public virtual DbSet<MunicipalityTax> MuniciaplitiesTaxes { get; set; }

        public MunicipalityContext(DbContextOptions<MunicipalityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new MunicipalityConfiguration(modelBuilder.Entity<Municipality>());
            new MunicipalityTaxConfiguration(modelBuilder.Entity<MunicipalityTax>());
        }
    }
}
