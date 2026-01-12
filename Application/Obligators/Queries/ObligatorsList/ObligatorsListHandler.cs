using Application.Obligators.Queries.ObligatorsList.DTOs;
using Domain.DAL;
using Domain.Entities.Account.Obligator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Obligators.Queries.Shared;
using System.Threading.Tasks;
using Application.Shared.Results;
using Application.Shared.Ordering;
using Application.Shared.Pagination;

namespace Application.Obligators.Queries.ObligatorsList;

/// <summary>
///     Список должников конкретного ЧСИ
/// </summary>
internal class ObligatorsListHandler : IObligatorsList
{
    private DatabaseContext _dbContext;

    public ObligatorsListHandler(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    ///     Получить список должников, используя: Фильтрацию, Сортировку, Пагинацию и 
    ///     конвертировать по DTO модель
    /// </summary>
    /// <param name="requestData"></param>
    /// <returns></returns>
    public async Task<Result<List<ObligatorsListDto>>> GetObligatorsAsync(ObligatorSortFilter requestData)
    {
        var filtered = ApplyFilters(requestData, _dbContext.Obligators.AsNoTracking());
        var sorted = ApplySorting(requestData, filtered);
        var paged = await ApplyPaging(requestData, sorted);
        return  ApplyMapping(paged);
    }

    private static IQueryable<ObligatorAccount> ApplyFilters(ObligatorSortFilter requestData, IQueryable<ObligatorAccount> obligatorsQuery)
    {
        if (requestData.MinDebAmount != null)
        {
            obligatorsQuery = obligatorsQuery.Where(x => x.DebtAmount >= requestData.MinDebAmount);
        }
        if (requestData.MaxDebtAmount != null)
        {
            obligatorsQuery = obligatorsQuery.Where(x => x.DebtAmount <= requestData.MaxDebtAmount);
        }
        if (requestData.Region != null)
        {
            obligatorsQuery = obligatorsQuery.Where(x => x.Region.ToLower() == requestData.Region.ToLower());
        }
        if (requestData.City != null)
        {
            obligatorsQuery = obligatorsQuery.Where(x => x.City.ToLower() == requestData.City.ToLower());
        }
        return obligatorsQuery;
    }

    private static IQueryable<ObligatorAccount> ApplySorting(ObligatorSortFilter requestData, IQueryable<ObligatorAccount> obligatorsQuery)
    {
        switch (requestData.SortField)
        {
            case SortObligatorEnum.ById:
                obligatorsQuery = OrderingExtension.Sort<ObligatorAccount, long>(obligatorsQuery, selector => selector.Id, requestData.SortByAscending);
                break;
            case SortObligatorEnum.ByDateTime:
                obligatorsQuery = OrderingExtension.Sort<ObligatorAccount, DateTime>(obligatorsQuery, selector => selector.CreationDateTime, requestData.SortByAscending);
                break;
            case SortObligatorEnum.ByName:
                obligatorsQuery = OrderingExtension.Sort<ObligatorAccount, string>(obligatorsQuery, selector => selector.Name, requestData.SortByAscending);
                break;
            case SortObligatorEnum.ByPassportNumber:
                obligatorsQuery = OrderingExtension.Sort<ObligatorAccount, string>(obligatorsQuery, selector => selector.PassportNumber, requestData.SortByAscending);
                break;
            case SortObligatorEnum.BySurname:
                obligatorsQuery = OrderingExtension.Sort<ObligatorAccount, string>(obligatorsQuery, selector => selector.Surname, requestData.SortByAscending);
                break;
            case SortObligatorEnum.ByDebt:
                obligatorsQuery = OrderingExtension.Sort<ObligatorAccount, decimal>(obligatorsQuery, selector => selector.DebtAmount, requestData.SortByAscending);
                break;
            case SortObligatorEnum.ByContractNumber:
                obligatorsQuery = OrderingExtension.Sort<ObligatorAccount, string>(obligatorsQuery, selector => selector.ObligationContractNumber, requestData.SortByAscending);
                break;
        }
        return obligatorsQuery;
    }

    private static async Task<List<ObligatorAccount>> ApplyPaging(ObligatorSortFilter requestData, IQueryable<ObligatorAccount> obligatorsQuery)
    {
        var paged = await PaginationExtension.ToPageAsync(obligatorsQuery, new Pagination(requestData.PageNumber, requestData.PageSize));
        return paged.Items;
    }

    private static Result<List<ObligatorsListDto>> ApplyMapping(IList<ObligatorAccount> obligatorsQuery)
    {
        try
        {
            var result = obligatorsQuery.Select(x => new ObligatorsListDto()
            {
                ObligatorId = x.Id,
                CreationDateTime = x.CreationDateTime,
                IsDeleted = x.IsDeleted,
                DebtAmount = x.DebtAmount,
                ContractNumber = x.ObligationContractNumber,
                Assets = x.ObligatorAssets.Select(x => new ObligatorAssetsModel()
                {
                    AssetDescription = x.DescriptionOfAsset,
                    AssetName = x.AssetName,
                    AssetValue = x.AssetValue
                }).ToList()
            }).ToList();

            return Result<List<ObligatorsListDto>>.Ok(result);        
        }
        catch (Exception ex) 
        {
            return Result<List<ObligatorsListDto>>.Fail(ex.Message);
        }
    }
}