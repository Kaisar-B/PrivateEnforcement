using Application.Administration.Commands.CreateEnforcement.DTOs;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Commands.CreateEmployee.DTOs;
using Application.EnforcementEmployees.Commands.DeleteEmployee;
using Application.EnforcementEmployees.Commands.UpdateEmployee;
using Application.EnforcementEmployees.Commands.UpdateEmployee.DTOs;
using Application.EnforcementEmployees.Queries.EmployeesList;
using Application.EnforcementEmployees.Queries.EmployeesList.DTOs;
using Application.EnforcementEmployees.Queries;
using Application.EnforcementEmployees.Queries.EmployeesList.Shared;
using Application.Shared.Results;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using Application.EnforcementEmployees.Commands.CreateEmployee.Validators;

namespace PrivateEnforcement.API.Controllers.EnforcementEmployees;


/// <summary>
///     Controller for manipulating enforcement employees. 
///     CRUD operations on Enforcment employees.
/// </summary>
[ApiController]
[Route("api/enforcement-employees")]
public class EnforcementEmployeesController : ControllerBase
{
    private readonly ICreateEmployee _create;
    private readonly IDeleteEmployee _delete;
    private readonly IUpdateEmployee _update;
    private readonly IEmployeesList _list;
    private readonly IValidator<List<CreateEnforcementEmployeeRequestDto>> _createValidator;
    private readonly IValidator<List<UpdateEnforcementEmployeeRequestDto>> _updateValidator;

    public EnforcementEmployeesController(ICreateEmployee create, IDeleteEmployee delete, IUpdateEmployee update, IEmployeesList list, IValidator<List<CreateEnforcementEmployeeRequestDto>> createValidator, IValidator<List<UpdateEnforcementEmployeeRequestDto>> updateValidator)
    {
        _create = create;
        _delete = delete;
        _update = update;
        _list = list;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateEnforcementEmployee([FromBody] List<CreateEnforcementEmployeeRequestDto> dto)
    {
        ValidationResult validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return UnprocessableEntity(validationResult.ToDictionary());
        }

        Result<string> result = await _create.CreateEmployeesAsync(dto);
        if (result.IsSuccess)
        {
            return Created();
        }
        return BadRequest();
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteEnforcementEmployee([FromQuery] List<long> dto)
    {
        Result<string> result = await _delete.DeleteEmployeesByIdAsync(dto);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpPatch("update")]
    public async Task<ActionResult> UpdateEnforcementEmployee([FromBody] List<UpdateEnforcementEmployeeRequestDto> dto)
    {
        ValidationResult validationResult = await _updateValidator.ValidateAsync(dto);
        if (!validationResult.IsValid) 
        {
            return UnprocessableEntity(validationResult.ToDictionary());
        }

        Result<string> result = await _update.UpdateEmployeesAsync(dto);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("query")]
    public async Task<ActionResult> QueryEnforcementEmployee([FromQuery] EmployeeFilterSort dto)
    {
        Result<List<QueryEnforcementEmployeeResponseDto>> result = await _list.GetEmployeesListAsync(dto);
        if (result.IsSuccess) 
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }
}
