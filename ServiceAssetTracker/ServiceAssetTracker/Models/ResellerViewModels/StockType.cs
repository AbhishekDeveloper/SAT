using System.ComponentModel.DataAnnotations;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class StockType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
