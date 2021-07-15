using AutoMapper;
using CleanArch.Application.Contracts.Infrastructure;
using CleanArch.Application.Contracts.Persistance;
using CleanArch.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Events.Queries.GetEventsExport
{
    class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, EventExportFileVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExpoerter;

        public GetEventsExportQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, ICsvExporter csvExpoerter)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _csvExpoerter = csvExpoerter;
        }
        public async Task<EventExportFileVm> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var Allevents = _mapper.Map<List<EventExportDto>>((await _eventRepository.ListAllAsnc()).OrderBy(x => x.Date));
            var fileData = _csvExpoerter.ExportEventToCsv(Allevents);
            var eventExportDto = new EventExportFileVm() { ContentType = "text/csv", Data = fileData, EventExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportDto;
        }
    }
}
