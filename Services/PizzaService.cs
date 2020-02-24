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
    public class PizzaService : IPizzaService
    {
        private readonly IRepositoryPizza _repositoryPizza;
        public PizzaService(IRepositoryPizza repositoryPizza)
        {
            _repositoryPizza = repositoryPizza;
        }
        public object AddPizza(DTOPizza newPizza)
        {
            var pizza = Pizza.Create(newPizza);
            _repositoryPizza.Pizza.Add(pizza); 
            _repositoryPizza.SaveChanges(); 
            return new {
                 id= pizza.id,
                 name=pizza.Name   
            };     
        }
    }

}