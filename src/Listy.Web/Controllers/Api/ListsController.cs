using System.Linq;
using System.Web.Http;
using Listy.Data;

namespace Listy.Web.Controllers.Api
{
    public class ListsController : ApiController
    {
        private readonly IDataContext _dataContext;

        public ListsController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public object Get()
        {
            var lists = _dataContext.ListyLists
                                    .OrderBy(l => l.Name);

            var result = lists.Select(l => new
                {
                    l.Id,
                    l.Name,
                    Items = l.Items.OrderBy(i => i.Ordinal).Select(x => new
                        {
                            x.Id,
                            x.Name,
                            x.Ordinal,
                        }).ToArray()
                }).ToArray();

            return result;
        }
    }
}