using System;
using pizzeria.dtos;
namespace pizzeria.Domain
{

    public class User
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }


        public static User Create(DtoRegister register)
        {
            var user = new User();
            user.Name = register.Name;
            return user;
        }
    }

}
