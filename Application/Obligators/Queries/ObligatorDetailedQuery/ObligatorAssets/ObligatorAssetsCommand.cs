using Application.Obligators.Queries.ObligatorDetailedQuery.ObligatorAssets.DTOs;
using Application.Obligators.Queries.ObligatorDetailedQuery.Shared;
using Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Obligators.Queries.ObligatorDetailedQuery.ObligatorAssets;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;

namespace Application.Obligators.Queries.ObligatorDetailedQuery.ObligatorAssets;
public class ObligatorAssetsCommand : IObligatorAssets
{
    private readonly DatabaseContext _dbContext;

    public ObligatorAssetsCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ObligatorDetailedQueryResult<string>> CreateAssetsAsync(AssetsDto dto)
    {
        var domainModel = new ObligatorAsset()
        {
            AssetName = dto.AssetName,
            AssetValue = dto.AssetValue,
            DescriptionOfAsset = dto.AssetDescription,
            OwnerObligatorAccountId = dto.ObligatorId
        };
        
        _dbContext.ObligatorsAssets.Add(domainModel);
        await _dbContext.SaveChangesAsync();
        return new ObligatorDetailedQueryResult<string>()
        {
            IsSuccess = true,
            Message = "Актив был успешно добавлен"
        };
    }

    public async Task<ObligatorDetailedQueryResult<string>> DeleteAssetsByIdAsync(List<long> Ids)
    {
        try
        {
            int deletedRecords = await _dbContext.ObligatorsAssets.Where(x => Ids.Contains(x.Id)).ExecuteDeleteAsync();
            if (deletedRecords == Ids.Count) 
            {
                return new ObligatorDetailedQueryResult<string>()
                {
                    IsSuccess = true,
                    Message = "Все запрошенные активы для удаления были успешно удаленны"
                };
            }
            return new ObligatorDetailedQueryResult<string>()
            {
                IsSuccess = true,
                Message = "Не все запрошенные активы для удаления были удаленны"
            };
        }
        catch (Exception ex) 
        {
            return new ObligatorDetailedQueryResult<string>
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }

    public async Task<ObligatorDetailedQueryResult<List<AssetDetailedDto>>> GetAssetsAsync(List<long> Ids)
    {
        var responseModel = await _dbContext.ObligatorsAssets.Where(x => Ids.Contains(x.Id)).ToListAsync().Select(x => new AssetDetailedDto()
        {
            Id = x.Id,
            AssetName = x.AssetName,
            AssetDescription = x.DescriptionOfAsset,
            AssetValue = x.AssetValue,
            CreationDateTime = x.CreationDateTime,
            OwnerObligator = x.OwnerObligatorAccount.Id
        }); ;

        return new ObligatorDetailedQueryResult<List<AssetDetailedDto>>()
        {
            IsSuccess = true,
            Message = "Операция успешно была завершенна",
            Result = responseModel
        };
    }

    public async Task<ObligatorDetailedQueryResult<string>> UpdateAssetsInfoAsync(List<AssetsDto> assetsDtos)
    {
        var dbRecords = await _dbContext.ObligatorsAssets.Where(x=>assetsDtos.Select(dto=>dto.Id).Contains(x.Id)).ToListAsync();

        foreach(var assetDto in assetsDtos)
        {
            var updateRecord = dbRecords.Where(x=>x.Id == assetDto.Id).First();
            UpdateRecord(assetDto, updateRecord);
        }
        await _dbContext.SaveChangesAsync();
        return new ObligatorDetailedQueryResult<string>()
        {
            IsSuccess = true,
            Message = "Записи были успешно обновленны"
        };
    }

    private void UpdateRecord(AssetsDto assetDto, ObligatorAsset obligatorAsset)
    {
        if (assetDto.AssetName != null)
        {
            obligatorAsset.AssetName = assetDto.AssetName;
        }
        if(assetDto.AssetDescription != null)
        {
            obligatorAsset.DescriptionOfAsset = assetDto.AssetDescription;
        }
        if(assetDto.AssetValue.HasValue)
        {
            obligatorAsset.AssetValue = assetDto.AssetValue.Value;
        }
    }
}
