using System;
using pizzeria.dtos;
using pizzeria.Domain;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.services;

namespace pizzeria.services
{
    public class UserServices : IUserService
    {
        public void Register(DTORegister register)
        {
            var user = User.Create(register);
            /**TODO: Grabar en bb.ddd*/
        }
    }

}