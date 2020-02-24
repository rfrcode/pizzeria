using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.dtos;
using pizzeria.services;


namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {

        private readonly ILogger<IngredientController> _logger;
        private readonly IIngredientService _ingredientService;

        public IngredientController(ILogger<IngredientController> logger, IIngredientService ingredientService)
        {
            _logger = logger;
            _ingredientService = ingredientService;
        }


        [HttpPost]
        public IActionResult Post([FromBody]DTOIngredient ingredients)
        { 
            var result = _ingredientService.AddIngredients(ingredients);
            return Ok(result);
           
        }
    }
}