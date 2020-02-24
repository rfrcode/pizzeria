
using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.infrastructure
{

    public class PizzeriaContext : DbContext, IUoW, IRepositoryUser
    {
        public PizzeriaContext(DbContextOptions<PizzeriaContext> options) : base(options) { 

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