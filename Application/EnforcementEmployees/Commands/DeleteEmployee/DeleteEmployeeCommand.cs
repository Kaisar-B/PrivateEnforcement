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

/// <summary>
///     Command responsible for deleting employees of private enforcement
///     by their identifiers.
/// </summary>
internal sealed class DeleteEmployeeCommand : IDeleteEmployee
{
    private readonly DatabaseContext _dbContext;

    /// <summary>
    ///     Initializes a new instance of <see cref="DeleteEmployeeCommand"/>.
    /// </summary>
    /// <param name="dbContext">Database context instance.</param>
    public DeleteEmployeeCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    ///     Deletes employees with the specified identifiers.
    /// </summary>
    /// <param name="Ids">
    ///     List of employee identifiers to be deleted.
    /// </param>
    /// <returns>
    ///     Result object containing information about the deletion operation.
    /// </returns>
    /// <summary>
    ///     Deletes employees using a single database command.
    /// </summary>
    public async Task<Result<string>> DeleteEmployeesByIdAsync(List<long> Ids)
    {
        if (Ids == null || Ids.Count == 0)
            return Result<string>.Fail("Список идентификаторов пуст.");

        try
        {
            var recordsDeleted = await _dbContext
                .EnforcementEmployees
                .Where(e => Ids.Contains(e.Id))
                .ExecuteDeleteAsync();

            return Result<string>.Ok(
                $"{recordsDeleted} - записей было удалено из БД");
        }
        catch (Exception ex)
        {
            return Result<string>.Fail(
                "Ошибка при удалении записей из базы данных.");
        }
    }

}
