using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
	public class BitirmeDbContext : DbContext
	{
		// Parametreli constructor
		public BitirmeDbContext(DbContextOptions<BitirmeDbContext> options)
			: base(options)
		{
		}

		// Parametresiz constructor ekliyoruz
		public BitirmeDbContext() : base() { }

		// DbSet'ler
		public DbSet<User> Users { get; set; }
		public DbSet<LoginAttempt> LoginAttempts { get; set; }
		public DbSet<SystemLog> SystemLogs { get; set; }

		// OnConfiguring metodu
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// Eğer DbContextOptions üzerinden yapılandırma yapılmamışsa, burada SQL Server kullanabiliriz.
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocalDB;Database=BitirmeDb;Trusted_Connection=true");
			}
		}
	}
}