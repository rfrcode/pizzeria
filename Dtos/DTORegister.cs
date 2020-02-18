using System.ComponentModel.DataAnnotations;

namespace pizzeria.dtos
{
    public class DTORegister
    {
        [Required]
        public string Name { get; set;}
        public string Email { get; set;}
        public string PassWord { get; set; }
    }
}