using System;
using System.ComponentModel.DataAnnotations;

namespace pizzeria.dtos
{
    public class DTOIngredient
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Decimal price {get; set; }

    }
}