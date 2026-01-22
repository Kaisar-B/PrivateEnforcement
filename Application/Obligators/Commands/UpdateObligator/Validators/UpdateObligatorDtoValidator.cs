using Application.Obligators.Commands.UpdateObligator.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.UpdateObligator.Validators;
internal class UpdateObligatorDtoValidator : AbstractValidator<UpdateObligatorDto>
{
    public UpdateObligatorDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithSeverity(Severity.Error)
            .WithName("Id должника")
            .WithMessage("Id должника должно быть больше чем 0");

        RuleFor(x=>x.DebtAmount)
            .GreaterThan(0)
            .WithSeverity(Severity.Error)
            .WithName("Начальная сумма долга")
            .WithMessage("Начальная сумма долга должна быть больше чем ноль.");

        RuleFor(x => x.ContractNumber)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Номер контракта")
            .WithMessage("Номер контракта с должником обезателен");

        RuleFor(x=>x.City)
            .Must(city=>city.All(ch=>char.IsLetter(ch)))
            .When(x=>!string.IsNullOrWhiteSpace(x.City))
            .WithSeverity(Severity.Error)
            .WithName("Город")
            .WithMessage("Название города не должно содержать цифры, только буквы");

        RuleFor(x => x.Region)
            .Must(region => region.All(x => char.IsLetter(x)))
            .When(x => !string.IsNullOrWhiteSpace(x.Region))
            .WithSeverity(Severity.Error)
            .WithName("Регион")
            .WithMessage("Название региона не должно содержать цифры, только буквы");

        RuleForEach(x => x.ObligatorAssets).SetValidator(new ObligatorAssetsDtoValidator());
    }
}
