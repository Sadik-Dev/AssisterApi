using System;
using System.Collections.Generic;

namespace AssisterApi.Models
{ 
public class Consultation {
     
    public int Id { get; set; }
	public Customer Customer { get; set; }
    [Newtonsoft.Json.JsonIgnore]
    public Invoice Invoice { get; set; }
    public DateTime Date { get; set; }

    public String Type { get; set; }

	    public Consultation()
            {

            }

        public Consultation(Customer customer, DateTime date, String type)
        {
            Customer = customer;
            Date = date;
            Type = type;
            customer.addAppointment(this);

        }

        public void generateInvoice(IList<ProductOrService> p_s)
        {
            Invoice = new Invoice(Customer,this);
            foreach (var pair in p_s)
            {
                string key = pair.Description;
                int value = pair.Price;
                Invoice.AddServiceOrProduct(key, value);
            }
            Invoice.GeneratePDF();
            Customer.addInvoice(Invoice);
        }
    }
}