using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bella.Models
{
    public class Product
    {
        public int ProductId { get; set; } // Updated to int to match the database schema
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }

        public string Size { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; } // Updated to int to match the database schema
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}