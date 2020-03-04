using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace pizzeria.dtos
{

    public class DTOPizza
    {

        [Required]
        public string Name { get; set; }
        [Range(0, 10)]
        public List<Guid> Ingredients { get; set; }

        public Guid Image { get; set; }

    }



}