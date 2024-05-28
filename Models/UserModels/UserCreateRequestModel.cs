using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestATOH1.Models.UserModels
{
    public class UserCreateRequestModel
    {
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Login validation error")]
        [DefaultValue("user")]
        public string Login { get; set; } = "user";//only latin letter and nums


        [Required(ErrorMessage = "This field is required")]
        [MinLength(5, ErrorMessage = "Minimal length is 6")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password validation error")]
        [DefaultValue("password")]
        public string Password { get; set; } //only latin letter and nums


        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Password validation error")]
        [DefaultValue("Ivan")]
        public string Name { get; set; } = "Ivan";//only russian and latin letter


        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[012]+$", ErrorMessage = "Gender is only 0 - female,1 - male,2 - unknown")]
        [DefaultValue(2)]
        public int Gender { get; set; } = 2;// 0 - female,1-male,2-unknown


        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Birthday validation error")]
        public DateTime Birthday { get; set; } //birthday date (nullable)


        [Required(ErrorMessage = "This field is required")]
        [DefaultValue(false)]
        public bool Admin { get; set; }//if the user is admin


        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.DateTime)]


        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;//date the user was created


        [Required(ErrorMessage = "This field is required")]
        public string CreatedBy { get; set; } = "";// login user on whose behalf the user was created

    }
}
