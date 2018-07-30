using System.ComponentModel.DataAnnotations;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class JobReferenceServices
    {
        [Key]
        public int Id { get; set; }
        public int JobReferenceId { get; set; }
        public int JobServiceId { get; set; }
    }
}
