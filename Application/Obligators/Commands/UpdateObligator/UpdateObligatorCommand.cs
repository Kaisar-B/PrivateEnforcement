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

namespace Application.Obligators.Commands.UpdateObligator;

/// <summary>
///     Command for updating record of obligator
/// </summary>
internal class UpdateObligatorCommand : IUpdateObligator
{
    private readonly DatabaseContext _dbContext;

    public UpdateObligatorCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int>> UpdateObligatorAsync(UpdateObligatorRequestDto updateObligatorDto)
    {
        try
        {
            var obligatorAccount = await _dbContext.Obligators.Include(x => x.ObligatorAssets).FirstOrDefaultAsync(x => x.Id == updateObligatorDto.Id);
            if (obligatorAccount != null)
            {
                UpdateDomainModel(updateObligatorDto, obligatorAccount);
                var rowsUpdated = await _dbContext.SaveChangesAsync();
                return Result<int>.Ok(rowsUpdated);
            }
            return Result<int>.Fail("Не был найден аккаунт должника для обновления с указанным id"); 
        }
        catch(Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
    }

    private void UpdateDomainModel(UpdateObligatorRequestDto updateObligatorDto, ObligatorAccount dbAccount)
    {
        if(updateObligatorDto.DebtAmount != null)
        {
            dbAccount.DebtAmount = updateObligatorDto.DebtAmount.Value;
        }
        if (!string.IsNullOrEmpty(updateObligatorDto.ContractNumber))
        {
            dbAccount.ObligationContractNumber = updateObligatorDto.ContractNumber;
        }
        if (!string.IsNullOrEmpty(updateObligatorDto.City))
        {
            dbAccount.City = updateObligatorDto.City;
        }
        if (!string.IsNullOrEmpty(updateObligatorDto.Region))
        {
            dbAccount.Region = updateObligatorDto.Region;
        }
        if (updateObligatorDto.ObligatorAssets != null && updateObligatorDto.ObligatorAssets.Any())
        {
            var updateIds = updateObligatorDto.ObligatorAssets.Select(x=> x.Id).ToHashSet();

            var assetsForUpdateDb = dbAccount.ObligatorAssets.Where(x=>updateIds.Contains(x.Id));

            foreach (var item in updateObligatorDto.ObligatorAssets)
            {
                var recordForUpdate = assetsForUpdateDb.First(x => x.Id == item.Id);
                if (item.AssetValue!=null)
                {
                    recordForUpdate.AssetValue = item.AssetValue.Value;
                }
                if (item.AssetName != null) 
                {
                    recordForUpdate.AssetName = item.AssetName;
                }
                if (item.DescriptionOfAsset != null) 
                {
                    recordForUpdate.DescriptionOfAsset = item.DescriptionOfAsset;
                }
            }
        }
    }
}
