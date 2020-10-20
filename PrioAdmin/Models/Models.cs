using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrioAdmin.Models
{
	public class NewUser
	{
		[Required]
		public string name;

		[Required]
		public string password;


	}
}
