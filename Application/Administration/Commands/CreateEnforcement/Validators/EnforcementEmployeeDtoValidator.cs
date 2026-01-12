using Application.Administration.Commands.CreateEnforcement.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.Validators;
public class EnforcementEmployeeDtoValidator : AbstractValidator<EnforcementEmployeeDto>
{
    public EnforcementEmployeeDtoValidator()
    {
        RuleFor(x => x.PassportNumber)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Номер паспорта работника")
            .WithMessage("Номер паспорта работника должен быть больше чем ноль");
    }
}
