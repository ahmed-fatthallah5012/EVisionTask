using System.Threading.Tasks;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Filter;
using Models.Models;

namespace Server.Controllers
{
    public class CustomerController : ApiControllerBase<CustomerModel , ICustomerService>
    {
        public CustomerController(ICustomerService service) : base(service)
        {
        }

        [HttpPost("search")]
        public async Task<ActionResult> RemoveAsync([FromBody] CustomerFilter filter) => Ok( await Service.SearchWithFilterToGetListAsync(filter));

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id) => Ok( await Service.GetSingleWithIdAsync(id));
    }
}