using Application.Obligators.Queries.ObligatorsList.DTOs;
using Application.Obligators.Queries.Shared;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Queries.ObligatorsList;

/// <summary>
///     Интерфейс для получения списка должников
/// </summary>
public interface IObligatorsList
{
    public Task<Result<List<ObligatorsListDto>>> GetObligatorsAsync(ObligatorFilterSorting requestData);
}
