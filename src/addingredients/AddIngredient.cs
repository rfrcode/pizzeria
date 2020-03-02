using System.IO;
using System.Text.Json;
using pizzeria.dtos;
using pizzeria.infrastructure;
using pizzeria.services;
using System.IO;

namespace addingredient
{
    class AddIngredient 
    {
        static void Main(string[] args)
        {
        List<string> Name = new List<string>();
        List<string> price = new List<string>();
        var reader = new StreamReader(@"C:\ingredients.csv");
        var context = new IngredientContext();

        while (!reader.EndOfStream)
        {
             var line = reader.ReadLine();
             var values = line.Split(';');


              var std = new Ingredient()
              {
                Name = values[0],
                price = values[1]
              };
              context.Students.Add(std);
                     
         }
    
            context.SaveChanges();
            

        }
    }
}
