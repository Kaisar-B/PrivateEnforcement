using Application.Obligators.Commands.CreateObligator.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Obligators.Commands.CreateObligator;
public interface ICreateObligator
{
    public Task CreateObligatorAsync(NewObligatorDto newObligator);
}
