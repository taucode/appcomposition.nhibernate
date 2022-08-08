using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace TauCode.AppComposition.NHibernate.ConfigurationBuilders;

[NHibernateConfigurationBuilder(typeof(MySqlDataDriver), typeof(DriverConnectionProvider), typeof(MySQL55InnoDBDialect))]
public class MySqlConfigurationBuilder : NHibernateConfigurationBuilderBase
{
    public MySqlConfigurationBuilder(string connectionString)
        : base(connectionString, null)
    {
    }
}