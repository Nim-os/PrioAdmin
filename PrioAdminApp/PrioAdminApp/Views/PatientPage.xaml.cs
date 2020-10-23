﻿using PrioAdminApp.Models;
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

		public PatientPage(PatientModel p)
		{
			InitializeComponent();

			patient = p;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			// Correct button thing
			
		}


	}
}