using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using pizzeria.Domain;
namespace pizzeria.dtos
{

    public class DTOPizza
    {

        [Required]
        public string Name { get; set; }
        [Range(0, 10)]
        public int Rank { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        //lista commentarios



    }



}