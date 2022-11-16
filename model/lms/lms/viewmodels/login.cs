using System.ComponentModel.DataAnnotations;

namespace lms.viewmodels
{
    public class login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Rememberme{ get; set; }
       
    }
}
