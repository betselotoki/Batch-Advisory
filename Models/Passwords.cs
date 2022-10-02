using System.ComponentModel.DataAnnotations;

namespace Batch_Advisory.Models
{
    public class Passwords
    {
        [Display(Name = "SRC")]
        public string Src { get; set; } = null!;
        [Required ,DataType(DataType.Password),Display(Name ="Current Password")]
        public string Password { get; set; } = null!;
        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        public string NewPassword { get; set; } = null!;
        [Required, DataType(DataType.Password), Display(Name = "Confirm New Password")]
        [Compare("NewPassword",ErrorMessage ="Password Doesnt Match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
