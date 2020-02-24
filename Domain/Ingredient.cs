using System.ComponentModel.DataAnnotations;
using System;
using pizzeria.dtos;
namespace pizzeria.Domain
{
    public class Ingredient{
        public Guid id {get; set;}
        public string Name {get; set; }
        public Decimal price {get; set; }
        
        public static Ingredient Create(DTOIngredient newIngredient)
        {
            var ingredient = new Ingredient();
            ingredient.id = Guid.NewGuid();
            ingredient.Name = newIngredient.Name;
            ingredient.price = newIngredient.price;
            return ingredient ;  
        }
    }

}