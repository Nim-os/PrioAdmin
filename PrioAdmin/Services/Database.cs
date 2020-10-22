using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrioAdmin
{
	using Models;
	using Models.Profiles;

	namespace Interfaces
	{
		public interface IProviderDatabase
		{
			IEnumerable<ProviderBase> All { get; }
			bool DoesUserExist(uint id);
			uint NextProfileID();
			ProviderBase Find(uint id);
			void Insert(ProviderBase user);
			void Update(ProviderBase user);
			void Delete(uint id);

		}
		public interface IPatientDatabase
		{
			IEnumerable<Patient> All { get; }
			bool DoesUserExist(uint id);
			uint NextProfileID();
			Patient Find(uint id);
			void Insert(Patient user);
			void Update(Patient user);
			void Delete(uint id);
		}
	}

	namespace Services
	{
		using Interfaces;

		public class ProviderRepository : IProviderDatabase
		{
			private Dictionary<uint, ProviderBase> _userList;

			private uint nextID;

			public ProviderRepository()
			{
				_userList = new Dictionary<uint, ProviderBase>();
				nextID = 0;
			}

			public IEnumerable<ProviderBase> All => _userList.Values;

			public void Delete(uint id)
			{
				_userList.Remove(id);
			}

			public bool DoesUserExist(uint id)
			{
				return _userList.ContainsKey(id);
			}

			public ProviderBase Find(uint id)
			{
				if (!DoesUserExist(id))
					return null; // TODO Change later

				return _userList[id];
			}

			public void Insert(ProviderBase user)
			{
				if (!DoesUserExist(user.internalID))
				{
					_userList.Add(user.internalID, user);

					nextID += 1;
				}

			}

			public uint NextProfileID()
			{
				return nextID;
			}

			public void Update(ProviderBase user)
			{
				if (DoesUserExist(user.internalID))
				{
					_userList[user.internalID] = user;
				}
				else
				{
					Insert(user);
				}
			}
		}

		public class PatientRepository : IPatientDatabase
		{
			private Dictionary<uint, Patient> _userList;

			private uint nextID;

			public PatientRepository()
			{
				_userList = new Dictionary<uint, Patient>();
				nextID = 0;
			}

			public IEnumerable<Patient> All => _userList.Values;

			public void Delete(uint id)
			{
				_userList.Remove(id);
			}

			public bool DoesUserExist(uint id)
			{
				return _userList.ContainsKey(id);
			}

			public Patient Find(uint id)
			{
				if (!DoesUserExist(id))
					return null; // TODO Change later

				return _userList[id];
			}

			public void Insert(Patient user)
			{
				if(!DoesUserExist(user.internalID))
				{
					_userList.Add(user.internalID, user);

					nextID += 1;
				}

			}

			public uint NextProfileID()
			{
				return nextID;
			}

			public void Update(Patient user)
			{
				if(DoesUserExist(user.internalID))
				{
					_userList[user.internalID] = user;
				}
				else
				{
					Insert(user);
				}
			}
		}

	}
}
