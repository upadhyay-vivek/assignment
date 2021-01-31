using Autofac;
using Autofac.Integration.WebApi;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Assignment.WebApp.Services;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Assignment.WebApp;

namespace Assignment.WebApp
{
    public class IocConfig
    {
        //public static void Configure()
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

        //    builder.RegisterType<ParcelService>()
        //        .As<IParcelService>()
        //        .InstancePerRequest();

        //    var container = builder.Build();
        //    var resolver = new AutofacWebApiDependencyResolver(container);
        //    GlobalConfiguration.Configuration.DependencyResolver = resolver;
        //}
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ParcelService>()
                .As<IParcelService>()
                .InstancePerRequest();

            builder.RegisterModule(new AutoMapperModule());

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}