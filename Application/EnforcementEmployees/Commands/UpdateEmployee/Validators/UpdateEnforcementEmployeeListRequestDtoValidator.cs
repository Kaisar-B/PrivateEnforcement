using Application.EnforcementEmployees.Commands.UpdateEmployee.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Commands.UpdateEmployee.Validators;
internal class UpdateEnforcementEmployeeListRequestDtoValidator : AbstractValidator<List<UpdateEnforcementEmployeeRequestDto>>
{
    public UpdateEnforcementEmployeeListRequestDtoValidator()
    {
        RuleForEach(x => x).SetValidator(new UpdateEnforcementEmployeeRequestDtoValidator());
    }
}
