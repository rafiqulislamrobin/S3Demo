using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

using System.ComponentModel.DataAnnotations;

namespace DemoProject.Areas.Admin.Models
{
    public class CreateCutomerModel
    {

        [Required, MaxLength(100, ErrorMessage = "Nameshould be less than 100 characters")]
        public string Name{ get; set; }

        [Required, Range(0, 150)]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        //private readonly IBookingService _bookingService;
        public CreateCutomerModel()
        {

        }
        //public CreateCutomerModel(IBookingService bookingService)
        //{
        //    //_bookingService = bookingService;
        //}

        internal void CreateCustomer()
        {
            //var customer = new CustomerBO()
            //{
            //    Name = Name,
            //    Age = Age,
            //    Address = Address,
               
            //};
            //_bookingService.CreateCustomer(customer);
        }
    }
}
