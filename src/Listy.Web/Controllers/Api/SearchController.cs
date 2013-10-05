using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Listy.Data.Entities;
using NHibernate;
using NHibernate.Linq;

namespace Listy.Web.Controllers.Api
{
    public class SearchController : ApiController
    {
        private readonly ISessionFactory _sessionFactory;

        public SearchController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public object Get(string term)
        {
            // Note this uses LINQ to NHibernate. The ListsController uses QueryOver.

            using (var session = _sessionFactory.OpenSession())
            {
                return session.Query<ListyListItem>()
                              .Where(i => i.Name.Contains(term))
                              .Select(x => new
                                  {
                                      List = x.ListyList.Name,
                                      Item = x.Name,
                                  })
                              .ToArray()
                    ;
            }
        }
    }
}
