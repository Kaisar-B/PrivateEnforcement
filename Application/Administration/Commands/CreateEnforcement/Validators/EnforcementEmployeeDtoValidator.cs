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

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Имя наемного сотрудника ЧСИ")
            .WithMessage("Имя сотрудника ЧСИ должно быть заполненно в обезательном порядке");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Фамилия наемного сотрудника ЧСИ")
            .WithMessage("Фамилия сотрудника ЧСИ должно быть заполненно в обезательном порядке");

        RuleFor(x => x.Login)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Логин")
            .WithMessage("Логин сотрудника ЧСИ должно быть заполненно в обезательном порядке");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Пароль")
            .WithMessage("Пароль одноразовый должен быть присвоен");

        RuleFor(x=>x.Position)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Должность")
            .WithMessage("Должность сотрудника ЧСИ должно быть заполненно в обезательном порядке");
    }
}
