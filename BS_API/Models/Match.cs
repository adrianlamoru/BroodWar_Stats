
using System;
using System.ComponentModel.DataAnnotations;

namespace BS.Models
{
    public class Match
    {
        [Key]
        public int MatchID {get; set;}
        [Required]
        public Player PlayerWinner {get; set;}
        [Required]
        public Player PlayerLoser {get; set;}
        [Required]
        public Race RaceWinner {get; set;}
        [Required]
        public Race RaceLoser {get; set;}
        public Player FirstObserver {get; set;}
        public Player SecondObserver {get; set;}
        public Player ThirtObserver {get; set;}
        public Player FourObserver {get; set;}
        [Required]
        public DateTime Date {get; set;}
        [Required]
        public decimal Duration {get; set;}
    }
}