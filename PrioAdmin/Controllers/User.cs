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

	enum UserErrorCode
	{

	}

	[Route("api/[controller]")]
	public class UserController : Controller
	{
		public readonly IProviderDatabase userRepo;

		public UserController(IProviderDatabase userRepository)
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
					return BadRequest(LoginErrorCode.MissingUserCredentials.ToString());
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
