using Application.Administration.Commands.CreateEnforcement;
using Application.Administration.Commands.CreateEnforcement.DTOs;
using Application.Administration.Commands.DeleteEnforcement.Block;
using Application.Administration.Commands.UpdateEnforcement;
using Application.Administration.Queries.EnforcementList;
using Application.Administration.Queries.EnforcementList.DTOs;
using Application.Administration.Queries.Shared;
using Application.Shared.Results;
using Domain.Entities.Account.Administration;
using Microsoft.AspNetCore.Mvc;

namespace PrivateEnforcement.API.Controllers.Administration;


/// <summary>
///     Controller for administration. Allows CRUD operations on Private Enforcement entities.
/// </summary>
[ApiController]
[Route("[controller]")]
public class AdministrationController : ControllerBase
{
    private readonly ICreateEnforcement _create;
    private readonly IBlockEnforcement _block;
    private readonly IUpdateEnforcement _update;
    private readonly IEnforcementList _list;

    public AdministrationController(ICreateEnforcement create, IBlockEnforcement block, IUpdateEnforcement update, IEnforcementList list)
    {
        _create = create;
        _block = block;
        _update = update;
        _list = list;
    }

    [HttpPost]
    public async Task<ActionResult> CreateEnforcementAsync([FromBody] EnforcementCreateDto dto)
    {
        Result<Unit> result = await _create.CreateEnforcementAsync(dto);
        if (result.IsSuccess)
        {
            return Created();
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpDelete]
    public async Task<ActionResult> BlockEnforcementAsync([FromQuery] long id)
    {
        Result<Unit> result = await _block.BlockEnforcementCommandAsync(id);
        if(result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateEnforcementAsync([FromBody] EnforcementUpdateDto dto)
    {
        Result<Unit> result = await _update.UpdateEnforcementCommandAsync(dto);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.ResponseMessage);
    }

    [HttpGet]
    public async Task<ActionResult<List<EnforcementDto>>> QueryEnforcementList([FromQuery] EnforcementFilterSorting dto)
    {
        Result<List<EnforcementDto>> result = await _list.QueryEnforcementListCommandAsync(dto);
        if (result.IsSuccess)
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }
}
