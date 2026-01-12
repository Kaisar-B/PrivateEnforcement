using Application.Obligators.Commands.UpdateObligator.DTOs;
using Application.Obligators.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.UpdateObligator;
internal class UpdateObligatorCommand : IUpdateObligator
{
    private readonly DatabaseContext _dbContext;

    public UpdateObligatorCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<string>> UpdateObligatorAsync(UpdateObligatorDto updateObligatorDto)
    {
        var dbAccount = await _dbContext.Obligators.Include(x=>x.ObligatorAssets).FirstOrDefaultAsync(x => x.Id == updateObligatorDto.Id);
        if (dbAccount != null)
        {
            UpdateDomainModel(updateObligatorDto, dbAccount);
            await _dbContext.SaveChangesAsync();
            return new Result<string>
            {
                IsSuccess = true,
                Message = "Не удалось обновить запись"
            };
        }
        else
        {
            return new Result<string>
            {
                IsSuccess = false,
                Message = "Обязатель с указанным Id не найден"
            };
        }
        
    }

    private void UpdateDomainModel(UpdateObligatorDto updateObligatorDto, ObligatorAccount dbAccount)
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
        if (updateObligatorDto.ObligatorAssets.Any())
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
