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
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PrivateEnforcement.API.Controllers.Obligators;


/// <summary>
///     Controller for CRUD operations over obligator party.
/// </summary>
[ApiController]
[Route("api/[controller]/")]
public class ObligatorController : ControllerBase
{
    private readonly ICreateObligator _create;
    private readonly IDeleteObligator _delete;
    private readonly IUpdateObligator _update;
    private readonly IObligatorsList _list;
    private readonly IValidator<CreateObligatorRequestDto> _createValidator;
    private readonly IValidator<UpdateObligatorRequestDto> _updateValidator;

    public ObligatorController(ICreateObligator create, IDeleteObligator delete, IUpdateObligator update, IObligatorsList list, IValidator<CreateObligatorRequestDto> createValidator, IValidator<UpdateObligatorRequestDto> updateValidator)
    {
        _create = create;
        _delete = delete;
        _update = update;
        _list = list;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateObligator([FromBody] CreateObligatorRequestDto dto)
    {
        ValidationResult validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid) 
        {
            return UnprocessableEntity(validationResult.ToDictionary());
        }

        Result<int> result = await _create.CreateObligatorAsync(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest();   
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteObligatorById([FromQuery] long id)
    {
        Result<int> result = await _delete.DeleteObligatorByIdAsync(id);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest();
    }

    [HttpDelete("group/delete")]
    public async Task<ActionResult> DeleteObligatorAsync([FromBody] DeleteObligatorRequestDto dto)
    {
        Result<int> result = await _delete.DeleteObligatorAsync(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpPatch("update")]
    public async Task<ActionResult> UpdateObligatorAsync([FromBody] UpdateObligatorRequestDto dto)
    {
        ValidationResult validationResult = await _updateValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return UnprocessableEntity(validationResult.ToDictionary());
        }

        Result<int> result = await _update.UpdateObligatorAsync(dto);
        if (result.IsSuccess) 
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpGet("query")]
    public async Task<ActionResult> QueryObligators([FromQuery] ObligatorFilterSorting dto)
    {
        Result<List<QueryObligatorsListResponseDto>> result = await _list.GetObligatorsAsync(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage); 
    }
}
