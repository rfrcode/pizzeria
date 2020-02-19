using System;
using System.ComponentModel.DataAnnotations;

namespace pizzeria.dtos
{
    public class DTORegister
    {
        [Key]
        public int id {get;set;}
        [Required]
         public string Name { get; set;}
         [Required(ErrorMessage="el campo es requerido")]
         [EmailAddress(ErrorMessage="el email no es correcto")]
        public string Email { get; set;}
         [Required]
        public string PassWord { get; set; }
    }
}