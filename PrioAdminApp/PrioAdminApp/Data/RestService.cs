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

			Uri uri = new Uri($"{restURL}login");

			try
			{
				string json = JsonConvert.SerializeObject(newUser);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage msg = await client.PutAsync(uri, content);

				if (msg.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"\tUser signed up successfully.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine($"\tERROR {ex.Message}");
			}

			return;
		}

		public async Task LoginAsync(UserModel user)
		{
			Uri uri = new Uri($"{restURL}login");

			try
			{
				string json = JsonConvert.SerializeObject(user);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage msg = await client.PostAsync(uri, content);

				if (msg.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"\tUser logged in successfully.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine($"\tERROR {ex.Message}");
			}

			return;
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
				Debug.WriteLine($"\tERROR {ex.Message}");
			}

			return patients;
		}

		public async Task AddPatientAsync(PatientModel patient)
		{
			Uri uri = new Uri($"{restURL}api/communication");

			try
			{
				string json = JsonConvert.SerializeObject(patient);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage msg = await client.PostAsync(uri, content);

				if (msg.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"\tUser logged in successfully.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine($"\tERROR {ex.Message}");
			}

			return;
		}

		public async Task CommunicationAsync(CommunicationModel communication)
		{
			Uri uri = new Uri($"{restURL}api/communication");

			try
			{
				string json = JsonConvert.SerializeObject(communication);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage msg = await client.PutAsync(uri, content);

				if (msg.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"\tUser logged in successfully.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine($"\tERROR {ex.Message}");
			}

			return;
		}
	}
}
