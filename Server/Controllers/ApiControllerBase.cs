// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Core.Services;
using Models.Models;

namespace Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("[controller]")]
    [ApiController]
    public abstract class ApiControllerBase<TModel , TService> : ControllerBase 
        where TModel : ModelBase where TService : IService<TModel>
    {
        protected readonly TService Service;

        protected ApiControllerBase(TService service) 
            => Service = service;

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await Service.GetAllAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] TModel model)
        {
            return Ok(await Service.SaveAsync(model));
        }

        [HttpPost("remove")]
        public async Task<ActionResult> RemoveAsync([FromBody] TModel model)
        {
            return   Ok(await Service.RemoveAsync(model));
        }
    }
}
