using System.Text.Json.Serialization;

namespace ASPDotNetExam.DataBase
{
    public class Stock
    {
        [JsonIgnore]
        public int ID { get; set; }
        public int Count { get; set; }
    }
}