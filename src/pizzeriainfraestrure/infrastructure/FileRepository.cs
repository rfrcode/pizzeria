using pizzeria.Domain;
using StackExchange.Redis;

namespace pizzeria.infrastructure
{


    public class FileRepository : IFileRepository
    {
        //https://stackexchange.github.io/StackExchange.Redis/Configuration.html



        public void Add(File image)
        {

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            IDatabase db = redis.GetDatabase();
             byte[] byteArray = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 };
       //     db.StringSet("image", image);   // Keyname , keyvalue


            //  byte[] byteArray = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 };
            //   IDatabase database = redis.GetDatabase();





            //  db.StringSet("image", image);   // Keyname , keyvalue
            //db.StringGet("image");  //recupera valor 
        }
    }
}
