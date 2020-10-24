using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrioAdminApp.Views
{
	using Models;

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPatientPage : ContentPage
	{
		public AddPatientPage()
		{
			InitializeComponent();
		}

		async void OnAddPatientClicked(object sender, EventArgs e)
		{
			if(patientName.Text == null)
			{
				Console.WriteLine("Patient name not supplied");

				return;
			}

			NewPatientModel patient = new NewPatientModel();

			patient.name = patientName.Text;

			await App.patientManager.InsertPatientAsync(patient);

			await Navigation.PopAsync();
		}
	}
}