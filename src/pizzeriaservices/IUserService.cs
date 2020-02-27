using System;
using pizzeria.dtos;

namespace pizzeria.services
{
    public interface IUserService
    {
        object Register(DTORegister register);
        object Login(DTOLogin login);
        //todo
        //todo que se ha de pasar a logout?
        object Logout(DTOLogin login);
        //todo
        object Refresh(DTOLogin register);
    }
}