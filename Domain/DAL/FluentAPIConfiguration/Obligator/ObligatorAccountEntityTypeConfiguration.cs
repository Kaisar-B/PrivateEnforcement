using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.DAL.FluentAPIConfiguration.Obligator;
internal class ObligatorAccountEntityTypeConfiguration : BaseAccountEntityTypeConfiguration<ObligatorAccount>
{
    public override void Configure(EntityTypeBuilder<ObligatorAccount> builder)
    {
        base.Configure(builder);

        // General table configurations 

        // Property - Scalar configurations - table columns
        builder.Property(x => x.DebtAmount).IsRequired(false);
        builder.Property(X => X.ObligationContractNumber).HasMaxLength(200);
        builder.HasIndex(x => x.ObligationContractNumber).IsUnique(true);
        builder.Ignore(x => x.Login);
        builder.Ignore(x => x.Password);

        // Relation configurations
        builder.HasMany(x => x.ObligatorAssets)
            .WithOne(x => x.OwnerObligatorAccount)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.OwnerEnforcementAccount)
            .WithMany(x => x.Obligators)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
