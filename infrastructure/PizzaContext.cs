
using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.infrastructure
{

    public class PizzaContext : DbContext, IUoW, IRepositoryUser
    {
        public DbSet<User> User { get; set; }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
       

    }

}