using Application.Obligators.Queries.ObligatorDetailedQuery.ObligatorAssets.DTOs;
using Application.Obligators.Queries.ObligatorDetailedQuery.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Queries.ObligatorDetailedQuery.ObligatorAssets;
public interface IObligatorAssets
{
    public Task<ObligatorDetailedQueryResult<string>> CreateAssetsAsync(AssetsDto dto);
    public Task<ObligatorDetailedQueryResult<string>> DeleteAssetsByIdAsync(List<long> Ids);
    public Task<ObligatorDetailedQueryResult<string>> UpdateAssetsInfoAsync(List<AssetsDto> assetsDtos);
    public Task<ObligatorDetailedQueryResult<List<AssetDetailedDto>>> GetAssetsAsync(List<long> Ids);
}
