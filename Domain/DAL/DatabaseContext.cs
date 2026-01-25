using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DAL.FluentAPIConfiguration.Administration;
using Domain.DAL.FluentAPIConfiguration.Enforcement;
using Domain.DAL.FluentAPIConfiguration.Obligator;
using Domain.Entities.Account.Administration;
using Domain.Entities.Account.Enforcement;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;

namespace Domain.DAL;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<AdministratorAccount> Administrators { get; set; }
    public DbSet<EnforcementAccount> Enforcements { get; set; }
    public DbSet<EnforcementEmployee> EnforcementEmployees { get; set; }
    public DbSet<ObligatorAccount> Obligators { get; set; }
    public DbSet<ObligatorAsset> ObligatorsAssets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AdministratorEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EnforcementAccountEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EnforcementEmployeeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ObligatorAccountEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ObligatorAssetEntityTypeConfiguration());
    }

}
