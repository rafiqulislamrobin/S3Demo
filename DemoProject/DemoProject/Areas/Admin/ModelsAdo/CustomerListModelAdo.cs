using Autofac;
using System.Collections.Generic;
using System;
using System.Linq;
using Demo.Customer.Services;
using Custom.DataLayer;

namespace DemoProject.Areas.Admin.ModelsAdo
{
    public class CustomerListModelAdo
    {
        public async Task<object> GetCustomers(DataTablesAjaxRequestModelAdo dataTableAjaxRequestModel)
        {
            var repository = new Repository();

            var customers = repository.GetAllCustomers();

            return new
            {
                data = (from record in customers
                        select new string[]
                        {
                                record.Name,
                                record.Age.ToString(),
                                record.Address.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public async Task Delete(Guid id)
        {
            var repository = new Repository();

            repository.DeleteCustomer(id);
        }
    }
}
