using System.ComponentModel.DataAnnotations;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int ResellerId { get; set; }
        public Reseller Reseller { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Term { get; set; }
        public bool Allocated { get; set; }
    }
}
