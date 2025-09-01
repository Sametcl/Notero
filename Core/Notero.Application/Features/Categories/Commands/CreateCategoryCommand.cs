using MediatR;
using Notero.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Application.Features.Categories.Commands
{
    public record CreateCategoryCommand(string CategoryName) :IRequest<BaseResult<bool>>;
}
