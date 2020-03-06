using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.infrastructure
{
    public interface IRepositoryIngredient : IUoW
    {
        DbSet<Ingredient> Ingredient { get; set; }
    }
}