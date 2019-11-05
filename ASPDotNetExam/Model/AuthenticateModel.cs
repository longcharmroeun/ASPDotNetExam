using System.ComponentModel.DataAnnotations;

namespace ASPDotNetExam.Model
{
    public class AuthenticateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
