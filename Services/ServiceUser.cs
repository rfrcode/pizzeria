using System;
using pizzeria.dtos;
using pizzeria.Domain;
namespace pizzeria.services
{
    public interface IUserService
    {
        void Register(DtoRegister register);
    }

    public class ServiceUsers : IUserService
    {
        public void Register(DtoRegister register)
        {
            var user = User.Create(register);
            //grabar en bb.ddd
        }
    }

}
