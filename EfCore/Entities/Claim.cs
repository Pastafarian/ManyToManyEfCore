using System;
using System.Collections.Generic;

namespace EfCore.Entities
{
	public class Claim
	{
		public Claim()
		{
			UserClaims = new List<UserClaim>();
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public List<UserClaim> UserClaims { get; set; }
	}
}