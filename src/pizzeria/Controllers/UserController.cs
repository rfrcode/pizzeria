using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.dtos;
using pizzeria.services;

namespace pizzeria.Controllers
{
    [ApiController]
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
        [Route("Register")]
        public IActionResult Register([FromBody]DTORegister userRegister)
        {
            var result = _userService.Register(userRegister);
            return Ok(result);

        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody]DTOLogin userLogin)
        {
            var result = _userService.Login(userLogin);
            return Ok(result);

        }
        [HttpPost]
        [Route("Logout")]

        //todo 
        public IActionResult Logout([FromBody]DTORegister userRegister)
        {
            var result = _userService.Logout(userRegister);
            return Ok(result);

        }
        [HttpPost]
        [Route("Refresh")]
        //todo
        public IActionResult Refresh([FromBody]DTORegister userRegister)
        {
            var result = _userService.Refresh(userRegister);
            return Ok(result);

        }
    }
}