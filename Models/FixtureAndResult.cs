using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Test2.Models
{
    public class FixtureAndResult
    {

        [Key]
        public int Match_id { get; set; }

        [Required]
        public string? Hometeam { get; set; }
        //[ForeignKey("team_id")]

        [Required]
        public string? Awayteam { get; set; }

        [Required]
        public string? Homescore { get; set; }

        [Required]
        public string? Awayscore { get; set; }

        [Required]
        public string? DatefGame { get; set; }
        //[ForeignKey("league_id")]

        //public int league_id { get; set; }

        public string? BasketballNiId { get; set; }
    }
}