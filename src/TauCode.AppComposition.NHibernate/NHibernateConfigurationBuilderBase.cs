using NHibernate.Cfg;
using System.Reflection;

namespace TauCode.AppComposition.NHibernate;

public abstract class NHibernateConfigurationBuilderBase : INHibernateConfigurationBuilder
{
    protected NHibernateConfigurationBuilderBase(string connectionString, string defaultSchemaName = null)
    {
        this.ConnectionString = connectionString;
        this.DefaultSchemaName = defaultSchemaName;
    }

    public string ConnectionString { get; protected set; }

    // todo: get rid of.
    public string DefaultSchemaName { get; protected set; }

    public Configuration Build()
    {
        var attr = this.GetType().GetCustomAttribute<NHibernateConfigurationBuilderAttribute>();

        var configuration = new Configuration();

        configuration.Properties.Add(
            "connection.connection_string",
            this.ConnectionString ?? throw new InvalidOperationException($"'{ConnectionString}' is null."));

        configuration.Properties.Add("connection.driver_class", attr.DriverClass.FullName);
        configuration.Properties.Add("connection.provider", attr.ProviderType.FullName);
        configuration.Properties.Add("dialect", attr.DialectType.FullName);

        if (this.DefaultSchemaName != null)
        {
            configuration.Properties.Add("default_schema", this.DefaultSchemaName);
        }

        return configuration;
    }
}