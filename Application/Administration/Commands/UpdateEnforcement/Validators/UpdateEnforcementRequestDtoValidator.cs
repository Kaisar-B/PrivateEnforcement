using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Administration.Commands.CreateEnforcement.DTOs;
using FluentValidation;

namespace Application.Administration.Commands.UpdateEnforcement.Validators;
internal class UpdateEnforcementRequestDtoValidator : AbstractValidator<UpdateEnforcementRequestDto>
{
    public UpdateEnforcementRequestDtoValidator()
    {

    }
}
