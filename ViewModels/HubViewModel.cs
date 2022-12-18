using Test2.Models;

namespace Test2.ViewModels
{
    public class HubViewModel
    {
        public List<Team> Teams { get; set; }
        
        public List<League> Leagues { get; set; }
    
        public List<Player> Players { get; set; }

        public List<FixtureAndResult> Fixtures { get; set; }
    }
}