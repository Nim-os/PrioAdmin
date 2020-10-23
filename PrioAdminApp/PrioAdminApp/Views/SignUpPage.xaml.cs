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
				// Something's missing

				return;
			}

			newUser.name = name.Text;
			newUser.email = email.Text;
			newUser.password = password.Text;
			newUser.role = (Role)picker.SelectedIndex;
			
			// Sign-up call
			
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