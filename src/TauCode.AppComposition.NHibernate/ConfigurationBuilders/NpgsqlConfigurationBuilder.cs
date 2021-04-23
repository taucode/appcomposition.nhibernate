using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace TauCode.AppComposition.NHibernate.ConfigurationBuilders
{
    [NHibernateConfigurationBuilder(typeof(NpgsqlDriver), typeof(DriverConnectionProvider), typeof(PostgreSQL83Dialect))]
    public class NpgsqlConfigurationBuilder : NHibernateConfigurationBuilderBase
    {
        public NpgsqlConfigurationBuilder(string connectionString, string defaultSchemaName = null)
            : base(connectionString, defaultSchemaName)
        {
        }
    }
}
