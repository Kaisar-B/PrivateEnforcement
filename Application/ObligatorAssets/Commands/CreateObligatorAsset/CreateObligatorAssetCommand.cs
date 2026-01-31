using Application.ObligatorAssets.Commands.CreateObligatorAsset.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Obligator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.CreateObligatorAsset;

/// <summary>
///     Command for creating new obligator asset model.
/// </summary>
public class CreateObligatorAssetCommand : ICreateObligatorAsset
{
    private readonly DatabaseContext _dbContext;

    public CreateObligatorAssetCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<Unit>> CreateNewObligatorAssetCommandAsync(List<CreateObligatorAssetRequestDto> dto)
    {
        try
        {
            var domainModels = ConvertToDomainModel(dto);
            _dbContext.ObligatorsAssets.AddRange(domainModels);
            await _dbContext.SaveChangesAsync();
            return Result<Unit>.Ok(Unit.ResultData);
        }
        catch (Exception ex) 
        {
            return Result<Unit>.Fail($"Ошибка при запросе в БД, {ex.Message}");
        }
    }

    private static ObligatorAsset[] ConvertToDomainModel(List<CreateObligatorAssetRequestDto> dto)
    {
        return dto.Select(x=> new ObligatorAsset() { AssetValue = x.EstimatedAssetValue, AssetName = x.AssetName, DescriptionOfAsset = x.AssetDescription, OwnerObligatorAccountId = x.ObligatorId }).ToArray();
    }
}
