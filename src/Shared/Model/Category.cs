using System.Collections.Generic;
using System.Linq;

namespace Shared.Model
{
    public class Category
    {
        public Category(int id, string title)
        {
            Title = title;
            Id = id;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        = new List<Product>();

        public static IEnumerable<Category> Defaults
            => new List<Category>
            {
                new Category(1, "cat 1"),
                new Category(2, "cate 2")
            };

        public static Category First
            => Defaults.First();

        public static Category Second
            => Defaults.Where(a => a.Id == 2).First();
    }
}
