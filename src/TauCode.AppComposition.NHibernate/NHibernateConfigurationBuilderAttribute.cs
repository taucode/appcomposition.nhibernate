namespace TauCode.AppComposition.NHibernate;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class NHibernateConfigurationBuilderAttribute : Attribute
{
    public NHibernateConfigurationBuilderAttribute(Type driverClass, Type providerType, Type dialectType)
    {
        this.DriverClass = driverClass ?? throw new ArgumentNullException(nameof(driverClass));
        this.ProviderType = providerType ?? throw new ArgumentNullException(nameof(providerType));
        this.DialectType = dialectType ?? throw new ArgumentNullException(nameof(dialectType));
    }

    public Type DriverClass { get; }

    public Type ProviderType { get; }

    public Type DialectType { get; }
}