using Application.Employees.Commands.CreateEmployee.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EnforcementEmployees.Commands.CreateEmployee.Validators;
internal class CreateEnforcementEmployeeRequestDtoValidator : AbstractValidator<CreateEnforcementEmployeeRequestDto>
{
    public CreateEnforcementEmployeeRequestDtoValidator()
    {
        RuleFor(x => x.PassportNumber)
                .NotEmpty()
                .WithSeverity(Severity.Error)
                .WithName("Номер паспорта")
                .WithMessage("Номер паспорта должен быть предоставлен в обязательном порядке для работника ЧСИ");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Имя работника")
            .WithMessage("Имя работника должно быть предоставлено");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Фамилия работника")
            .WithMessage("Фамилия работника должна быть предоставлена");

        RuleFor(x => x.Login)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Логин работника")
            .WithMessage("Логин работника должен быть предоставлен");

        RuleFor(x => x.Position)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Должность работника")
            .WithMessage("Должность работника должна быть предоставлена");
    }
}
