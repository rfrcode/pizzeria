using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.Infraestructure
{
    public interface IIngredientoW
    {
        int SaveChanges();
    }
    public interface IIngredientRepository : IIngredientoW
    {
        DbSet<Ingredient> Ingredient { get; set; }

    }
}