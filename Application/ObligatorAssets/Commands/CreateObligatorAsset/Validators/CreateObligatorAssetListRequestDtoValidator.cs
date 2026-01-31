using Application.ObligatorAssets.Commands.CreateObligatorAsset.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ObligatorAssets.Commands.CreateObligatorAsset.Validators
{
    internal class CreateObligatorAssetListRequestDtoValidator : AbstractValidator<List<CreateObligatorAssetRequestDto>>
    {
        public CreateObligatorAssetListRequestDtoValidator() 
        {
            RuleForEach(x=>x).SetValidator(new CreateObligatorAssetRequestDtoValidator());
        }
    }
}
