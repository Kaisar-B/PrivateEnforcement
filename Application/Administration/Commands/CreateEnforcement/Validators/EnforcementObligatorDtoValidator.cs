using Application.Administration.Commands.CreateEnforcement.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.Validators;

/// <summary>
///     Validation rules for debtor (obligator) data.
/// </summary>
public class EnforcementObligatorDtoValidator : AbstractValidator<EnforcementObligatorDto>
{
    public EnforcementObligatorDtoValidator()
    {
        RuleFor(x => x.PassportNumber)
            .NotEmpty()
            .MinimumLength(2)
            .WithSeverity(Severity.Error)
            .WithName("Номер паспорта")
            .WithMessage("Номер паспорта должен содержать не менее 2 символов");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .WithSeverity(Severity.Error)
            .WithName("Имя")
            .WithMessage("Имя должника должно содержать не менее 2 букв");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .MinimumLength(2)
            .WithSeverity(Severity.Error)
            .WithName("Фамилия")
            .WithMessage("Фамилия должника должна содержать не менее 2 букв");

        RuleFor(x => x.DebtAmount)
            .GreaterThan(10)
            .WithSeverity(Severity.Error)
            .WithName("Сумма долга")
            .WithMessage("Сумма долга должна быть больше 10 единиц");

        RuleFor(x => x.ObligationContractNumber)
            .NotEmpty()
            .MinimumLength(1)
            .WithSeverity(Severity.Error)
            .WithName("Номер контракта")
            .WithMessage("Номер контракта обязателен для заполнения");

        RuleFor(x => x.City)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Город")
            .WithMessage("Город проживания должника обязателен для заполнения");

        RuleFor(x => x.Region)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Область")
            .WithMessage("Область проживания должника обязательна для заполнения");

        RuleForEach(x => x.ObligatorAssetDtos)
            .SetValidator(new ObligatorAssetDtoValidator());
    }
}

