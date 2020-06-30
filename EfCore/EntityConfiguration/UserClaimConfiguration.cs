using EfCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.EntityConfiguration
{
	public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
	{
		public void Configure(EntityTypeBuilder<UserClaim> b)
		{
			b.HasKey(userClaim => new { userClaim.ClaimId, userClaim.UserId });

			b.HasOne(userClaim => userClaim.User)
				.WithMany(user => user.UserClaims)
				.HasForeignKey(userClaim => userClaim.UserId);

			b.HasOne(userClaim => userClaim.Claim)
				.WithMany(claim => claim.UserClaims)
				.HasForeignKey(userClaim => userClaim.ClaimId);
		}
	}
}