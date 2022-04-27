
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

        public void CreateCustomerSp()
        {
            var customer = new Custom.DataLayer.Customer()
            {
                Name = Name,
                Age = Age,
                Address = Address,
            };

            var dbContext = new Repository();
            dbContext.AddCustomerSp(customer);
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

            var dbContext = new Repository();
            dbContext.AddCustomer(customer, entityName);

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
