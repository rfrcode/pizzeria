using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.infrastructure
{
    public class PizzeriaContext : DbContext, IUoW, IRepositoryUser, IRepositoryPizza, IRepositoryIngredient
    {
        public PizzeriaContext(DbContextOptions<PizzeriaContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(c => new { c.id });
            modelBuilder.Entity<Ingredient>().HasKey(c => new { c.id });

            // modelBuilder.Entity<Pizza>().HasKey(c => new { c.id, c.Ingredients});

        }

        public DbSet<User> User { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
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