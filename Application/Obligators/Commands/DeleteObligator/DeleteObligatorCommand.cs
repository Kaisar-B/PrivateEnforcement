using Application.Obligators.Commands.DeleteObligator.DTOs;
using Application.Obligators.Shared.Results;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Obligator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.DeleteObligator;
public class DeleteObligatorCommand : IDeleteObligator
{
    private readonly DatabaseContext _dbContext;

    public DeleteObligatorCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<string>> DeleteObligatorAsync(DeleteObligatorDto dto)
    {
        var deleteObligator = DeleteObligatorByModel(dto);
        if (deleteObligator != null) 
        {
            _dbContext.Obligators.Remove(deleteObligator);
            await _dbContext.SaveChangesAsync();
            return new Result<string>()
            {
                IsSuccess = true,
                Message = "Запись была удаленна"
            };
        }
        return new Result<string>()
        {
            IsSuccess = false,
            Message = "Запись для удаления по указанным параметрам не была найденна в БД"
        };
    }

    public async Task<Result<string>> DeleteObligatorByIdAsync(long id)
    {
        var modelToRemove = _dbContext.Obligators.FirstOrDefault(x => x.Id == id);

        if (modelToRemove != null)
        {
            _dbContext.Remove(modelToRemove);
            await _dbContext.SaveChangesAsync();
            return new Result<string>()
            {
                IsSuccess = true,
                Message = "Запис была успешн удаленна"
            };
        }
        return new Result<string>()
        {
            IsSuccess = false,
            Message = $"Должник с указанным id {id} для удаление не был найден в БД"
        };
    }

    private ObligatorAccount? DeleteObligatorByModel(DeleteObligatorDto dto) 
    {
        if(dto.Id != null)
        {
            var deleteModel = _dbContext.Obligators.FirstOrDefault(x => x.Id == dto.Id);
            return deleteModel;
        }
        if (dto.PassportNumber != null)
        {
            var deleteModel = _dbContext.Obligators.FirstOrDefault(x => x.PassportNumber == dto.PassportNumber);
            return deleteModel;
        }
        if (dto.ContractNumber != null) 
        {
            var deleteModel = _dbContext.Obligators.FirstOrDefault(x=>x.ObligationContractNumber == dto.ContractNumber);
            return deleteModel;
        }
        return null;
    }
}
