﻿using PrioAdminApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrioAdminApp.Data
{
	public interface IRestService
	{
		Task RegisterAsync(NewUserModel newUser);

		Task<int> LoginAsync(UserModel user);

		Task<List<PatientModel>> RefreshDataAsync();

		Task AddPatientAsync(NewPatientModel patient);

		Task CommunicationAsync(CommunicationModel communication);

	}
}
