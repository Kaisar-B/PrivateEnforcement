using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Obligators.Commands.CreateObligator.DTOs;
using FluentValidation;

namespace Application.Obligators.Commands.CreateObligator;
public class CreateObligatorValidator : AbstractValidator<NewObligatorDto>
{
    public CreateObligatorValidator()
    {
        RuleFor(x=>x.DebtAmount).GreaterThanOrEqualTo(0).WithName("Сумма долга - debt amount").WithMessage("Значение сумма долга должника должно быть больше чем ноль");
        RuleFor(x => x.ObligationContractNumber).NotNull().MaximumLength(256).WithName("Номер контракта с должником").WithMessage("Номер контракта должен быть указан, при созданий должника");
        RuleFor(x => x.City).Must(x => x.ToArray().All(char.IsLetter)).WithName("Город").WithMessage("Город не должен содержать цифры или другие знаки кроме букв");
        RuleFor(x => x.Region).Must(x => x.ToArray().All(char.IsLetter)).WithName("Область").WithMessage("Название области не должно содержать цифры или другие знаки кроме букв");
        RuleForEach(x => x.ObligatorAssets).Null().ChildRules(x => 
        { 
            x.RuleFor(x => x.AssetValue).NotNull().WithSeverity(Severity.Error).WithName("Стоимость актива").WithMessage("Если создается актив, тогда оценочная стоимость актива должна быть обезательно"); 
            x.RuleFor(x=>x.AssetName).NotNull().WithSeverity(Severity.Error).WithName("Название актива").WithMessage("Если создается актив, тогда название актива должна быть обезательно");
        });
    }
}
