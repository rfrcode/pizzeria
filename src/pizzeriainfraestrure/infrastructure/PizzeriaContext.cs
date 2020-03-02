using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.infrastructure
{

    public class PizzeriaContext : DbContext, IUoW, IRepositoryUser, IRepositoryPizza
    {
        public PizzeriaContext(DbContextOptions<PizzeriaContext> options) : base(options)
        {

        }

        public PizzeriaContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(c => new { c.id });
            //modelBuilder.Entity<Pizza>().HasKey(c => new { c.id });

        }

        public DbSet<User> User { get; set; }
        public DbSet<Pizza> Pizza { get; set; }

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