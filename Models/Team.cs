using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Test2.Models
{
    public class Team
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Description { get; set; }

        [Required]
        public string? LeagueName { get; set; }

        public string? BasketballNiId { get; set; }


    }
}