using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrioAdmin.Models
{
	public enum Role
	{
		Urgence,
		Coordo,
		AIC,
		Pediatre,
		Infirmirary
	}
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
