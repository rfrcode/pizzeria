using System.Security.Cryptography;
using System;
using pizzeria.dtos;
using System.Text;

namespace pizzeria.Domain
{

    public class User
    {
        public Guid id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }


        public  static string GetPassWord(string passWord){

             using (SHA256 mySHA256 = SHA256.Create())
            {
                var hash = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(passWord));
                return  Convert.ToBase64String(hash); 
            }

        }
        public static User Create(DTORegister register)
        {
            var user = new User();
            user.id = Guid.NewGuid();
            user.Name = register.Name;
            user.Email = register.Email;
            user.PassWord = GetPassWord(register.PassWord)
            return user;
        }
    }

}