using Autofac;
using Custom.DataLayer;
using Demo.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILifetimeScope _scope;

        public HomeController(ILogger<HomeController> logger,
            ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }


        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Customers()
        {
            var dataTableAjaxRequestModel = new DataTablesAjaxRequestModelAdo(Request);
            var model = new CustomerListModelAdo();
            var data = await model.GetCustomers(dataTableAjaxRequestModel);
            return Ok(data);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Customer(Guid id)
        {
            var model = new EditCustomerModelAdo();
            await model.LoadModelData(id);
            return Ok(model);
        }

        [HttpPost]
        [Route("api/[controller]/Create")]
        public async Task<IActionResult> Create([FromBody] CreateCutomerModelAdo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AutofacResolve(_scope);
                    await model.CreateCustomerSpAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Customer");
                    _logger.LogError(ex, "Add Customer Failed");
                    return BadRequest(model);
                }
            }

            return Ok(model);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = new CustomerListModelAdo();
            await model.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EditCustomerModelAdo model)
        {

            if (model != null)
            {
                if (ModelState.IsValid)
                {
                    await model.Update();
                }

                return View(model);
            }

            return NotFound("Student not found");
        }
    }
}
