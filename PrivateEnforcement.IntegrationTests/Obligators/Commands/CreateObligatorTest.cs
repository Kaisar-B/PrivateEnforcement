using Application.Obligators.Commands.CreateObligator;
using Application.Obligators.Commands.CreateObligator.DTOs;
using PrivateEnforcement.IntegrationTests.TestSetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateEnforcement.IntegrationTests.Obligators.Commands;

[CollectionDefinition("Database collection")]
public class CreateObligatorTest
{
    public DatabaseFactoryFixture DatabaseFixture { get; set; }
    public CreateObligatorTest(DatabaseFactoryFixture database)
    {
        DatabaseFixture = database;
    }
    [Fact]
    public async Task CreateObligatorAsync_ValidDTO_SavesRecord()
    {
        using var dbContext = DatabaseFixture.CreateContext();
        var creator = new CreateObligatorCommand(dbContext);

        var dto = new NewObligatorDto() 
        {
            DebtAmount =1000,
            ObligationContractNumber = "435FF",
            City = "Almaty",
            Region = "Almaty",
            OwnerEnforcementAccountId=1,
            ObligatorAssets = new ObligatorAssetsDto[] {new ObligatorAssetsDto() { AssetName="Car", AssetValue = 4_000_000, DescriptionOfAsset="Car 2010 year" } }
        };

        await creator.CreateObligatorAsync(dto);
    } 
}
