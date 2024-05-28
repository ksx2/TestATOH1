using System.ComponentModel.DataAnnotations;

namespace TestATOH1.Models.UserModels
{
    public class UserGetByLoginResponseModel
    {
        [Required]
        public string Name { get; set; }//only russian and latin letter
        [Required]
        public int Gender { get; set; }// 0 - female,1-male,2-unknown
        [Required]
        public DateOnly Birthday { get; set; }//birthday date (nullable)
        [Required]
        public bool Available { get; set; }//online/offline status
    }
}
