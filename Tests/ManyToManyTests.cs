using System.Linq;
using EfCore;
using EfCore.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{

	public class ManyToManyTests
	{
		[Fact]
		public void Test1()
		{
			var context = BuildSqlServerDbContext();

			var idClaim = new Claim {Name = "Id", Value = "1"};
			var nameClaim = new Claim { Name = "Name", Value = "Dave" };

			context.Claims.Add(idClaim);
			context.Claims.Add(nameClaim);

			var userDave = new User {Name = "Dave"};
			context.Users.Add(userDave);
			
			context.UserClaims.Add(new UserClaim { Claim = idClaim, User = userDave});
			context.UserClaims.Add(new UserClaim { Claim = nameClaim, User = userDave});

			context.SaveChanges();


			idClaim = new Claim { Name = "Id", Value = "2" };
			nameClaim = new Claim { Name = "Name", Value = "Steve" };

			context.Claims.Add(idClaim);
			context.Claims.Add(nameClaim);

			var userSteve = new User { Name = "Steve" };
			context.Users.Add(userSteve);

			context.UserClaims.Add(new UserClaim { Claim = idClaim, User = userSteve });
			context.UserClaims.Add(new UserClaim { Claim = nameClaim, User = userSteve });

			context.SaveChanges();

			var dave = context.Users
				.Include(x => x.UserClaims)
				.Single(x => x.Id == userDave.Id);

			var steve = context.Users
				.Include(x => x.UserClaims)
				.Single(x => x.Id == userSteve.Id);

			Assert.True(dave.UserClaims.Count == 2);
			Assert.Contains(dave.UserClaims, x => x.Claim.Name == "Name" && x.Claim.Value == "Dave");
			Assert.Contains(dave.UserClaims, x => x.Claim.Name == "Id" && x.Claim.Value == "1");


			Assert.True(steve.UserClaims.Count == 2);
			Assert.Contains(steve.UserClaims, x => x.Claim.Name == "Name" && x.Claim.Value == "Steve");
			Assert.Contains(steve.UserClaims, x => x.Claim.Name == "Id" && x.Claim.Value == "2");

		}


		public static Context BuildSqlServerDbContext()
		{
			var context = new Context();
			context.Database.EnsureCreated();
			context.SaveChanges();
			return context;
		}
	}
}
