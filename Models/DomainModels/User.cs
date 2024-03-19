﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IP_AmazonFreshIndia_Project.Models
{
	public class User : IdentityUser
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }

		[NotMapped]
		public IList<string> RoleNames { get; set; }

	}
}
