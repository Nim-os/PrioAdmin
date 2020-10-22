using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrioAdmin.Controllers
{
	using Interfaces;
	using Models;
	using Models.Profiles;

	enum CommunicationErrorCode
	{
		MissingPatientInformation,
		CouldNotFindPatient,
		CouldNotCreatePatient,
		CouldNotUpdatePatient
	}

	[Route("api/[controller]")]
	public class CommunicationController : Controller
	{
		public readonly IPatientDatabase patientRepo;

		public CommunicationController(IPatientDatabase database)
		{
			patientRepo = database;
		}

		[HttpGet]
		public IActionResult GetPatients()
		{
			return Ok(patientRepo.All);
		}


		[HttpPost]
		public IActionResult AddPatient([FromBody] PatientModel patient)
		{
			Patient p;

			try
			{
				if (patient == null || !ModelState.IsValid)
				{
					return BadRequest(CommunicationErrorCode.MissingPatientInformation.ToString());
				}

				p = new Patient(patient.name, patientRepo.NextProfileID());


			}
			catch (Exception)
			{
				return BadRequest(CommunicationErrorCode.CouldNotCreatePatient.ToString());
			}

			return Ok(p);
		}


		[HttpPut]
		public IActionResult UpdatePatient([FromBody] CommunicationModel patient)
		{

			Patient p;

			try
			{
				if (patient == null || !ModelState.IsValid)
				{
					return BadRequest (CommunicationErrorCode.MissingPatientInformation.ToString());
				}

				p = patientRepo.Find (patient.patientID);

				if (p == null)
				{
					return BadRequest (CommunicationErrorCode.CouldNotFindPatient.ToString());
				}

				p.SetStage(patient.newStage);

			}
			catch (Exception)
			{
				return BadRequest (CommunicationErrorCode.CouldNotUpdatePatient.ToString());
			}

			return Ok (p);
		}
	}
}
