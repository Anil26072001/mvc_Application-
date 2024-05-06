using System.ComponentModel.DataAnnotations;

namespace FileUploadOperation.Models
{
    public class UserLogin
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "please enter email")]
        [Required(ErrorMessage = "Email is Required")]

        public string Email { get; set; }
        [Display(Name = "please enter password")]
        [Required(ErrorMessage = "password is Required")]
        public string password { get; set; }
        //public bool IsDeleted { get; set; } = true;
        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
