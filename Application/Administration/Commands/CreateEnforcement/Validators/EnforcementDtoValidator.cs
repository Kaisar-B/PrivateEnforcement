using Application.Administration.Commands.CreateEnforcement.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement.Validators;

/// <summary>
///     Validation rules applied when creating a new enforcement entity.
/// </summary>
internal class EnforcementDtoValidator : AbstractValidator<EnforcementCreateDto>
{
    public EnforcementDtoValidator()
    {
        RuleFor(x => x.EnforcementName)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Название ЧСИ")
            .WithMessage("Имя ЧСИ обязательно для заполнения");

        RuleFor(x => x.LicenseNumber)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Номер лицензии ЧСИ")
            .WithMessage("Номер лицензии или сертификата ЧСИ должен быть указан");

        RuleFor(x => x.City)
            .NotEmpty()
            .WithSeverity(Severity.Error)
            .WithName("Город ЧСИ")
            .WithMessage("Необходимо указать город, откуда ЧСИ");

        // Country is optional because it defaults to KZ on the backend
        RuleFor(x => x.Country)
            .Null()
            .WithSeverity(Severity.Warning)
            .WithName("Страна откуда ЧСИ")
            .WithMessage("По умолчанию указана страна КЗ. При необходимости измените значение.");

        RuleForEach(x=>x.EnforcementEmployeesDto).SetValidator(new EnforcementEmployeeDtoValidator());

        RuleForEach(x=>x.EnforcementObligatorsDto).SetValidator(new EnforcementObligatorDtoValidator());
    }
}
