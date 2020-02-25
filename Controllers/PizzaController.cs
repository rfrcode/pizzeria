using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.dtos;
using pizzeria.services;


namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {

        private readonly ILogger<PizzaController> _logger;
        private readonly pizzeria.services.IPizzaService _pizzaService;

        public PizzaController(ILogger<PizzaController> logger, IPizzaService pizzaService)
        {
            _logger = logger;
            _pizzaService = pizzaService;
        }

        [HttpPost]
        public void Post([FromBody]IFormFile file)
        { 
            /*var result = _pizzaService.AddPizza(newPizza);
            return Ok(result);*/
           
        }
    }
}