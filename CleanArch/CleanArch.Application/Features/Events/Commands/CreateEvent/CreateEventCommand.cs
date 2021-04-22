﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Events.Commands.CreateEvent
{
   public class CreateEventCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public String ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"Event Name: {Name}; Price: {Price}; By: {Artist}; On:{Date.ToShortDateString()}; Description: {Description}";
        }
    }
}
