using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace OrderService.Controllers;
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IPublishEndpoint _publishEndpoint;
    public OrderController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Order order)
    {
        await _publishEndpoint.Publish<Order>(order);
        return Ok();
    }
}