using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Derscription { get; set; }
        public double Price;

        public Item(string Name, string Derscription, double Price)
        {
            this.Name = Name;
            this.Derscription = Derscription;
            this.Price = Price;
        }
        public Item()
        { }
    }

    
}

