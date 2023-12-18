namespace FishingShop.WebApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int TypeOfProductId { get; set; } = 0;

        public TypeOfProduct TypeOfProduct { get; set; } = null!;

        public double Price {  get; set; }

        public int Count {  get; set; }
    }
}
