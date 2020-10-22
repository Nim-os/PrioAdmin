using System;

namespace PrioAdminApp.Models
{
	public enum PatientStage
	{
		Default,
		BedNeeded,
		BedAssigned,
		BedReady,
		PatientReady,
		PatientArrived
	}

	public class PatientModel
	{
		public string name { get; set; }

		public uint id { get; set; }

		public PatientStage stage { get; set; }
	}
}
