using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pizzeria.services;
using pizzeria.infrastructure;
using pizzeria.utils;
using Microsoft.EntityFrameworkCore;

namespace pizzeria
{
    public class Pepito
    {
        public Pepito(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            /*services.AddMvc()   
            .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true;  
            });*/
            //  services.AddCors();
            services.AddControllers();
            var userServices = new ServiceDescriptor(typeof(IUserService), typeof(UserServices), ServiceLifetime.Scoped);
            var repositoryUser = new ServiceDescriptor(typeof(IRepositoryUser), typeof(PizzeriaContext), ServiceLifetime.Scoped);
            services.Add(userServices);
            services.Add(repositoryUser);

            var pizzaService = new ServiceDescriptor(typeof(IPizzaService), typeof(PizzaService), ServiceLifetime.Scoped);
            services.Add(pizzaService);
            var repositoryPizza = new ServiceDescriptor(typeof(IRepositoryPizza), typeof(PizzeriaContext), ServiceLifetime.Scoped);
            services.Add(repositoryPizza);

            var streamService = new ServiceDescriptor(typeof(IStreamService),typeof(StreamService),ServiceLifetime.Scoped);
            services.Add(streamService);

            var fileRepository = new ServiceDescriptor(typeof(IFileRepository),typeof(FileRepository),ServiceLifetime.Scoped);
            services.Add(fileRepository);

		    var ingredientServices = new ServiceDescriptor(typeof(IIngredientService), typeof(IngredientService), ServiceLifetime.Scoped);
            services.Add(ingredientServices);
            var repositoryIngredient = new ServiceDescriptor(typeof(IRepositoryIngredient), typeof(PizzeriaContext), ServiceLifetime.Scoped);
            services.Add(repositoryIngredient);
            var imageServer = new ServiceDescriptor(typeof(IImageServer),typeof(ImageServer),ServiceLifetime.Scoped);
            services.Add(imageServer);
            
            services.AddHttpClient();



            



            services.AddDbContext<PizzeriaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}