using System.Collections.Generic;
using Listy.Data.Entities;

namespace Listy.Data
{
    public class DataContext
        : IDataContext
    {
        // ReSharper disable InconsistentNaming
        private static readonly IList<ListyList> _listyLists = new List<ListyList>();
        // ReSharper restore InconsistentNaming

        static DataContext()
        {
            var list1 = new ListyList("Test list 1");
            list1.Items.Add(new ListyListItem("Steal socks", 1));
            list1.Items.Add(new ListyListItem("???", 2));
            list1.Items.Add(new ListyListItem("Profit!", 3));
            
            _listyLists = new List<ListyList>()
                {
                    list1, new ListyList("Test list 2"), new ListyList("Test list 3")
                };
        }


        public IList<ListyList> ListyLists
        {
            get { return _listyLists; }
        }
    }
}