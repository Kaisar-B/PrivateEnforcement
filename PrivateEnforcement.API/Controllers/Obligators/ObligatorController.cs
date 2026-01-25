using Application.Obligators.Commands.CreateObligator;
using Application.Obligators.Commands.CreateObligator.DTOs;
using Application.Obligators.Commands.DeleteObligator;
using Application.Obligators.Commands.DeleteObligator.DTOs;
using Application.Obligators.Commands.UpdateObligator;
using Application.Obligators.Commands.UpdateObligator.DTOs;
using Application.Obligators.Queries.ObligatorsList;
using Application.Obligators.Queries.ObligatorsList.DTOs;
using Application.Obligators.Queries.Shared;
using Application.Shared.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PrivateEnforcement.API.Controllers.Obligators;


/// <summary>
///     Controller for CRUD operations over obligator party.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ObligatorController : ControllerBase
{
    private readonly ICreateObligator _create;
    private readonly IDeleteObligator _delete;
    private readonly IUpdateObligator _update;
    private readonly IObligatorsList _list;

    public ObligatorController(ICreateObligator create, IDeleteObligator delete, IUpdateObligator update, IObligatorsList list)
    {
        _create = create;
        _delete = delete;
        _update = update;
        _list = list;
    }

    [HttpPost]
    public async Task<ActionResult> CreateObligator([FromBody] NewObligatorDto dto)
    {
        Result<int> result = await _create.CreateObligatorAsync(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest();   
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteObligatorById([FromQuery] long id)
    {
        Result<int> result = await _delete.DeleteObligatorByIdAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteObligatorAsync([FromBody] DeleteObligatorDto dto)
    {
        Result<int> result = await _delete.DeleteObligatorAsync(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateObligatorAsync([FromBody] UpdateObligatorDto dto)
    {
        Result<int> result = await _update.UpdateObligatorAsync(dto);
        if (result.IsSuccess) 
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpGet]
    public async Task<ActionResult> QueryObligators([FromQuery] ObligatorFilterSorting dto)
    {
        Result<List<ObligatorsListDto>> result = await _list.GetObligatorsAsync(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage); 
    }
}
