using System.Collections.Generic;

#nullable disable

namespace AwesomeShop.Data.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
