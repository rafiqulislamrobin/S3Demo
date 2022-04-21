using Demo.Customer.Context;
using Demo.Customer.Repositories;
using DevSkill.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Customer.Unit_of_Work
{
    public class BookingUnitOfWork : UnitOfWork, IBookingUnitOfWork
    {
        public ICustomerRepository Customers { get; private set; }

        public BookingUnitOfWork(IBookingDbContext context,
            ICustomerRepository customers)
            : base((DbContext)context)
        {
            Customers = customers;
        }
    }
}
