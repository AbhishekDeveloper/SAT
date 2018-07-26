using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class Reseller_Service
    {
        [Key]
        public int ResellerServiceId { get; set; }
        public int ResellerId { get; set; }
        public Reseller Reseller { get; set; }
        public string ShortDescription { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }
        public string Task { get; set; }
        public double Price { get; set; }
        public string Metric { get; set; }
    }
}
