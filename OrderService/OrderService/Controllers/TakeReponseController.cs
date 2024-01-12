using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using MassTransit;
namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TakeReponseController : ControllerBase
    {
        private readonly IRequestClient<Order> _requestClient;
        public TakeReponseController(IRequestClient<Order> requestClient)
        {
            _requestClient = requestClient;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            // Send a request and wait for the response
            var response = await _requestClient.GetResponse<OrderResponse>(order);
            await Console.Out.WriteLineAsync(response.ToString());
            return Ok(response);
        }
    }
}
