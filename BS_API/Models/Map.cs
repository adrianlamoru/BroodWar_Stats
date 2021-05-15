using System.ComponentModel.DataAnnotations;

namespace BS.Models
{   
    public class Map
    {
        [Key]
        public int MapID {get; set;}
        [Required]
        [MaxLength(250)]
        public string Name {get; set;}
        [Required]
        public int NumberOfPositions {get; set;}
    }
    
}