using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrioAdmin.ViewModels
{
	class LoginViewModel
	{
		// api services

		

		public string username { get; set; }

		public string password { get; set; }

		public ICommand LoginCommand
		{

			get
			{
				return new Command(async() =>
				{
					// await _apiServices.LoginAsync(username, password);
				});
			}
		}
	}
}
