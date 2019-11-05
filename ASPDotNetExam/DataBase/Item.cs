using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ASPDotNetExam.DataBase
{
    public class Item 
    {
        [JsonIgnore]
        public int ID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public Itemtype Type { get; set; }
        public Category Category { get; set; }
        public  ItemDate ItemDate { get; set; }
        public Stock Stock { get; set; }
        public Price Price { get; set; }
        public  Promo Promo { get; set; }
    }
}
