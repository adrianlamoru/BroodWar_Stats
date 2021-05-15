using System.ComponentModel.DataAnnotations;

namespace BS.Models
{
    public class Country
    {
        [Key]
        public int CountryID{get;set;}

        [Required]
        [MaxLength(250)]
        public string Name{get;set;}
    }
}