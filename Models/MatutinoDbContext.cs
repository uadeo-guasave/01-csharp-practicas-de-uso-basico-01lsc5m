using Microsoft.EntityFrameworkCore;

namespace _02_csharp_practicas_de_uso_basico.Models
{
  public class MatutinoDbContext : DbContext
  {
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=Db/matutino.db");
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Role>(role =>
      {
        role.HasIndex(r => r.Name).IsUnique();

        role.HasMany(r => r.Users)
            .WithOne(u => u.Role);

        role.HasMany(r => r.Permissions)
            .WithOne(rhp => rhp.Role);
      });

      modelBuilder.Entity<Permission>(permission =>
      {
        permission.HasIndex(p => p.Name).IsUnique();

        permission.HasMany(p => p.Roles)
            .WithOne(rhp => rhp.Permission);
      });

      modelBuilder.Entity<User>(user =>
      {
        user.HasIndex(u => u.Name).IsUnique();
        user.HasIndex(u => u.Email).IsUnique();

        user.Property(u => u.RoleId).HasColumnName("role_id");

        user.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
      });

      modelBuilder.Entity<RolesHasPermissions>(rhp =>
      {
        rhp.HasKey(rp => new { rp.RoleId, rp.PermissionId });

        rhp.Property(rp => rp.RoleId).HasColumnName("role_id");
        rhp.Property(rp => rp.PermissionId).HasColumnName("permission_id");

        rhp.HasOne(rp => rp.Role)
            .WithMany(r => r.Permissions)
            .HasForeignKey(rp => rp.RoleId);

        rhp.HasOne(rp => rp.Permission)
            .WithMany(p => p.Roles)
            .HasForeignKey(rp => rp.PermissionId);
      });

      base.OnModelCreating(modelBuilder);
    }

  }
}