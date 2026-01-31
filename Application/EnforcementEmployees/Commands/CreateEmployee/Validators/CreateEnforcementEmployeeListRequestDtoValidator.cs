using Application.Employees.Commands.CreateEmployee.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Commands.CreateEmployee.Validators
{
    public class CreateEnforcementEmployeeListRequestDtoValidator : AbstractValidator<List<CreateEnforcementEmployeeRequestDto>>
    {
        public CreateEnforcementEmployeeListRequestDtoValidator()
        {
            RuleForEach(x => x).SetValidator(new CreateEnforcementEmployeeRequestDtoValidator());
        }
    }
}
