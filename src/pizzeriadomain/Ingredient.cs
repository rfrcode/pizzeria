using System;
using pizzeria.Dtos;

namespace pizzeria.Domain
{
    public class Ingredient{
        public Guid id {get; set;}
        public string Name {get; set; }
        public Decimal Price {get; set; }
        
        public static Ingredient Create(IngredientFileRead newPizza)
        {
            var ingredient = new Ingredient();     
            ingredient.id= Guid.NewGuid();
            ingredient.Name= newPizza.Name;
            ingredient.Price = newPizza.Price;
            return ingredient;
        }
    }

    
}