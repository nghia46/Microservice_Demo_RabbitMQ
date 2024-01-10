using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {

        public InventoryController()
        {
            
        }
        [HttpGet]
        public IActionResult Index() { 
            return Ok();
        }
    }
}
