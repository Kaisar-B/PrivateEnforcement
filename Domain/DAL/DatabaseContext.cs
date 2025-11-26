using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Administration;
using Domain.Entities.Account.Enforcement;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;

namespace Domain.DAL;
internal class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AdministratorAccount> Administrators { get; set; }
    public DbSet<EnforcementAccount> Enforcements { get; set; }
    public DbSet<ObligatorAccount> Obligators { get; set; }
    public DbSet<ObligatorAssets> ObligatorsAssets { get; set; }

}
