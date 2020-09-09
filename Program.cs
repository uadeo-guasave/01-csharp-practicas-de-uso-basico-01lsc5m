using System;
using _02_csharp_practicas_de_uso_basico.Models;

namespace _02_csharp_practicas_de_uso_basico
{
  class Program
  {
    static void Main(string[] args)
    {
      // Anterior();
      using (var db = new MatutinoDbContext())
      {
        try
        {
          System.Console.WriteLine("Conectando a la base de datos...");
          db.Database.EnsureCreated();

          var roleAdmin = new Role
          {
            Name = "Administrator",
            Description = "Role with all rights",
            Level = 1
          };

          var loginPermission = new Permission
          {
            Name="Login",
            Description="Users with it, can login"
          };

          db.Roles.Add(roleAdmin);
          db.Permissions.Add(loginPermission);
          db.SaveChanges();
        }
        catch (Exception ex)
        {
          System.Console.WriteLine(ex.Message);
        }
      }

    }

    private static void Anterior()
    {
      var usuario = new User
      {
        Id = 2321321,
        Name = "bidkar",
        Gender = gender.MAN
      };
      //   usuario.Id = 2321321;
      //   usuario.Name = "bidkar";
      //   usuario.Gender = gender.MAN;

      //   System.Console.WriteLine("Usuario:" + usuario.Id + ", Género:" + (int)usuario.Gender);
      System.Console.WriteLine($"Usuario: {usuario.Id}, Género: {(int)usuario.Gender}");
    }
  }
}
