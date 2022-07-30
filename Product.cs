using System;
namespace ProductManagementSystem
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Product(string name, string type, decimal price, string description)
        {
            Name = name;
            Type = type;
            Price = price;
            Description = description;

        }
    }
}

