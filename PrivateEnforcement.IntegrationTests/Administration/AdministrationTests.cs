
using Application.Administration.Commands.CreateEnforcement.DTOs;
using PrivateEnforcement.IntegrationTests.API.TestSetUp;

namespace PrivateEnforcement.IntegrationTests.API.Administration;
public class AdministrationTests : BaseIntegrationTest
{
    public AdministrationTests(TestWebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Create_ShouldAdd_NewEnforcementPartyToDb()
    {
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

        _createEnforcement.CreateEnforcementAsync(enforcementDto);

        var dbResult = _databaseContext.Enforcements.SingleOrDefault(x => x.PassportNumber == "AA1234567");

        Assert.Equal(dbResult.PassportNumber, enforcementDto.PassportNumber);
    }
}
