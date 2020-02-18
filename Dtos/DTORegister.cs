using System.ComponentModel.DataAnnotations;

namespace pizzeria.dtos
{
    public class DTORegister
    {
        [Required]
        public string Name { get; set;}
         [Required]
        public string Email { get; set;}
         [Required]
        public string PassWord { get; set; }
    }
}