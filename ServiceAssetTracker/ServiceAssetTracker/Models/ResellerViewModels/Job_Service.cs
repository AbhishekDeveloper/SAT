using System.ComponentModel.DataAnnotations;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class Job_Service
    {
        [Key]
        public int Id { get; set; }
        public int JobReferenceId { get; set; }
        public int CategoryId { get; set; }
        public int ResellerServiceId { get; set; }
        public string SerialNumber { get; set; }
        public string CustomerTag { get; set; }
        public string StockType { get; set; }
        public string ShippingReference { get; set; }
        public string RegionSite { get; set; }
        public string Notes { get; set; }
    }
}