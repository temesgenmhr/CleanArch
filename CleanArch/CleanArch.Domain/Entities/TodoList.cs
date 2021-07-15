using CleanArch.Domain.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
   public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Color Colour { get; set; } = Color.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();

    }
}
