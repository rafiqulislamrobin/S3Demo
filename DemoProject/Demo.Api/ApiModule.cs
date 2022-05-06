using Autofac;
using Demo.Api.Models;
using DemoProject.Areas.Admin.Models;

namespace Demo.Api
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateCutomerModelAdo>().AsSelf();

            base.Load(builder);
        }
    }
}
