using CleanArch.Application.Features.Events.Queries.GetEventsExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Contracts.Infrastructure
{
   public interface ICsvExporter
    {
        byte[] ExportEventToCsv(List<EventExportDto> eventExportDtos); 
    }
}
