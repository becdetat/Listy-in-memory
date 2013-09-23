using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Listy.Core.Configuration;
using Listy.Data.Entities;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Listy.Web.App_Start.nh
{
    public class NhibernateConfig
    {

        public static ISessionFactory Register(IConfigurationProvider configurationProvider)
        {
            var persistenceConfigurer =
                MsSqlConfiguration.MsSql2008
                                  .ConnectionString(configurationProvider.ListyConnectionString);

            return Fluently.Configure()
                           .Database(persistenceConfigurer)
                           .Mappings(m => m.AutoMappings.Add(CreateAutomappings))
                           .BuildSessionFactory();
        }

        static void BuildSchema(Configuration config)
        {
            new SchemaExport(config)
                .Create(false, true);
        }

        static AutoPersistenceModel CreateAutomappings()
        {
            return AutoMap.AssemblyOf<ListyList>(new ListyAutomappingConfiguration())
                .Conventions.Add<CascadeConvention>()
                .Conventions.Add<ListyForeignKeyConvention>()
                ;
        }
    }
}