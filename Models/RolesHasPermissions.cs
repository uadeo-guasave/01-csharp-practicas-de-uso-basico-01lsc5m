using System.ComponentModel.DataAnnotations.Schema;

namespace _02_csharp_practicas_de_uso_basico.Models
{
    [Table("roles_has_permissions")]
    public class RolesHasPermissions
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        // Requeridos por EFCore
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}