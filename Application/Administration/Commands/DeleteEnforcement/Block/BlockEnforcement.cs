using Application.Shared.Results;
using Domain.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Administration.Commands.DeleteEnforcement.Block
{
    /// <summary>
    /// Command for blocking an enforcement entity in the system.
    /// Sets <see cref="EnforcementAccount.IsBlocked"/> to true.
    /// </summary>
    internal class BlockEnforcement : IBlockEnforcement
    {
        private readonly DatabaseContext _dbContext;

        public BlockEnforcement(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<Unit>> BlockEnforcementCommandAsync(long id)
        {
            var enforcement = await _dbContext.Enforcements.FirstOrDefaultAsync(x => x.Id == id);
            if (enforcement == null)
                return Result<Unit>.Fail($"ЧСИ с данным Id - {id} не существует в БД");

            enforcement.IsBlocked = true;
            await _dbContext.SaveChangesAsync();
            return Result<Unit>.Ok(Unit.ResultData);

        }
    }
}
