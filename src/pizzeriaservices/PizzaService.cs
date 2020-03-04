using pizzeria.dtos;
using pizzeria.Domain;
using pizzeria.infrastructure;

namespace pizzeria.services
{
    public class PizzaService : IPizzaService
    {
  
        private readonly IRepositoryPizza _repositoryPizza;
         private readonly IFileRepository _repositoryFile;
         private readonly IImageServer _imageServer;
        public PizzaService(IRepositoryPizza repositoryPizza, 
            IFileRepository fileRepository,
            IImageServer imageServer
        
        )
        {
            _repositoryPizza = repositoryPizza;
            _repositoryFile =  fileRepository;
            _imageServer = imageServer;

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
            var image = _repositoryFile.Get(newPizza.Image);
            _imageServer.GetImages(image);
            //_repositoryFile.Delete(newPizza.Image);
            return null;
            //crear lista de ingredientes
            /*var pizza = Pizza.Create(newPizza);
            _repositoryPizza.Pizza.Add(pizza);
            _repositoryPizza.SaveChanges();
            return new
            {
                id = pizza.Id,
                name = pizza.Name
            };*/
        }
    }

}