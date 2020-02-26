using System;
using pizzeria.dtos;

namespace pizzeria.services
{
    public interface IUserService
    {
        object Register(DTORegister register);
    }
}