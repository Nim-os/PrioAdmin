using PrioAdmin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrioAdmin.Models.Profiles
{
	public enum Role
	{
		Urgence,
		Coordo,
		AIC,
		Pediatre,
		Infirmirary
	}

	public abstract class ProfileBase
	{
		public string name { get; private set; }
		public readonly uint internalID;

		public ProfileBase(string pName, uint id)
		{
			name = pName;
			internalID = id;
		}

	}

	public abstract class ProviderBase : ProfileBase
	{
		public string email { get; private set; }
		public string password { get; private set; }

		public Role role { get; protected set; }

		public List<Patient> patients { get; private set; }

		public ProviderBase(string pName, string pEmail, string pPassword, uint id) : base(pName, id)
		{

			email = pEmail;
			password = pPassword;

			patients = new List<Patient>();
		}
	}

	public class Coordinator : ProviderBase
	{
		public Coordinator(string pName, string pEmail, string pPassword, uint id) : base(pName, pEmail, pPassword, id)
		{
			role = Role.Coordo;
		}

	}

	public class AIC : ProviderBase
	{
		public AIC(string pName, string pEmail, string pPassword, uint id) : base(pName, pEmail, pPassword, id)
		{
			role = Role.AIC;

		}

	}

	public class Urgence : ProviderBase
	{
		public Urgence(string pName, string pEmail, string pPassword, uint id) : base(pName, pEmail, pPassword, id)
		{
			role = Role.Urgence;

		}

	}
	public class Infirmirary : ProviderBase
	{
		public Infirmirary(string pName, string pEmail, string pPassword, uint id) : base(pName, pEmail, pPassword, id)
		{
			role = Role.Infirmirary;

		}

	}

	public class Resident : ProviderBase
	{

		public Resident(string pName, string pEmail, string pPassword, uint id) : base(pName, pEmail, pPassword, id)
		{
			role = Role.Pediatre;

		}


	}


	public enum PatientStage
	{
		Default,
		BedNeeded,
		BedAssigned,
		BedReady,
		PatientReady,
		PatientArrived
	}
	public class Patient : ProfileBase
	{

		public PatientStage patientStage { get; private set; }

		public Patient(string pPatientName, uint pPatientID) : base(pPatientName, pPatientID)
		{
			patientStage = PatientStage.Default;
		}

		public void SetStage(PatientStage newStage)
		{
			patientStage = newStage;
		}
	}
}
