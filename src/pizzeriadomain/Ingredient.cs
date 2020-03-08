using System.ComponentModel.DataAnnotations;
using System;
using pizzeria.dtos;

namespace pizzeria.Domain
{
    public class Ingredient{
        public Guid Id {get; set;}
        public string Name {get; set; }
        public Decimal Price {get; set; }
        
        public static Ingredient Create(DTOIngredient newPizza)
        {
            var ingredient = new Ingredient();     
            ingredient.Id= Guid.NewGuid();
            ingredient.Name= newPizza.Name;
            ingredient.Price = newPizza.price;
            
            return ingredient;
        }
    }

    
}