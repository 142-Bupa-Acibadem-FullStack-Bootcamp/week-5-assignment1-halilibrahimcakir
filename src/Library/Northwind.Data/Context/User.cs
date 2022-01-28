using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data.Context
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        [MaxLength(30)]
        public string UserName { get; set; }

        [MaxLength(30)]
        public string UserLastName { get; set; }

        [MaxLength(40)]
        [Required(ErrorMessage = "UserCode is reuired")]
        public string UserCode { get; set; }

        [MaxLength(60)]
        [Required(ErrorMessage = "Password is reuired")]
        public string Password { get; set; }
    }
}