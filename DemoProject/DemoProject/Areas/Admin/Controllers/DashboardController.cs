using Autofac;
using DemoProject.Areas.Admin.Models;
using DemoProject.Areas.Admin.ModelsAdo;
using Microsoft.AspNetCore.Mvc;

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
            var model = new CustomerListModelAdo();

            return View(model);
        }

        public async Task<JsonResult> GetCustomerData()
        {
            var dataTableAjaxRequestModel = new DataTablesAjaxRequestModelAdo(Request);
            var model = new CustomerListModelAdo();
            var data = await model.GetCustomers(dataTableAjaxRequestModel);
            return Json(data);
        }

        public IActionResult Create()
        {
            var model = new CreateCutomerModelAdo();
            return View(model);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateCutomerModelAdo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     model.CreateCustomer();
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
            var model = new EditCustomerModelAdo();
            await model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditCustomerModelAdo model)
        {
            if (ModelState.IsValid)
            {
                await model.Update();
            }

            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = new CustomerListModelAdo();
            await model.Delete(id);
            return RedirectToAction(nameof(Customers));
        }
    }
}
