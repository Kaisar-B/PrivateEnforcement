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
using Microsoft.AspNetCore.Mvc.Testing;
using PrivateEnforcement.API;

namespace PrivateEnforcement.IntegrationTests.API.TestSetUp;
public abstract class BaseIntegrationTest : IClassFixture<TestWebAppFactory>, IDisposable
{
    private readonly IServiceScope _serviceScope;
    protected readonly DatabaseContext _databaseContext;
    public BaseIntegrationTest(TestWebAppFactory factory)
    {
        _serviceScope = factory.Services.CreateScope();

        _databaseContext = _serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
    }

    public void Dispose()
    {
        _serviceScope.Dispose();
    }
}
