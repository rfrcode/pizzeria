using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace pizzeria.dtos
{
    public class DTOIngredient
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Decimal price { get; set; }
        //lista commentarios
    }
}