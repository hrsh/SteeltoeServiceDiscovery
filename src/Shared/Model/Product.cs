using System.Collections.Generic;

namespace Shared.Model
{
    public class Product
    {
        public Product(int id, string name, int price, string coverImage)
        {
            Id = id;
            Name = name;
            Price = price;
            CoverImage = coverImage;
        }
        public Product(int id, string name, int price, string coverImage,
            Category category)
        {
            Id = id;
            Name = name;
            Price = price;
            CoverImage = coverImage;
            Category = category;
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string CoverImage { get; set; }

        public virtual int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public static IEnumerable<Product> Shop
            => new List<Product>
            {
                new Product(1004, "Calculator", 1000, "Digital",Category.First),
                new Product(1005, "Pencil", 1230, "book", Category.Second),
                new Product(1006, "Mobile Phone", 2000, "Digital", Category.Second),
                new Product(1007, "Watch", 1600, "Men Wear", Category.First)
            };
    }
}
