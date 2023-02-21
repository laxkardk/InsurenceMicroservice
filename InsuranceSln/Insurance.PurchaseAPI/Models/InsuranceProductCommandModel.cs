namespace Insurance.PurchaseAPI.Models
{
    public class InsuranceProductCommandModel
    {
        public int Id { get; set; }
        public int CustomerPolicyId { get; set; }
        public string? CustomerAddress { get; set; }
        public decimal Price { get; set; }
        public string? PaymentType { get; set; }
        public int? PolicyQuantity { get; set; }
        public bool? IsConfirm { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
