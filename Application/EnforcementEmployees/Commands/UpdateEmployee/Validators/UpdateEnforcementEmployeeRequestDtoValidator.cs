using Application.EnforcementEmployees.Commands.UpdateEmployee.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Commands.UpdateEmployee.Validators;
internal class UpdateEnforcementEmployeeRequestDtoValidator : AbstractValidator<UpdateEnforcementEmployeeRequestDto>
{
    public UpdateEnforcementEmployeeRequestDtoValidator()
    {

    }
}
