using Application.ObligatorAssets.Commands.CreateObligatorAsset.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.CreateObligatorAsset.Validators
{
    internal class CreateObligatorAssetRequestDtoValidator : AbstractValidator<CreateObligatorAssetRequestDto>
    {
        public CreateObligatorAssetRequestDtoValidator() 
        {
            RuleFor(x => x.ObligatorId)
                .NotEmpty()
                .GreaterThan(0)
                .WithSeverity(Severity.Error)
                .WithName("Id должника")
                .WithMessage("Id должника, к которому будет привязан актив обязателен");

            RuleFor(x => x.AssetName)
                .Must(x => x.All(ch => char.IsLetter(ch)))
                .When(x => !string.IsNullOrEmpty(x.AssetName))
                .WithSeverity(Severity.Error)
                .WithName("Название актива")
                .WithMessage("Название актива не должно содержать цифры, только буквы");

            RuleFor(x=>x.AssetDescription)
                .NotEmpty()
                .WithSeverity(Severity.Error)
                .WithName("Описание актива")
                .WithMessage("Описание актива не должно быть пустым");

            RuleFor(x=>x.EstimatedAssetValue)
                .GreaterThanOrEqualTo(0)
                .WithSeverity(Severity.Error)
                .WithName("Стоимость актива")
                .WithMessage("Стоимость актива должна быть больше нуля");
        }
    }
}
