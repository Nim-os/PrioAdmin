using PrioAdmin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrioAdmin.Models.Profiles
{
	public abstract class ProfileBase
	{
		public string name { get; private set; }
		public string email { get; private set; }
		public string password { get; private set; }

		public readonly uint internalID;

		public ProfileBase(string pName, string pPassword)
		{
			name = pName;
			password = pPassword;

			internalID = 0;
		}
	}

	public class Coordinator : ProfileBase
	{
		public Coordinator(string pName, string pPassword) : base(pName, pPassword)
		{

		}

	}

	public class AIC : ProfileBase
	{
		public AIC(string pName, string pPassword) : base(pName, pPassword)
		{

		}

	}

	public class EMT : ProfileBase
	{
		public EMT(string pName, string pPassword) : base(pName, pPassword)
		{

		}

	}

	public class Resident : ProfileBase
	{

		public Resident(string pName, string pPassword) : base(pName, pPassword)
		{

		}


	}
}
