using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Demo.Customer.Services;
using Demo.Customer.Business_Object;

namespace DemoProject.Areas.Admin.Models
{
    public class EditCustomerModel

    {
        public Guid Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Nameshould be less than 100 characters")]
        public string Name { get; set; }
        [Required, Range(0, 150)]
        public int? Age { get; set; }
        [Required, MaxLength(300, ErrorMessage = "Nameshould be less than 300 characters")]
        public string Address { get; set; }
        private ILifetimeScope _scope;
        private IBookingService _bookingService;

        //private readonly IBookingService _bookingService;
        public EditCustomerModel()
        {

        }

        public EditCustomerModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _bookingService = _scope.Resolve<IBookingService>();
        }


        public async Task LoadModelData(Guid id)
        {
            var Customer = await _bookingService.GetCustomer(id);

            Id = Customer.Id;
            Name = Customer!.Name;
            Age = Customer!.Age;
            Address = Customer!.Address;
        }

        public async Task Update()
        {
            var customer = new CustomerBO
            {
                Id = Id,
                Name = Name,
                Age = Age.HasValue ? Age.Value : 0,
                Address = Address

            };

            await _bookingService.UpdateCustomer(customer);
        }
    }
}
