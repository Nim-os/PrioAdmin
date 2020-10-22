using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PrioAdmin.Models
{
	using Profiles;

	public class CommunicationModel
	{
		[Required]
		public uint patientID;

		[Required]
		public PatientStage newStage;

		public bool seen = false;
	}
}
