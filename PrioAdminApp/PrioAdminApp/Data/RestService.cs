using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace PrioAdminApp.Data
{
	using Models;
	class RestService : IRestService
	{
		HttpClient client;

		public List<PatientModel> patients { get; private set; }

		public const string restURL = "http://127.168.12.4:5000/";



		public RestService()
		{
#if DEBUG
			client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#else
			client = new HttpClient();
#endif
		}

		public async Task RegisterAsync(NewUserModel newUser)
		{
			throw new NotImplementedException();
		}

		public async Task LoginAsync(UserModel user)
		{
			throw new NotImplementedException();
		}

		public async Task<List<PatientModel>> RefreshDataAsync()
		{
			patients = new List<PatientModel>();

			Uri uri = new Uri($"{restURL}api/communication");

			try
			{
				HttpResponseMessage response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					patients = JsonConvert.DeserializeObject<List<PatientModel>>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}

			return patients;

			throw new NotImplementedException();
		}

		public async Task AddPatientAsync(PatientModel patient)
		{
			throw new NotImplementedException();
		}

		public async Task CommunicationAsync(CommunicationModel communication)
		{
			throw new NotImplementedException();
		}
	}
}
