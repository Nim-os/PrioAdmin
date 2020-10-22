using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PrioAdmin.Models
{
	public class PatientModel
	{
		[Required]
		public string name;
	}
}
