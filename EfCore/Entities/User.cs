using System;
using System.Collections.Generic;

namespace EfCore.Entities
{
	public class User
	{
		public User()
		{
			UserClaims = new List<UserClaim>();
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<UserClaim> UserClaims { get; set; }
	}
}
