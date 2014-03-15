using System.IO.Abstractions;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Listy.Core.Configuration;
using Listy.Data;

namespace Listy.Web.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileSystem>();

            var configurationProvider = new ListyWebConfigurationProvider();

            builder
                .RegisterInstance(configurationProvider)
                .SingleInstance()
                ;

            builder
                .RegisterType<DataContext>()
                .As<IDataContext>()
                .SingleInstance();

            var assemblies = new[]
                {
                    typeof (MvcApplication).Assembly,
                    typeof (IConfigurationProvider).Assembly,
                    typeof (IDataContext).Assembly,
                };

            builder.RegisterAssemblyTypes(assemblies);
            builder.RegisterAssemblyModules(assemblies);

            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterFilterProvider();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            builder
                .RegisterControllers(assemblies)
                .OnActivated(e =>
                    {
                        dynamic viewBag = ((Controller) e.Instance).ViewBag;
                        // add things to ViewBag
                    });

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}