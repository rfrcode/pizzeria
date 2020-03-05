using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Http;
using pizzeria.Dtos;
using pizzeria.Application;
using CsvHelper;

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
        public IActionResult ingredient([FromForm]IFormFile csv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            using (MemoryStream ms = new MemoryStream())
            {
                csv.CopyTo(ms);
                using (TextReader fileReader = new StreamReader(ms))
                {
                    var csvReader = new CsvReader(fileReader);
                    var result = csvReader.GetRecords<IngredientFileRead>();
                    _ingredientService.AddRange(result);
                    return Ok();
                }
            }

        }
    }
}