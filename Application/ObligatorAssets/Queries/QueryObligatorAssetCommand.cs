using Application.ObligatorAssets.Queries.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Queries;

/// <summary>
///     Command that queries obligator assets from DB.
/// </summary>
internal class QueryObligatorAssetCommand : IQueryObligatorAsset
{
    private readonly DatabaseContext _dbContext;

    public QueryObligatorAssetCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<List<ObligatorAssetDto>>> QueryObligatorsById(long[] ids)
    {
        try
        {
            var obligatorAssets = _dbContext.ObligatorsAssets.Where(x => ids.Contains(x.Id));
            if (!obligatorAssets.Any()) 
            {
                return Result<List<ObligatorAssetDto>>.Fail("Записи с указанным id не были найденны в БД");
            }
            var dtoConverted = await obligatorAssets.Select(x => new ObligatorAssetDto() { Id = x.Id, Name = x.AssetName, Description = x.DescriptionOfAsset, AssetsValue = x.AssetValue }).ToListAsync();

            return Result<List<ObligatorAssetDto>>.Ok(dtoConverted);
        }
        catch(Exception ex)
        {
            return Result<List<ObligatorAssetDto>>.Fail("Возникла ошибка при запросы в БД");
        }
    }
}
