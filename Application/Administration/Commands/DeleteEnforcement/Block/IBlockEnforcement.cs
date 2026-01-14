using Application.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.DeleteEnforcement.Block
{
    public interface IBlockEnforcement
    {
        /// <summary>
        ///     Blocks an enforcement entity by its Id.
        /// </summary>
        /// <param name="id">The unique identifier of the enforcement to block.</param>
        /// <returns>
        ///     Result indicating success or failure. Contains <see cref="Unit"/> if successful.
        /// </returns>
        public Task<Result<Unit>> BlockEnforcementCommandAsync(long id);
    }
}
