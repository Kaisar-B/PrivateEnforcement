using Application.Employees.Commands.CreateEmployee.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Enforcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Commands.CreateEmployee;
public class CreateEmployeeCommand : ICreateEmployee
{
    private readonly DatabaseContext _dbContext;

    public CreateEmployeeCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<string>> CreateEmployeesAsync(List<CreateEmployeeDto> dto)
    {
        var domainModels = dto.Select(x =>
            new EnforcementEmployee()
            {
                PassportNumber = x.PassportNumber,
                Name = x.Name,
                Surname = x.Surname,
                Login = x.Login,
                Position = x.Position
            });
        _dbContext.EnforcementEmployees.AddRange(domainModels);

        try
        {
            await _dbContext.SaveChangesAsync();
            return new Result<string>()
            {
                IsSuccess = true,
                ResponseMessage = "Работник/и был создан в БД"
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
}
