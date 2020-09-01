using System;
using _02_csharp_practicas_de_uso_basico.Models;

namespace _02_csharp_practicas_de_uso_basico
{
  class Program
  {
    static void Main(string[] args)
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
