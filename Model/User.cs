using System.ComponentModel.DataAnnotations;

namespace BC_Veterinaria.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public string listaDog { get; set; }
    }
}
