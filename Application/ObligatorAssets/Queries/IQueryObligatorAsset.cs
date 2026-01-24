using Application.Shared.Results;
using Application.ObligatorAssets.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Queries;

/// <summary>
///     Query data related to Obligator assets.
/// </summary>
public interface IQueryObligatorAsset
{
    public Task<Result<List<ObligatorAssetDto>>> QueryObligatorsById(long[] ids);
}
