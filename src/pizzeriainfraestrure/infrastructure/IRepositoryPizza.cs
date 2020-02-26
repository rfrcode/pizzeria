using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;
namespace pizzeria.infrastructure{
    public interface IRepositoryPizza:IUoW
    {
        DbSet<Pizza> Pizza{get;set;}
    }
} 