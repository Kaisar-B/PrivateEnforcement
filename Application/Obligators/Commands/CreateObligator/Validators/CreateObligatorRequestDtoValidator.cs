using Application.Obligators.Commands.CreateObligator.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.CreateObligator.Validators;
internal class CreateObligatorRequestDtoValidator : AbstractValidator<CreateObligatorRequestDto>
{
    public CreateObligatorRequestDtoValidator()
    {
        RuleFor(x => x.DebtAmount)
            .GreaterThanOrEqualTo(0)
            .WithName("Сумма долга - debt amount")
            .WithMessage("Значение сумма долга должника должно быть больше чем ноль");

        RuleFor(x => x.ObligationContractNumber)
            .NotNull()
            .MaximumLength(256)
            .WithName("Номер контракта с должником")
            .WithMessage("Номер контракта должен быть указан, при созданий должника");

        RuleFor(x => x.City)
            .Must(x => x.ToArray()
            .All(char.IsLetter))
            .WithName("Город")
            .WithMessage("Город не должен содержать цифры или другие знаки кроме букв");

        RuleFor(x => x.Region)
            .Must(x => x.ToArray().All(char.IsLetter))
            .WithName("Область")
            .WithMessage("Название области не должно содержать цифры или другие знаки кроме букв");

        RuleForEach(x=>x.ObligatorAssets).SetValidator(new ObligatorAssetsDtoValidator());
    }
}
