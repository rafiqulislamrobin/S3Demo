using Autofac;

namespace Custom.DataLayer
{
    public class DataLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository>().As<IRepository>()
            .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
