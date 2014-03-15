using System;
using System.Linq;
using System.Web.Http;
using Listy.Data;
using Listy.Data.Entities;
using Listy.Web.Models.Api.List;

namespace Listy.Web.Controllers.Api
{
    public class ListController : ApiController
    {
        private readonly IDataContext _dataContext;

        public ListController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Post(Guid id, ListUpdateModel model)
        {
            var list = _dataContext.ListyLists.Single(x => x.Id == id);

            list.SetName(model.Name);

            var ordinal = 0;
            foreach (var item in model.Items ?? new ListItemUpdateModel[0])
            {
                var listItem = item.Id.HasValue ? list.Items.SingleOrDefault(x => x.Id == item.Id) : null;
                var isNew = listItem == null;
                listItem = listItem ?? new ListyListItem();

                listItem.SetOrdinal(ordinal++);
                listItem.SetName(item.Name ?? "");

                if (isNew)
                {
                    list.Items.Add(listItem);
                }
            }
        }
    }
}