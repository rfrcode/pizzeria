using System;
using pizzeria.dtos;
using System.Collections.Generic;
namespace pizzeria.Domain
{

    public class Pizza
    {
        
        public Guid id { set; get; }
        public String Name { get; set; }

        public byte[] Image { get; set; }
        public HashSet<Guid> Ingredients { get;set; }
 
        // const de 5.00M


        public static Pizza Create(DTOPizza newPizza)
        {
           var pizza = new Pizza();     
            pizza.id= Guid.NewGuid();
            pizza.Name= newPizza.Name;
            
            return pizza;
        }

    }
}