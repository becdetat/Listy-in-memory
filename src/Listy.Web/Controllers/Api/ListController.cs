using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Listy.Data.Entities;
using Listy.Web.Models.Api.List;
using NHibernate;

namespace Listy.Web.Controllers.Api
{
    public class ListController : ApiController
    {
        private readonly ISessionFactory _sessionFactory;

        public ListController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Post(Guid id, ListUpdateModel model)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var list = session.Get<ListyList>(id);

                Update(list, model);

                var ordinal = 0;
                foreach (var item in model.Items ?? new ListItemUpdateModel[0])
                {
                    var listItem = list.Items.First(x => x.Id == item.Id);
                    listItem.Ordinal = ordinal++;
                    listItem.Name = item.Name;
                }

                transaction.Commit();
            }
        }

        static void Update(ListyList list, ListUpdateModel model)
        {
            list.Name = model.Name;
        }
    }
}
