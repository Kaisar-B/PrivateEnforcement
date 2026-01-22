using Application.Obligators.Commands.CreateObligator.DTOs;
using Application.Shared.Results;
using Domain.DAL;
using Domain.Entities.Account.Obligator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.CreateObligator;

/// <summary>
///     Command responsible for creating a new <see cref="ObligatorAccount"/> in the system.
/// </summary>
internal class CreateObligatorCommand : ICreateObligator
{
    private readonly DatabaseContext _dbContext;

    public CreateObligatorCommand(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<int>> CreateObligatorAsync(NewObligatorDto newObligator)
    {
        if (newObligator is null)
            return Result<int>.Fail("NewObligatorDto cannot be null.");

        var domainModel = ConvertDomainModel(newObligator);

        try
        {
            _dbContext.Add(domainModel);
            var rowCreated = await _dbContext.SaveChangesAsync();
            return Result<int>.Ok(rowCreated);
        }
        catch(Exception ex)
        {
            return Result<int>.Fail(ex.Message);
        }
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
