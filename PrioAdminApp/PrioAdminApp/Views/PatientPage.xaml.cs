using PrioAdminApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrioAdminApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PatientPage : ContentPage
	{
		PatientModel patient;
		Role role;

		public PatientPage(PatientModel p, Role r)
		{
			InitializeComponent();

			patient = p;
			role = r;
			
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			switch(role)
			{
				case Role.Urgence:
					Button.Text = "Request Bed";
					break;
				case Role.Coordo:
					Button.Text = "Request Bed";
					break;
				case Role.Infirmiere:
					Button.Text = "Patient Arrived";
					break;
				default:
					Button.Text = "Not Implemented";
					break;
			}
			
		}

		async void OnGenericButtonClicked(object sender, EventArgs e)
		{

			CommunicationModel comm = new CommunicationModel();

			comm.patientID = patient.id;
			comm.newStage = (PatientStage)(patient.stage + 1);

			Console.WriteLine($"Patient ID: {patient.id}\nNext Stage: {comm.newStage}\nBuffer");

			Button.IsEnabled = false;

			await App.patientManager.SendCommunicationAsync(comm);
		}


	}
}