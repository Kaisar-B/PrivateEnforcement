using Application.EnforcementEmployees.Commands.UpdateEmployee.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Enforcement;
using Microsoft.EntityFrameworkCore;

namespace Application.EnforcementEmployees.Commands.UpdateEmployee;

/// <summary>
///     Command responsible for updating employee records
///     of private enforcement.
/// </summary>

public class UpdateEmployeeCommand : IUpdateEmployee
{
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    ///     Initializes a new instance of <see cref="UpdateEmployeeCommand"/>.
    /// </summary>
    /// <param name="dbContext">Database context.</param>

    public UpdateEmployeeCommand(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    /// <summary>
    ///     Updates employees based on provided DTOs.
    ///     Only non-null DTO properties are applied.
    /// </summary>
    /// <param name="dtos">List of update DTOs.</param>
    /// <returns>
    ///     Result containing information about update operation.
    /// </returns>
    public async Task<Result<string>> UpdateEmployeesAsync(List<UpdateEnforcementEmployeeRequestDto> dtos)
    {
        try
        {
            var domainsToUpdate = await _databaseContext.EnforcementEmployees.Where(x => dtos.Select(y => y.Id).Contains(x.Id))
            .ToListAsync();

            var dictionaryDomain = domainsToUpdate.ToDictionary(x => x.Id, x=>x);

            int updatedEntitiesCount = 0;

            foreach (var dto in dtos)
            {
                if (!dictionaryDomain.TryGetValue(dto.Id, out var employee))
                {
                    continue;
                }

                var updated = UpdateEmployeeRecord(dto, employee);
                if (updated)
                    updatedEntitiesCount++;
            }

            await _databaseContext.SaveChangesAsync();
            return Result<string>.Ok($"{updatedEntitiesCount} - записей были успешно обновлены");

        }
        catch (Exception ex)
        {
            return Result<string>.Fail(
                "Произошла ошибка в момент обновления записей в БД");

        }

    }

    /// <summary>
    ///     Applies DTO values to the domain model.
    /// </summary>
    /// <param name="dto">Update DTO.</param>
    /// <param name="enforcementEmployee">Employee entity.</param>
    /// <returns>
    ///     True if at least one property was updated.
    /// </returns>
    private static bool UpdateEmployeeRecord(
        UpdateEnforcementEmployeeRequestDto dto,
        EnforcementEmployee enforcementEmployee)
    {
        bool updated = false;

        if (dto.Login != null && dto.Login != enforcementEmployee.Login)
        {
            enforcementEmployee.Login = dto.Login;
            updated = true;
        }

        if (dto.PassportNumber != null &&
            dto.PassportNumber != enforcementEmployee.PassportNumber)
        {
            enforcementEmployee.PassportNumber = dto.PassportNumber;
            updated = true;
        }

        if (dto.Name != null && dto.Name != enforcementEmployee.Name)
        {
            enforcementEmployee.Name = dto.Name;
            updated = true;
        }

        if (dto.Surname != null && dto.Surname != enforcementEmployee.Surname)
        {
            enforcementEmployee.Surname = dto.Surname;
            updated = true;
        }

        if (dto.Position != null && dto.Position != enforcementEmployee.Position)
        {
            enforcementEmployee.Position = dto.Position;
            updated = true;
        }

        return updated;
    }
}
