using System;
using System.ComponentModel.DataAnnotations;

namespace pizzeria.dtos
{
    public class DTOLogin
    {
        [Required(ErrorMessage = "el campo es requerido")]
        [EmailAddress(ErrorMessage = "el email no es correcto")]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}