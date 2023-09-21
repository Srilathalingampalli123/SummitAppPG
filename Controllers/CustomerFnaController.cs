using Microsoft.AspNetCore.Mvc;
using Summit.Repositories.Services.Interfaces;
using SummitAppDemo.ActionFilters;
using SummitAppDemo.Contracts.Requests;
using SummitAppDemo.Contracts.Responses;
using SummitAppDemo.Routes;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SummitAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFnaController : ControllerBase
    {
        private readonly ICustomerFNAInfoService _customerFNAInfoService;
        public CustomerFnaController(ICustomerFNAInfoService customerFNAInfoService)
        {
                _customerFNAInfoService = customerFNAInfoService;
        }
        // GET: api/<CustomerFnaController>
        [HttpGet(APIRoutes.CustomerFNAs)]
        [SwaggerResponse(statusCode: 200, type: typeof(CustomerFNAResponse))]
        [Route("GetCustomerfnas")]
        public async Task<IActionResult> GetCustomerFNAS(String customerid,CancellationToken cancellationToken)
        {
           var res=await _customerFNAInfoService.GetCustomerFnasByCustomerId(customerid,cancellationToken);
       return Ok(res);
        }

        // GET api/<CustomerFnaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerFnaController>
        [HttpPost(APIRoutes.Customers)]
        [SwaggerResponse(statusCode: 200, type: typeof(CustomerFNAResponse))]
        [ServiceFilter(typeof(ValidationBodyActionFilter))]
        public async Task<IActionResult> CreateCustomerFNA([FromBody] CreateCustomerFnaReq customerreq)
        {
            var result = await _customerFNAInfoService.CreateCustomerAsync(customerreq);
            return Ok();
        }

        // PUT api/<CustomerFnaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerFnaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
