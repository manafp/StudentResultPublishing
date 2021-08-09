using System.ComponentModel.DataAnnotations;

namespace StudentResultPublishing
{
   public class LoginModel
    {
        [Required(ErrorMessage ="Enter valid Email")]
        [EmailAddress]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Invalid Password")]
        public string Password { get; set; }
    }
}