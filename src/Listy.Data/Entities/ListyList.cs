using System;
using System.Collections.Generic;

namespace Listy.Data.Entities
{
    public class ListyList
    {
        public ListyList()
        {
            Id = Guid.NewGuid();
            Items = new HashSet<ListyListItem>();
        }

        public ListyList(string name)
            : this()
        {
            SetName(name);
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<ListyListItem> Items { get; private set; }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}