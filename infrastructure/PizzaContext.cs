
using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.infrastructure
{

    public class PizzaContext : DbContext, IUoW, IRepositoryUser
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>()                
                .HasKey(c=>new {c.id});
                
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