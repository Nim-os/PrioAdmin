using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using Xamarin.Forms;


namespace PrioAdminApp.Data
{
	using Models;
	class RestService : IRestService
	{
		HttpClient client;

		public List<PatientModel> patients { get; private set; }


		public RestService()
		{
#if DEBUG
			//client = new HttpClient(DependencyService.Get<HttpClientHandler>().GetInsecureHandler());
			Console.WriteLine("Debug mode actived mate");
#else
			client = new HttpClient();
#endif
		}

		public Task RegisterAsync(NewUserModel newUser)
		{
			throw new NotImplementedException();
		}

		public Task LoginAsync(UserModel user)
		{
			throw new NotImplementedException();
		}

		public Task<List<PatientModel>> RefreshDataAsync()
		{
			patients = new List<PatientModel>();

			//Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

			throw new NotImplementedException();
		}

		public Task AddPatientAsync(PatientModel patient)
		{
			throw new NotImplementedException();
		}

		public Task CommunicationAsync(CommunicationModel communication)
		{
			throw new NotImplementedException();
		}
	}
}
