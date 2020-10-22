using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrioAdmin
{
	using Models;
	using Models.Profiles;
	using Interfaces;

	public class Database
	{
		public static Database instance { get; private set; }

		private readonly string filePath;

		private Database(string pFilePath)
		{
			filePath = pFilePath;
		}

		public static void InitialiseDatabase()
		{
			if (instance == null)
			{
				instance = new Database("database/");
			}
		}
		public static void InitialiseDatabase(string filePath)
		{
			if(instance == null && filePath != null)
			{
				instance = new Database(filePath);
			}
		}


		private IUserRepository userRepo;
	}
}
