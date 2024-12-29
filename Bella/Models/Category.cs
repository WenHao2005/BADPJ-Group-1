using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bella.Models
{
    public class Category
    {
        public int CategoryId { get; set; } // Updated to int to match the database schema

        public string Name { get; set; }
        public string Description { get; set; }

        public string SkinTone { get; set; }
        public string BodyShape { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}