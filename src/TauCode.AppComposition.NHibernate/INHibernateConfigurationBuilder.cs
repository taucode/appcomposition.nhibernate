using NHibernate.Cfg;

namespace TauCode.AppComposition.NHibernate
{
    public interface INHibernateConfigurationBuilder
    {
        public string ConnectionString { get; }
        Configuration Build();
    }
}
