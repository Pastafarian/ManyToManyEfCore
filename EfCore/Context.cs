using EfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCore
{
	public class Context : DbContext
	{
		public DbSet<User> Users { get; set; }         
		public DbSet<Claim> Claims { get; set; }
		public DbSet<UserClaim> UserClaims { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Data Source=(local);Initial Catalog=ManyToMany;Integrated Security=SSPI;Trusted_Connection=true;");

		protected override void OnModelCreating(ModelBuilder modelBuilder)    
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
		}
	}

}