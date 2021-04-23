using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace TauCode.AppComposition.NHibernate.ConfigurationBuilders
{
    [NHibernateConfigurationBuilder(typeof(SQLite20Driver), typeof(DriverConnectionProvider), typeof(SQLiteDialect))]
    public class SQLiteConfigurationBuilder : NHibernateConfigurationBuilderBase
    {
        public SQLiteConfigurationBuilder(string connectionString)
            : base(connectionString, null)
        {
        }
    }
}
