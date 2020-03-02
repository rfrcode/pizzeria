using System;
using pizzeria.dtos;

namespace pizzeria.services
{
    public interface IIngredientService
    {
        object Register(DTORegister register);
    }
}