using System.ComponentModel.DataAnnotations;
using System;
using pizzeria.dtos;
namespace pizzeria.Domain
{

    public class User
    {
        public Guid id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }


        public static User Create(DTORegister register)
        {
            var user = new User();
            user.id = Guid.NewGuid();
            user.Name = register.Name;
            user.Email = register.Email;
            user.PassWord = register.PassWord; //TODO conviertir a encriptacion sha256
            return user;
        }
    }

}