using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Administration.Commands.CreateEnforcement;
using Application.ObligatorAssets.Commands.CreateObligatorAsset;
using Domain.DAL;
using Microsoft.EntityFrameworkCore;

namespace PrivateEnforcement.IntegrationTests.API.TestSetUp;
public abstract class BaseIntegrationTest : IClassFixture<TestWebAppFactory>
{
    private readonly IServiceScope _serviceScope;
    protected readonly ICreateObligatorAsset _createObligatorAsset;
    protected readonly ICreateEnforcement _createEnforcement;
    protected readonly DatabaseContext _databaseContext;
    protected BaseIntegrationTest(TestWebAppFactory factory)
    {
        _serviceScope = factory.Services.CreateScope();

        _databaseContext = _serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

        _databaseContext.Database.EnsureDeleted();
        _databaseContext.Database.EnsureCreated();

        _createObligatorAsset = _serviceScope.ServiceProvider.GetRequiredService<ICreateObligatorAsset>();
        _createEnforcement = _serviceScope.ServiceProvider.GetRequiredService<ICreateEnforcement>();
    }
}
