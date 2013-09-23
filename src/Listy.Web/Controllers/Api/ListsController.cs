using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Listy.Data.Entities;
using NHibernate;

namespace Listy.Web.Controllers.Api
{
    public class ListsController : ApiController
    {
        private readonly ISessionFactory _sessionFactory;

        public ListsController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public object Get()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var lists = session.CreateCriteria<ListyList>().List<ListyList>();
                    return lists.Select(l => new
                        {
                            Id = l.Id,
                            Name= l.Name,
                        });
                }
            }
        }
    }
}
