using Application.Administration.Commands.CreateEnforcement.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.Validators;

/// <summary>
///     Validation rules for obligor asset data.
/// </summary>
internal class ObligatorAssetDtoValidator : AbstractValidator<ObligatorAssetDto>
{
    public ObligatorAssetDtoValidator()
    {
        RuleFor(x => x.AssetName)
            .NotEmpty()
            .MinimumLength(2)
            .WithSeverity(Severity.Error)
            .WithName("Название актива")
            .WithMessage("Название актива должно содержать не менее 2 букв");

        RuleFor(x => x.AssetValue)
            .GreaterThan(0)
            .WithSeverity(Severity.Error)
            .WithName("Стоимость актива")
            .WithMessage("Стоимость актива должна быть больше нуля");

        RuleFor(x => x.DescriptionOfAsset)
            .MinimumLength(2)
            .WithSeverity(Severity.Warning)
            .WithName("Описание актива")
            .WithMessage("Описание актива должно содержать не менее 2 букв");
    }
}
