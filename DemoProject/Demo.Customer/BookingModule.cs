using Autofac;
using Demo.Customer.Context;
using Demo.Customer.Repositories;
using Demo.Customer.Services;
using Demo.Customer.Unit_of_Work;

namespace Demo.Customer
{
    public class BookingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public BookingModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;

        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookingDbContext>()
                .AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<BookingDbContext>().As<IBookingDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();


            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<BookingUnitOfWork>().As<IBookingUnitOfWork>()
               .InstancePerLifetimeScope();
            builder.RegisterType<BookingService>().As<IBookingService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

