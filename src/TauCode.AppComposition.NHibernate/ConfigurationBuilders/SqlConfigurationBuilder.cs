using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace TauCode.AppComposition.NHibernate.ConfigurationBuilders;

[NHibernateConfigurationBuilder(typeof(SqlClientDriver), typeof(DriverConnectionProvider), typeof(MsSql2012Dialect))]
public class SqlConfigurationBuilder : NHibernateConfigurationBuilderBase
{
    public SqlConfigurationBuilder(string connectionString, string defaultSchemaName = null)
        : base(connectionString, defaultSchemaName)
    {
    }
}