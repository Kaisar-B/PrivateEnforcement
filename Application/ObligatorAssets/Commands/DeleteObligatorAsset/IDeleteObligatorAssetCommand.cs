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
public interface IDeleteObligatorAssetCommand
{
    public Task<Result<Unit>> DeleteObligatorAssetAsync(long[] assetId);
}
