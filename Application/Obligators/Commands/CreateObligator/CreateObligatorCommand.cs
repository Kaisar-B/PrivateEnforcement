using Application.Obligators.Commands.CreateObligator.DTOs;
using Domain.DAL;
using Domain.Entities.Account.Obligator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.CreateObligator;
internal class CreateObligatorCommand : ICreateObligator
{
    private DatabaseContext _dbContext;

    public CreateObligatorCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateObligatorAsync(NewObligatorDto newObligator)
    {
        var domainModel = ConvertDomainModel(newObligator);

        _dbContext.Add(domainModel);
        await _dbContext.SaveChangesAsync();
    }

    private ObligatorAccount ConvertDomainModel(NewObligatorDto dto) 
    {
        return new ObligatorAccount()
        {
            DebtAmount = dto.DebtAmount,
            ObligationContractNumber = dto.ObligationContractNumber,
            City = dto.City,
            Region = dto.Region,
            //todo  - assign OwnerEnforcementAccountId - based on Context request
            ObligatorAssets = dto.ObligatorAssets
                .Select(x => new ObligatorAsset() 
                { 
                    AssetName = x.AssetName,
                    AssetValue = x.AssetValue,
                    CreationDateTime = DateTime.Now,
                    DescriptionOfAsset = x.DescriptionOfAsset
                    //todo assign asset`s owner (Private enforcement)
                }).ToList(),
        };
    }
}
