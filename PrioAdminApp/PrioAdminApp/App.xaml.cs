using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrioAdminApp
{
	using PrioAdminApp.Data;
	using Views;

	public partial class App : Application
	{
		public static PatientManager patientManager { get; private set; }
		
		public App()
		{
			patientManager = new PatientManager(new RestService());
			
			InitializeComponent();

			MainPage = new NavigationPage(new LoginPage());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
