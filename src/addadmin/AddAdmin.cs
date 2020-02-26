using System.IO;
using System.Text.Json;
using pizzeria.dtos;
using pizzeria.infrastructure;
using pizzeria.services;

namespace addadmin
{
    class AddAdmin
    {
        static void Main(string[] args)
        {
            var createAdmin = File.ReadAllText(args[0]);
            var dTORegister = JsonSerializer.Deserialize<DTORegister>(createAdmin);

            //var context = new PizzeriaContext();

            var userService = new UserServices(context);
            userService.Register(dTORegister)
        }
    }
}
