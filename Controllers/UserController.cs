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
        //        public void Post([FromBody]DTORegister userRegister)
        public IActionResult Post(DTORegister userRegister)
        
        {  //error 404
            if (!ModelState.IsValid)
            {

                //ModelState.AddModelError("Name","error"); 
                //envia error 404  //https://docs.microsoft.com/es-es/aspnet/core/web-api/action-return-types?view=aspnetcore-3.1#iactionresult-type
                    //muestra el error 
               return BadRequest(ModelState); 

            }
             _userService.Register(userRegister);
            // muestra el json
            return Ok(userRegister);
           
        }
    }
}