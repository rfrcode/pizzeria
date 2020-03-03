using pizzeria.dtos;
using pizzeria.Domain;
using pizzeria.infrastructure;

namespace pizzeria.services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepositoryIngredient _repositoryIngredient;
        public IngredientService(IRepositoryIngredient repositoryIngredient)
        {
            _repositoryIngredient = repositoryIngredient;
        }
        public object AddIngredient(DTOIngredient newPizza)
        {

            //crear lista de ingredientes
            var pizza = Ingredient.Create(newPizza);
            _repositoryIngredient.Ingredient.Add(pizza); 
            _repositoryIngredient.SaveChanges();
            System.Console.Write("bien");
            return new {
                 id= pizza.id,
                 name=pizza.Name ,
                 price=pizza.price  
            };     
        }

    }

}