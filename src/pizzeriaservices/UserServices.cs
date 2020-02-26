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
            return new {
                 id= user.id,
                 name=user.Name   
            };     
        }
        public void Login(string email,string passWord){
                //recuperar el user
                var user = _repositoryUser.User.Where(u=>u.Email == email).FirstOrDefault();
                if(user!=null){
                    if (User.GetPassWord(passWord)!=user.PassWord){
                        throw new Exception("Usuario incorrecto");
                    }
                }
                //retornar el jwt y guardar en redis la session

        }
        public void Logout(){
            //borrar de redis la session
        }
        public void Refresh(){
            //comprobar en redis el ultimo token
            //elimino
            //creo uno nuevo
            //retornar el nuevo
        }
    }

}