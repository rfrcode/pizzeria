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
            //TODO hacer las migraciones


            //TODO arreglar los nombres de las propiedades may. la primera de la propiedad

            modelBuilder.Entity<Ingredient>(ingredient =>
                {
                    ingredient.HasKey(i => i.Id);
                    ingredient.Property(i => i.Price).IsRequired();
                    ingredient.Property(i => i.Name).IsRequired();

                });

           modelBuilder.Entity<Pizza>(pizza =>
            {
                pizza.HasKey(p => p.Id);
                pizza.Property(p => p.Name).IsRequired();
                pizza.Ignore(p => p.Price);
                pizza.HasMany<Image>(p => p.Images);
            });

            modelBuilder.Entity<PizzaIngredient>(pizin =>
             {
                 pizin.HasKey(pi => new { pi.Id });

                 pizin.HasOne<Ingredient>(pi => pi.Ingredient)
                 .WithMany().HasForeignKey(pi => pi.Id).IsRequired();

                 pizin.HasOne<Pizza>(pi => pi.Pizza).WithMany()
               .HasForeignKey(pi => pi.Id).IsRequired();
             });

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