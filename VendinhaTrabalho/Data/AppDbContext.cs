using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using VendinhaTrabalho.Models;

namespace VendinhaTrabalho.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.Load();

        string host = Environment.GetEnvironmentVariable("DB_HOST")!;
        string port = Environment.GetEnvironmentVariable("DB_PORT")!;
        string database = Environment.GetEnvironmentVariable("DB_NAME")!;
        string username = Environment.GetEnvironmentVariable("DB_USER")!;
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD")!;

        string connectionString =
            $"Host={host};" +
            $"Port={port};" +
            $"Database={database};" +
            $"Username={username};" +
            $"Password={password}";

        optionsBuilder.UseNpgsql(connectionString);
    }

    public DbSet<Clientes> Clientes { get; set; }

    public DbSet<Dividas> Dividas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clientes>()
            .HasIndex(c => c.Cpf)
            .IsUnique();

        modelBuilder.Entity<Dividas>()
            .HasOne(d => d.Cliente)
            .WithMany(c => c.Dividas);
            //.HasForeignKey(d => d.ClienteId);
    }
}