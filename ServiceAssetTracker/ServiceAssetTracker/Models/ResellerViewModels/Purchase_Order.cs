using System.ComponentModel.DataAnnotations;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class Purchase_Order
    {
        [Key]
        public int PoId { get; set; }
        public int ResellerId { get; set; }
        public int CustomerId { get; set; }
        public string OrderReference { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
    }
}

