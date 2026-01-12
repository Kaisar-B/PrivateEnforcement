using Application.Administration.Commands.CreateEnforcement.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.Validators;
public class EnforcementObligatorDtoValidator : AbstractValidator<EnforcementObligatorDto>
{
    public EnforcementObligatorDtoValidator()
    {
        RuleFor(x=>x.PassportNumber)
            .NotEmpty()
            .MinimumLength(1)
            .WithSeverity(Severity.Error)
            .WithName("Номер паспорта")
            .WithMessage("Номер паспорта должен иметь значение больше чем 1 цифра или буква");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(1)
            .WithSeverity(Severity.Error)
            .WithName("Имя")
            .WithMessage("Имя должника должно быть больше чем 1 буква");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Фамилия")
            .WithMessage("Фамилия должника должно быть больше чем 1 буква");

        RuleFor(x => x.DebtAmount)
            .GreaterThan(10)
            .WithSeverity(Severity.Error)
            .WithName("Сумма долга")
            .WithMessage("Сумма долга должна быть больше чем 10 едениц ");

        RuleFor(x => x.ObligationContractNumber)
            .NotEmpty()
            .MinimumLength(1)
            .WithSeverity(Severity.Error)
            .WithName("Номер контракта")
            .WithMessage("Номер контракта не должен быть пустым");

        RuleFor(x => x.City)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Город")
            .WithMessage("Город проживание должника не должен быть пустым");

        RuleFor(x=>x.Region)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Область")
            .WithMessage("Область проживание должника не должен быть пустым");

        RuleForEach(x => x.ObligatorAssetDtos).SetValidator(new ObligatorAssetDtoValidator());
    }
}
