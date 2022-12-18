using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Test2.Models
{
    public class User : IdentityUser 
    {

        public string? FavouriteTeam { get; set; }
        
        public string? FavouritePlayer { get; set; }

        public string? County { get; set; }
    }
}
