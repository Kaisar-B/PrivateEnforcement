using Application.ObligatorAssets.Commands.CreateObligatorAsset;
using Application.ObligatorAssets.Commands.CreateObligatorAsset.DTOs;
using Application.ObligatorAssets.Commands.DeleteObligatorAsset;
using Application.ObligatorAssets.Commands.UpdateObligatorAsset;
using Application.ObligatorAssets.Queries;
using Application.Shared.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using QueryDtoDirection = Application.ObligatorAssets.Queries.DTOs;
using ObligatorAssetsDtoUpdate = Application.Obligators.Commands.UpdateObligator.DTOs;

namespace PrivateEnforcement.API.Controllers.ObligatorAssets;

/// <summary>
///     Controller operates CRUD operations on obligator assets.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ObligatorAssetsController : ControllerBase
{
    private readonly ICreateObligatorAsset _create;
    private readonly IDeleteObligatorAsset _delete;
    private readonly IUpdateObligatorAsset _update;
    private readonly IQueryObligatorAsset _query;

    public ObligatorAssetsController(ICreateObligatorAsset create, IDeleteObligatorAsset delete, IUpdateObligatorAsset update, IQueryObligatorAsset query)
    {
        _create = create;
        _delete = delete;
        _update = update;
        _query = query;
    }

    [HttpPost]
    public async Task<ActionResult> CreateObligatorAsset([FromBody]ObligatorAssetDto[] dto)
    {
        Result<Unit> result = await _create.CreateNewObligatorAssetCommandAsync(dto);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteObligatorAsset([FromBody] long[] dto)
    {
        Result<(int deleted, int unmatched)> result = await _delete.DeleteObligatorAssetAsync(dto);
        if (result.IsSuccess)
        {
            return Ok($"Deleted - {result.ResultData.deleted}. Unmatched - {result.ResultData.unmatched}");
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateObligatorAsset([FromBody]ObligatorAssetsDtoUpdate.ObligatorAssetsDto dto)
    {
        Result<string> result = await _update.UpdateObligatorAssetCommand(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpGet]
    public async Task<ActionResult> QueryObligatorsList([FromQuery] long[] dto)
    {
        Result<List<QueryDtoDirection.ObligatorAssetDto>> result = await _query.QueryObligatorsById(dto);
        if (result.IsSuccess) 
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }
}
