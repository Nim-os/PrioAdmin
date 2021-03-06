﻿using PrioAdminApp.Models;
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
			UserModel user = new UserModel();

			if(loginEmail.Text == null || loginPass == null)
			{
				return;
			}

			user.email = loginEmail.Text;
			user.password = loginPass.Text;

			Console.WriteLine($"Email: {user.email}\nPassword: {user.password}");


			int ret = await App.patientManager.LoginUserAsync(user);

			if(ret == -1)
			{
				return;
			}

			await Navigation.PushAsync(new ProviderPage((Role)ret)
			{
				BindingContext = new RoleModel() { role = ret, roleName = ((Role)ret).ToString()}

			});
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new SignUpPage());
		}
	}
}
