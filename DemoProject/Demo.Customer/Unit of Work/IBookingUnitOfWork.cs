using Demo.Customer.Repositories;
using DevSkill.Data;

namespace Demo.Customer.Unit_of_Work
{
    public interface IBookingUnitOfWork : IUnitOfWork
    {
        ICustomerRepository Customers { get; }
    }
}