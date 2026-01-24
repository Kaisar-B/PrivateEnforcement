using Application.Obligators.Commands.UpdateObligator.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.UpdateObligatorAsset;

/// <summary>
///     Command for updating obligator assets record.
/// </summary>
internal class UpdateObligatorCommandAsync : IUpdateObligator
{
    private readonly DatabaseContext _dbContext;
    public UpdateObligatorCommandAsync(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<string>> UpdateObligatorAssetCommand(ObligatorAssetsDto dto)
    {
        var domainToUpdate = await _dbContext.ObligatorsAssets.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if(domainToUpdate != null)
        {
            if(dto.AssetValue.HasValue)
            {
                domainToUpdate.AssetValue = dto.AssetValue.Value;
            }
            if (!string.IsNullOrEmpty(dto.AssetName))
            {
                domainToUpdate.AssetName = dto.AssetName;
            }
            if (!string.IsNullOrEmpty(dto.DescriptionOfAsset))
            {
                domainToUpdate.DescriptionOfAsset = dto.DescriptionOfAsset;
            }
            try
            {
                await _dbContext.SaveChangesAsync();
                return Result<string>.Ok("Запись успешно обновлена");
            }
            catch (Exception ex) 
            {
                return Result<string>.Fail(ex.Message);
            }
        }
        return Result<string>.Fail("Запись не была найдена в БД");
    }
}
