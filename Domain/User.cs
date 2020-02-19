using System.ComponentModel.DataAnnotations;
using System;
using pizzeria.dtos;
namespace pizzeria.Domain
{

    public class User
    {
        public  int id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }


        public static User Create(DTORegister register)
        {
            var user = new User();
            user.id = register.id;
            user.Name = register.Name;
            user.Email = register.Email;
            user.PassWord = register.PassWord; //TODO conviertir a encriptacion sha256

            /*   para la encriptación sha256
            https://docs.microsoft.com/es-es/dotnet/api/system.security.cryptography.sha256?view=netframework-4.8
            */
            return user;
        }
    }

}