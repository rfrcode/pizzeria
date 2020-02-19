
using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.infrastructure
{

    public class PizzaContext : DbContext, IUoW, IRepositoryUser
    {
        //https://elanderson.net/2019/11/entity-framework-core-no-database-provider-has-been-configured-for-this-dbcontext/
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { 

        }

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