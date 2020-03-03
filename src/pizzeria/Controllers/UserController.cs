using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.dtos;
using pizzeria.services;

namespace pizzeria.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
            ///_userService = new ServiceUsers(); SE VIOLA LA D DE SOLID
            // ServiceDescriptor  para registro de dependencias

        }


        //   //actionresult
        //task http response  
        //async //await
        //http response
        // cambiar void para retornar algo
        // si es valido retorna token



        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]DTORegister userRegister)
        {
            var result = _userService.Register(userRegister);
            return Ok(result);
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]DTOLogin userLogin)
        {
            var result = _userService.Login(userLogin);
            return Ok(result);
        }
        [HttpPost]
        [Route("logout")]

        //todo 
        public IActionResult Logout([FromBody]DTOLogin userLogin)
        {
            var result = _userService.Logout(userLogin);
            return Ok(result);
        }
        [HttpPost]
        [Route("refresh")]
        //todo
        public IActionResult Refresh([FromBody]DTOLogin userLogin)
        {
            var result = _userService.Login(userLogin);
            return Ok(result);
        }
    }
}