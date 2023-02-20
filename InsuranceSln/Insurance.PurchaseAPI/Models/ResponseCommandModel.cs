namespace Insurance.PurchaseAPI.Models
{
    public class ResponseCommandModel
    {
        public string status { get; set; }

        public int code { get; set; }
        public string message { get; set; }

        public object data { get; set; }
    }
}
