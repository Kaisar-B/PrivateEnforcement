using Application.ObligatorAssets.Commands.CreateObligatorAsset;
using Application.ObligatorAssets.Commands.CreateObligatorAsset.DTOs;
using Application.ObligatorAssets.Commands.DeleteObligatorAsset;
using Application.ObligatorAssets.Commands.UpdateObligatorAsset;
using Application.ObligatorAssets.Commands.UpdateObligatorAsset.DTOs;
using Application.ObligatorAssets.Queries;
using Application.Shared.Results;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ObligatorAssetsDtoUpdate = Application.Obligators.Commands.UpdateObligator.DTOs;
using QueryDtoDirection = Application.ObligatorAssets.Queries.DTOs;

namespace PrivateEnforcement.API.Controllers.ObligatorAssets;

/// <summary>
///     Controller operates CRUD operations on obligator assets.
/// </summary>
[ApiController]
[Route("api/obligator-asset/")]
public class ObligatorAssetsController : ControllerBase
{
    private readonly ICreateObligatorAsset _create;
    private readonly IDeleteObligatorAsset _delete;
    private readonly IUpdateObligatorAsset _update;
    private readonly IQueryObligatorAsset _query;
    private readonly IValidator<List<CreateObligatorAssetRequestDto>> _createValidator;
    private readonly IValidator<UpdateObligatorAssetRequestDto> _updateValidator;

    public ObligatorAssetsController(ICreateObligatorAsset create, IDeleteObligatorAsset delete, IUpdateObligatorAsset update, IQueryObligatorAsset query, IValidator<List<CreateObligatorAssetRequestDto>> createValidator, IValidator<UpdateObligatorAssetRequestDto> updateValidator)
    {
        _create = create;
        _delete = delete;
        _update = update;
        _query = query;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateObligatorAsset([FromBody]List<CreateObligatorAssetRequestDto> dto)
    {
        ValidationResult validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid) 
        {
            return UnprocessableEntity(validationResult.ToDictionary());
        }

        Result<Unit> result = await _create.CreateNewObligatorAssetCommandAsync(dto);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteObligatorAsset([FromBody] long[] dto)
    {
        Result<(int deleted, int unmatched)> result = await _delete.DeleteObligatorAssetAsync(dto);
        if (result.IsSuccess)
        {
            return Ok($"Deleted - {result.ResultData.deleted}. Unmatched - {result.ResultData.unmatched}");
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpPatch("update")]
    public async Task<ActionResult> UpdateObligatorAsset([FromBody]UpdateObligatorAssetRequestDto dto)
    {
        ValidationResult validationResult = await _updateValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return UnprocessableEntity(validationResult.ToDictionary());
        }

        Result<string> result = await _update.UpdateObligatorAssetCommand(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpGet("query")]
    public async Task<ActionResult> QueryObligatorsList([FromQuery] long[] dto)
    {
        Result<List<QueryDtoDirection.QueryObligatorAssetResponseDto>> result = await _query.QueryObligatorsById(dto);
        if (result.IsSuccess) 
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }
}
