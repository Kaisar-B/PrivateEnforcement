using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account;
using Domain.Entities.Account.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.DAL.FluentAPIConfiguration.Administration;

/// <summary>
///     Fluent API configs for Administrator account
/// </summary>
internal class AdministratorEntityTypeConfiguration : BaseAccountEntityTypeConfiguration<AdministratorAccount> 
{
    public override void Configure(EntityTypeBuilder<AdministratorAccount> builder)
    {
        // Base scalars config

        base.Configure(builder);

        // General table configurations

        // Property - Scalar configurations - table columns
        builder.Property(x => x.TelegramId).IsRequired(false);
        builder.Property(x => x.TelegramId).HasMaxLength(100);

        // Relation configurations
    }
}
