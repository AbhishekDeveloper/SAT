using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class Job_Service
    {
        [Key]
        public int Id { get; set; }
        public int JobReferenceId { get; set; }
        public Job_Reference Job_Reference { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }
        public int ResellerServiceId { get; set; }
        public string SerialNumber { get; set; }
        public string CustomerTag { get; set; }
        public string StockType { get; set; }
        public string ShippingReference { get; set; }
        public string RegionSite { get; set; }
        public string Notes { get; set; }
    }
}