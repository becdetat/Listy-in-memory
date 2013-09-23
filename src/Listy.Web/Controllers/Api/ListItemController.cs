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
    //public class ListItemController : ApiController
    //{
    //    private readonly ISessionFactory _sessionFactory;

    //    public ListItemController(ISessionFactory sessionFactory)
    //    {
    //        _sessionFactory = sessionFactory;
    //    }

    //    public void Post(Guid id, ListItemUpdateModel model)
    //    {
    //        using (var session = _sessionFactory.OpenSession())
    //        using (var transaction = session.BeginTransaction())
    //        {
    //            var item = session.Get<ListyListItem>(id);
    //            item.Name = model.Name;
    //            transaction.Commit();
    //        }
    //    }

    //    public ListyListItem Post(ListItemUpdateModel model)
    //    {
    //        using (var session = _sessionFactory.OpenSession())
    //        using (var transaction = session.BeginTransaction())
    //        {
    //            var item = new ListyListItem
    //            item.Name = model.Name;
    //            transaction.Commit();
    //        }
    //    }
    //}
}
