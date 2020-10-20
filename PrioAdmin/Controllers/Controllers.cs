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

	[Route("api/[controller]")]
	public class UserLoginController : Controller
	{
		public UserLoginController()
		{

		}

		[HttpGet]
		public IActionResult Login([FromBody] User user)
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

			}
			catch(Exception)
			{

			}

			return Ok();
		}
	}

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
				if(id == null)
				{
					return BadRequest();
				}

				// TODO
			}
			catch(Exception)
			{

			}


			return Ok();
		}
	}
}
