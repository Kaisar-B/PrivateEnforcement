using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Domain.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using Domain.Entities.Account.Enforcement;

namespace PrivateEnforcement.IntegrationTests.TestSetUp;
public class DatabaseFactoryFixture : IDisposable
{
    private readonly string _connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
    private static readonly object _locker = new();
    private static bool _dbWasInitilized = false;
    private DatabaseContext _dbContext;

    /// <summary>
    ///     Seeding data, password was "12345" based on Sha256.
    /// </summary>
    public DatabaseFactoryFixture()
    {
        lock (_locker) 
        {
            if (!_dbWasInitilized)
            {
                _dbContext = CreateContext();
                _dbContext.Database.EnsureDeleted();
                _dbContext.Database.EnsureCreated();
                _dbContext.AddRange(new EnforcementAccount[]
                {
                    new EnforcementAccount(){ Id=1, IsDeleted=false, PassportNumber="34353543", Name="Arman", Surname="Kulbaev", Login="arman@mplat.kz", Password="5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", EnforcementName="Arman ЧСИ", LicenseNumber="1234nn", City="Almaty", Country="Kz", Employees=null, Obligators=null}
                });
            }
            _dbWasInitilized= true;
        }
    }
    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public DatabaseContext CreateContext()
    {
        var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(_connectionString).Options);
        return context;
    }
}

[CollectionDefinition("Database collection")]
public class DatabaseCollection : ICollectionFixture<DatabaseFactoryFixture>
{
}
