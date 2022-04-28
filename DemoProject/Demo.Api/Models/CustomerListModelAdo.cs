using Autofac;
using System.Collections.Generic;
using System;
using System.Linq;
using Demo.Customer.Services;
using Custom.DataLayer;

namespace Demo.Api.Models
{
    public class CustomerListModelAdo
    {
        public async Task<object> GetCustomers(DataTablesAjaxRequestModelAdo dataTableAjaxRequestModel)
        {
            var repository = new Repository();

            var customers = repository.GetAllCustomers();

            //return new
            //{
            //    data = (from record in customers
            //            select new string[]
            //            {
            //                    record.Name,
            //                    record.Age.ToString(),
            //                    record.Address.ToString(),
            //                    record.Id.ToString()
            //            }
            //        ).ToArray()
            //};
            return customers;
        }

        public async Task Delete(Guid id)
        {
            var repository = new Repository();

            repository.DeleteCustomer(id);
        }
    }
}
