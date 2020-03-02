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
    //[Route("[controller]/[action]/")]
    public class PizzasController : ControllerBase
    {

        private readonly ILogger<PizzasController> _logger;
        private readonly pizzeria.services.IPizzaService _pizzaService;
        private readonly IStreamService _streamService;

        public PizzasController(ILogger<PizzasController> logger, IPizzaService pizzaService,IStreamService streamService)
        {
            _logger = logger;
            _pizzaService = pizzaService;
            _streamService = streamService;
        }
       // [Route("/pizzas/image")]
        [HttpPost("/pizzas/image")]
        public IActionResult Post([FromForm]IFormFile file)
        {
            var result = _streamService.GetBytes(file);
            var imageId =_pizzaService.AddImage(result);
            return Ok(imageId);
        }
    }
}