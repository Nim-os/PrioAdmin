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
	using PrioAdmin.Services;

	enum ErrorCode
	{
		MissingUserCredentials,
		EmailAlreadyInUse,
		UserNotFound,
		InvalidPassword,
		CouldNotLoginUser,
		CouldNotCreateUser,
		CouldNotUpdateUser,
		CouldNotDeleteUser
	}

	[Route("[controller]")]
	public class LoginController : Controller
	{
		private readonly IUserRepository userRepo;

		public LoginController(IUserRepository repo)
		{
			userRepo = repo;
		}

		[HttpGet]
		public IActionResult Login([FromBody] UserModel user)
		{
			try
			{
				if(user == null || !ModelState.IsValid)
				{
					return BadRequest(ErrorCode.MissingUserCredentials.ToString());
				}

				
				
			}
			catch(Exception)
			{
				return BadRequest(ErrorCode.CouldNotLoginUser.ToString());
			}

			return Ok(); // TODO
		}

		[HttpPost]
		public IActionResult SignUp([FromBody] NewUser newUser)
		{
			try
			{
				if (newUser == null || !ModelState.IsValid)
				{
					return BadRequest(ErrorCode.MissingUserCredentials.ToString());
				}
			}
			catch(Exception)
			{
				return BadRequest(ErrorCode.CouldNotCreateUser.ToString());
			}

			return Ok();
		}
	}

	
}
