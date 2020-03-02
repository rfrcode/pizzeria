using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ingredient.services;
using ingredient.utils;


namespace ingredient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {

        private readonly ILogger<IngredientController> _logger;
        private readonly ingredient.services.IIngredientService _pizzaService;

        public IngredientController(ILogger<IngredientController> logger, IIngredientService pizzaService)
        {
            _logger = logger;
            _pizzaService = pizzaService;
        }

        [HttpPost]
        public IActionResult Post([FromForm]IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
         //   _pizzaService.Upload(file);
            return Ok();
        }
    }
}