using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Test2.Models
{
    public class Player
    {
        [Key]
        public int Player_id { get; set; }

        [Required]
        public string? Name { get; set; }
        // [ForeignKey("team_id")]
        [Required]
        public string? TeamName { get; set; }
        [Required]
        public string? Points { get; set; }
        [Required]
        public string? Rebounds { get; set; }
        [Required]
        public string? Assists { get; set; }
        [Required]
        public string? Blocks { get; set; }
        [Required]
        public string? Steals { get; set; }

        public string? BasketballNiId { get; set;}
    }
}