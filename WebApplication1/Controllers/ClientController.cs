using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;


    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientWithSubscriptions(int id)
        {
            var clientDTO = await _clientService.GetClientWithSubscriptionsAsync(id);

            if (clientDTO == null)
            {
                return NotFound();
            }

            return Ok(clientDTO);
        }
        
    }