using PrioAdminApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrioAdminApp.Data
{
	public interface IRestService
	{
		Task RegisterAsync(NewUserModel newUser);

		Task LoginAsync(UserModel user);

		Task<List<PatientModel>> RefreshDataAsync();

		Task AddPatientAsync(PatientModel patient);

		Task CommunicationAsync(CommunicationModel communication);

	}
}
