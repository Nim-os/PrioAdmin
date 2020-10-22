using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PrioAdmin.Models
{
	using Profiles;

	public class UserModel
	{
		[Required]
		public string email;

		[Required]
		public string password;

	}

	public class NewUser : UserModel
	{
		[Required]
		public string name;

		[Required]
		public Role role;


	}
}
