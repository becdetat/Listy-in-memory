using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Listy.Core.Configuration;
using Listy.Data;
using Listy.Data.Entities;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Listy.Web.App_Start
{
    public class NhibernateConfig
    {
        class ListyAutomappingConfiguration : DefaultAutomappingConfiguration
        {
            public override bool ShouldMap(Type type)
            {
                return type.Namespace == "Listy.Data.Entities";
            }

            public override bool IsComponent(Type type)
            {
                return false;
                //return type == typeof(Location);
            }
        }

        class CascadeConvention : IReferenceConvention, IHasManyConvention, IHasManyToManyConvention
        {
            public void Apply(IManyToOneInstance instance)
            {
                instance.Cascade.All();
            }

            public void Apply(IOneToManyCollectionInstance instance)
            {
                instance.Cascade.All();
            }

            public void Apply(IManyToManyCollectionInstance instance)
            {
                instance.Cascade.All();
            }
        }

        public static ISessionFactory Register(IConfigurationProvider configurationProvider)
        {
            var persistenceConfigurer =
                MsSqlConfiguration.MsSql2008
                                  .ConnectionString(configurationProvider.ListyConnectionString);

            return Fluently.Configure()
                           .Database(persistenceConfigurer)
                           .Mappings(m => m.AutoMappings.Add(CreateAutomappings))
                //.ExposeConfiguration(BuildSchema)
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
                .Conventions.Add<CascadeConvention>();
        }
    }
}