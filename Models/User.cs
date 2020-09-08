using System.ComponentModel.DataAnnotations;

namespace _02_csharp_practicas_de_uso_basico.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(16)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Password { get; set; }

        [Required, MaxLength(50)]
        public string Firstname { get; set; }

        [Required, MaxLength(50)]
        public string Lastname { get; set; }

        [Required, MaxLength(200)]
        public string Email { get; set; }

        [Required]
        public gender Gender { get; set; }

        [Required]
        public int RoleId { get; set; }


        // Manejado por EFCore
        public Role Role { get; set; }
    }

    public enum gender
    {
        WOMAN, MAN
    }
}