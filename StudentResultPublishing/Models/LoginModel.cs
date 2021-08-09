using System.ComponentModel.DataAnnotations;

namespace StudentResultPublishing
{
   public class LoginModel
    {
        [Required(ErrorMessage ="Enter valid Email")]
        [Display(Name = "Email")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Invalid Password")]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}