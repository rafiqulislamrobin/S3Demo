using Autofac;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DemoProject.Areas.Admin.Models
{
    public class CustomerListModel
    {
        

        //private readonly IBookingService _bookingService;
        //public CustomerListModel()
        //{
        //    _bookingService = Startup.AutofacContainer.Resolve<IBookingService>();
        //}
        //public CustomerListModel(IBookingService bookingService)
        //{
        //    _bookingService = bookingService;
        //}

        //internal object GetCustomers(DataTablesAjaxRequestModel dataTableAjaxRequestModel)
        //{
            
        //        var data = _bookingService.GetCutomers(
        //            dataTableAjaxRequestModel.PageIndex,
        //            dataTableAjaxRequestModel.PageSize,
        //            dataTableAjaxRequestModel.SearchText,
        //            dataTableAjaxRequestModel.GetSortText(new string[] { "Name", "Age", "Address" }));

        //        return new
        //        {
        //            recordsTotal = data.total,
        //            recordsFiltered = data.totalDisplay,
        //            data = (from record in data.records
        //                    select new string[]
        //                    {
        //                        record.Name,
        //                        record.Age.ToString(),
        //                        record.Address.ToString(),
        //                        record.Id.ToString()
        //                    }
        //                ).ToArray()
        //        };
            
        //}

        //internal void Delete(int id)
        //{
        //    _bookingService.DeleteCustomer(id);
        //}
    }
}
