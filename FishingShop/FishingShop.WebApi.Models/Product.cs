namespace FishingShop.WebApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TypeOfProductId {  get; set; }

        public TypeOfProduct TypeOfProduct { get; set; } = null!;

        public double Price {  get; set; }

        public int Count {  get; set; }
    }
}
