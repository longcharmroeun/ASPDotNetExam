using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASPDotNetExam.DataBase
{
    public class Price
    {
        [JsonIgnore]
        public int ID { get; set; }
        [DataType(DataType.Currency)]
        public int Money { get; set; }
    }
}