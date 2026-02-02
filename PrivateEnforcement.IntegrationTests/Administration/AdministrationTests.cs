using Application.Administration.Commands.CreateEnforcement.DTOs;
using Application.Administration.Queries.Shared;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using PrivateEnforcement.IntegrationTests.API.TestSetUp;
using System.Net;
using System.Text;

namespace PrivateEnforcement.IntegrationTests.API.Administration;
public class AdministrationTests : BaseIntegrationTest
{
    private readonly HttpClient _httpClient;
    public AdministrationTests(TestWebAppFactory factory) : base(factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Create_ShouldAdd_NewEnforcementPartyToDb()
    {
        // Arrange
        var enforcementDto = new CreateEnforcementRequestDto
        {
            PassportNumber = "AA1234567",
            Name = "John",
            Surname = "Marshall",
            Login = "enforcement.admin",
            Password = "Admin@123",
            EnforcementName = "Central Enforcement Agency",
            LicenseNumber = "LIC-2024-001",
            City = "Berlin",
            Country = "Germany",

            EnforcementEmployeesDto = new List<EnforcementEmployeeDto>
            {
                new EnforcementEmployeeDto
                {
                    PassportNumber = "BB7654321",
                    Name = "Anna",
                    Surname = "Keller",
                    Login = "anna.keller",
                    Password = "Emp@123",
                    Position = "Senior Enforcement Officer"
                }
            },

            EnforcementObligatorsDto = new List<EnforcementObligatorDto>
            {
                new EnforcementObligatorDto
                {
                    PassportNumber = "CC9988776",
                    Name = "Michael",
                    Surname = "Brown",
                    Login = "michael.brown",
                    DebtAmount = 15000,
                    ObligationContractNumber = "CONTRACT-2024-009",
                    City = "Munich",
                    Region = "Bavaria",

                    ObligatorAssetDtos = new List<ObligatorAssetDto>
                    {
                        new ObligatorAssetDto
                        {
                            AssetName = "Toyota Camry",
                            AssetValue = 45044,
                            DescriptionOfAsset = "2019 Toyota Camry, black, good condition"
                        }
                    }
                }
            }
        };

        var payload = JsonConvert.SerializeObject(enforcementDto);
        var content = new StringContent(payload, Encoding.UTF8, "application/json");

        // Act
        var respone = await _httpClient.PostAsync("api/administration/enforcement/create", content);

        // Assert
        Assert.NotNull(respone);
    }

    [Fact]
    public async Task Delete_ShouldDelete_OldEnforcementFromDb()
    {
        // Arrange
        var id = 12;

        // Act
        var response = await _httpClient.DeleteAsync($"api/administration/enforcement/delete/{id}");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Update_ShouldUpdate_OldEnforcementinDb()
    {
        // Arrange
        var updateEnforcementRequest = new UpdateEnforcementRequestDto
        {
            EnforcementId = 12345,
            EnforcementName = "City Enforcement Authority",
            LicenseNumber = "LIC-987654",
            City = "New York",
            Country = "USA"
        };

        var payload = JsonConvert.SerializeObject(updateEnforcementRequest);

        var content = new StringContent(payload, Encoding.UTF8, "application/json");

        // Act
        var response = await _httpClient.PatchAsync("api/administration/enforcement/update", content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.True(response.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task Query_ShouldQuery_RecordsFromDb()
    {
        // Arrange 
        var enforcementFilterSorting = new EnforcementFilterSorting
        {
            EnforcementId = 12345,
            //LicenseNumber = "LIC-987654",
            //City = "New York",
            //Country = "USA",
            //SortByAscending = true,
        };

        // Act
        var response = await _httpClient.GetAsync("api/administration/enforcement/query?EnforcementId = 12345");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.True(response.StatusCode == HttpStatusCode.OK);
    }
}
