using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.DataLayer
{
    public interface IRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer Customer, string entityName);
        void AddCustomerBulk(List<Customer> customers, string entityName);
        Task AddCustomerSpAsync(Customer Customer);
        void UpdateCustomer(Customer Customer);
        Customer GetCustomerData(Guid id);
        void DeleteCustomer(Guid id);
        string GenerateGuidSequentially();
    }
}
