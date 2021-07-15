using AutoMapper;
using CleanArch.Application.Features.Categories.Commands.CreateCategory;
using CleanArch.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArch.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using CleanArch.Application.Features.Events.Commands.CreateEvent;
using CleanArch.Application.Features.Events.Commands.UpdateEvent;
using CleanArch.Application.Features.Events.Queries.GetEventDetail;
using CleanArch.Application.Features.Events.Queries.GetEventList;
using CleanArch.Application.Features.Events.Queries.GetEventsExport;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Profiles
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            


            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetialVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

        }
    }
}
