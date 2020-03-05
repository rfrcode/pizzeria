using System.Collections.Generic;
using pizzeria.Domain;
using pizzeria.Dtos;
using pizzeria.Infraestructure;
using pizzeria.infrastructure;

namespace pizzeria.Application
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepositoryIngredient _repositoryIngredient;
        public IngredientService(IRepositoryIngredient repositoryIngredient)
        {
            _repositoryIngredient = repositoryIngredient;
        }

        public void AddRange(IEnumerable<IngredientFileRead> ingredientFileRead)
        {
            foreach(var ingredient in ingredientFileRead){
                var ing=Ingredient.Create(ingredient);
                _repositoryIngredient.Ingredient.Add(ing);
            }
            _repositoryIngredient.SaveChanges();
        }
    }
}