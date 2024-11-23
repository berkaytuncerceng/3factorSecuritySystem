using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
	public class BitirmeDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocaldb; Database=BitirmeDb;Trusted_Connection=true");
		}
		public DbSet<User> Users { get; set; }
		public DbSet<LoginAttempt> LoginAttempts { get; set; }
		public DbSet<SystemLog> SystemLogs { get; set; }
	}
}
