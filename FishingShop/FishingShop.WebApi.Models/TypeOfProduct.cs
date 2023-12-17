namespace FishingShop.WebApi.Models
{
    public class TypeOfProduct
    {
        public int Id { get; set; }

        public string ProductTypeName { get; set; }
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
