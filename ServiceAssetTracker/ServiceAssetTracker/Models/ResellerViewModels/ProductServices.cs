using System.ComponentModel.DataAnnotations;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class ProductServices
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ServiceId { get; set; }
    }
}
