using pizzeria.dtos;

namespace pizzeria.services
{
    public interface IIngredientService
    {
        object AddIngredient(DTOIngredient ingredient);
    }
}