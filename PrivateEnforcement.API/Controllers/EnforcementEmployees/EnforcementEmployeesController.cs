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
using EnforcementEmployeeDtoList = Application.EnforcementEmployees.Queries.EmployeesList.DTOs.EnforcementEmployeeDto;
using Application.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace PrivateEnforcement.API.Controllers.EnforcementEmployees;


/// <summary>
///     Controller for manipulating enforcement employees. 
///     CRUD operations on Enforcment employees.
/// </summary>
[ApiController]
[Route("[controller]")]
public class EnforcementEmployeesController : ControllerBase
{
    private readonly ICreateEmployee _create;
    private readonly IDeleteEmployee _delete;
    private readonly IUpdateEmployee _update;
    private readonly IEmployeesList _list;

    public EnforcementEmployeesController(ICreateEmployee create, IDeleteEmployee delete, IUpdateEmployee update, IEmployeesList list)
    {
        _create = create;
        _delete = delete;
        _update = update;
        _list = list;
    }

    [HttpPost]
    public async Task<ActionResult> CreateEnforcementEmployee([FromBody] List<CreateEmployeeDto> dto)
    {
        Result<string> result = await _create.CreateEmployeesAsync(dto);
        if (result.IsSuccess)
        {
            return Created();
        }
        return BadRequest();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteEnforcementEmployee([FromBody] List<long> dto)
    {
        Result<string> result = await _delete.DeleteEmployeesByIdAsync(dto);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateEnforcementEmployee([FromBody] List<UpdateEmployeeDto> dto)
    {
        Result<string> result = await _update.UpdateEmployeesAsync(dto);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet]
    public async Task<ActionResult> QueryEnforcementEmployee([FromQuery] EmployeeFilterSort dto)
    {
        Result<List<EnforcementEmployeeDtoList>> result = await _list.GetEmployeesListAsync(dto);
        if (result.IsSuccess) 
        {
            return Ok(result.ResultData);
        }
        return BadRequest(result.ResponseMessage);
    }
}
