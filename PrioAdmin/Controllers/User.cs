using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PrioAdmin.Controllers
{
	using Interfaces;
	using Models;
	using Models.Profiles;

	[Route("api/[controller]")]
	public class UserController : Controller
	{
		public readonly IUserRepository userRepo;

		public UserController(IUserRepository userRepository)
		{
			userRepo = userRepository;
		}

		[HttpGet("{id}")]
		public IActionResult GetProfile(string id)
		{
			try
			{
				if (id == null)
				{
					return BadRequest(ErrorCode.MissingUserCredentials.ToString());
				}

				// TODO
			}
			catch (Exception)
			{
				return BadRequest();
			}


			return Ok(userRepo.All);
		}
	}
}
