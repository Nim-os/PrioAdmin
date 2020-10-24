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
			return rest.RegisterAsync(newUser);
		}

		public Task<int> LoginUserAsync(UserModel user)
		{
			return rest.LoginAsync(user); // TODO
		}

		public Task InsertPatientAsync(NewPatientModel patient)
		{
			return rest.AddPatientAsync(patient);
		}

		public Task SendCommunicationAsync(CommunicationModel communication)
		{
			return rest.CommunicationAsync(communication);
		}
	}
}
