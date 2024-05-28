using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TestATOH1.Models.UserModels
{
    public class UserModel
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }//unique identify

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Login validation error")]
        public string Login { get; set; }//only latin letter and nums
        [Required]
        [JsonIgnore]
        public string PasswordHash { get; set; }//hashed password(only latin letter and nums)
        [Required]
        public string Name { get; set; }//only russian and latin letter
        [Required]
        [RegularExpression(@"^[012]+$", ErrorMessage = "Gender is only 0 - female,1 - male,2 - unknown")]
        public int Gender { get; set; }// 0 - female,1-male,2-unknown
        [Required]
        public DateTime? Birthday { get; set; }//birthday date (nullable)
        [Required]
        public bool Admin { get; set; }//if the user is admin
        [Required]
        public DateTime CreatedOn { get; set; }//date the user was created
        [Required]
        public string CreatedBy { get; set; }// login user on whose behalf the user was created

        public DateTime ModifiedOn { get; set; }//date the user was changed

        public string ModifiedBy { get; set; } // login user on whose behalf the user was changed

        public DateTime RevokedOn { get; set; }//date the user was deleted

        public string RevokedBy { get; set; } // login user on whose behalf the user was deleted
    }
}
