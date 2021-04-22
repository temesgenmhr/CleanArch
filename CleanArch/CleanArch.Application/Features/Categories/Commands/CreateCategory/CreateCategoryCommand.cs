using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Categories.Commands.CreateCategory
{
  public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string name { get; set; }
    }
}
