using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrioAdmin
{
	namespace Interfaces
	{
		using Models;
		using Models.Profiles;

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
		using Models;
		using Models.Profiles;
		using Interfaces;

		public class UserRepository : IUserRepository
		{
			private Dictionary<uint, ProfileBase> _userList;

			public UserRepository()
			{
				_userList = new Dictionary<uint, ProfileBase>();
			}

			public IEnumerable<ProfileBase> All => _userList.Values;

			public void Delete(uint id)
			{
				_userList.Remove(id);
			}

			public bool DoesUserExist(uint id)
			{
				return _userList[id] != null;
			}

			public ProfileBase Find(uint id)
			{
				if (!_userList.ContainsKey(id))
					return null; // TODO Change later

				return _userList[id];
			}

			public void Insert(ProfileBase user)
			{
				if(_userList.ContainsKey(user.internalID))
				{
					return;
				}

				_userList.Add(user.internalID, user);

			}

			public uint NextProfileID()
			{
				throw new NotImplementedException();
			}

			public void Update(ProfileBase user)
			{
				throw new NotImplementedException();
			}
		}

	}
}
