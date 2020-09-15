using System;
using System.Collections.Generic;
using System.Linq;
using _02_csharp_practicas_de_uso_basico.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_csharp_practicas_de_uso_basico
{
  class Program
  {
    static void Main(string[] args)
    {
      // Anterior();
      // setRolesAndPermissions();
      PrintRolesWithPermissions();
    }

    private static void PrintRolesWithPermissions()
    {
      using (var db = new MatutinoDbContext())
      {
        var roles = db.Roles
                      .Include(r => r.Permissions)
                        .ThenInclude(h => h.Permission)
                      .ToList();
        foreach (var role in roles)
        {
          var permissions = role.Permissions.ToList();
          var perms = new List<string>();
          foreach (var perm in permissions)
          {
            perms.Add(perm.Permission.Name);
          }
          System.Console.WriteLine($"{role.Name} has [{string.Join(',',perms.ToArray())}] permissions");
        }
      }
    }

    private static void setRolesAndPermissions()
    {
      using (var db = new MatutinoDbContext())
      {
        try
        {
          System.Console.WriteLine("Conectando a la base de datos...");
          db.Database.EnsureCreated();

          // var roleAdmin = new Role
          // {
          //   Name = "Administrator",
          //   Description = "Role with all rights",
          //   Level = 1
          // };

          // var loginPermission = new Permission
          // {
          //   Name = "Login",
          //   Description = "Users with it, can login"
          // };

          // db.Roles.Add(roleAdmin);
          // db.Permissions.Add(loginPermission);
          // db.SaveChanges();
          var roles = new List<Role>
          {
            new Role {
              Name = "Guest",
              Description = "Role with only read rights",
              Level = 2
            },
            new Role {
              Name = "Operator",
              Description = "Role with limit rights",
              Level = 3
            }
          };

          var permissions = new List<Permission>
          {
            new Permission {
              Name = "Edit",
              Description = "User can edit information"
            },
            new Permission {
              Name = "Delete",
              Description = "User can delete information"
            },
            new Permission {
              Name = "View",
              Description = "User can view information"
            }
          };

          // db.Roles.AddRange(roles);
          // db.Permissions.AddRange(permissions);
          // db.SaveChanges();

          var misRoles = db.Roles.ToList();
          foreach (var role in misRoles)
          {
            System.Console.WriteLine($"Role: {role.Name}, Description: {role.Description}");
          }
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
