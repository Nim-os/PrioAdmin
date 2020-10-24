using System;

namespace PrioAdminApp.Models
{
	public enum Role
	{
		Urgence,
		Coordo,
		AIC,
		Pediatre,
		Infirmiere
	}

	public class UserModel
	{
		public string email { get; set; }

		public string password { get; set; }

	}

	public class NewUserModel : UserModel
	{
		public string name { get; set; }

		public Role role { get; set; }


	}
}
