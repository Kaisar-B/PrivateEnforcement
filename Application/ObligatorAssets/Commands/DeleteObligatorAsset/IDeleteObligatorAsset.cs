using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.DeleteObligatorAsset;

/// <summary>
///     Interface for deleting obligator assets record in db
/// </summary>
public interface IDeleteObligatorAsset
{
    public Task<Result<(int deleted, int unmatched)>> DeleteObligatorAssetAsync(long[] assetId);
}
