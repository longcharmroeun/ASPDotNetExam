using System.Text.Json.Serialization;

namespace ASPDotNetExam.DataBase
{
    public class Promo
    {
        [JsonIgnore]
        public int ID { get; set; }
        public int Discount { get; set; }
    }
}