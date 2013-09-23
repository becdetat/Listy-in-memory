using System;
using System.Collections.Generic;

namespace Listy.Data.Entities
{
    public class ListyList
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<ListyListItem> Items { get; set; }

        public ListyList()
        {
            Items = new HashSet<ListyListItem>();
        }
    }
}