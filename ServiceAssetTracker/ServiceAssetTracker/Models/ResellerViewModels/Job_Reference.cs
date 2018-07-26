using System.ComponentModel.DataAnnotations;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class Job_Reference
    {
        [Key]
        public int JobReferenceId { get; set; }
        public string CustomerReference { get; set; }
        public string MojoReference { get; set; }
        public string WorkflowReference { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}