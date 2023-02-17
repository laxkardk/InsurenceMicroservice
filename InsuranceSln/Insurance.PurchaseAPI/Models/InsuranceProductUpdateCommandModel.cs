namespace Insurance.PurchaseAPI.Models
{
    public class InsuranceProductUpdateCommandModel
    {
        public bool? IsConfirm { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
