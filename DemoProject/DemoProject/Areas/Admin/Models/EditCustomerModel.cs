using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Areas.Admin.Models
{
    public class EditCustomerModel

    { 
        //public int? Id { get; set; }
        //[Required , MaxLength(100,ErrorMessage = "Nameshould be less than 100 characters")]
        //public string Name { get; set; }
        //[Required,Range(0,150)]
        //public int? Age { get; set; }
        //[Required, MaxLength(300, ErrorMessage = "Nameshould be less than 300 characters")]
        //public string Address { get; set; }

        //private readonly IBookingService _bookingService;
        //public EditCustomerModel()
        //{
        //    _bookingService = Startup.AutofacContainer.Resolve<IBookingService>();
        //}
        //public EditCustomerModel(IBookingService bookingService)
        //{
        //    _bookingService = bookingService;
        //}

        //public void LoadModelData(int id)
        //{
        //    var Customer = _bookingService.GetCustomer(id);

        //    Id = Customer?.Id;
        //    Name = Customer?.Name;
        //    Age = Customer?.Age;
        //    Address = Customer?.Address;
        //}

        //internal void Update()
        //{
        //    var customer = new CustomerBO
        //    {
        //        Id =Id.HasValue? Id.Value :0,
        //        Name= Name,
        //        Age =Age.HasValue? Age.Value :0,
        //        Address =Address
               
        //    };
        //    _bookingService.UpdateCustomer(customer);
        //}
    }
}
