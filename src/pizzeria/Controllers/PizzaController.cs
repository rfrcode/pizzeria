using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.services;
using pizzeria.utils;


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
        public void Post([FromForm]IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(file.FileName, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

            }
        }
    }
}