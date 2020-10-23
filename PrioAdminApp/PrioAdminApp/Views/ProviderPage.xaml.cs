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
		public ProviderPage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			// Get all patients
		}


		async void OnPatientClicked(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushAsync(new PatientPage(e.SelectedItem as PatientModel)
			{
				BindingContext = e.SelectedItem as PatientModel
			});
		}
	}
}