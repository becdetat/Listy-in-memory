using System.Linq;
using System.Web.Http;
using Listy.Data;

namespace Listy.Web.Controllers.Api
{
    public class SearchController : ApiController
    {
        private readonly IDataContext _dataContext;

        public SearchController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public object Get(string term)
        {
            return from list in _dataContext.ListyLists
                   from item in list.Items
                   where item.Name.Contains(term)
                   select new
                       {
                           List = list.Name,
                           Item = item.Name
                       };
        }
    }
}