using Application.Shared.Results;
using Domain.DAL;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account.Enforcement;
using Microsoft.EntityFrameworkCore;

namespace Application.EnforcementEmployees.Commands.DeleteEmployee;
internal class DeleteEmployeeCommand : IDeleteEmployee
{
    private readonly DatabaseContext _dbContext;

    public DeleteEmployeeCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<string>> DeleteEmployeesByIdAsync(List<long> Ids)
    {
        foreach (long id in Ids) 
        {
            _dbContext.EnforcementEmployees.Entry(new EnforcementEmployee() { Id=id}).State = EntityState.Deleted;
        }
        try
        {
            await _dbContext.SaveChangesAsync();
            return new Result<string>()
            {
                IsSuccess = true,
                ResponseMessage = "Запись была удаленна из БД"
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
