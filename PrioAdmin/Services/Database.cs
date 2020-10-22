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
		public interface IDatabase
		{
			IEnumerable<ProfileBase> All { get; }

		}

		public interface IUserRepository
		{
			IEnumerable<ProfileBase> All { get; }
			bool DoesUserExist(uint id);
			uint NextProfileID();
			ProfileBase Find(uint id);
			void Insert(ProfileBase user);
			void Update(ProfileBase user);
			void Delete(uint id);
		}
	}

	namespace Services
	{
		using Interfaces;

		public class UserRepository : IUserRepository
		{
			private Dictionary<uint, ProfileBase> _userList;

			private uint nextID;

			public UserRepository()
			{
				_userList = new Dictionary<uint, ProfileBase>();
				nextID = 0;
			}

			public IEnumerable<ProfileBase> All => _userList.Values;

			public void Delete(uint id)
			{
				_userList.Remove(id);
			}

			public bool DoesUserExist(uint id)
			{
				return _userList.ContainsKey(id);
			}

			public ProfileBase Find(uint id)
			{
				if (!DoesUserExist(id))
					return null; // TODO Change later

				return _userList[id];
			}

			public void Insert(ProfileBase user)
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

			public void Update(ProfileBase user)
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
