using EfCore;
using EfCore.Entities;
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
			context.SaveChanges();

			var userDave = new User {Name = "Dave"};
			context.Users.Add(userDave);
			context.SaveChanges();

			context.UserClaims.Add(new UserClaim { Claim = idClaim, ClaimId = idClaim.Id, User = userDave, UserId = userDave.Id});
			context.UserClaims.Add(new UserClaim  { Claim = nameClaim, ClaimId = nameClaim.Id, User = userDave, UserId = userDave.Id});

			context.SaveChanges();

			var foo = "";
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
