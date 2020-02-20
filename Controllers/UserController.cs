using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.dtos;
using pizzeria.services;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult Post([FromBody]DTORegister userRegister)
        { 
            var result = _userService.Register(userRegister);
            return Ok(result);
           
        }
    }
}