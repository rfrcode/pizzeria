using System;
using System.Collections.Generic;
namespace pizzeria.Domain
{

    public class PizzaIngredient
    {

        public Guid Id {get;set;}
      public Pizza Pizza {get;set;}   
        public Ingredient Ingredient { get; set; }

    
   /* public static PizzaIngredient Create (){
                var pizzaIngredient = new PizzaIngredient();
            pizzaIngredient.Id = Guid.NewGuid();
            pizzaIngredient.Pizza = //newPizza.Name;
            pizzaIngredient.Ingredient // 
            return pizza;


    }*/
    
    }

}