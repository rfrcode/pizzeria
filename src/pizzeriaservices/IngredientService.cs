using pizzeria.dtos;
using pizzeria.Domain;
using pizzeria.infrastructure;
using ingredient.dtos;

namespace pizzeria.services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepositoryIngredient _repositoryIngredient;
        public PizzaService(IRepositoryPizza repositoryIngredient)
        {
            _repositoryIngredient = repositoryIngredient;
        }
        public object AddIngredient(DTOIngredient newPizza)
        {

            //crear lista de ingredientes
            var pizza = Ingredient.Create(newPizza);
            _repositoryIngredient.Ingredient.Create(pizza); 
            _repositoryPizza.SaveChanges(); 
            return new {
                 id= pizza.id,
                 name=pizza.Name   
            };     
        }
    }

}