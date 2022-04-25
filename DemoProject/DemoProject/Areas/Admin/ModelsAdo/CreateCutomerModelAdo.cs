using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

using System.ComponentModel.DataAnnotations;
using Demo.Customer.Services;
using Demo.Customer.Business_Object;
using Custom.DataLayer;

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

        public void CreateCustomerSp()
        {
            var customer = new Customer()
            {
                Name = Name,
                Age = Age,
                Address = Address,
            };

            var dbContext = new DbContext();
            dbContext.AddCustomerSp(customer);
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

            var dbContext = new DbContext();
            dbContext.AddCustomer(customer, entityName);
        }
    }
}
