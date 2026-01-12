using Application.Obligators.Commands.DeleteObligator.DTOs;
using Application.Obligators.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.DeleteObligator;
public interface IDeleteObligator
{
    public Task<Result<string>> DeleteObligatorByIdAsync(long id);
    public Task<Result<string>> DeleteObligatorAsync(DeleteObligatorDto dto);
}
