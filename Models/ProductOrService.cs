using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models
{
    public class ProductOrService
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }

        public ProductOrService()
        {

        }
        public ProductOrService(string description, int price)
        {
            Description = description;
            Price = price;
        }
    }
}
