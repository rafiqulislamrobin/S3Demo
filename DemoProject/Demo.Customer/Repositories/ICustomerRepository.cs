using Demo.Customer.Entites;
using DevSkill.Data;
using Demo.Customer.Context;

namespace Demo.Customer.Repositories
{
    public interface ICustomerRepository : IRepository<CustomerEO, Guid, BookingDbContext>
    {
    }
}
