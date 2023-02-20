namespace Insurance.PurchaseAPI.Models
{
    public class CommonMessages
    {
        public List<CommonMessage> commonMessage { get; set; }
    }

    public class CommonMessage
    {
        public string status200OK { get; set; }
        public string statusCode500 { get; set; }
    }



    public enum ErrorCodes
    {
        statusCode4000 = 4000,
        statusCode5000 = 5000,
        statusCode5001 = 5001,
        statusCode5002 = 5002,
        statusCode5003 = 5003,
        statusCode5004 = 5004,
        statusCode5005 = 5005,
        statusCode5006 = 5006,
        statusCode5007 = 5007,
        statusCode5008 = 5008,
        statusCode5009 = 5009,
        statusCode5010 = 5010,
        statusCode5011 = 5011,
        statusCode5012 = 5012,
        statusCode5013 = 5013,
        statusCode5014 = 5014,
        statusCode5015 = 5015,
        statusCode5016 = 5016,
        statusCode5017 = 5017,
        statusCode5018 = 5018,
        statusCode5019 = 5019,
        statusCode5020 = 5020,
        statusCode5021 = 5021,
        statusCode5022 = 5022,
        statusCode5023 = 5023,
        statusCode5024 = 5024,
        statusCode5025 = 5025,
        statusCode5026 = 5026,
        statusCode5027 = 5027,
        statusCode5028 = 5028,
        statusCode5029 = 5029,
        statusCode5030 = 5030,
        statusCode5031 = 5031,
        statusCode5032 = 5032,
        statusCode5033 = 5033,
        statusCode5034 = 5034,
        statusCode5035 = 5035
    }
}
