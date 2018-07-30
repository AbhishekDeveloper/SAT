using System.ComponentModel.DataAnnotations;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class PoSerial
    {
        [Key]
        public int Id { get; set; }
        public int PoId { get; set; }
        public int SerialId { get; set; }
    }
}
