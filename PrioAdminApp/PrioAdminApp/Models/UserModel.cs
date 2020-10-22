using System;

namespace PrioAdminApp.Models
{

	public class UserModel
	{
		public string email { get; set; }

		public string password { get; set; }

	}

	public class NewUserModel : UserModel
	{
		public string name { get; set; }

		public int role { get; set; }


	}
}
