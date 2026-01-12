using Application.Obligators.Commands.UpdateObligator.DTOs;
using Application.Obligators.Shared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.UpdateObligator;
public interface IUpdateObligator
{
    public Task<Result<string>> UpdateObligatorAsync(UpdateObligatorDto updateObligatorDto);
}
