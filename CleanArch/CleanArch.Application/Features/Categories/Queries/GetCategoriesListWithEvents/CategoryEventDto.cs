﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
   public class CategoryEventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
    }
}