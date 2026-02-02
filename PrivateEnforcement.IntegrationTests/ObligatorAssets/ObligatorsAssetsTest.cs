using Application.ObligatorAssets.Commands.CreateObligatorAsset;
using Application.ObligatorAssets.Commands.CreateObligatorAsset.DTOs;
using Microsoft.EntityFrameworkCore;
using PrivateEnforcement.IntegrationTests.API.TestSetUp;

namespace PrivateEnforcement.IntegrationTests.API.ObligatorAssets;
public class ObligatorsAssetsTest : BaseIntegrationTest
{
    public ObligatorsAssetsTest(TestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Create_ShouldAdd_NewObligatorAssetToDatabase()
    {
        // Arrange

        Console.WriteLine("TEST STARTED");

        var newAsset = new CreateObligatorAssetRequestDto
        {
            ObligatorId = 1,
            AssetName = "Car",
            EstimatedAssetValue = 444,
            AssetDescription = "Car"
        };

        Console.WriteLine("BEFORE COMMAND");

        // Act

        await _createObligatorAsset.CreateNewObligatorAssetCommandAsync(
            new List<CreateObligatorAssetRequestDto> { newAsset });

        Console.WriteLine("AFTER COMMAND");

        // Assert

        var dbResult = await _databaseContext.ObligatorsAssets
            .SingleOrDefaultAsync(x => x.AssetValue == 444);

        Console.WriteLine("AFTER QUERY");

        Assert.NotNull(dbResult);
    }

}
