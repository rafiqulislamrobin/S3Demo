using Demo.Customer.Business_Object;

namespace Demo.Customer.Services
{
    public interface IBookingService
    {
        Task CreateCustomer(CustomerBO customer);
        Task<(IList<CustomerBO> records, int total, int totalDisplay)> GetCutomers(int pageIndex, int pageSize,
                                                       string searchText, string sortText);
        Task<CustomerBO> GetCustomer(Guid id);
        Task UpdateCustomer(CustomerBO customer);
        Task DeleteCustomer(Guid id);
    }
}
