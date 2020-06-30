using EfCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.EntityConfiguration
{
	public class ClaimConfiguration : IEntityTypeConfiguration<Claim>
	{
		public void Configure(EntityTypeBuilder<Claim> b)
		{
			b.HasKey(x => x.Id);
			b.Property(x => x.Value).IsRequired().HasMaxLength(128);
			b.Property(x => x.Name).IsRequired().HasMaxLength(128);
			
			b.HasMany(claim => claim.UserClaims)
				.WithOne(userClaim => userClaim.Claim)
				.HasForeignKey(userClaim => userClaim.ClaimId);
		}
	}
}