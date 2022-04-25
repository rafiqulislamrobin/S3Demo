using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Demo.Customer.Services;
using Demo.Customer.Business_Object;
using Custom.DataLayer;

namespace DemoProject.Areas.Admin.ModelsAdo
{
    public class EditCustomerModelAdo

    {
        public Guid Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Nameshould be less than 100 characters")]
        public string Name { get; set; }
        [Required, Range(0, 150)]
        public int? Age { get; set; }
        [Required, MaxLength(300, ErrorMessage = "Nameshould be less than 300 characters")]
        public string Address { get; set; }


        public async Task LoadModelData(Guid id)
        {
            var dbContext = new DbContext();
            var customer = dbContext.GetCustomerData(id);

            Id = customer.Id;
            Name = customer!.Name;
            Age = customer!.Age;
            Address = customer!.Address;
        }

        public async Task Update()
        {
            var dbContext = new DbContext();

            var customer = new Customer
            {
                Id = Id,
                Name = Name,
                Age = Age.HasValue ? Age.Value : 0,
                Address = Address

            };

            dbContext.UpdateCustomer(customer);
        }
    }
}
