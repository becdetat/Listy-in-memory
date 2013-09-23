using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Listy.Data.Entities
{
    public class ListyListItem
    {
        public virtual Guid Id { get; set; }
        [Column("ListyListId")]
        public virtual ListyList ListyList { get; set; }
        public virtual string Name { get; set; }
        public virtual int Ordinal { get; set; }
    }
}