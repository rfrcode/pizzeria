using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.dtos;
using pizzeria.services;

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

        [HttpPost]
        public void Post([FromBody]DTORegister userRegister)
        {  //error 404
             if(!ModelState.IsValid){

                
               // cambiar void para retornar algo
               // si es valido retorna token
               // si no error


            } 
            _userService.Register(userRegister);
        }
    }
}