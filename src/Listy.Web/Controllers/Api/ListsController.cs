using System.Linq;
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
                    var lists = session
                        .QueryOver<ListyList>()
                        .OrderBy(l => l.Name).Asc
                        .List<ListyList>();

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
    }
}