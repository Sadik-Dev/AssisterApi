using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssisterApi.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public IList<Invoice> Invoices { get; set; }
		public IList<Consultation> Appointments { get; set; }
		public String Name { get; set; }
		public String Email { get; set; }
		[JsonIgnore]
		public String Password { get; set; }
		public String Gender { get; set; }
		public DateTime BirthDate { get; set; }
		public long RijkRegisterNummer { get; set; }



		public Customer()
        {

        }

		public Customer(String name, String email, String password, String gender, long rijkregisternummer, DateTime birthdate)
        {
			Name = name;
			Email = email;
			Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
			Invoices = new List<Invoice>();
			Appointments = new List<Consultation>();
			Gender = gender;
			RijkRegisterNummer = rijkregisternummer;
			BirthDate = birthdate;
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
