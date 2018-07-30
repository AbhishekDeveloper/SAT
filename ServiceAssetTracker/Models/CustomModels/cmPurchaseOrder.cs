
namespace ServiceAssetTracker.Models.CustomModels
{
    public class cmPurchaseOrder
    {
        public int PoId { get; set; }
        public string ResellerId { get; set; }
        public string CustomerId { get; set; }
        public string OrderReference { get; set; }
        public string ProductId { get; set; }
        public double Price { get; set; }
    }
}
