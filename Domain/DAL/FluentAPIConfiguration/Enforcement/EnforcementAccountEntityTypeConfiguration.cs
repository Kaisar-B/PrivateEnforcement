using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Enforcement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.DAL.FluentAPIConfiguration.Enforcement;
internal class EnforcementAccountEntityTypeConfiguration : BaseAccountEntityTypeConfiguration<EnforcementAccount>
{
    public override void Configure(EntityTypeBuilder<EnforcementAccount> builder)
    {
        base.Configure(builder);
        // General table configurations

        // Property - Scalar configurations - table columns

        builder.Property(x => x.EnforcementName).IsRequired(true);
        builder.Property(x => x.EnforcementName).HasMaxLength(150);
        builder.Property(x => x.LicenseNumber).IsRequired(true);
        builder.Property(x => x.LicenseNumber).HasMaxLength(200);
        builder.Property(x => x.City).IsRequired(true);
        builder.Property(x => x.Country).HasMaxLength(100);
        builder.Property(x => x.Country).HasDefaultValue("KZ");
        builder.Property(x => x.Country).HasMaxLength(100);

        //  Relation configurations
        builder.HasMany(x => x.Employees).WithOne(x => x.EnforcementEmployer).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.Obligators).WithOne(x => x.OwnerEnforcementAccount).OnDelete(DeleteBehavior.Cascade);
    }
}
