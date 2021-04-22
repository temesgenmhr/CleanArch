using AutoMapper;
using CleanArch.Application.Contracts.Persistance;
using CleanArch.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Events.Commands.UpdateEvent
{
    class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {

        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper mapper )
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            await _eventRepository.UpdateAsnc(eventToUpdate);

            return Unit.Value;
        }
    }
}
