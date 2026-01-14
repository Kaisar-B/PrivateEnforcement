using Application.Administration.Commands.CreateEnforcement.DTOs;
using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.UpdateEnforcement
{
    public interface IUpdateEnforcement
    {
        /// <summary>
        ///     Updates an enforcement entity with the given data.
        ///     Only non-null properties of <paramref name="enforcementUpdateDto"/> will be applied.
        /// </summary>
        /// <param name="enforcementUpdateDto"> DTO containing the update data.</param>
        /// <returns>Result indicating success or failure.</returns>
        public Task<Result<Unit>> UpdateEnforcementCommandAsync(EnforcementUpdateDto enforcementUpdateDto);
    }

}
