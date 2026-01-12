using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace Domain.DAL.FluentAPIConfiguration.Obligator;
internal class ObligatorAssetEntityTypeConfiguration : IEntityTypeConfiguration<ObligatorAsset>
{
    public void Configure(EntityTypeBuilder<ObligatorAsset> builder)
    {
        // Table configurations 

        // Property - Scalar configurations - table columns
        builder.Property(x => x.AssetValue).IsRequired(true);
        builder.Property(x => x.AssetName).IsRequired(true);
        builder.Property(x => x.DescriptionOfAsset).HasMaxLength(20000).IsRequired(false);

        // Relation configurations
        builder.HasOne(x => x.OwnerObligatorAccount).WithMany(x => x.ObligatorAssets);
    }
}
