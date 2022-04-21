using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Areas.Admin.Models
{
    public class TicketListModel
    {


        //private readonly IBookingService _bookingService;
        //public TicketListModel()
        //{
        //    _bookingService = Startup.AutofacContainer.Resolve<IBookingService>();
        //}
        //public TicketListModel(IBookingService bookingService)
        //{
        //    _bookingService = bookingService;
        //}

        //internal object GetTickets(DataTablesAjaxRequestModel dataTableAjaxRequestModel)
        //{

        //    var data = _bookingService.GetTickets(
        //        dataTableAjaxRequestModel.PageIndex,
        //        dataTableAjaxRequestModel.PageSize,
        //        dataTableAjaxRequestModel.SearchText,
        //        dataTableAjaxRequestModel.GetSortText(new string[] { "destination", "fees", "customerId" }));

        //    return new
        //    {
        //        recordsTotal = data.total,
        //        recordsFiltered = data.totalDisplay,
        //        data = (from record in data.records
        //                select new string[]
        //                {
        //                        record.destination,
        //                        record.fees.ToString(),
        //                        record.customerId.ToString(),
        //                        record.Id.ToString()
        //                }
        //            ).ToArray()
        //    };

        //}

        //internal void Delete(int id)
        //{
        //    _bookingService.DeleteCustomer(id);
        //}
    }
}
