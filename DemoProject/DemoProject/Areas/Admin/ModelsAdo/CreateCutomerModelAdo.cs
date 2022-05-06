using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

using System.ComponentModel.DataAnnotations;
using Demo.Customer.Services;
using Demo.Customer.Business_Object;
using Custom.DataLayer;
using ChildRepositoryAdoGeneric = Demo.GenericCustomLayerAdo.ChildRepositoryAdoGeneric ;

namespace DemoProject.Areas.Admin.ModelsAdo
{
    public class CreateCutomerModelAdo
    {

        [Required, MaxLength(100, ErrorMessage = "Nameshould be less than 100 characters")]
        public string Name{ get; set; }

        [Required, Range(0, 150)]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        public async Task CreateCustomerSp()
        {
            var customer = new Customer()
            {
                Name = Name,
                Age = Age,
                Address = Address,
            };

            var dbContext = new Repository();
            await dbContext.AddCustomerSpAsync(customer);
        }

        public void CreateCustomer()
        {
            var entityName = "Customers";
            var customer = new Customer()
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
            var customers = new List<Customer>();

            for (int i = 0; i < 10; i++)
            {
                var customer = new Customer()
                {
                    Name = $"abc{i}" ,
                    Age = 1+1,
                    Address = "xyz",
                };
                customers.Add(customer);
            }

            var dbContext = new Repository();
            dbContext.AddCustomerBulk(customers, entityName);
        }
    }
}
