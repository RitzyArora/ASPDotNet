using System.ComponentModel.DataAnnotations;
namespace JWTAuthenticationWithEFCore.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Hashed password

        [Required]
        public string Role { get; set; }
    }

}
