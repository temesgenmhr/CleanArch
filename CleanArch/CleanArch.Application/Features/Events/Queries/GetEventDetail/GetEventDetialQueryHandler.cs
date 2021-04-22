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

namespace CleanArch.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetialQueryHandler : IRequestHandler<GetEventDetialQuery, EventDetialVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetEventDetialQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<EventDetialVm> Handle(GetEventDetialQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);
            var eventDetialDto = _mapper.Map<EventDetialVm>(@event);

            var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

            eventDetialDto.Category = _mapper.Map<CategoryDto>(category);

            return eventDetialDto;
        }
    }
}
