using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Obligators.Commands.UpdateObligator.DTOs;
using FluentValidation;
using Microsoft.Identity.Client;

namespace Application.Obligators.Commands.UpdateObligator.Validators;
internal class ObligatorAssetsDtoValidator : AbstractValidator<ObligatorAssetsDto>
{
    public ObligatorAssetsDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Id актива должника")
            .WithMessage("Id актива должника должен быть указан для обновления");
    }
}
