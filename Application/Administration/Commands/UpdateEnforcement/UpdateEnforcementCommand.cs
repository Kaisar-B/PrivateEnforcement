using Application.Administration.Commands.CreateEnforcement.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Enforcement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.UpdateEnforcement
{
    /// <summary>
    ///     Command to update an enforcement entity in the system.
    ///     Only properties that are not null in the <see cref="EnforcementUpdateDto"/> 
    ///     will be applied to the entity.
    /// </summary>
    internal class UpdateEnforcementCommand : IUpdateEnforcement
    {
        private readonly DatabaseContext _dbContext;

        public UpdateEnforcementCommand(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<Unit>> UpdateEnforcementCommandAsync(EnforcementUpdateDto enforcementUpdateDto)
        {
            var domainModel = await _dbContext.Enforcements.FirstOrDefaultAsync(x=>x.Id== enforcementUpdateDto.EnforcementId);
            if (domainModel == null) 
            {
                return Result<Unit>.Fail($"ЧСИ с указанным Id - {enforcementUpdateDto.EnforcementId} не существует");
            }
            ApplyUpdate(enforcementUpdateDto, domainModel);
            await _dbContext.SaveChangesAsync();
            return Result<Unit>.Ok(Unit.ResultData);
        }

        private void ApplyUpdate(EnforcementUpdateDto dto, EnforcementAccount enforcementDomain)
        {
            if (dto.EnforcementName != null)
            {
                enforcementDomain.EnforcementName = dto.EnforcementName;
            }
            if (dto.LicenseNumber != null) 
            {
                enforcementDomain.LicenseNumber = dto.LicenseNumber;
            }
            if (dto.City != null) 
            {
                enforcementDomain.City = dto.City;
            }
            if (dto.Country != null) 
            {
                enforcementDomain.Country = dto.Country;
            }
        }
    }
}
