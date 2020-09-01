using System.Collections.Generic;

namespace _02_csharp_practicas_de_uso_basico.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}