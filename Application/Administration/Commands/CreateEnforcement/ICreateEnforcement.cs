using Application.Administration.Commands.CreateEnforcement.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.CreateEnforcement;
public interface ICreateEnforcement
{
    /// <summary>
    ///     Application-level contract for creating a new enforcement entity.
    /// </summary>
    public Task<Result<Unit>> CreateEnforcementAsync(EnforcementCreateDto enforcementDto);
}
