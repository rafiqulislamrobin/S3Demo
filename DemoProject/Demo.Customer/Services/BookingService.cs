using Demo.Customer.Business_Object;
using Demo.Customer.Exceptions;
using Demo.Customer.Unit_of_Work;

namespace Demo.Customer.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingUnitOfWork _bookingUnitOfWork;

        public BookingService(IBookingUnitOfWork bookingUnitOfWork)
        {
            _bookingUnitOfWork = bookingUnitOfWork;

        }
        public IList<CustomerBO> GetAllCustomer()
        {

            var customerEntities = _bookingUnitOfWork.Customers.GetAll();
            var customers = new List<CustomerBO>();

            foreach (var entity in customerEntities)
            {
                var customer = new CustomerBO()
                {
                    Name = entity.Name,
                    Age = entity.Age,
                    Address = entity.Address
                };
                customers.Add(customer);
            }
            return customers;
        }

        public async Task CreateCustomer(CustomerBO customer)
        {
            if (customer == null)
                throw new InvalidParameterException("Customer was not found");

            if (IsNameAlreadyUsed(customer.Name))
                throw new DuplicateException("Customer Name");

            _bookingUnitOfWork.Customers.Add(
                    new Entites.CustomerEO
                    {

                        Name = customer.Name,
                        Age = customer.Age,
                        Address = customer.Address

                    }
                   );
             await _bookingUnitOfWork.SaveAsync();

        }

        public async Task<(IList<CustomerBO> records, int total, int totalDisplay)> GetCutomers(int pageIndex, int pageSize,
        string searchText, string sortText)
        {
            var customerData = await _bookingUnitOfWork.Customers.GetDynamicAsync(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, null, pageIndex, pageSize);

            var resultData = (from customer in customerData.data
                              select new CustomerBO
                              {
                                  Id = customer.Id,
                                  Name = customer.Name,
                                  Age = customer.Age,
                                  Address = customer.Address
                              }).ToList();

            return (resultData, customerData.total, customerData.totalDisplay);
        }

        public async Task<CustomerBO> GetCustomer(Guid id)
        {

            var customer = await _bookingUnitOfWork.Customers.GetByIdAsync(id);

            if (customer == null)
            {
                throw new InvalidParameterException("Customer Not Found.");
            }

            return new CustomerBO
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                Address = customer.Address
            };
        }

        public async Task UpdateCustomer(CustomerBO customer)
        {
            if (customer == null)
            {
                throw new InvalidOperationException("Customer is missing");
            }

            if (IsNameAlreadyUsed(customer.Name, customer.Id))
            {
                throw new DuplicateException("Customer name is already used");
            }
            var customerInfo = await _bookingUnitOfWork.Customers.GetByIdAsync(customer.Id);

            if (customerInfo != null)
            {
                customerInfo.Id = customer.Id;
                customerInfo.Name = customer.Name;
                customerInfo.Age = customer.Age;
                customerInfo.Address = customer.Address;
                await _bookingUnitOfWork.SaveAsync();
            }
            else
            {
                throw new InvalidOperationException("Customer is not available");
            }

        }

        public async Task DeleteCustomer(Guid id)
        {
            _bookingUnitOfWork.Customers.Remove(id);
            await _bookingUnitOfWork.SaveAsync();

        }


        private bool IsNameAlreadyUsed(string name) =>
            _bookingUnitOfWork.Customers.GetCount(n => n.Name == name) > 0;

        private bool IsNameAlreadyUsed(string name, Guid id) =>
           _bookingUnitOfWork.Customers.GetCount(n => n.Name == name && n.Id != id) > 0;
    }
}
