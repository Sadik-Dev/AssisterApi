using System;
using System.Collections.Generic;

namespace AssisterApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Consultation Consultation { get; set; }
        public IList<ProductOrService> Services_Products {get;set;}
        public byte[] PDF { get; set; }

        public int TotalPrice { get; set; }

        public Invoice()
        {

        }
        public Invoice(Customer customer, Consultation consultation)
        {
            Services_Products = new List<ProductOrService>();
            TotalPrice = 0;
            Consultation = consultation;
            Customer = customer;
        }
        public void AddServiceOrProduct(String name, int price)
        {
            Services_Products.Add(new ProductOrService(name,price));
            TotalPrice += price;
        }

        public void GeneratePDF()
        {
           
        }
    }

}
