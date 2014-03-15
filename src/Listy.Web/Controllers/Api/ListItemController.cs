using System;
using System.Linq;
using System.Web.Http;
using Listy.Data;
using Listy.Web.Models.Api.List;

namespace Listy.Web.Controllers.Api
{
    public class ListItemController : ApiController
    {
        private readonly IDataContext _dataContext;

        public ListItemController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Post(Guid id, ListItemUpdateModel model)
        {
            var item = _dataContext.ListyLists
                .SelectMany(x => x.Items)
                .Single(x => x.Id == id);

            item.SetName(model.Name ?? "");
        }
    }
}