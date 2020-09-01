namespace _02_csharp_practicas_de_uso_basico.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }
    }
}