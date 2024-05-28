namespace TestATOH1.Models.AuthentificateModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Login validation error")]
        [DefaultValue("user")]
        public string Login { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(5, ErrorMessage = "Minimal length is 6")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password validation error")]
        [DefaultValue("password")]
        public string Password { get; set; }
    }
}
