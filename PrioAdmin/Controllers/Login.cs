﻿using System;
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

	enum LoginErrorCode
	{
		MissingUserCredentials,
		EmailAlreadyInUse,
		RoleNotValid,
		UserNotFound,
		InvalidPassword,
		CouldNotLoginUser,
		CouldNotCreateUser
	}

	[Route("[controller]")]
	public class LoginController : Controller
	{
		public readonly IProviderDatabase userRepo;

		public LoginController(IProviderDatabase repo)
		{
			userRepo = repo;
		}

		[HttpPost]
		public IActionResult Login([FromBody] UserModel user)
		{
			ProviderBase profile;

			try
			{
				if (user == null || !ModelState.IsValid)
				{
					return BadRequest(LoginErrorCode.MissingUserCredentials.ToString());
				}

				
				IEnumerable<ProviderBase> providers = userRepo.All.Where(x => x.email.Equals(user.email));


				if (!providers.Any())
				{
					return BadRequest(LoginErrorCode.UserNotFound.ToString());
				}


				if (!providers.First().password.Equals(user.password))
				{
					return BadRequest(LoginErrorCode.InvalidPassword.ToString());
				}

				profile = providers.First();

			}
			catch(Exception)
			{
				return BadRequest(LoginErrorCode.CouldNotLoginUser.ToString());
			}

			return Ok((int)profile.role);
		}

		[HttpPut]
		public IActionResult SignUp([FromBody] NewUserModel newUser)
		{
			ProviderBase prof;
			try
			{
				if (newUser == null || !ModelState.IsValid)
				{
					return BadRequest(LoginErrorCode.MissingUserCredentials.ToString());
				}


				if (userRepo.All.Any())
				{
					IEnumerable<ProviderBase> providers;

					providers = userRepo.All.Where(x => x.email.Equals(newUser.email));

					if (providers.Any())
					{
						return BadRequest(LoginErrorCode.EmailAlreadyInUse.ToString());
					}
				}


				switch(newUser.role)
				{
					case Role.Coordo:
						prof = new Coordinator(newUser.name, newUser.email, newUser.password, userRepo.NextProfileID());
						break;
					case Role.Urgence:
						prof = new Urgence(newUser.name, newUser.email, newUser.password, userRepo.NextProfileID());
						break;
					case Role.AIC:
						prof = new AIC(newUser.name, newUser.email, newUser.password, userRepo.NextProfileID());
						break;
					case Role.Infirmirary:
						prof = new Infirmirary(newUser.name, newUser.email, newUser.password, userRepo.NextProfileID());
						break;
					case Role.Pediatre:
						prof = new Resident(newUser.name, newUser.email, newUser.password, userRepo.NextProfileID());
						break;
					default:
						return BadRequest(LoginErrorCode.RoleNotValid.ToString());
				}

				userRepo.Insert(prof);
			}
			catch(Exception)
			{
				return BadRequest(LoginErrorCode.CouldNotCreateUser.ToString());
			}

			return Ok(prof);
		}
	}

	
}
