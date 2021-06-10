using System.ComponentModel.DataAnnotations;

namespace BS.Models
{
    public class User
    {
        [Key]
        public int UserID {get; set;}

        [Required]
        public string UserName {get; set;}

        [Required]
        public byte[] PasswordHash {get; set;}

        [Required]
        public byte[] PasswordSalt {get; set;}

        [Required]
        public string Role {get; set;}
    }
}