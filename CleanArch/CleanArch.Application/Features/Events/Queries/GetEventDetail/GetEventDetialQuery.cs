using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetialQuery : IRequest<EventDetialVm>
    {
        public Guid Id { get; set; }
    }
}
