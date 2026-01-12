using Application.EnforcementEmployees.Commands.UpdateEmployee.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Enforcement;

namespace Application.EnforcementEmployees.Commands.UpdateEmployee;
internal class UpdateEmployeeCommand : IUpdateEmployee
{
    private readonly DatabaseContext _dbContext;

    public UpdateEmployeeCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<string>> UpdateEmployeesAsync(List<UpdateEmployeeDto> dtos)
    {
        foreach (UpdateEmployeeDto dto in dtos) 
        {
            var domainModel = _dbContext.EnforcementEmployees.First(x => x.Id == dto.Id);
            // todo 1) Where - to get all list
            // 2) ChangeTracker - 
            UpdateEmployeeRecord(dto, domainModel);
        }
        try
        {
            await _dbContext.SaveChangesAsync();
            return new Result<string>()
            {
                IsSuccess = true,
                ResponseMessage = "Записи были успешно обновленны"
            };
        }
        catch (Exception ex) 
        {
            return new Result<string>()
            {
                IsSuccess = false,
                ResponseMessage = ex.Message
            };
        }
    }

    private static void UpdateEmployeeRecord(UpdateEmployeeDto dto, EnforcementEmployee enforcementEmployee) 
    {
        if (dto.Login != null) 
        {
            enforcementEmployee.Login = dto.Login;
        }
        if (dto.PassportNumber != null) 
        {
            enforcementEmployee.PassportNumber = dto.PassportNumber;
        }
        if (dto.Name != null) 
        {
            enforcementEmployee.Name = dto.Name;
        }
        if (dto.Surname != null)
        {
            enforcementEmployee.Surname = dto.Surname;
        }
        if (dto.Position != null) 
        {
            enforcementEmployee.Position = dto.Position;
        }
    }
}
