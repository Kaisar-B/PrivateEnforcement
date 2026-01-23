using Application.Shared.Results;
using Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.DeleteObligatorAsset;
internal class DeleteObligatorAsset : IDeleteObligatorAssetCommand
{
    private readonly DatabaseContext _dbContext;

    public DeleteObligatorAsset(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Result<Unit>> DeleteObligatorAssetAsync(long[] assetId)
    {
        //todo retrive all related, then apply intersect or union, so you can determine how many was deleted.
    }
}
