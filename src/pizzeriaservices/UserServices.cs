using System;
using pizzeria.dtos;
using pizzeria.Domain;
using System.Linq;


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
            return new
            {
                id = user.id,
                name = user.Name
            };
        }
        public object Login(DTOLogin login)
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
            //retornar el jwt y guardar en redis la session
            return new
            {
                id = user.id,
                name = user.Name
            };

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