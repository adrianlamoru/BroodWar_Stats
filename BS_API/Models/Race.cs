using System.ComponentModel.DataAnnotations;

namespace BS.Models
{
    public class Race
    {
        [Key]
        public string RaceID {get; set;}
        [Required]
        [MaxLength(10)]
        public string Name {get; set;}
    }
}