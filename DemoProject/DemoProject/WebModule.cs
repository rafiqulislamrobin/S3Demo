using Autofac;
using DemoProject.Areas.Admin.Models;

namespace DemoProject
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerListModel>().AsSelf();
            builder.RegisterType<CreateCutomerModel>().AsSelf();
            builder.RegisterType<EditCustomerModel>().AsSelf();

            base.Load(builder);
        }
    }
}
