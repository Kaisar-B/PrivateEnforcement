using Application.Administration.Commands.CreateEnforcement;
using Application.Administration.Commands.CreateEnforcement.DTOs;
using Application.Administration.Commands.DeleteEnforcement.Block;
using Application.Administration.Commands.UpdateEnforcement;
using Application.Administration.Queries.EnforcementList;
using Application.Administration.Queries.EnforcementList.DTOs;
using Application.Administration.Queries.Shared;
using Application.Shared.Results;
using Domain.Entities.Account.Administration;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace PrivateEnforcement.API.Controllers.Administration;


/// <summary>
///     Controller for administration. Allows CRUD operations on Private Enforcement entities.
/// </summary>
[ApiController]
[Route("api/[controller]/enforcement")]
public class AdministrationController : ControllerBase
{
    private readonly ICreateEnforcement _create;
    private readonly IBlockEnforcement _block;
    private readonly IUpdateEnforcement _update;
    private readonly IEnforcementList _list;
    private readonly IValidator<CreateEnforcementRequestDto> _createValidator;
    private readonly IValidator<UpdateEnforcementRequestDto> _updateValidator;

    public AdministrationController(ICreateEnforcement create, IBlockEnforcement block, IUpdateEnforcement update, IEnforcementList list, IValidator<CreateEnforcementRequestDto> createValidator, IValidator<UpdateEnforcementRequestDto> updateValidator)
    {
        _create = create;
        _block = block;
        _update = update;
        _list = list;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateEnforcementAsync([FromBody] CreateEnforcementRequestDto dto)
    {
        ValidationResult validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return UnprocessableEntity(validationResult.ToDictionary());
        }

        Result<Unit> result = await _create.CreateEnforcementAsync(dto);
        if (result.IsSuccess)
        { 
            return Created();
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> BlockEnforcementAsync([FromQuery] long id)
    {
        Result<Unit> result = await _block.BlockEnforcementCommandAsync(id);
        if(result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpPatch("update")]
    public async Task<ActionResult> UpdateEnforcementAsync([FromBody] UpdateEnforcementRequestDto dto)
    {
        ValidationResult validationResult = await _updateValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return UnprocessableEntity(validationResult.ToDictionary());
        }
        Result<Unit> result = await _update.UpdateEnforcementCommandAsync(dto);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpGet("query")]
    public async Task<ActionResult<List<QueryEnforcementResponseDto>>> QueryEnforcementList([FromQuery] EnforcementFilterSorting dto)
    {
        Result<List<QueryEnforcementResponseDto>> result = await _list.QueryEnforcementListCommandAsync(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }
}
