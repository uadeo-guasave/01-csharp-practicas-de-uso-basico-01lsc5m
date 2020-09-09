using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_csharp_practicas_de_uso_basico.Models
{
    [Table("roles")]
    public class Role
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public int Level { get; set; }


        // Manejado por EFCore
        public List<User> Users { get; set; }
        public List<RolesHasPermissions> Permissions { get; set; }
    }
}