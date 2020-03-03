using pizzeria.dtos;
using pizzeria.Domain;
using pizzeria.infrastructure;

namespace pizzeria.services
{
    public class PizzaService : IPizzaService
    {
  
        private readonly IRepositoryPizza _repositoryPizza;
         private readonly IFileRepository _repositoryFile;
        public PizzaService(IRepositoryPizza repositoryPizza, IFileRepository fileRepository)
        {
            _repositoryPizza = repositoryPizza;
            _repositoryFile =  fileRepository;

        }

        public object AddImage(byte[] image)
        {
            var file = File.Create(image);             
             _repositoryFile.Add(file);
            return new
            {
                Id = file.Id
            };
        }

        public object AddPizza(DTOPizza newPizza)
        {
            //crear lista de ingredientes
            var pizza = Pizza.Create(newPizza);
            _repositoryPizza.Pizza.Add(pizza);
            _repositoryPizza.SaveChanges();
            return new
            {
                id = pizza.id,
                name = pizza.Name
            };
        }
    }

}