using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceAssetTracker.Models.ResellerViewModels
{
    public class Reseller
    {
        [Key]
        public int ResellerId { get; set; }
        public string TradingName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ContractName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedOn { get; set; }
        public Boolean Status { get; set; }
    }
}
