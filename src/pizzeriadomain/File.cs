  
using System;
namespace pizzeria.Domain{
    public class File{
        public Guid Id { get; set; } 
        public byte[] Image {get;set;}
        public static File Create(byte[] Image){
            return new File(){
                Id=Guid.NewGuid(),
                Image = Image,
            };
        }
    }
}