using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssisterApi.Models
{
	public class Customer
	{
		public int Id { get; set; }
		private IList<Invoice> Invoices { get; set; }
		private IList<Consultation> Appointments { get; set; }
		public String Name { get; set; }
		public String Email { get; set; }
		[JsonIgnore]
		public String Password { get; set; }



		public Customer()
        {

        }

		public Customer(String name, String email, String password)
        {
			Name = name;
			Email = email;
			Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
			Invoices = new List<Invoice>();
			Appointments = new List<Consultation>();

		}

		public void addInvoice(Invoice invoice)
        {
			Invoices.Add(invoice);
			
        }

		public void addAppointment(Consultation consultation)
		{
			Appointments.Add(consultation);

		}

	}

}
