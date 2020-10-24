using System;

namespace PrioAdminApp.Models
{

	public class CommunicationModel
	{
		public uint patientID { get; set; }

		public PatientStage newStage { get; set; }

		public bool seen { get; set; }
	}
}
