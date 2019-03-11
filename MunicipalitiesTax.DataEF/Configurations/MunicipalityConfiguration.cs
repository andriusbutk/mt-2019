using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MunicipalitiesTax.Domain.Entities;

namespace MunicipalitiesTax.DataEF.Configurations
{
    public class MunicipalityConfiguration
    {
        public MunicipalityConfiguration(EntityTypeBuilder<Municipality> entity)
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
