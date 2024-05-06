using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileUploadOperation.Models
{
    public class Register
    {
        [key]
        [Required]
        public int id { get; set; }

        //[RegularExpression(^"A-Za-z")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = " Name Should be min 3 and max 20 length")]
        [Display(Name = "Name")]

        public required string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }
        [Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

       


        public bool IsDeleted { get; set; } = true;

    }

    internal class keyAttribute : Attribute
    {

    }


}
