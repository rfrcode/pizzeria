using pizzeria.Dtos;
using System.Collections.Generic;

namespace pizzeria.Application
{
    public interface IIngredientService
    {
        void AddRange(IEnumerable<IngredientFileRead> ingredientFileRead);
    }
}