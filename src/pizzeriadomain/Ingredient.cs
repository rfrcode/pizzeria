using System.ComponentModel.DataAnnotations;
using System;
using ingredient.dtos;

namespace pizzeria.Domain
{
    public class Ingredient{
        public Guid id {get; set;}
        public string Name {get; set; }
        public Decimal price {get; set; }
        
        public static Ingredient Create(DTOIngredient newPizza)
        {
            var ingredient = new Ingredient();     
            ingredient.id= Guid.NewGuid();
            ingredient.Name= newPizza.Name;
            ingredient.price = newPizza.price;
            
            return ingredient;
        }
    }

    
}