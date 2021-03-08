using System.Collections.Generic;

namespace Shared.Model
{
    public class Product
    {
        public Product(int id, string name, int price, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Category { get; set; }

        public static IEnumerable<Product> Shop
            => new List<Product>
            {
                new Product(1004, "Calculator", 1000, "Digital"),
                new Product(1005, "Pencil", 1230, "book"),
                new Product(1006, "Mobile Phone", 2000, "Digital"),
                new Product(1007, "Watch", 1600, "Men Wear")
            };
    }
}
