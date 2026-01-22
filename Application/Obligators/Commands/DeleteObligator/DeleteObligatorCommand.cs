using Application.Obligators.Commands.DeleteObligator.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.DeleteObligator;

/// <summary>
///     Command responsible for deleting <see cref="ObligatorAccount"/> records.
/// </summary>
public class DeleteObligatorCommand : IDeleteObligator
{
    private readonly DatabaseContext _dbContext;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DeleteObligatorCommand"/> class.
    /// </summary>
    /// <param name="dbContext">Database context used for data access.</param>
    public DeleteObligatorCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    ///     Deletes an obligator using identification data provided in the DTO.
    ///     The deletion is performed using the first non-null identifier
    ///     (Id, PassportNumber, or ContractNumber).
    /// </summary>
    /// <param name="dto">DTO containing delete criteria.</param>
    /// <returns>
    ///     A <see cref="Result{T}"/> containing the number of deleted rows,
    ///     or an error message if no matching record is found.
    /// </returns>
    public async Task<Result<int>> DeleteObligatorAsync(DeleteObligatorDto dto)
    {
        var deleteObligator = await DeleteObligatorByModel(dto);
        if (deleteObligator != null) 
        {
            _dbContext.Obligators.Remove(deleteObligator);
            var deletedRows = await _dbContext.SaveChangesAsync();
            return Result<int>.Ok(deletedRows);
        }
        return Result<int>.Fail("Запись для удаления по указанным параметрами не была найдена в БД");
    }

    /// <summary>
    ///     Deletes an obligator by its unique identifier.
    /// </summary>
    /// <param name="id">Obligator identifier.</param>
    /// <returns>
    ///     A <see cref="Result{T}"/> containing the number of deleted rows,
    ///     or an error message if the record is not found.
    /// </returns>
    public async Task<Result<int>> DeleteObligatorByIdAsync(long id)
    {
        var modelToRemove = _dbContext.Obligators.FirstOrDefault(x => x.Id == id);

        if (modelToRemove != null)
        {
            _dbContext.Remove(modelToRemove);
            var deletedRows = await _dbContext.SaveChangesAsync();
            return Result<int>.Ok(deletedRows);
        }
        return Result<int>.Fail("Запись для удаления по указанным параметрам не была найдена в БД");
    }

    private async Task<ObligatorAccount?> DeleteObligatorByModel(DeleteObligatorDto dto) 
    {
        if(dto.Id != null)
        {
            var deleteModel = await _dbContext.Obligators.FirstOrDefaultAsync(x => x.Id == dto.Id);
            return deleteModel;
        }
        if (dto.PassportNumber != null)
        {
            var deleteModel = await _dbContext.Obligators.FirstOrDefaultAsync(x => x.PassportNumber == dto.PassportNumber);
            return deleteModel;
        }
        if (dto.ContractNumber != null) 
        {
            var deleteModel = await _dbContext.Obligators.FirstOrDefaultAsync(x=>x.ObligationContractNumber == dto.ContractNumber);
            return deleteModel;
        }
        return null;
    }
}
