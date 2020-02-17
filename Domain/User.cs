using System;
using pizzeria.dtos;
namespace pizzeria.Domain
{

    public class User
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }


        public static User Create(DTORegister register)
        {
            var user = new User();
            user.Name = register.Name;
            user.PassWord = register.PassWord; //TODO conviertir a encriptacion sha256

            //https://docs.microsoft.com/es-es/dotnet/api/system.security.cryptography.sha256?view=netframework-4.8
            return user;
        }
    }

}