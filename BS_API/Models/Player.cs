using System.ComponentModel.DataAnnotations;

namespace BS.Models
{
    public class Player
    {
        [Key]
        public int PlayerID {get; set;}
        [Required]
        public Race Race {get; set;}
        [Required]
        [MaxLength(50)]
        public string NickName {get; set;}
        [Required]
        [MaxLength(50)]
        public string Name {get; set;}
        [Required]
        [MaxLength(50)]
        public string LastName {get; set;}
        [Required]
        [MaxLength(20)]
        public Country Country {get; set;}
        [Required]
        public int Age {get; set;}
   }
}