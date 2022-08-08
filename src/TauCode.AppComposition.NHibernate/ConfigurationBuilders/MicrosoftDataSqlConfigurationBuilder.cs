using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace TauCode.AppComposition.NHibernate.ConfigurationBuilders;

[NHibernateConfigurationBuilder(typeof(MicrosoftDataSqlClientDriver), typeof(DriverConnectionProvider), typeof(MsSql2012Dialect))]
public class MicrosoftDataSqlConfigurationBuilder : NHibernateConfigurationBuilderBase
{
    public MicrosoftDataSqlConfigurationBuilder(string connectionString, string defaultSchemaName = null)
        : base(connectionString, defaultSchemaName)
    {
    }
}