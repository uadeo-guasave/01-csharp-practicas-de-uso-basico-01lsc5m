using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_csharp_practicas_de_uso_basico.Models
{
    [Table("permissions")]
    public class Permission
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }


        // Manejado por EFCore
        public List<RolesHasPermissions> Roles { get; set; }
    }
}