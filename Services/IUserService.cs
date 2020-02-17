using System;
using pizzeria.dtos;

namespace pizzeria.services
{
    public interface IUserService
    {
        void Register(DTORegister register);
    }
}