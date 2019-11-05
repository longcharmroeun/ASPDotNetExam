using System.Text.Json.Serialization;

namespace ASPDotNetExam.DataBase
{
    public class UserItem
    {
        [JsonIgnore]
        public int UserID { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }
        [JsonIgnore]
        public int ItemID { get; set; }
    }
}
