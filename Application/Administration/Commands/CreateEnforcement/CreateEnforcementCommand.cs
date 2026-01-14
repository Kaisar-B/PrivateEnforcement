using Application.Administration.Commands.CreateEnforcement.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Enforcement;
using Domain.Entities.Account.Obligator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement;

/// <summary>
///     Handles creation of an enforcement entity, including its employees and obligators (and his assets).
///     Maps the provided DTOs to domain models and saves them in the database.
/// </summary>
internal class CreateEnforcementCommand : ICreateEnforcement
{
    private readonly DatabaseContext _dbContext;

    public CreateEnforcementCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<Unit>> CreateEnforcementAsync(EnforcementCreateDto enforcementDto)
    {
        _dbContext.Enforcements.Add(MapToDomainModel(enforcementDto));
        await _dbContext.SaveChangesAsync();
        return Result<Unit>.Ok(Unit.ResultData);
    }

    private EnforcementAccount MapToDomainModel(EnforcementCreateDto dto)
    {
        return new EnforcementAccount()
        {
            EnforcementName = dto.EnforcementName,
            LicenseNumber = dto.LicenseNumber,
            City = dto.City,
            Country = dto.Country,
            Employees = dto.EnforcementEmployeesDto.Select(MapEmployee).ToList(),
            Obligators = dto.EnforcementObligatorsDto.Select(MapObligator).ToList(),
        };
    }

    private static EnforcementEmployee MapEmployee(EnforcementEmployeeDto x)
        => new EnforcementEmployee() {
            PassportNumber = x.PassportNumber,
            Name = x.Name,
            Surname = x.Surname,
            Login = x.Login,
            Password = x.Password,
            Position = x.Position
        };

    private static ObligatorAccount MapObligator(EnforcementObligatorDto x)
        => new ObligatorAccount() {
            PassportNumber = x.PassportNumber,
            Name = x.Name,
            Surname = x.Surname,
            DebtAmount = x.DebtAmount,
            ObligationContractNumber = x.ObligationContractNumber,
            City = x.City,
            Region = x.Region,
            ObligatorAssets = x.ObligatorAssetDtos.Select(y => new ObligatorAsset() { AssetName = y.AssetName, AssetValue = y.AssetValue, DescriptionOfAsset = y.DescriptionOfAsset }).ToList()
        };
}
