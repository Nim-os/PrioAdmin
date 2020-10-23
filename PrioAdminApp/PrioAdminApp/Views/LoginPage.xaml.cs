using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PrioAdminApp.Views
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			
			await Navigation.PushAsync(new ProviderPage());
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new SignUpPage());
		}
	}
}
