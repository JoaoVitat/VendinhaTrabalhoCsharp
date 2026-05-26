using Microsoft.EntityFrameworkCore;
using VendinhaTrabalho.Models;

namespace VendinhaTrabalho.Data
	public class AppDbContext : DbContext
	{
		private readonly string _connectionString;

		public AppDbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public DbSet<Clientes> Clientes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Clientes>()
				.ToTable("cliente");

			modelBuilder.Entity<Clientes>()
				.Property(c => c.Cpf)
				.HasColumnName("Cpf");

			modelBuilder.Entity<Clientes>()
				.HasKey(c => c.IdCliente);

			modelBuilder.Entity<Clientes>()
				.Property(c => c.IdCliente)
				.HasColumnName("Id");

			modelBuilder.Entity<Clientes>()
				.Property(c => c.Nome)
				.HasColumnName("Nome");

			modelBuilder.Entity<Clientes>()
				.Property(c => c.Email)
				.HasColumnName("Email");

			modelBuilder.Entity<Clientes>()
				.Property(c => c.DataNascimento)
				.HasColumnName("DataNascimento");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseNpgsql(_connectionString);
			}
		}
	}
}