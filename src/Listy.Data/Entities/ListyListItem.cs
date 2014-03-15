using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Listy.Data.Entities
{
    public class ListyListItem
    {
        public ListyListItem()
        {
            Id = Guid.NewGuid();
        }

        public ListyListItem(string name, int ordinal)
            : this()
        {
            SetName(name);
            SetOrdinal(ordinal);
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Ordinal { get; private set; }

        public void SetOrdinal(int ordinal)
        {
            Ordinal = ordinal;
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}