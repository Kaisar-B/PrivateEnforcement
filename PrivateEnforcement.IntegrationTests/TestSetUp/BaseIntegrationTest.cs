using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateEnforcement.IntegrationTests.API.TestSetUp;
public abstract class BaseIntegrationTest : IClassFixture<TestWebAppFactory>
{
    private readonly IServiceScope _serviceScope;
    public BaseIntegrationTest(TestWebAppFactory factory)
    {
        _serviceScope = factory.Services.CreateScope();
    }
}
