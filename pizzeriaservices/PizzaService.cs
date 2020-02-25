using pizzeria.dtos;
using pizzeria.Domain;
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

            //crear lista de ingredientes
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