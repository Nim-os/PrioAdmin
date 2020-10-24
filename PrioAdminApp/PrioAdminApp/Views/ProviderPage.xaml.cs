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
	public partial class ProviderPage : ContentPage
	{
		Role role;

		public ProviderPage(Role r)
		{
			InitializeComponent();

			role = r;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			listView.ItemsSource = await App.patientManager.GetPatientsAsync();
		}


		async void OnPatientClicked(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushAsync(new PatientPage(e.SelectedItem as PatientModel, role)
			{
				BindingContext = e.SelectedItem as PatientModel
			});
		}

		async void OnAddPatientClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddPatientPage());
		}
	}
}