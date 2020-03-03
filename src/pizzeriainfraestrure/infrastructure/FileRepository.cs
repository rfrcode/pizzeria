using System;
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

        public void Add(File image)
        {

            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_connection))
            {
                IDatabase db = redis.GetDatabase();
                db.SetAdd(image.Id.ToString(), image.Image);   
                db.KeyExpire(image.Id.ToString(),TimeSpan.FromHours(12));
            }

            
        }
    }
}
