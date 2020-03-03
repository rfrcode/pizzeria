using System;
using pizzeria.dtos;
using pizzeria.Domain;
using System.Linq;


using pizzeria.services;
using pizzeria.infrastructure;
using Microsoft.Extensions.Configuration;
using JWT.Builder;
using JWT.Algorithms;

namespace pizzeria.services
{
    public class UserServices : IUserService
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IConfiguration _configuration;
        public UserServices(IRepositoryUser repositoryUser, IConfiguration Configuration)
        {
            _repositoryUser = repositoryUser;
            _configuration = Configuration;
        }
        public object Register(DTORegister register)
        {
            var user = User.Create(register);
            _repositoryUser.User.Add(user); //repository pattern
            _repositoryUser.SaveChanges(); //unit of work
            return Login(new DTOLogin() { Email = register.Email, PassWord = register.PassWord });
        }
        public object Login(DTOLogin login)
        {

            //recuperar el user
            var user = _repositoryUser.User.Where(u => u.Email == login.Email).FirstOrDefault();
            if (user != null)
            {
                if (User.GetPassWord(login.PassWord) != user.PassWord)
                {
                    throw new Exception("Wrong user");
                }
            }
            //retornar el jwt y guardar en redis la session
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(_configuration.GetValue<string>("secret"))
                .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                .AddClaim("user", user.Name)            
                .Encode();


        }
        //todo
        public object Logout(DTOLogin login)
        {
            //recuperar el user
            var user = _repositoryUser.User.Where(u => u.Email == login.Email).FirstOrDefault();
            if (user != null)
            {
                if (User.GetPassWord(login.PassWord) != user.PassWord)
                {
                    throw new Exception("Usuario incorrecto");
                }
            }
            //todo
            return new
            {
                message = "logout test succesful"
            };
            //borrar de redis la session
        }
        //todo 
        public object Refresh(DTOLogin login)
        {
            var user = _repositoryUser.User.Where(u => u.Email == login.Email).FirstOrDefault();
            if (user != null)
            {
                if (User.GetPassWord(login.PassWord) != user.PassWord)
                {
                    throw new Exception("Usuario incorrecto");
                }
            }
            //retornar el jwt y guardar en redis la session
            //todo
            return new
            {
                id = user.id,
                name = user.Name
            };
            //comprobar en redis el ultimo token
            //elimino
            //creo uno nuevo
            //retornar el nuevo
        }
    }

}