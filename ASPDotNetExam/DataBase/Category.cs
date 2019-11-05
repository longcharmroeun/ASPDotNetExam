using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASPDotNetExam.DataBase
{
    public class Category
    {
        [JsonIgnore]
        public int ID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}