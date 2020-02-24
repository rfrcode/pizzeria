using System;
using pizzeria.dtos;

namespace pizzeria.services
{
    public interface IPizzaService
    {
        object AddPizza(DTOPizza newPizza);
    }
}