using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrioAdmin.Models
{
	using Profiles;

	public class UserModel
	{
		[Required]
		public string email { get; set; }

		[Required]
		public string password { get; set; }

	}

	public class NewUserModel
	{
		[Required]
		public string email { get; set; }

		[Required]
		public string password { get; set; }

		[Required]
		public string name { get; set; }

		[Required]
		public Role role { get; set; }


	}
}
