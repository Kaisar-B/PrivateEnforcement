using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Obligators.Commands.CreateObligator.DTOs;

namespace Application.Obligators.Commands.CreateObligator.Validators;
internal class ObligatorAssetsDtoValidator : AbstractValidator<ObligatorAssetsDto>
{
    public ObligatorAssetsDtoValidator()
    {
        RuleFor(x => x.AssetValue)
            .NotNull()
            .WithSeverity(Severity.Error)
            .WithName("Стоимость актива")
            .WithMessage("Если создается актив, тогда оценочная стоимость актива должна быть обезательно");

        RuleFor(x => x.AssetName)
            .NotNull()
            .WithSeverity(Severity.Error)
            .WithName("Название актива")
            .WithMessage("Если создается актив, тогда название актива должна быть обезательно");

    }
}
