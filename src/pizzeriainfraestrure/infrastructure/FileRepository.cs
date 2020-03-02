using pizzeria.Domain;
using StackExchange.Redis;

namespace pizzeria.infrastructure
{


    public class FileRepository : IFileRepository
    {
        //https://stackexchange.github.io/StackExchange.Redis/Configuration.html



        public void Add(File image)
        {
            using (var multiplexer = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                byte[] byteArray = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 };
                var db = multiplexer.GetDatabase();
                db.StringSet("bytearray", byteArray);
            }

             
            //db.StringSet("image", image);   // Keyname , keyvalue
            //db.StringGet("image");  //recupera valor 
        }
    }
}
