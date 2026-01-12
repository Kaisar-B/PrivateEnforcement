using Application.Administration.Commands.CreateEnforcement.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.Validators;
internal class ObligatorAssetDtoValidator : AbstractValidator<ObligatorAssetDto>
{
    public ObligatorAssetDtoValidator()
    {
        RuleFor(x=>x.AssetName)
            .NotEmpty()
            .MinimumLength(1)
            .WithSeverity(Severity.Error)
            .WithName("Название актива")
            .WithMessage("Название актива должно быть больше чем 1 буква");

        RuleFor(x=>x.AssetValue)
            .NotEmpty()
            .GreaterThan(0)
            .WithSeverity(Severity.Error)
            .WithName("Стоимость актива")
            .WithMessage("Стоимаость актива должна быть больше нуля");

        RuleFor(x => x.DescriptionOfAsset)
            .MinimumLength(1)
            .WithSeverity(Severity.Warning)
            .WithName("Описание актива")
            .WithMessage("Описание актива долдно быть больше чем одна буква");
    }
}
