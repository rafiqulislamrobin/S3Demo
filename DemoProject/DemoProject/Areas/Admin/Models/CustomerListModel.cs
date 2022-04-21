using Autofac;
using System.Collections.Generic;
using System;
using System.Linq;
using Demo.Customer.Services;

namespace DemoProject.Areas.Admin.Models
{
    public class CustomerListModel
    {
        private ILifetimeScope _scope;
        private IBookingService _bookingService;
        public CustomerListModel()
        {

        }

        public CustomerListModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _bookingService = _scope.Resolve<IBookingService>();
        }

        internal async Task<object> GetCustomers(DataTablesAjaxRequestModel dataTableAjaxRequestModel)
        {

            var data = await _bookingService.GetCutomers(
                dataTableAjaxRequestModel.PageIndex,
                dataTableAjaxRequestModel.PageSize,
                dataTableAjaxRequestModel.SearchText,
                dataTableAjaxRequestModel.GetSortText(new string[] { "Name", "Age", "Address", "Id" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
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

        internal async Task Delete(Guid id)
        {
            await _bookingService.DeleteCustomer(id);
        }
    }
}
