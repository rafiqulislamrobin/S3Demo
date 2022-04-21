using Demo.Customer.Context;
using Demo.Customer.Entites;
using DevSkill.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Demo.Customer.Repositories
{
    public class CustomerRepository : Repository<CustomerEO , Guid, BookingDbContext> , ICustomerRepository
    {
        public CustomerRepository(IBookingDbContext context)
           : base((BookingDbContext)context)
        {

        }
    }
    
}
