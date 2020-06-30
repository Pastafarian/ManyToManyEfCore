using EfCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.EntityConfiguration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> b)
		{
			b.HasKey(x => x.Id);
			b.HasMany(user => user.UserClaims)
				.WithOne(userClaim => userClaim.User)
				.HasForeignKey(userClaim => userClaim.UserId);
		}
	}
}