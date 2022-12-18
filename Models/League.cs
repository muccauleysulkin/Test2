using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class League
    {
        [Key]
        public int League_id { get; set; }

        [Required]
        public string? Leaguename { get; set; }
        [Required]
        public string? LeagueDescription { get; set; }
        [Required]
        public string? Level { get; set; }

        public string? BasketballNiId { get; set; }
    }
}