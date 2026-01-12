using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace Domain.DAL.FluentAPIConfiguration;
internal abstract class BaseAccountEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T: BaseAccount
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        // Table configurations

        // Property - Scalar configurations - table columns

        // BaseDomainModel
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreationDateTime).HasDefaultValueSql("getdate()");
        builder.HasQueryFilter(x => !x.IsDeleted);

        // BaseAccount
        builder.Property(x => x.PassportNumber).IsRequired(false);
        builder.Property(x => x.PassportNumber).HasMaxLength(50);
        builder.HasIndex(x => x.PassportNumber).IsUnique(true);
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Surname).IsRequired(false);
        builder.Property(x => x.Surname).HasMaxLength(50);
        builder.Property(x => x.Login).IsRequired(true);
        builder.HasIndex(x=>x.Login).IsUnique(true);
        builder.Property(x => x.Login).HasMaxLength(80);
        builder.Property(x => x.Password).HasMaxLength(100);
        builder.Property(x => x.Password).IsRequired(true);

        // Relations configurations
    }
}
