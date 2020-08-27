namespace _02_csharp_practicas_de_uso_basico.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Genero Gender { get; set; }
        public int Level { get; set; }
    }

    public enum Genero
    {
        MUJER, HOMBRE
    }
}