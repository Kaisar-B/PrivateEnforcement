using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Enforcement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.DAL.FluentAPIConfiguration.Enforcement;
internal class EnforcementEmployeeEntityTypeConfiguration : BaseAccountEntityTypeConfiguration<EnforcementEmployee>
{
    public override void Configure(EntityTypeBuilder<EnforcementEmployee> builder)
    {
        base.Configure(builder);

        // General table configurations 

        // Property - Scalar configurations - table columns
        builder.HasOne(x => x.EnforcementEmployer)
            .WithMany(x => x.Employees)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Position).IsRequired(true);
        builder.Property(x => x.Position).HasMaxLength(100); 

        // Relation configurations
        builder.HasOne(x => x.EnforcementEmployer)
            .WithMany(x => x.Employees)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
