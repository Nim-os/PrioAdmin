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
	public partial class SignUpPage : ContentPage
	{
		NewUserModel newUser;

		public SignUpPage()
		{
			InitializeComponent();

			newUser = new NewUserModel();
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{

			if(name.Text == null || email.Text == null || password.Text == null || picker.SelectedIndex == -1)
			{
				Console.WriteLine("Null item in signup");

				return;
			}
			Console.WriteLine("Signup looks good");

			newUser.name = name.Text;
			newUser.email = email.Text;
			newUser.password = password.Text;
			newUser.role = (Role)picker.SelectedIndex;

			Console.WriteLine($"\n\n\nName: {newUser.name}\nEmail: {newUser.email}\nPassword: {newUser.password}\nRole: {newUser.role}\nBuffer Buffer\n\n\n");

			await App.patientManager.RegisterUserAsync(newUser);

			await Navigation.PopAsync();
			
		}
		void OnPickerSelectedIndexChanged(object sender, EventArgs e)
		{
			var picker = (Picker)sender;
			int selectedIndex = picker.SelectedIndex;

			if (selectedIndex != -1)
			{
				newUser.role = (Role)selectedIndex;
			}
		}
	}
}