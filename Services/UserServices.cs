using System;
using pizzeria.dtos;
using pizzeria.Domain;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.services;
using pizzeria.infrastructure;

namespace pizzeria.services
{
    public class UserServices : IUserService
    {
        private readonly IRepositoryUser _repositoryUser;
        public UserServices(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }
        public object Register(DTORegister register)
        {
            var user = User.Create(register);
            _repositoryUser.User.Add(user); //repository pattern
            _repositoryUser.SaveChanges(); //unit of work       
            return new {
                 id= user.id,
                 name=user.Name   
            };     
        }
    }

}