using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASPDotNetExam.DataBase
{
    public partial class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(255)]
        public string Token { get; set; }
    }
}
