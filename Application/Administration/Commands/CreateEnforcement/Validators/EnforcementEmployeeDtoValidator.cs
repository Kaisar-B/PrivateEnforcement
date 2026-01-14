using Application.Administration.Commands.CreateEnforcement.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.Validators;

/// <summary>
///     Validation rules for enforcement employee data during creation or update.
/// </summary>
public class EnforcementEmployeeDtoValidator : AbstractValidator<EnforcementEmployeeDto>
{
    public EnforcementEmployeeDtoValidator()
    {
        RuleFor(x => x.PassportNumber)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Номер паспорта сотрудника")
            .WithMessage("Номер паспорта сотрудника обязателен для заполнения");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Имя наёмного сотрудника ЧСИ")
            .WithMessage("Имя сотрудника ЧСИ обязательно для заполнения");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Фамилия наёмного сотрудника ЧСИ")
            .WithMessage("Фамилия сотрудника ЧСИ обязательна для заполнения");

        RuleFor(x => x.Login)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Логин")
            .WithMessage("Логин сотрудника ЧСИ обязателен для заполнения");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Пароль")
            .WithMessage("Одноразовый пароль должен быть задан");

        RuleFor(x => x.Position)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Должность")
            .WithMessage("Должность сотрудника ЧСИ обязательна для заполнения");
    }
}

