using System.Collections.Generic;
using Listy.Data.Entities;

namespace Listy.Data
{
    public interface IDataContext
    {
        IList<ListyList> ListyLists { get; }
    }
}