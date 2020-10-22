using Microsoft.AspNetCore.Mvc;
using PrioAdmin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrioAdmin.Controllers
{
	using Interfaces;
	using Models;
	using Models.Profiles;

	enum PatientErrorCode
	{

	}

	[Route("api/[controller]")]
	public class PatientController : Controller
	{

		public readonly IPatientDatabase patientRepo;

		public PatientController(IPatientDatabase database)
		{
			patientRepo = database;
		}

		[HttpGet]
		public IActionResult GetPatient([FromBody] PatientModel patient)
		{
			try
			{
				if (patient == null || !ModelState.IsValid)
				{
					return BadRequest(LoginErrorCode.MissingUserCredentials.ToString());
				}



			}
			catch (Exception)
			{
				return BadRequest(LoginErrorCode.CouldNotLoginUser.ToString());
			}

			return Ok(); // TODO
		}
	}
}
