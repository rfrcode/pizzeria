using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Extensions.Configuration;
using pizzeria.Domain;
using StackExchange.Redis;

namespace pizzeria.infrastructure
{


    public class FileRepository : IFileRepository
    {

        readonly IConfiguration _configuration;
        readonly string _connection;
        const string KEYCONNECTION = "RedisConnection";

        public FileRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = configuration.GetValue<string>(KEYCONNECTION);
        }

        public void Add(Domain.File image)
        {

            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_connection))
            {
                IDatabase db = redis.GetDatabase();
                db.SetAdd(image.Id.ToString(), image.Image);
                db.KeyExpire(image.Id.ToString(), TimeSpan.FromHours(12));
            }


        }

        public byte[] Get(Guid Id)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_connection))
            {
                IDatabase db = redis.GetDatabase();
                var result = db.SetMembers(Id.ToString());
                return result[0];
               
               //var a = db.gt
                
            }
        }
        public void Delete(Guid Id){
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_connection))
            {
                IDatabase db = redis.GetDatabase();
                db.KeyDelete(Id.ToString());
                
            }
        }

        

    }
}
