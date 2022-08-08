using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using Inflector;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace TauCode.AppComposition.NHibernate;

public static class AppCompositionNHibernateExtensions
{
    public static ISessionFactory BuildSessionFactory(
        Configuration configuration,
        Assembly mappingsAssembly)
    {
        return Fluently.Configure(configuration)
            .Mappings(m => m.FluentMappings.AddFromAssembly(mappingsAssembly)
                .Conventions.Add(ForeignKey.Format((p, t) =>
                {
                    if (p == null) return t.Name.Underscore() + "_id";

                    return p.Name.Underscore() + "_id";
                }))
                .Conventions.Add(LazyLoad.Never())
                .Conventions.Add(Table.Is(x => x.TableName.Underscore().ToUpper()))
                .Conventions.Add(ConventionBuilder.Property.Always(x => x.Column(x.Property.Name.Underscore())))
            )
            .BuildSessionFactory();
    }

    public static ContainerBuilder AddNHibernate(
        this ContainerBuilder containerBuilder,
        Configuration configuration,
        Assembly mappingsAssembly)
    {
        containerBuilder
            .Register(c => BuildSessionFactory(configuration, mappingsAssembly))
            .As<ISessionFactory>()
            .SingleInstance();

        containerBuilder
            .Register(c => c.Resolve<ISessionFactory>().OpenSession())
            .As<ISession>()
            .InstancePerLifetimeScope();

        return containerBuilder;
    }
}