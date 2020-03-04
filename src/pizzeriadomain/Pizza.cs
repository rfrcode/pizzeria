using System;
using pizzeria.dtos;
using System.Collections.Generic;
namespace pizzeria.Domain
{

    public class Pizza
    {

        public Guid Id { set; get; }
        public String Name { get; set; }

        public HashSet<Image> Images {get;set;}
        public HashSet<PizzaIngredient> Ingredients { get; set; }

        // const de 5.00M


        public static Pizza Create(DTOPizza newPizza)
        {
            var pizza = new Pizza();
            pizza.Id = Guid.NewGuid();
            pizza.Name = newPizza.Name;
            return pizza;
        }

    }
}