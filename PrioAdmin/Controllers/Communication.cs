using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PrioAdmin.Controllers
{
	[Route("api/[controller]")]
	public class CommunicationController : Controller
	{
		public CommunicationController()
		{

		}

		[HttpGet]
		public IActionResult PleaseWork()
		{
			return Ok();
		}
	}
}
