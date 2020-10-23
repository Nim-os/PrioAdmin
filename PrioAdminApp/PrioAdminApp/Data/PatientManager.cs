using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrioAdminApp.Data
{
	using Models;
	public class PatientManager
	{

		IRestService rest;

		public PatientManager(IRestService service)
		{
			rest = service;
		}

		public Task<List<PatientModel>> GetPatientsAsync()
		{
			return rest.RefreshDataAsync();
		}


		public Task RegisterUserAsync(NewUserModel newUser)
		{
			throw new NotImplementedException();
		}

		public Task LoginUserAsync(UserModel user)
		{
			throw new NotImplementedException();
		}

		public Task InsertPatientAsync(PatientModel patient)
		{
			throw new NotImplementedException();
		}

		public Task SendCommunicationAsync(CommunicationModel communication)
		{
			throw new NotImplementedException();
		}
	}
}
