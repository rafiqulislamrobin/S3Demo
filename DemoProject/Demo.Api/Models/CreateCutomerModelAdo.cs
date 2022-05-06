
using Autofac;
using Custom.DataLayer;
using System.ComponentModel.DataAnnotations;

namespace Demo.Api.Models
{
    public class CreateCutomerModelAdo
    {

        [Required, MaxLength(100, ErrorMessage = "Nameshould be less than 100 characters")]
        public string Name { get; set; }

        [Required, Range(0, 150)]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        private IRepository _repository;
        private ILifetimeScope _scope;
        public CreateCutomerModelAdo()
        {

        }

        public CreateCutomerModelAdo(IRepository repository)
        {
            _repository = repository;
        }

        //public void Resolve(IRepository repository)
        //{
        //    _repository = repository;
        //}

        public void AutofacResolve(ILifetimeScope scope)
        {
            _scope = scope;
            _repository = _scope.Resolve<IRepository>();
        }

        public async Task CreateCustomerSpAsync()
        {
            var customer = new Custom.DataLayer.Customer()
            {
                Name = Name,
                Age = Age,
                Address = Address,
            };

            //var dbContext = new Repository();
            //dbContext.AddCustomerSp(customer);
            if (!string.IsNullOrWhiteSpace(customer.Name))
                await _repository.AddCustomerSpAsync(customer);
            else
                throw new InvalidOperationException("Customer name can not be null");
        }

        public void CreateCustomer()
        {
            var entityName = "Customers";

            var customer = new Custom.DataLayer.Customer()
            {
                Name = Name,
                Age = Age,
                Address = Address,
            };

            _repository.AddCustomer(customer, entityName);
        }

        public void CreateCustomerBulk()
        {
            var entityName = "Customers";
            var customers = new List<Custom.DataLayer.Customer>();

            for (int i = 0; i < 10; i++)
            {
                var customer = new Custom.DataLayer.Customer()
                {
                    Name = $"abc{i}",
                    Age = 1 + 1,
                    Address = "xyz",
                };
                customers.Add(customer);
            }

            var dbContext = new Repository();
            dbContext.AddCustomerBulk(customers, entityName);
        }
    }
}
