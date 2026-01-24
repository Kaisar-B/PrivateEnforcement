using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.DeleteObligatorAsset;

/// <summary>
///     Class for deleting obligator assets based on provided Id or list of Ids.
/// </summary>
internal class DeleteObligatorAssetCommand : IDeleteObligatorAsset
{
    private readonly DatabaseContext _dbContext;

    public DeleteObligatorAssetCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<(int deleted, int unmatched)>> DeleteObligatorAssetAsync(long[] assetIds)
    {
        try
        {
            var foundIdsDb = await _dbContext.ObligatorsAssets.Where(x => assetIds.Contains(x.Id)).CountAsync();
            var deleted = await _dbContext.ObligatorsAssets.Where(x => assetIds.Contains(x.Id)).ExecuteDeleteAsync();

            await _dbContext.SaveChangesAsync();

            return Result<(int deleted, int unmatched)>.Ok((deleted, assetIds.Count()-foundIdsDb));
        }
        catch(Exception ex)
        {
            return Result<(int deleted, int unmatched)>.Fail($"Возникла ошибка при запросе в БД, {ex.Message}");
        }


    }
}
