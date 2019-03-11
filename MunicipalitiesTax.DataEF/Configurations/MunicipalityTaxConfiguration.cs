using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunicipalitiesTax.Domain.Entities;
using MunicipalitiesTax.Domain.Enums;

namespace MunicipalitiesTax.DataEF.Configurations
{
    public class MunicipalityTaxConfiguration
    {
        public MunicipalityTaxConfiguration(EntityTypeBuilder<MunicipalityTax> entity)
        {
            entity.HasOne(p => p.Municipality)
                .WithMany(b => b.Taxes)
                .HasForeignKey(p => p.MunicipalityId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.StartDate)
                .IsRequired();

            entity.Property(e => e.Value)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(e => e.TaxType)
                .IsRequired();
        }
    }
}
