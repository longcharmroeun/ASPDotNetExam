using System;
using System.Text.Json.Serialization;

namespace ASPDotNetExam.DataBase
{
    public class ItemDate
    {
        [JsonIgnore]
        public int ID { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime ProduceDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}