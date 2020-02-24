using pizzeria.dtos;
using pizzeria.Domain;
using pizzeria.infrastructure;

namespace pizzeria.services
{
    public class IngredientService:IIngredientService
    {
        private readonly IRepositoryIngredient _repositoryIngredient;

        public IngredientService(IRepositoryIngredient repositoryIngredient)
        {
            _repositoryIngredient = repositoryIngredient;
        }

        public object AddIngredients(DTOIngredient newIngredient)
        {
            var ingredient = Ingredient.Create(newIngredient);
            _repositoryIngredient.Ingredients.Add(ingredient); 
            _repositoryIngredient.SaveChanges();        
            return new {
                 Name= ingredient.Name,
                 price = ingredient.price
            };                
        }
    }

}