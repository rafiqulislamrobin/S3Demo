using Autofac;
using DemoProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ILifetimeScope _scope;

        public DashboardController(ILogger<DashboardController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult Customers()
        {
            var model = _scope.Resolve<CustomerListModel>();

            return View(model);
        }

        public async Task<JsonResult> GetCustomerData()
        {
            var dataTableAjaxRequestModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<CustomerListModel>();
            var data = await model.GetCustomers(dataTableAjaxRequestModel);
            return Json(data);
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<CreateCutomerModel>(); ;
            return View(model);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateCutomerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    await model.CreateCustomer();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Customer");
                    _logger.LogError(ex, "Add Customer Failed");
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = _scope.Resolve<EditCustomerModel>();
            await model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                await model.Update();
            }
            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _scope.Resolve<CustomerListModel>();
            await model.Delete(id);
            return RedirectToAction(nameof(Customers));
        }
    }
}
