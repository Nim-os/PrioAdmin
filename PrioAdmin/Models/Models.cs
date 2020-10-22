using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrioAdmin.Models
{
	public class User
	{
		[Required]
		public string email;

		[Required]
		public string password;

	}

	public class NewUser : User
	{
		[Required]
		public string name;
	}
}
