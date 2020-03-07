using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.infrastructure
{
    public interface IRepositoryUser : IUoW
    {
        DbSet<User> User { get; set; }
    }
}